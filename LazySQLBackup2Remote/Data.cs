using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.Utils.Serializing;
using Microsoft.Win32.TaskScheduler;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    public class JobData : IXtraSerializable, INotifyPropertyChanged
    {
        Guid _jobId;
        string _serverName;
        bool _integratedSecurity = true;
        string _userName;
        string _password;
        bool _backupAllNonSystemDBs;
        List<string> _databases;
        BindingList<DestinationData> _destinations;
        EmailSettingsData _emailSettings;
        BindingList<ScheduleData> _fullBackupSchedule;
        BindingList<ScheduleData> _diffBackupSchedule;
        BindingList<ScheduleData> _tranBackupSchedule;

        bool _sendEmails;
        string _onSuccessEmailTo;
        string _onFailureEmailTo;
        bool _scheduleThisJob;
        string _scheduleUserId;
        string _schedulePassword;
        string _beforeBackupSQLScript;
        string _afterBackupSQLScript;

        public JobData()
        {
            _jobId = Guid.NewGuid();
            _serverName = "(local)";
        }

        [XtraSerializableProperty]
        public Guid JobId
        {
            get { return _jobId; }
            set
            {
                if (_jobId == value) return;
                _jobId = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string ServerName
        {
            get { return _serverName; }
            set
            {
                if (_serverName == value) return;
                _serverName = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public bool IntegratedSecurity
        {
            get { return _integratedSecurity; }
            set
            {
                if (_integratedSecurity == value) return;
                _integratedSecurity = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName == value) return;
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string PasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(Password); }
            set { Password = CryptoHelper.Decrypt(value); }
        }

        [XtraSerializableProperty]
        public bool BackupAllNonSystemDBs
        {
            get { return _backupAllNonSystemDBs; }
            set
            {
                if (_backupAllNonSystemDBs == value) return;
                _backupAllNonSystemDBs = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public bool SendEmails
        {
            get { return _sendEmails; }
            set
            {
                if (_sendEmails == value) return;
                _sendEmails = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string OnSuccessEmailTo
        {
            get { return _onSuccessEmailTo; }
            set
            {
                if (_onSuccessEmailTo == value) return;
                _onSuccessEmailTo = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string OnFailureEmailTo
        {
            get { return _onFailureEmailTo; }
            set
            {
                if (_onFailureEmailTo == value) return;
                _onFailureEmailTo = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public bool ScheduleThisJob
        {
            get { return _scheduleThisJob; }
            set
            {
                if (_scheduleThisJob == value) return;
                _scheduleThisJob = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string ScheduleUserId
        {
            get { return _scheduleUserId; }
            set
            {
                if (_scheduleUserId == value) return;
                _scheduleUserId = value;
                OnPropertyChanged();
            }
        }

        public string SchedulePassword
        {
            get { return _schedulePassword; }
            set
            {
                if (_schedulePassword == value) return;
                _schedulePassword = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string SchedulePasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(SchedulePassword); }
            set { SchedulePassword = CryptoHelper.Decrypt(value); }
        }

        [XtraSerializableProperty]
        public string BeforeBackupSqlScript
        {
            get { return _beforeBackupSQLScript; }
            set
            {
                if (_beforeBackupSQLScript == value) return;
                _beforeBackupSQLScript = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public string AfterBackupSqlScript
        {
            get { return _afterBackupSQLScript; }
            set
            {
                if (_afterBackupSQLScript == value) return;
                _afterBackupSQLScript = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public int FileVersion { get; set; }

        public string FileName { get; private set; }

        [XtraSerializableProperty(XtraSerializationVisibility.SimpleCollection, true, false, true, 1, XtraSerializationFlags.None)]
        public List<string> Databases => _databases ?? (_databases = new List<string>());

        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 2, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]
        public BindingList<DestinationData> Destinations => _destinations ?? (_destinations = new BindingList<DestinationData>());

        [XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public EmailSettingsData EmailSettings => _emailSettings ?? (_emailSettings = new EmailSettingsData { SmtpPort = 25 });

        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 3, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]
        public BindingList<ScheduleData> FullBackupSchedule => _fullBackupSchedule ?? (_fullBackupSchedule = new BindingList<ScheduleData>());

        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 4, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]
        public BindingList<ScheduleData> DiffBackupSchedule => _diffBackupSchedule ?? (_diffBackupSchedule = new BindingList<ScheduleData>());

        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 5, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]
        public BindingList<ScheduleData> TranBackupSchedule => _tranBackupSchedule ?? (_tranBackupSchedule = new BindingList<ScheduleData>());

        public void Load(string fileName)
        {
            FileName = fileName;
            File.SetAttributes(fileName, FileAttributes.Normal);

            LoadCore(new XmlXtraSerializer(), fileName);
        }

        // ReSharper disable UnusedMethodReturnValue.Global
        public bool Save(string fileName)
        {
            // perform upgrades
            FileVersion = 2;

            FileName = fileName;
            if (File.Exists(fileName))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
            }

            return SaveCore(new XmlXtraSerializer(), fileName);
        }
        // ReSharper restore UnusedMethodReturnValue.Global

        #region IXtraSerializable Members

        void IXtraSerializable.OnEndDeserializing(string restoredVersion) { }
        void IXtraSerializable.OnEndSerializing() { }
        void IXtraSerializable.OnStartDeserializing(DevExpress.Utils.LayoutAllowEventArgs e) { }
        void IXtraSerializable.OnStartSerializing() { }

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        object XtraCreateDatabasesItem(XtraItemEventArgs e)
        {
            return e.Item.Value;
        }
        object XtraCreateDestinationsItem(XtraItemEventArgs e)
        {
            return new DestinationData();
        }
        void XtraSetIndexDestinationsItem(XtraSetItemIndexEventArgs e)
        {
            Destinations.Insert(e.NewIndex, (DestinationData)e.Item.Value);
        }
        object XtraCreateFullBackupScheduleItem(XtraItemEventArgs e)
        {
            return new ScheduleData();
        }
        void XtraSetIndexFullBackupScheduleItem(XtraSetItemIndexEventArgs e)
        {
            FullBackupSchedule.Insert(e.NewIndex, (ScheduleData)e.Item.Value);
        }
        object XtraCreateDiffBackupScheduleItem(XtraItemEventArgs e)
        {
            return new ScheduleData();
        }
        void XtraSetIndexDiffBackupScheduleItem(XtraSetItemIndexEventArgs e)
        {
            DiffBackupSchedule.Insert(e.NewIndex, (ScheduleData)e.Item.Value);
        }
        object XtraCreateTranBackupScheduleItem(XtraItemEventArgs e)
        {
            return new ScheduleData();
        }
        void XtraSetIndexTranBackupScheduleItem(XtraSetItemIndexEventArgs e)
        {
            TranBackupSchedule.Insert(e.NewIndex, (ScheduleData)e.Item.Value);
        }
        // ReSharper restore UnusedParameter.Local
        // ReSharper restore UnusedMember.Local

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        bool SaveCore(XtraSerializer serializer, object path)
        {
            var stream = path as Stream;
            if (stream != null)
                return serializer.SerializeObjects(new[] { new XtraObjectInfo("JobData", this) }, stream, GetType().Name);
            return serializer.SerializeObjects(new[] { new XtraObjectInfo("JobData", this) }, path.ToString(), GetType().Name);
        }

        void LoadCore(XtraSerializer serializer, object path)
        {
            var stream = path as Stream;
            if (stream != null)
                serializer.DeserializeObjects(new[] { new XtraObjectInfo("JobData", this) }, stream, GetType().Name);
            else
                serializer.DeserializeObjects(new[] { new XtraObjectInfo("JobData", this) }, path.ToString(), GetType().Name);
        }

    }

    public class DestinationData
    {
        [XtraSerializableProperty]
        public int Type { get; set; }

        [XtraSerializableProperty]
        public string Path { get; set; }

        [XtraSerializableProperty]
        public int DeleteAfterMonths { get; set; }

        [XtraSerializableProperty]
        public int DeleteAfterDays { get; set; }

        [XtraSerializableProperty]
        public string UserName { get; set; }

        public string Password { get; set; }

        [XtraSerializableProperty]
        public string PasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(Password); }
            set { Password = CryptoHelper.Decrypt(value); }
        }

        [XtraSerializableProperty]
        public int Protocol { get; set; }

        [XtraSerializableProperty]
        public int Port { get; set; }

        [XtraSerializableProperty]
        public string RemoteFolder { get; set; }

        public string TypeName
        {
            get
            {
                switch (Type)
                {
                    case 1:
                        return "FTP Server";
                    default:
                        return "Local/Network Folder";
                }
            }
        }
    }

    public class EmailSettingsData
    {
        [XtraSerializableProperty]
        public string From { get; set; }

        [XtraSerializableProperty]
        public string SmtpServer { get; set; }

        [XtraSerializableProperty]
        public int SmtpPort { get; set; }

        [XtraSerializableProperty]
        public bool UseAuthentication { get; set; }

        [XtraSerializableProperty]
        public bool EnableSsl { get; set; }

        [XtraSerializableProperty]
        public string UserName { get; set; }

        public string Password { get; set; }

        [XtraSerializableProperty]
        public string PasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(Password); }
            set { Password = CryptoHelper.Decrypt(value); }
        }
    }

    public class ScheduleData : INotifyPropertyChanged
    {
        private int _recurrence;
        private short _repeatEvery;
        private DaysOfTheWeek _daysOfWeek;
        private List<int> _daysOfMonth;
        private MonthsOfTheYear _monthsOfYear;
        private DateTime _startBoundary;
        private bool _runOnLastDayOfMonth;

        [XtraSerializableProperty]
        public int Recurrence
        {
            get { return _recurrence; }
            set
            {
                if (_recurrence == value) return;
                _recurrence = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public short RepeatEvery
        {
            get { return _repeatEvery; }
            set
            {
                if (_repeatEvery == value) return;
                _repeatEvery = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public DaysOfTheWeek DaysOfWeek
        {
            get { return _daysOfWeek; }
            set
            {
                if (_daysOfWeek == value) return;
                _daysOfWeek = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty(XtraSerializationVisibility.SimpleCollection, true, false, true, 1, XtraSerializationFlags.None)]
        public List<int> DaysOfMonth => _daysOfMonth ?? (_daysOfMonth = new List<int>());

        // ReSharper disable UnusedMember.Local
        // ReSharper disable UnusedParameter.Local
        object XtraCreateDaysOfMonthItem(XtraItemEventArgs e)
        {
            return Convert.ToInt32(e.Item.Value);
        }
        // ReSharper restore UnusedMember.Local
        // ReSharper restore UnusedParameter.Local

        [XtraSerializableProperty]
        public bool RunOnLastDayOfMonth
        {
            get { return _runOnLastDayOfMonth; }
            set
            {
                if (_runOnLastDayOfMonth == value) return;
                _runOnLastDayOfMonth = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public MonthsOfTheYear MonthsOfYear
        {
            get { return _monthsOfYear; }
            set
            {
                if (_monthsOfYear == value) return;
                _monthsOfYear = value;
                OnPropertyChanged();
            }
        }

        [XtraSerializableProperty]
        public DateTime StartBoundary
        {
            get { return _startBoundary; }
            set
            {
                if (_startBoundary == value) return;
                _startBoundary = value;
                OnPropertyChanged();
            }
        }

        public void SetStartBoundaryTime(DateTime time)
        {
            var date = StartBoundary.Date;
            date = date.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(time.Second);
            StartBoundary = date;
        }

        public Trigger CreateTrigger()
        {
            Trigger trigger;
            switch (Recurrence)
            {
                case 0:
                    trigger = new DailyTrigger(RepeatEvery);
                    break;
                case 1:
                    trigger = new WeeklyTrigger(DaysOfWeek, RepeatEvery);
                    break;
                default:
                    trigger = new MonthlyTrigger();
                    ((MonthlyTrigger)trigger).DaysOfMonth = DaysOfMonth.ToArray();
                    ((MonthlyTrigger)trigger).MonthsOfYear = MonthsOfYear;
                    ((MonthlyTrigger)trigger).RunOnLastDayOfMonth = RunOnLastDayOfMonth;
                    break;
            }
            trigger.Enabled = true;
            trigger.StartBoundary = StartBoundary;

            return trigger;
        }

        public override string ToString()
        {
            string str;
            switch (Recurrence)
            {
                case 0:
                    return string.Format(ConstStrings.AtTime, StartBoundary) + " " + (RepeatEvery < 2 ? ConstStrings.EveryDay : string.Format(ConstStrings.EveryDays, RepeatEvery)) + ", " + string.Format(ConstStrings.StartBoundary, StartBoundary);
                case 1:
                    return string.Format(ConstStrings.AtTime, StartBoundary) + " " + ConstStrings.On + " " + DaysOfWeek + " " + (RepeatEvery < 2 ? ConstStrings.EveryWeek : string.Format(ConstStrings.EveryWeeks, RepeatEvery)) + ", " + string.Format(ConstStrings.StartBoundary, StartBoundary);
                default:
                    var days = DaysOfMonth != null ? TextHelper.Join(",", DaysOfMonth.Select(d => d.ToString())) : string.Empty;
                    if (RunOnLastDayOfMonth)
                    {
                        days = TextHelper.Join(",", days, "посл.");
                    }
                    str = string.Format(ConstStrings.AtTime, StartBoundary) + " " + string.Format(ConstStrings.AtDaysMonths, days, MonthsOfYear) + ", " + string.Format(ConstStrings.StartBoundary, StartBoundary);
                    break;
            }

            return str;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }

    public enum BackupType
    {
        Full,
        Differential,
        TransactionLog
    }

    public enum DestinationType
    {
        LocalFolder = 0,
        FtpServer = 1
    }
}
