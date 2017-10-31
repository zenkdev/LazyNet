using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Dekart.LazyNet.SQLBackup2Remote.Controls
{
    /// <summary>
    /// Summary description for JobControl.
    /// </summary>
    public partial class JobControl : XtraUserControl
    {
        public JobControl()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            foreach (Control item in lcMain.Controls)
            {
                var edit = item as BaseEdit;
                if (edit != null)
                {
                    edit.MenuManager = lcMain.MenuManager;
                    edit.EditValueChanged += (sender, args) => RaiseChangedEvent();
                }
            }
        }

        AppMainForm ParentFormMain => ParentForm as AppMainForm;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JobData Data { get; } = new JobData();

        public event EventHandler Changed;

        void RaiseChangedEvent()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public bool LoadJob(string fileName)
        {
            try
            {
                Data.Load(fileName);
                InitData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ParentFormMain, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                XtraMessageBox.Show(ParentFormMain, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public string SaveJobAs()
        {
            var dlg = new SaveFileDialog { Filter = ConstStrings.JobFilesFilter, Title = ConstStrings.SaveAs };
            if (dlg.ShowDialog(ParentFormMain) == DialogResult.OK)
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
                    XtraMessageBox.Show(ParentFormMain, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return string.Empty;
        }

        public void RunJob()
        {
            SaveData();

            using (var form = new RunJobForm(ParentFormMain, Data))
                form.ShowDialog(this);
        }

        public void InitData()
        {
            lcServerName.Text = Data.ServerName;
            cbBackupAllNonSystemDBs.Checked = Data.BackupAllNonSystemDBs;

            InitDatabases();
            gcDestinations.DataSource = Data.Destinations;

            cbSendEmails.Checked = Data.SendEmails;
            if (cbSendEmails.Checked)
            {
                teOnSuccessMailTo.Text = Data.OnSuccessEmailTo;
                teOnFailureMailTo.Text = Data.OnFailureEmailTo;
                teOnSuccessMailTo.Enabled = teOnFailureMailTo.Enabled = true;
            }
            else
            {
                teOnSuccessMailTo.Text = teOnFailureMailTo.Text = null;
                teOnSuccessMailTo.Enabled = teOnFailureMailTo.Enabled = false;
            }
            sbEmailSettings.Enabled = cbSendEmails.Checked;
            cbScheduleThisJob.Checked = Data.ScheduleThisJob;

            var scheduleData = Data.FullBackupSchedule.FirstOrDefault();
            if (scheduleData == null)
            {
                scheduleData = new ScheduleData { Recurrence = 0, RepeatEvery = 1, StartBoundary = DateTime.Now };
                Data.FullBackupSchedule.Add(scheduleData);
            }
            teNextFullBackupStart.Time = scheduleData.StartBoundary;
        }

        void InitDatabases()
        {
            lbDatabases.Items.Clear();

            lbDatabases.Enabled = !Data.BackupAllNonSystemDBs;

            SqlConnection cn = null;
            try
            {
                cn = DbHelper.GetNewOpenConnection(Data);
                var databases = DbHelper.GetDatabaseNames(cbShowSystemDatabases.Checked, cn);
                foreach (var db in Data.Databases)
                {
                    if (!databases.Contains(db))
                    {
                        databases.Add(db);
                    }
                }
                foreach (var db in databases)
                {
                    lbDatabases.Items.Add(db, (Data.BackupAllNonSystemDBs && !db.IsSystemDatabase()) || Data.Databases.Contains(db));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ParentFormMain, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn?.Close();
            }
        }

        void SaveData()
        {
            Data.BackupAllNonSystemDBs = cbBackupAllNonSystemDBs.Checked;
            Data.OnSuccessEmailTo = teOnSuccessMailTo.Text;
            Data.OnFailureEmailTo = teOnFailureMailTo.Text;
            Data.ScheduleThisJob = cbScheduleThisJob.Checked;
            var scheduleData = Data.FullBackupSchedule.FirstOrDefault();
            scheduleData?.SetStartBoundaryTime(teNextFullBackupStart.Time);
            if (!Data.ScheduleThisJob) return;

            if (string.IsNullOrWhiteSpace(Data.ScheduleUserId) || string.IsNullOrWhiteSpace(Data.SchedulePassword))
            {
                using (var form = new TaskSchedulerAccountForm())
                {
                    if (form.ShowDialog(this) != DialogResult.OK) return;
                    Data.ScheduleUserId = form.Username;
                    Data.SchedulePassword = form.Password;
                }
            }
        }

        void SbConnectClick(object sender, EventArgs e)
        {
            using (var form = new AddConnectionForm(ParentFormMain, Data, lcMain.MenuManager))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                lcServerName.Text = Data.ServerName;
                InitDatabases();
                RaiseChangedEvent();
            }
        }

        void CbBackupAllNonSystemDBsCheckedChanged(object sender, EventArgs e)
        {
            Data.BackupAllNonSystemDBs = cbBackupAllNonSystemDBs.Checked;
            if (Data.BackupAllNonSystemDBs)
            {
                Data.Databases.Clear();
            }

            InitDatabases();
        }

        void CbShowSystemDatabasesCheckedChanged(object sender, EventArgs e)
        {
            InitDatabases();
        }

        void LbDatabasesItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (e.State == CheckState.Checked)
            {
                Data.Databases.Add(lbDatabases.GetItem(e.Index).ToString());
            }
            else
            {
                Data.Databases.Remove(lbDatabases.GetItem(e.Index).ToString());
            }
            RaiseChangedEvent();
        }

        #region Destinations

        DestinationData CurrentDestination => advMain.GetRow(advMain.FocusedRowHandle) as DestinationData;

        void HlAddDestinationOpenLink(object sender, OpenLinkEventArgs e)
        {
            int type;
            using (var form = new AddDestinationForm(ParentFormMain))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                type = form.DestinationType;
            }

            switch (type)
            {
                case 0:
                    using (var form = new AddFolderDestinationForm(ParentFormMain, null, lcMain.MenuManager))
                    {
                        if (form.ShowDialog(this) != DialogResult.OK) return;

                        Data.Destinations.Add(form.Destination);
                        RaiseChangedEvent();
                    }
                    break;
                case 1:
                    using (var form = new AddFtpDestinationForm(ParentFormMain, null, lcMain.MenuManager))
                    {
                        if (form.ShowDialog(this) != DialogResult.OK) return;

                        Data.Destinations.Add(form.Destination);
                        RaiseChangedEvent();
                    }
                    break;
            }
        }

        void BeDeleteButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentDestination == null) return;
            Data.Destinations.Remove(CurrentDestination);
            RaiseChangedEvent();
        }

        void BeEditButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var destination = CurrentDestination;
            if (destination == null) return;

            switch (destination.Type)
            {
                case 0:
                    using (var form = new AddFolderDestinationForm(ParentFormMain, destination, lcMain.MenuManager))
                    {
                        if (form.ShowDialog(this) != DialogResult.OK) return;
                        RaiseChangedEvent();
                    }
                    break;
                case 1:
                    using (var form = new AddFtpDestinationForm(ParentFormMain, destination, lcMain.MenuManager))
                    {
                        if (form.ShowDialog(this) != DialogResult.OK) return;
                        RaiseChangedEvent();
                    }
                    break;
            }

        }

        #endregion

        #region Send Emails

        void CbSendEmailsCheckedChanged(object sender, EventArgs e)
        {
            Data.SendEmails = cbSendEmails.Checked;
            teOnSuccessMailTo.Enabled = teOnFailureMailTo.Enabled = sbEmailSettings.Enabled = cbSendEmails.Checked;
            if (!cbSendEmails.Checked)
            {
                teOnSuccessMailTo.Text = teOnFailureMailTo.Text = null;
            }
        }

        void SbEmailSettingsClick(object sender, EventArgs e)
        {
            var to = teOnSuccessMailTo.Text.Split(';', ',');
            using (var form = new AddEmailSettingsForm(ParentFormMain, Data.EmailSettings, lcMain.MenuManager, to))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                RaiseChangedEvent();
            }
        }

        #endregion

        void SbSchedulerSettingsClick(object sender, EventArgs e)
        {
            var scheduleData = Data.FullBackupSchedule.FirstOrDefault();
            if (scheduleData == null)
            {
                scheduleData = new ScheduleData { Recurrence = 0, RepeatEvery = 1, StartBoundary = DateTime.Now };
                Data.FullBackupSchedule.Add(scheduleData);
            }
            scheduleData.SetStartBoundaryTime(teNextFullBackupStart.Time);
            using (var form = new AddSchedulerSettingsForm(ParentFormMain, Data, lcMain.MenuManager))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                teNextFullBackupStart.Time = scheduleData.StartBoundary;
                RaiseChangedEvent();
            }
        }

        void SbRunNowClick(object sender, EventArgs e)
        {
            RunJob();
        }

        void hlBeforeBackup_OpenLink(object sender, OpenLinkEventArgs e)
        {
            using (var form = new AddCustomSQLScript(ParentFormMain, Data.BeforeBackupSqlScript, ConstStrings.BeforeBackupSqlScriptCaption, lcMain.MenuManager))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                Data.BeforeBackupSqlScript = form.SQL;
                RaiseChangedEvent();
            }
        }

        void hlAfterBackup_OpenLink(object sender, OpenLinkEventArgs e)
        {
            using (var form = new AddCustomSQLScript(ParentFormMain, Data.AfterBackupSqlScript, ConstStrings.AfterBackupSqlScriptCaption, lcMain.MenuManager))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                Data.AfterBackupSqlScript = form.SQL;
                RaiseChangedEvent();
            }
        }

    }
}
