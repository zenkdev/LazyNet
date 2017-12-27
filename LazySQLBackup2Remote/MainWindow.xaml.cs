using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using Dekart.LazyNet.SQLBackup2Remote.Windows;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        #region Fields
        string _jobName;
        bool _modified;
        int _jobIndex;
        MruListBox mruMenu;

        #endregion

        #region Ctor
        public MainWindow(string jobName)
        {
            InitializeComponent();

            _jobName = jobName;
        }

        #endregion

        #region Properties

        string JobNameDefault => $"New Job {_jobIndex}";

        string JobName
        {
            get { return _jobName; }
            set
            {
                _jobName = value;
                UpdateText();
            }
        }
        bool NewJob { get; set; } = true;

        bool Modified
        {
            get { return _modified; }
            set
            {
                _modified = value;
                UpdateText();
            }
        }

        #endregion

        #region Methods

        void UpdateText()
        {
            Title = JobName + (Modified ? "*" : "") + "- " + ConstStrings.ApplicationCaption;
            ribbon.Title = Title;
            slDocName.Text = $"  {JobName}";
            slModified.Text = Modified ? "   Modified   " : "";
        }

        async void CreateNewJob(string fileName = null)
        {
            _jobIndex++;
            if (fileName != null)
            {
                if (await jobControl.LoadJob(fileName))
                {
                    JobName = fileName;
                    Modified = false;
                    NewJob = false;
                }
            }
            else
            {
                await jobControl.InitData();
                JobName = JobNameDefault;
                NewJob = true;
            }
        }

        void InitMostRecentFiles()
        {
            mruMenu = new MruListBox(MruListBox, new MruListBox.ClickedHandler(OnMruFile), 10);
            if (WinFormData.Current.MRUFiles?.Length > 0)
            {
                mruMenu.SetFiles(WinFormData.Current.MRUFiles);
            }
        }

        void OpenFile()
        {
            var dlg = new OpenFileDialog { Filter = ConstStrings.JobFilesFilter, Title = ConstStrings.Open };
            if (dlg.ShowDialog(this) == true)
            {
                OpenFile(dlg.FileName);
            }
        }

        public void OpenFile(string name)
        {
            CreateNewJob(name);
            mruMenu.AddFile(name);
        }

        void AddToWindowsScheduler(string name)
        {
            var data = jobControl.Data;

            try
            {
                var executablePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    var taskName = WinHelper.AppName + " {" + data.JobId + "} ";

                    var identity = WindowsIdentity.GetCurrent();
                    var author = identity.Name;
                    if (data.ScheduleThisJob && data.FullBackupSchedule.Count > 0)
                    {
                        // Create a new task definition and assign properties
                        var td = ts.NewTask();
                        td.RegistrationInfo.Author = author;
                        td.RegistrationInfo.Description = name;

                        foreach (var scheduleData in data.FullBackupSchedule)
                        {
                            td.Triggers.Add(scheduleData.CreateTrigger());
                        }
                        // Create an action that will launch Notepad whenever the trigger fires
                        td.Actions.Add(new ExecAction(executablePath, "-runjob \"" + name + "\" " + BackupType.Full));

                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(taskName + TextHelper.ConvertEnum(BackupType.Full.ToString()), td, TaskCreation.CreateOrUpdate, data.ScheduleUserId, data.SchedulePassword, TaskLogonType.Password);
                    }
                    else
                    {
                        // Remove the task
                        ts.RootFolder.DeleteTask(taskName + TextHelper.ConvertEnum(BackupType.Full.ToString()), false);
                    }

                    if (data.ScheduleThisJob && data.DiffBackupSchedule.Count > 0)
                    {
                        // Create a new task definition and assign properties
                        var td = ts.NewTask();
                        td.RegistrationInfo.Author = author;
                        td.RegistrationInfo.Description = name;

                        foreach (var scheduleData in data.DiffBackupSchedule)
                        {
                            td.Triggers.Add(scheduleData.CreateTrigger());
                        }
                        // Create an action that will launch app whenever the trigger fires
                        td.Actions.Add(new ExecAction(executablePath, "-runjob \"" + name + "\" " + BackupType.Differential));

                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(taskName + TextHelper.ConvertEnum(BackupType.Differential.ToString()), td, TaskCreation.CreateOrUpdate, data.ScheduleUserId, data.SchedulePassword, TaskLogonType.Password);
                    }
                    else
                    {
                        // Remove the task
                        ts.RootFolder.DeleteTask(taskName + TextHelper.ConvertEnum(BackupType.Differential.ToString()), false);
                    }

                    if (data.ScheduleThisJob && data.TranBackupSchedule.Count > 0)
                    {
                        // Create a new task definition and assign properties
                        var td = ts.NewTask();
                        td.RegistrationInfo.Author = author;
                        td.RegistrationInfo.Description = name;

                        foreach (var scheduleData in data.TranBackupSchedule)
                        {
                            td.Triggers.Add(scheduleData.CreateTrigger());
                        }
                        // Create an action that will launch app whenever the trigger fires
                        td.Actions.Add(new ExecAction(executablePath, "-runjob \"" + name + "\" " + BackupType.TransactionLog));

                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(taskName + TextHelper.ConvertEnum(BackupType.TransactionLog.ToString()), td, TaskCreation.CreateOrUpdate, data.ScheduleUserId, data.SchedulePassword, TaskLogonType.Password);
                    }
                    else
                    {
                        // Remove the task
                        ts.RootFolder.DeleteTask(taskName + TextHelper.ConvertEnum(BackupType.TransactionLog.ToString()), false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnMruFile(int number, string filename)
        {
            OpenFile(filename);
        }

        bool SaveQuestion()
        {
            if (Modified)
            {
                switch (MessageBox.Show(this, "Do you want to save the changes you made to " + JobName + "?", "Question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                {
                    case MessageBoxResult.Cancel:
                        return false;
                    case MessageBoxResult.Yes:
                        Save();
                        break;
                }
            }
            return true;
        }

        void Save()
        {
            if (NewJob)
            {
                SaveAs();
            }
            else
            {
                if (jobControl.SaveJob(JobName))
                {
                    AddToWindowsScheduler(JobName);
                    Modified = false;
                }
            }
        }

        void SaveAs()
        {
            var jobName = jobControl.SaveJobAs();
            if (jobName == string.Empty) return;

            mruMenu.AddFile(jobName);
            AddToWindowsScheduler(jobName);
            JobName = jobName;
            Modified = false;
            NewJob = false;
        }

        #endregion

        #region Events Handlers

        private void RibbonWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            InitMostRecentFiles();
            if (!string.IsNullOrEmpty(_jobName))
            {
                OpenFile(_jobName);
            }
            else
            {
                if (mruMenu.NumEntries > 0)
                {
                    OpenFile(mruMenu.GetFileAt(0));
                }
                else
                {
                    CreateNewJob();
                }
            }
            WinFormData.LoadFormLayout(this);
        }

        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!SaveQuestion())
            {
                e.Cancel = true;
                return;
            }
            WinFormData.SaveFormLayout(this);
            WinFormData.SaveDefaultProperties(null);
            WinFormData.SaveDefaultProperties(mruMenu.GetFiles());
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SaveQuestion())
            {
                CreateNewJob();
            }
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (SaveQuestion())
            {
                OpenFile();
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Save();
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _modified;
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveAs();
        }

        private void DownloadCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new DownloadAndRestore(jobControl.Data).ShowDialog(this);
        }

        private void JobsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new ScheduledJobs().ShowDialog(this);
        }

        private void LogsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var path = WinHelper.GetDataDirectory() + "\\" + WinHelper.AppName + "_log.txt";
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        void JobChanged(object sender, EventArgs e)
        {
            Modified = true;
            UpdateText();
        }

        void BiAboutItemClick(object sender, EventArgs e)
        {
            //new AboutBox().ShowDialog(this);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://www.dekart.ru");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

    }
}
