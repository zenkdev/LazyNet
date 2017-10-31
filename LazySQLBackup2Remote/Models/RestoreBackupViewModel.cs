using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using Dekart.LazyNet.SQLBackup2Remote.Views;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.SQLBackup2Remote.Models
{
    public class RestoreBackupViewModel : BindableBase
    {
        private RestoreBackupView _view;

        public void Init(RestoreBackupView view)
        {
            _view = view;

            var databases = _view._job.Databases.ToArray();
            using (var cn = DbHelper.GetNewOpenConnection(_view._job))
            {
                BackupDirectory = DbHelper.GetBackupDirectory(cn);
                TargetDatabases = DbHelper.GetDatabaseNames(false, cn).ToObservableCollection();
            }
            if (_view._job.BackupAllNonSystemDBs)
            {
                databases = TargetDatabases.ToArray();
            }
            Databases = new ObservableCollection<string>(databases);
            CurrentDatabase = Databases.FirstOrDefault();

            Destinations = _view._job.Destinations.ToObservableCollection();
            CurrentDestination = Destinations.FirstOrDefault();
            SelectedDate = DateTime.Today;
        }

        public virtual ObservableCollection<string> Databases { get; set; }

        public virtual string CurrentDatabase { get; set; }

        public virtual ObservableCollection<string> TargetDatabases { get; set; }

        public virtual string TargetDatabase { get; set; }

        public virtual ObservableCollection<DestinationData> Destinations { get; set; }

        public virtual DestinationData CurrentDestination { get; set; }

        /// <summary> Changed callback </summary>
        protected void OnCurrentDatabaseChanged()
        {
            RefreshBackupHistory();

            TargetDatabase = CurrentDatabase;
        }

        public virtual DateTime SelectedDate { get; set; }

        /// <summary> Changed callback </summary>
        protected void OnSelectedDateChanged()
        {
            RefreshBackupHistory();
        }

        public virtual string BackupDirectory { get; set; }

        public virtual bool DeleteFilesOnSuccess { get; set; } = true;

        public virtual ObservableCollection<BackupHistoryViewModel> BackupHistory { get; set; }


        public void RefreshBackupHistory()
        {
            try
            {
                var database = CurrentDatabase;
                if (!string.IsNullOrEmpty(database))
                {
                    using (var cn = DbHelper.GetNewOpenConnection(_view._job))
                    {
                        var collection = new ObservableCollection<BackupHistoryViewModel>();
                        var backupHistory = DbHelper.GetBackupHistory(cn, database);
                        var lastBackup = backupHistory.Where(x => x.FinishDate < SelectedDate.AddDays(1)).OrderByDescending(x => x.FinishDate).FirstOrDefault();
                        if (lastBackup != null)
                        {
                            BackupHistoryViewModel fullBackup = null, incrementalBackup = null;
                            List<BackupHistoryViewModel> transactionLogBackups = null;
                            if (lastBackup.Type == "L")
                            {
                                fullBackup = backupHistory.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == lastBackup.DatabaseBackupLsn);
                                incrementalBackup = backupHistory.Where(x => x.Type == "I" && x.DatabaseBackupLsn == lastBackup.DatabaseBackupLsn && string.CompareOrdinal(x.CheckpointLsn, lastBackup.CheckpointLsn) <= 0).OrderByDescending(x => x.CheckpointLsn).FirstOrDefault();
                                transactionLogBackups = backupHistory.Where(x => x.Type == "L" && x.DatabaseBackupLsn == lastBackup.DatabaseBackupLsn && (incrementalBackup == null || string.CompareOrdinal(x.CheckpointLsn, incrementalBackup.CheckpointLsn) > 0) && string.CompareOrdinal(x.CheckpointLsn, lastBackup.CheckpointLsn) <= 0).ToList();
                            }
                            else if (lastBackup.Type == "I")
                            {
                                incrementalBackup = lastBackup;
                                fullBackup = backupHistory.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == lastBackup.DatabaseBackupLsn);
                            }
                            else if (lastBackup.Type == "D")
                            {
                                fullBackup = lastBackup;
                            }
                            if (fullBackup != null)
                            {
                                collection.Add(fullBackup);
                            }
                            if (incrementalBackup != null)
                            {
                                collection.Add(incrementalBackup);
                            }
                            if (transactionLogBackups != null)
                            {
                                foreach (var transactionLogBackup in transactionLogBackups)
                                {
                                    collection.Add(transactionLogBackup);
                                }
                            }
                        }
                        BackupHistory = collection;
                    }
                }
                else
                {
                    BackupHistory = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(_view, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
