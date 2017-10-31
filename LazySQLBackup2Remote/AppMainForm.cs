using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using Dekart.LazyNet.SQLBackup2Remote.Models;
using Dekart.LazyNet.SQLBackup2Remote.Views;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Taskbar;
using DevExpress.XtraSplashScreen;
using Microsoft.Win32.TaskScheduler;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    public partial class AppMainForm : RibbonForm
    {
        #region Fields
        string _jobName;
        bool _modified;
        int _jobIndex;

        #endregion

        #region Ctor

        public AppMainForm(string jobName)
        {
            _jobName = jobName;

            InitializeComponent();
            InitSkinGallery();
            InitEditors();
            InitSchemeCombo();

            UserLookAndFeel.Default.StyleChanged += OnLookAndFeelStyleChanged;
            UserLookAndFeel.Default.SetSkinStyle("Office 2013");
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
                //sbiSave.Enabled = _modified;
                biSave.Enabled = _modified;
                UpdateText();
            }
        }

        #endregion

        #region RibbonForm overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SplashScreenManager.CloseForm(false);

            WinFormData.LoadDefaultSkin();
            _arMRUList = new MRUArrayList(pcAppMenuFileLabels, imageCollection.Images[0], imageCollection.Images[1]);
            _arMRUList.LabelClicked += OnMRUFileLabelClicked;
            InitMostRecentFiles();
            rcMain.ForceInitialize();
            var skins = new GalleryDropDown { Ribbon = rcMain };
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGalleryDropDown(skins);
            iPaintStyle.DropDownControl = skins;
            if (!string.IsNullOrEmpty(_jobName))
            {
                OpenFile(_jobName);
            }
            else
            {
                if (_arMRUList.Count > 0)
                {
                    OpenFile(_arMRUList[0].ToString());
                }
                else
                {
                    CreateNewJob();
                }
            }
            beLogo.EditValue = ResourceImageHelper.CreateImageFromResources("Dekart.LazyNet.SQLBackup2Remote.online.gif", typeof(AppMainForm).Assembly);
        }

        #endregion

        #region Init

        void InitSkinGallery()
        {
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        void InitEditors()
        {
            riicStyle.Items.Add(new ImageComboBoxItem(ConstStrings.Office2007, RibbonControlStyle.Office2007, -1));
            riicStyle.Items.Add(new ImageComboBoxItem(ConstStrings.Office2010, RibbonControlStyle.Office2010, -1));
            riicStyle.Items.Add(new ImageComboBoxItem(ConstStrings.Office2013, RibbonControlStyle.Office2013, -1));
            riicStyle.Items.Add(new ImageComboBoxItem(ConstStrings.MacOffice, RibbonControlStyle.MacOffice, -1));
            biStyle.EditValue = rcMain.RibbonStyle;
        }

        void InitSchemeCombo()
        {
            foreach (var obj in Enum.GetValues(typeof(RibbonControlColorScheme)))
            {
                repositoryItemComboBox1.Items.Add(obj);
            }
            beScheme.EditValue = RibbonControlColorScheme.Yellow;
        }

        void UpdateText()
        {
            rcMain.ApplicationCaption = ConstStrings.ApplicationCaption;
            rcMain.ApplicationDocumentCaption = JobName + (Modified ? "*" : "");
            siDocName.Caption = $"  {JobName}";
            siModified.Caption = Modified ? "   Modified   " : "";
        }

        void UpdateLookAndFeel()
        {
            string skinName;
            var style = rcMain.RibbonStyle;
            switch (style)
            {
                case RibbonControlStyle.Default:
                case RibbonControlStyle.Office2007:
                    skinName = "Office 2007 Blue";
                    break;
                case RibbonControlStyle.Office2013:
                    skinName = "Office 2013";
                    break;
                //case RibbonControlStyle.Office2010:
                //case RibbonControlStyle.MacOffice:
                default:
                    skinName = "Office 2010 Blue";
                    break;
            }
            UserLookAndFeel.Default.SetSkinStyle(skinName);
        }

        void UpdateSchemeCombo()
        {
            if (rcMain.RibbonStyle == RibbonControlStyle.MacOffice ||
                rcMain.RibbonStyle == RibbonControlStyle.Office2010 || rcMain.RibbonStyle == RibbonControlStyle.Office2013)
            {
                beScheme.Visibility = UserLookAndFeel.Default.ActiveSkinName.Contains("Office 2010") ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
            else
            {
                beScheme.Visibility = BarItemVisibility.Never;
            }
        }

        void CreateNewJob(string fileName = null)
        {
            _jobIndex++;
            if (fileName != null)
            {
                if (jobControl.LoadJob(fileName))
                {
                    JobName = fileName;
                    Modified = false;
                    NewJob = false;
                }
            }
            else
            {
                jobControl.InitData();
                JobName = JobNameDefault;
                NewJob = true;
            }
        }

        #endregion

        #region File

        void BiNewItemClick(object sender, ItemClickEventArgs e)
        {
            if (SaveQuestion())
            {
                CreateNewJob();
            }
        }

        void OpenFile()
        {
            var dlg = new OpenFileDialog { Filter = ConstStrings.JobFilesFilter, Title = ConstStrings.Open };
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                OpenFile(dlg.FileName);
            }
        }

        public void OpenFile(string name)
        {
            CreateNewJob(name);
            AddToMostRecentFiles(name, _arMRUList);
            AddToMostRecentFiles(name, recentItemsControl1.MRUFileList);
            AddToMostRecentFolders(name, recentItemsControl1.MRUFolderList);
        }

        void AddToMostRecentFiles(string name, MRUArrayList arMRUList)
        {
            arMRUList.InsertElement(name);
        }

        void AddToMostRecentFolders(string name, MRUArrayList arMRUList)
        {
            name = Path.GetFullPath(name);
            arMRUList.InsertElement(Path.GetDirectoryName(name));
        }

        void AddToWindowsScheduler(string name)
        {
            var data = jobControl.Data;

            try
            {
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
                        td.Actions.Add(new ExecAction(Application.ExecutablePath, "-runjob \"" + name + "\" " + BackupType.Full));

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
                        td.Actions.Add(new ExecAction(Application.ExecutablePath, "-runjob \"" + name + "\" " + BackupType.Differential));

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
                        td.Actions.Add(new ExecAction(Application.ExecutablePath, "-runjob \"" + name + "\" " + BackupType.TransactionLog));

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
                XtraMessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BiOpenItemClick(object sender, ItemClickEventArgs e)
        {
            if (SaveQuestion())
            {
                OpenFile();
            }
        }

        void BiSaveItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        void BiSaveAsItemClick(object sender, ItemClickEventArgs e)
        {
            SaveAs();
        }

        bool SaveQuestion()
        {
            if (Modified)
            {
                switch (XtraMessageBox.Show("Do you want to save the changes you made to " + JobName + "?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
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

            AddToMostRecentFiles(jobName, _arMRUList);
            AddToMostRecentFiles(jobName, recentItemsControl1.MRUFileList);
            AddToMostRecentFolders(jobName, recentItemsControl1.MRUFolderList);
            AddToWindowsScheduler(jobName);
            JobName = jobName;
            Modified = false;
            NewJob = false;
        }

        void BiExitItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        void RpgFileCaptionButtonClick(object sender, RibbonPageGroupEventArgs e)
        {
            OpenFile();
        }

        void RpgExitCaptionButtonClick(object sender, RibbonPageGroupEventArgs e)
        {
            SaveAs();
        }

        #endregion

        #region MostRecentFiles
        MRUArrayList _arMRUList;

        void AppMainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SaveQuestion())
            {
                e.Cancel = true;
                return;
            }

            WinFormData.SaveDefaultProperties(_arMRUList, recentItemsControl1.MRUFolderList);
        }
        void InitMostRecentFiles()
        {
            _arMRUList.Init(WinFormData.Current.MRUFiles);
            recentItemsControl1.MRUFileList.Init(WinFormData.Current.MRUFiles);
            recentItemsControl1.MRUFolderList.Init(WinFormData.Current.MRUFolders, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }

        void OnMRUFileLabelClicked(object sender, EventArgs e)
        {
            rcMain.DeactivateKeyboardNavigation();
            pmAppMain.HidePopup();
            Refresh();
            OpenFile(sender.ToString());
        }

        #endregion

        #region Taskbar

        void OnNewThumbButtonClick(object sender, ThumbButtonClickEventArgs e)
        {
            CreateNewJob();
        }

        void OnRunThumbButtonClick(object sender, ThumbButtonClickEventArgs e)
        {
            jobControl.RunJob();
        }

        void OnExitThumbButtonClick(object sender, ThumbButtonClickEventArgs e)
        {
            Close();
        }

        #endregion

        #region Events handlers

        void OnLookAndFeelStyleChanged(object sender, EventArgs e)
        {
            UpdateSchemeCombo();
        }

        void JobChanged(object sender, EventArgs e)
        {
            Modified = true;
            UpdateText();
        }

        void BiJobsItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new ScheduledJobsForm())
                form.ShowDialog(this);
        }

        void BiLogItemClick(object sender, ItemClickEventArgs e)
        {
            var path = WinHelper.GetDataDirectory() + "\\" + WinHelper.AppName + "_log.txt";
            WinHelper.StartProcess(path);
        }

        void BiAboutItemClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.Utils.About.AboutHelper.Show(new DevExpress.Utils.About.ProductInfo(string.Empty, typeof(AppMainForm), DevExpress.Utils.About.ProductKind.DXperienceWin, DevExpress.Utils.About.ProductInfoStage.Registered));
        }

        void BvItemExitItemClick(object sender, BackstageViewItemEventArgs e)
        {
            Close();
        }

        void BeSchemeEditValueChanged(object sender, EventArgs e)
        {
            rcMain.ColorScheme = ((RibbonControlColorScheme)beScheme.EditValue);
        }

        void RcMainApplicationButtonDoubleClick(object sender, EventArgs e)
        {
            if (rcMain.RibbonStyle == RibbonControlStyle.Office2007)
                Close();
        }

        void BarEditItem1ItemPress(object sender, ItemClickEventArgs e)
        {
            Process.Start("http://www.dekart.ru");
        }

        void BiStyleEditValueChanged(object sender, EventArgs e)
        {
            var style = (RibbonControlStyle)biStyle.EditValue;
            rcMain.RibbonStyle = style;
            if (style == RibbonControlStyle.Office2010 || style == RibbonControlStyle.MacOffice || style == RibbonControlStyle.Office2013)
            {
                rcMain.ApplicationButtonDropDownControl = backstageViewControl1;
            }
            else
            {
                rcMain.ApplicationButtonDropDownControl = pmAppMain;
            }
            UpdateSchemeCombo();
            UpdateLookAndFeel();
        }

        void SbExitClick(object sender, EventArgs e)
        {
            Close();
        }

        void BvItemSaveItemClick(object sender, BackstageViewItemEventArgs e)
        {
            Save();
        }

        void BvItemSaveAsItemClick(object sender, BackstageViewItemEventArgs e)
        {
            SaveAs();
        }

        void BvItemOpenItemClick(object sender, BackstageViewItemEventArgs e)
        {
            OpenFile();
        }

        void BiDownloadItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new RestoreBackupView(this, jobControl.Data))
                form.ShowDialog(this);
        }

        #endregion

    }
}
