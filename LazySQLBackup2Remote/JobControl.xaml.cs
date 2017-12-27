using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using Dekart.LazyNet.SQLBackup2Remote.Windows;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    /// <summary>
    /// Логика взаимодействия для JobControl.xaml
    /// </summary>
    public partial class JobControl : UserControl
    {
        public JobControl()
        {
            InitializeComponent();

            cbBackupAllNonSystemDBs.Checked += (sender, args) => RaiseChangedEvent();
            cbSendEmails.Checked += (sender, args) => RaiseChangedEvent();
            teOnSuccessMailTo.TextChanged += (sender, args) => RaiseChangedEvent();
            teOnFailureMailTo.TextChanged += (sender, args) => RaiseChangedEvent();
            ScheduleThisJobCheckBox.Checked += (sender, args) => RaiseChangedEvent();
            ScheduleThisJobCheckBox.Unchecked += (sender, args) => RaiseChangedEvent();
            NextFullBackupStartTimePicker.ValueChanged += (sender, args) => RaiseChangedEvent();
        }

        MainWindow ParentWindow => Application.Current.MainWindow as MainWindow;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JobData Data { get; } = new JobData();

        public event EventHandler Changed;

        void RaiseChangedEvent()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public async Task<bool> LoadJob(string fileName)
        {
            try
            {
                Data.Load(fileName);
                await InitData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ParentWindow, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public bool SaveJob(string fileName)
        {
            try
            {
                SaveData();
                Data.Save(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ParentWindow, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public string SaveJobAs()
        {
            var dlg = new SaveFileDialog { Filter = ConstStrings.JobFilesFilter, Title = ConstStrings.SaveAs };
            if (dlg.ShowDialog(ParentWindow) == true)
            {
                try
                {
                    SaveData();
                    // Generate new job id
                    Data.JobId = Guid.NewGuid();
                    Data.Save(dlg.FileName);
                    return dlg.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ParentWindow, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return string.Empty;
        }

        public void RunJob()
        {
            SaveData();

            new RunJob(Data).ShowDialog(ParentWindow);
        }

        public async Task InitData()
        {
            lcServerName.Text = Data.ServerName;
            cbBackupAllNonSystemDBs.IsChecked = Data.BackupAllNonSystemDBs;

            await InitDatabases();
            DestinationsGrid.ItemsSource = Data.Destinations;

            cbSendEmails.IsChecked = Data.SendEmails;
            if (cbSendEmails.IsChecked == true)
            {
                teOnSuccessMailTo.Text = Data.OnSuccessEmailTo;
                teOnFailureMailTo.Text = Data.OnFailureEmailTo;
                teOnSuccessMailTo.IsEnabled = teOnFailureMailTo.IsEnabled = true;
            }
            else
            {
                teOnSuccessMailTo.Text = teOnFailureMailTo.Text = null;
                teOnSuccessMailTo.IsEnabled = teOnFailureMailTo.IsEnabled = false;
            }
            sbEmailSettings.IsEnabled = cbSendEmails.IsChecked == true;

            ScheduleThisJobCheckBox.IsChecked = Data.ScheduleThisJob;
            if (ScheduleThisJobCheckBox.IsChecked == true)
            {
                var scheduleData = Data.FullBackupSchedule.FirstOrDefault();
                if (scheduleData == null)
                {
                    scheduleData = new ScheduleData { Recurrence = 0, RepeatEvery = 1, StartBoundary = DateTime.Now };
                    Data.FullBackupSchedule.Add(scheduleData);
                }
                NextFullBackupStartTimePicker.Value = scheduleData.StartBoundary;
            }
            else
            {
                NextFullBackupStartTimePicker.Value = null;
            }
            ScheduleSettingsButton.IsEnabled = NextFullBackupStartTimePicker.IsEnabled = ScheduleThisJobCheckBox.IsChecked == true;
        }

        async Task InitDatabases()
        {
            lbDatabases.Items.Clear();
            lbDatabases.IsEnabled = !Data.BackupAllNonSystemDBs;

            SqlConnection cn = null;

            Cursor = Cursors.Wait;

            try
            {
                cn = await DbHelper.GetNewOpenConnectionAsync(Data);
                var databases = await DbHelper.GetDatabaseNamesAsync(cbShowSystemDatabases.IsChecked == true, cn);
                foreach (var db in Data.Databases)
                {
                    if (!databases.Contains(db))
                    {
                        databases.Add(db);
                    }
                }
                foreach (var db in databases)
                {
                    var item = new CheckedListItem<string>(db, (Data.BackupAllNonSystemDBs && !db.IsSystemDatabase()) || Data.Databases.Contains(db));
                    lbDatabases.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ParentWindow, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                cn?.Close();
                Cursor = Cursors.Arrow;
            }
        }

        void SaveData()
        {
            Data.BackupAllNonSystemDBs = cbBackupAllNonSystemDBs.IsChecked == true;
            Data.OnSuccessEmailTo = teOnSuccessMailTo.Text;
            Data.OnFailureEmailTo = teOnFailureMailTo.Text;
            Data.ScheduleThisJob = ScheduleThisJobCheckBox.IsChecked == true;
            if (Data.ScheduleThisJob)
            {
                var scheduleData = Data.FullBackupSchedule.FirstOrDefault();
                var startBoundary = NextFullBackupStartTimePicker.Value;
                if (scheduleData != null && startBoundary != null)
                {
                    scheduleData.SetStartBoundaryTime(startBoundary.Value);
                }
                if (string.IsNullOrWhiteSpace(Data.ScheduleUserId) || string.IsNullOrWhiteSpace(Data.SchedulePassword))
                {
                    var window = new TaskSchedulerAccount();
                    if (window.ShowDialog(ParentWindow) != true) return;
                    Data.ScheduleUserId = window.Username;
                    Data.SchedulePassword = window.Password;
                }
            }
        }

        async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddConnection(Data);
            if (window.ShowDialog(ParentWindow) != true) return;
            lcServerName.Text = Data.ServerName;
            await InitDatabases();
            RaiseChangedEvent();
        }

        async void CbBackupAllNonSystemDBs_Click(object sender, RoutedEventArgs e)
        {
            Data.BackupAllNonSystemDBs = cbBackupAllNonSystemDBs.IsChecked == true;
            if (Data.BackupAllNonSystemDBs)
            {
                Data.Databases.Clear();
            }

            await InitDatabases();
        }

        async void CbShowSystemDatabases_Click(object sender, RoutedEventArgs e)
        {
            await InitDatabases();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var db = (string)checkBox.Content;
            if (checkBox.IsChecked == true)
            {
                if (!Data.Databases.Contains(db))
                    Data.Databases.Add(db);
            }
            else if (checkBox.IsChecked == false)
            {
                while (Data.Databases.Contains(db))
                    Data.Databases.Remove(db);
            }
            RaiseChangedEvent();
        }

        void HlBeforeBackup_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddCustomSQLScript(Data.BeforeBackupSqlScript) { Title = ConstStrings.BeforeBackupSqlScriptCaption };
            if (window.ShowDialog(ParentWindow) != true) return;
            Data.BeforeBackupSqlScript = window.SQL;
            RaiseChangedEvent();
        }

        void HlAfterBackup_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddCustomSQLScript(Data.AfterBackupSqlScript) { Title = ConstStrings.AfterBackupSqlScriptCaption };
            if (window.ShowDialog(ParentWindow) != true) return;
            Data.AfterBackupSqlScript = window.SQL;
            RaiseChangedEvent();
        }

        void SbRunNowClick(object sender, RoutedEventArgs e)
        {
            RunJob();
        }

        #region Destinations

        void HlAddDestination_Click(object sender, RoutedEventArgs e)
        {
            int type;
            var window = new AddDestination();
            if (window.ShowDialog(ParentWindow) != true) return;
            type = window.DestinationType;

            switch (type)
            {
                case 0:
                    var window2 = new AddFolderDestination(null);
                    if (window2.ShowDialog(ParentWindow) != true) return;
                    Data.Destinations.Add(window2.Destination);
                    RaiseChangedEvent();
                    break;
                case 1:
                    var window3 = new AddFtpDestination(null);
                    if (window3.ShowDialog(ParentWindow) != true) return;
                    Data.Destinations.Add(window3.Destination);
                    RaiseChangedEvent();
                    break;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = DestinationsGrid.SelectedItem as DestinationData;
            if (dataItem == null) return;
            Data.Destinations.Remove(dataItem);
            RaiseChangedEvent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var dataItem = DestinationsGrid.SelectedItem as DestinationData;
            if (dataItem == null) return;
            switch (dataItem.Type)
            {
                case 0:
                    var window1 = new AddFolderDestination(dataItem);
                    if (window1.ShowDialog(ParentWindow) != true) return;
                    RaiseChangedEvent();
                    break;
                case 1:
                    var window2 = new AddFtpDestination(dataItem);
                    if (window2.ShowDialog(ParentWindow) != true) return;
                    RaiseChangedEvent();
                    break;
            }
        }

        #endregion

        #region Send Emails

        void CbSendEmails_Click(object sender, RoutedEventArgs e)
        {
            Data.SendEmails = cbSendEmails.IsChecked == true;
            teOnSuccessMailTo.IsEnabled = teOnFailureMailTo.IsEnabled = sbEmailSettings.IsEnabled = Data.SendEmails;
            if (!Data.SendEmails)
            {
                teOnSuccessMailTo.Text = teOnFailureMailTo.Text = null;
            }
        }

        void SbEmailSettings_Click(object sender, RoutedEventArgs e)
        {
            var to = teOnSuccessMailTo.Text.Split(';', ',');
            var window = new AddEmailSettings(Data.EmailSettings, to);
            if (window.ShowDialog(ParentWindow) != true) return;
            RaiseChangedEvent();
        }

        #endregion

        #region Schedule

        void ScheduleThisJobCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleThisJobCheckBox.IsChecked == true)
            {
                var scheduleData = Data.FullBackupSchedule.FirstOrDefault();
                if (scheduleData == null)
                {
                    scheduleData = new ScheduleData { Recurrence = 0, RepeatEvery = 1, StartBoundary = DateTime.Now };
                    Data.FullBackupSchedule.Add(scheduleData);
                }
                NextFullBackupStartTimePicker.Value = scheduleData.StartBoundary;
            }
            else
            {
                NextFullBackupStartTimePicker.Value = null;
            }
            ScheduleSettingsButton.IsEnabled = NextFullBackupStartTimePicker.IsEnabled = ScheduleThisJobCheckBox.IsChecked == true;
        }

        void ScheduleSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var scheduleData = Data.FullBackupSchedule.FirstOrDefault();
            if (scheduleData == null)
            {
                scheduleData = new ScheduleData { Recurrence = 0, RepeatEvery = 1, StartBoundary = DateTime.Now };
                Data.FullBackupSchedule.Add(scheduleData);
            }
            var window = new ScheduleSettings(Data);
            if (window.ShowDialog(ParentWindow) != true) return;
            NextFullBackupStartTimePicker.Value = scheduleData.StartBoundary;
            RaiseChangedEvent();
        }

        #endregion

    }
}
