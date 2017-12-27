using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.Win32.TaskScheduler;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    class MagicAttribute : Attribute { }

    [Magic, JsonObject(MemberSerialization.OptIn)]
    public class JobData : INotifyPropertyChanged
    {
        List<string> _databases;
        BindingList<DestinationData> _destinations;
        EmailSettingsData _emailSettings;
        BindingList<ScheduleData> _fullBackupSchedule;
        BindingList<ScheduleData> _diffBackupSchedule;
        BindingList<ScheduleData> _tranBackupSchedule;

        [JsonProperty]
        public Guid JobId { get; set; } = Guid.NewGuid();

        [JsonProperty]
        public string ServerName { get; set; } = "(local)";

        [JsonProperty]
        public bool IntegratedSecurity { get; set; } = true;

        [JsonProperty]
        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonProperty]
        public string PasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(Password); }
            set { Password = CryptoHelper.Decrypt(value); }
        }

        [JsonProperty]
        public bool BackupAllNonSystemDBs { get; set; }

        [JsonProperty]
        public bool SendEmails { get; set; }

        [JsonProperty]
        public string OnSuccessEmailTo { get; set; }

        [JsonProperty]
        public string OnFailureEmailTo { get; set; }

        [JsonProperty]
        public bool ScheduleThisJob { get; set; }

        [JsonProperty]
        public string ScheduleUserId { get; set; }

        public string SchedulePassword { get; set; }

        [JsonProperty]
        public string SchedulePasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(SchedulePassword); }
            set { SchedulePassword = CryptoHelper.Decrypt(value); }
        }

        [JsonProperty]
        public string BeforeBackupSqlScript { get; set; }

        [JsonProperty]
        public string AfterBackupSqlScript { get; set; }

        [JsonProperty]
        public int FileVersion { get; set; }

        public string FileName { get; private set; }

        [JsonProperty]
        public List<string> Databases => _databases ?? (_databases = new List<string>());

        [JsonProperty]
        public BindingList<DestinationData> Destinations => _destinations ?? (_destinations = new BindingList<DestinationData>());

        [JsonProperty]
        public EmailSettingsData EmailSettings => _emailSettings ?? (_emailSettings = new EmailSettingsData { SmtpPort = 25 });

        [JsonProperty]
        public BindingList<ScheduleData> FullBackupSchedule => _fullBackupSchedule ?? (_fullBackupSchedule = new BindingList<ScheduleData>());

        [JsonProperty]
        public BindingList<ScheduleData> DiffBackupSchedule => _diffBackupSchedule ?? (_diffBackupSchedule = new BindingList<ScheduleData>());

        [JsonProperty]
        public BindingList<ScheduleData> TranBackupSchedule => _tranBackupSchedule ?? (_tranBackupSchedule = new BindingList<ScheduleData>());

        public void Load(string fileName)
        {
            FileName = fileName;
            File.SetAttributes(fileName, FileAttributes.Normal);

            Reset();

            LoadCore(new JsonSerializer(), fileName);
        }

        // ReSharper disable UnusedMethodReturnValue.Global
        public bool Save(string fileName)
        {
            // perform upgrades
            FileVersion = 3;

            FileName = fileName;
            if (File.Exists(fileName))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
            }

            return SaveCore(new JsonSerializer(), fileName);
        }
        // ReSharper restore UnusedMethodReturnValue.Global

        void Reset()
        {
            _databases = null;
            _destinations = null;
            _emailSettings = null;
            _fullBackupSchedule = null;
            _diffBackupSchedule = null;
            _tranBackupSchedule = null;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        bool SaveCore(JsonSerializer serializer, object path)
        {
            try
            {
                var stream = path as Stream;
                using (StreamWriter sw = stream != null ? new StreamWriter(stream) : new StreamWriter(path.ToString()))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, this);
                }
                return true;
            }
            catch (Exception exc)
            {
                LogHelper.WriteError(exc);
                return false;
            }
        }

        void LoadCore(JsonSerializer serializer, object path)
        {
            try
            {
                var stream = path as Stream;
                using (StreamReader sr = stream != null ? new StreamReader(stream) : new StreamReader(path.ToString()))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    serializer.Populate(reader, this);
                }
            }
            catch (Exception exc)
            {
                LogHelper.WriteError(exc);
                throw;
            }
        }

     }

    [Magic, JsonObject(MemberSerialization.OptIn)]
    public class DestinationData : INotifyPropertyChanged
    {
        [JsonProperty]
        public int Type { get; set; }

        [JsonProperty]
        public string Path { get; set; }

        [JsonProperty]
        public int DeleteAfterMonths { get; set; }

        [JsonProperty]
        public int DeleteAfterDays { get; set; }

        [JsonProperty]
        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonProperty]
        public string PasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(Password); }
            set { Password = CryptoHelper.Decrypt(value); }
        }

        [JsonProperty]
        public int Protocol { get; set; }

        [JsonProperty]
        public int Port { get; set; }

        [JsonProperty]
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

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class EmailSettingsData
    {
        [JsonProperty]
        public string From { get; set; }

        [JsonProperty]
        public string SmtpServer { get; set; }

        [JsonProperty]
        public int SmtpPort { get; set; }

        [JsonProperty]
        public bool UseAuthentication { get; set; }

        [JsonProperty]
        public bool EnableSsl { get; set; }

        [JsonProperty]
        public string UserName { get; set; }

        public string Password { get; set; }

        [JsonProperty]
        public string PasswordEncrypted
        {
            get { return CryptoHelper.Encrypt(Password); }
            set { Password = CryptoHelper.Decrypt(value); }
        }
    }

    [Magic, JsonObject(MemberSerialization.OptIn)]
    public class ScheduleData : INotifyPropertyChanged
    {
        private int _recurrence;
        private short _repeatEvery;
        private DaysOfTheWeek _daysOfWeek;
        private List<int> _daysOfMonth;
        private MonthsOfTheYear _monthsOfYear;
        private DateTime _startBoundary;
        private bool _runOnLastDayOfMonth;

        [JsonProperty]
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

        [JsonProperty]
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

        [JsonProperty]
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

        [JsonProperty]
        public List<int> DaysOfMonth => _daysOfMonth ?? (_daysOfMonth = new List<int>());

        [JsonProperty]
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

        [JsonProperty]
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

        [JsonProperty]
        public DateTime StartBoundary
        {
            get { return _startBoundary; }
            set
            {
                if (_startBoundary == value) return;
                _startBoundary = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
                OnPropertyChanged();
            }
        }

        public string PlainText => ToString();

        public void SetStartBoundaryTime(DateTime time)
        {
            var date = StartBoundary.Date;
            date = date.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(time.Second);
            StartBoundary = date;
        }

        public Microsoft.Win32.TaskScheduler.Trigger CreateTrigger()
        {
            Microsoft.Win32.TaskScheduler.Trigger trigger;
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
            handler?.Invoke(this, new PropertyChangedEventArgs("PlainText"));
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

    [Magic]
    public class BackupHistoryData : INotifyPropertyChanged
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Type { get; set; }
        public decimal BackupSize { get; set; }
        public decimal CompressedBackupSize { get; set; }
        public string LogicalDeviceName { get; set; }
        public string PhysicalDeviceName { get; set; }
        public string BackupsetName { get; set; }
        public string Description { get; set; }
        public string FirstLsn { get; set; }
        public string LastLsn { get; set; }
        public string CheckpointLsn { get; set; }
        public string DatabaseBackupLsn { get; set; }

        public string BackupType
        {
            get
            {
                switch (Type)
                {
                    case "D":
                        return "Database";
                    case "I":
                        return "Incremental";
                    case "L":
                        return "Log";
                }
                return null;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

    }

    public class DatabaseFileData
    {
        public int file_id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string physical_name { get; set; }

    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WinFormData
    {
        private List<WinFormLayout> _layouts;

        /// <summary>
        /// Most recent files
        /// </summary>
        [JsonProperty]
        public string[] MRUFiles { get; set; }

        [JsonProperty]
        public List<WinFormLayout> Layouts => _layouts ?? (_layouts = new List<WinFormLayout>());

        void Load(string fileName)
        {
            if (!File.Exists(fileName)) return;

            File.SetAttributes(fileName, FileAttributes.Normal);

            LoadCore(new JsonSerializer(), fileName);
        }

        bool Save(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
            }

            return SaveCore(new JsonSerializer(), fileName);
        }

        bool SaveCore(JsonSerializer serializer, object path)
        {
            try
            {
                var stream = path as Stream;
                using (StreamWriter sw = stream != null ? new StreamWriter(stream) : new StreamWriter(path.ToString()))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, this);
                }
                return true;
            }
            catch (Exception exc)
            {
                LogHelper.WriteError(exc);
                return false;
            }
        }

        void LoadCore(JsonSerializer serializer, object path)
        {
            try
            {
                var stream = path as Stream;
                using (StreamReader sr = stream != null ? new StreamReader(stream) : new StreamReader(path.ToString()))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    serializer.Populate(reader, this);
                }
            }
            catch (Exception exc)
            {
                LogHelper.WriteError(exc);
            }
        }

        #region Static
        static WinFormData _current;

        /// <summary>
        /// Gets the current property
        /// </summary>
        public static WinFormData Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new WinFormData();
                    _current.Load(WinHelper.GetDataDirectory() + "\\settings.json");
                }
                return _current;
            }
        }

        public static void LoadFormLayout(Window form)
        {
            var layout = Current.Layouts.FirstOrDefault(x => x.Name == form.Name);
            if (layout != null && !layout.FormBounds.IsEmpty)
            {
                Rect restoreBounds = layout.FormBounds;
                form.Left = restoreBounds.Left;
                form.Top = restoreBounds.Top;
                form.Width = restoreBounds.Width;
                form.Height = restoreBounds.Height;
                form.WindowState = layout.WindowState;
            }
        }

        public static void SaveFormLayout(Window form)
        {
            var layout = Current.Layouts.FirstOrDefault(x => x.Name == form.Name);
            if (layout == null)
            {
                layout = new WinFormLayout { Name = form.Name };
                Current.Layouts.Add(layout);
            }
            layout.WindowState = form.WindowState;
            layout.FormBounds = form.WindowState == WindowState.Maximized ? form.RestoreBounds : new Rect(form.Left, form.Top, form.Width, form.Height);
        }

        /// <summary>
        /// Saves default properties
        /// </summary>
        public static void SaveDefaultProperties(string[] mruFiles)
        {
            Current.MRUFiles = mruFiles;
            Current.Save(WinHelper.GetDataDirectory() + "\\settings.json");
        }

        #endregion
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WinFormLayout
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public WindowState WindowState { get; set; }

        [JsonProperty]
        public Rect FormBounds { get; set; }
    }

    public class CheckedListItem<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isChecked;
        private T item;

        public CheckedListItem()
        { }

        public CheckedListItem(T item, bool isChecked = false)
        {
            this.item = item;
            this.isChecked = isChecked;
        }

        public T Item
        {
            get { return item; }
            set
            {
                item = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
            }
        }


        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}
