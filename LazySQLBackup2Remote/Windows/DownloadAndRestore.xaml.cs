using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для DownloadAndRestore.xaml
    /// </summary>
    public partial class DownloadAndRestore : Window
    {
        readonly JobData _job;
        readonly BackgroundWorker _worker = new BackgroundWorker();
        private BindingList<BackupHistoryData> backupHistory;

        public DownloadAndRestore(JobData job)
        {
            InitializeComponent();

            _job = job;
            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        async void InitData()
        {
            try
            {
                var databases = _job.Databases.ToArray();
                List<string> targetDatabases;
                using (var cn = await DbHelper.GetNewOpenConnectionAsync(_job))
                {
                    targetDatabases = await DbHelper.GetDatabaseNamesAsync(false, cn);
                }
                if (_job.BackupAllNonSystemDBs)
                {
                    databases = targetDatabases.ToArray();
                }
                DatabaseComboBox.Items.Clear();
                for (var n = 0; n < databases.Length; n++)
                {
                    DatabaseComboBox.Items.Add(databases[n]);
                    if (n == 0)
                        DatabaseComboBox.SelectedIndex = n;
                }

                DestinationComboBox.ItemsSource = _job.Destinations.Select(x => new { Value = x, Description = $"{x.Path} ({x.TypeName})" }).ToList();
                DestinationComboBox.SelectedValue = _job.Destinations.FirstOrDefault();

                TargerComboBox.Items.Clear();
                for (var n = 0; n < targetDatabases.Count; n++)
                {
                    TargerComboBox.Items.Add(targetDatabases[n]);
                    if (n == 0)
                        TargerComboBox.SelectedIndex = n;
                }

                SelectedDatePicker.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        async void RefreshBackupHistory()
        {
            try
            {
                var database = (string)DatabaseComboBox.SelectedItem;
                if (!string.IsNullOrEmpty(database))
                {
                    using (var cn = await DbHelper.GetNewOpenConnectionAsync(_job))
                    {
                        var collection = new BindingList<BackupHistoryData>();
                        var history = await DbHelper.GetBackupHistoryAsync(cn, database);
                        var lastBackup = history.Where(x => x.FinishDate < SelectedDatePicker.Value.Value.Date.AddDays(1)).OrderByDescending(x => x.FinishDate).FirstOrDefault();
                        if (lastBackup != null)
                        {
                            BackupHistoryData fullBackup = null, incrementalBackup = null;
                            List<BackupHistoryData> transactionLogBackups = null;
                            if (lastBackup.Type == "L")
                            {
                                fullBackup = history.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == lastBackup.DatabaseBackupLsn);
                                incrementalBackup = history.Where(x => x.Type == "I" && x.DatabaseBackupLsn == lastBackup.DatabaseBackupLsn && string.CompareOrdinal(x.CheckpointLsn, lastBackup.CheckpointLsn) <= 0).OrderByDescending(x => x.CheckpointLsn).FirstOrDefault();
                                transactionLogBackups = history.Where(x => x.Type == "L" && x.DatabaseBackupLsn == lastBackup.DatabaseBackupLsn && (incrementalBackup == null || string.CompareOrdinal(x.CheckpointLsn, incrementalBackup.CheckpointLsn) > 0) && string.CompareOrdinal(x.CheckpointLsn, lastBackup.CheckpointLsn) <= 0).ToList();
                            }
                            else if (lastBackup.Type == "I")
                            {
                                incrementalBackup = lastBackup;
                                fullBackup = history.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == lastBackup.DatabaseBackupLsn);
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
                        backupHistory = collection;
                    }
                }
                else
                {
                    backupHistory = null;
                }
                BackupHistoryGrid.ItemsSource = backupHistory;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void ReportProgress(string text)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action(delegate { ReportProgress(text); }));
            }
            else
            {
                ProgressBar.BusyContent = text;
            }
        }

        void SafeDeleteFile(string path)
        {
            try
            {
                var attr = File.GetAttributes(path);
                if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    File.SetAttributes(path, attr & ~FileAttributes.ReadOnly);
                }
                File.Delete(path);
            }
            catch (Exception ex)
            {
                WinHelper.LogException(ex);
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string database = ((dynamic)e.Argument).Database;
            DestinationData destination = ((dynamic)e.Argument).Destination;
            string targetDatabase = ((dynamic)e.Argument).TargetDatabase;
            bool deleteFilesOnSuccess = ((dynamic)e.Argument).DeleteFilesOnSuccess;
            var tempDirectory = WinHelper.GetTempDirectory();

            var rows = new List<BackupHistoryData>();
            foreach (BackupHistoryData row in backupHistory.Where(x => x.IsSelected).ToList())
            {
                var backup = Path.GetFileName(row.PhysicalDeviceName);
                var archive = Path.ChangeExtension(backup, "zip");
                var to = Path.GetDirectoryName(row.PhysicalDeviceName);

                ReportProgress(string.Format(ConstStrings.DownloadingFileProgress, archive, 0));

                bool result;
                switch (destination.Type)
                {
                    case 0:
                        result = FileHelper.DownloadFromLocalFolder(destination, database, tempDirectory, archive,
                            (o, args) => ReportProgress(string.Format(ConstStrings.DownloadingFileProgress, archive, args.ProgressPercentage)));
                        break;
                    default:
                        result = FileHelper.DownloadFromFtpServer(destination, database, tempDirectory, archive);
                        break;
                }

                if (!result)
                {
                    return;
                }

                ReportProgress(string.Format(FileSizeFormatProvider.Default, ConstStrings.ExtractingFileProgress, backup, 0, 0));
                result = FileHelper.ExtractFile(tempDirectory, archive, to, backup, (o, args) => ReportProgress(string.Format(FileSizeFormatProvider.Default, ConstStrings.ExtractingFileProgress, backup, args.BytesTransferred, args.TotalBytesToTransfer)));
                if (!result)
                {
                    return;
                }

                rows.Add(row);
            }

            var sql = "";
            var fullBackup = rows.Where(x => x.Type == "D").OrderByDescending(x => x.CheckpointLsn).FirstOrDefault();
            var incrementalBackup = rows.Where(x => x.Type == "I" && (fullBackup == null || fullBackup.CheckpointLsn == x.DatabaseBackupLsn)).OrderByDescending(x => x.CheckpointLsn).FirstOrDefault();
            var transactionLogBackups = rows.Where(x => x.Type == "L" && (fullBackup == null || fullBackup.CheckpointLsn == x.DatabaseBackupLsn) && (incrementalBackup == null || incrementalBackup.DatabaseBackupLsn == x.DatabaseBackupLsn)).OrderBy(x => x.CheckpointLsn).ToList();
            if (fullBackup != null)
            {
                var move = "";
                if (database != targetDatabase)
                {
                    using (var cn = DbHelper.GetNewOpenConnection(_job))
                    {
                        var files = DbHelper.GetDatabaseFiles(cn, database);
                        var targetFiles = DbHelper.GetDatabaseFiles(cn, targetDatabase);
                        foreach (var file in files)
                        {
                            string physicalName;
                            var targetFile = targetFiles.FirstOrDefault(x => x.type == file.type);
                            if (targetFile != null)
                            {
                                physicalName = targetFile.physical_name;
                                targetFiles.Remove(targetFile);
                            }
                            else
                            {
                                var dir = "" + Path.GetDirectoryName(file.physical_name);
                                var fileName = targetDatabase + (file.type == 1 ? "_log" : "") + Path.GetExtension(file.physical_name);
                                physicalName = Path.Combine(dir, fileName);
                            }
                            move = move + $"  MOVE N'{file.name}' TO N'{physicalName}',";
                        }
                    }
                }
                sql += $"RESTORE DATABASE [{targetDatabase}] FROM  DISK = N'{fullBackup.PhysicalDeviceName}' WITH  FILE = 1," + move + (incrementalBackup != null || transactionLogBackups.Count > 0 ? "  NORECOVERY," : "") + "  NOUNLOAD,  REPLACE,  STATS = 5" + Environment.NewLine;
            }
            if (incrementalBackup != null)
            {
                sql += $"RESTORE DATABASE [{targetDatabase}] FROM  DISK = N'{incrementalBackup.PhysicalDeviceName}' WITH  FILE = 1," + (transactionLogBackups.Count > 0 ? "  NORECOVERY," : "") + "  NOUNLOAD,  STATS = 5" + Environment.NewLine;
            }
            for (var n = 0; n < transactionLogBackups.Count; n++)
            {
                sql += $"RESTORE LOG [{targetDatabase}] FROM  DISK = N'{transactionLogBackups[n].PhysicalDeviceName}' WITH  FILE = 1," + (n < transactionLogBackups.Count - 1 ? "  NORECOVERY," : "") + "  NOUNLOAD,  STATS = 5" + Environment.NewLine;
            }

            string errors = "", backupDirectory;
            LogHelper.WriteLine(string.Format(ConstStrings.RestoringDatabase, DateTime.Now, targetDatabase));
            ReportProgress(string.Format(ConstStrings.RestoringDatabaseProgress, targetDatabase, ""));
            using (var cn = DbHelper.GetNewOpenConnection(_job))
            {
                backupDirectory = DbHelper.GetBackupDirectory(cn);
                cn.FireInfoMessageEventOnUserErrors = true;
                cn.InfoMessage += (o, args) =>
                {
                    ReportProgress(string.Format(ConstStrings.RestoringDatabaseProgress, targetDatabase, args.Message));
                    LogHelper.WriteLine(DateTime.Now.ToString("G") + " " + args.Message);
                    errors = args.Errors.Cast<SqlError>().Where(error => error.Class > 10).Aggregate(errors, (current, error) => $"{current}{error.Message}{Environment.NewLine}");
                };
                var cmd = cn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
            }

            if (!string.IsNullOrEmpty(errors))
            {
                throw new Exception(errors);
            }
            if (deleteFilesOnSuccess)
            {
                var archives = Directory.GetFiles(tempDirectory, "*.zip");
                foreach (var archive in archives)
                    SafeDeleteFile(archive);
                var backups = Directory.GetFiles(backupDirectory, "*.bak");
                foreach (var backup in backups)
                    SafeDeleteFile(backup);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var now = DateTime.Now;
            ProgressBar.IsBusy = false;

            if (e.Error != null) LogHelper.WriteError(e.Error);
            LogHelper.WriteLine(string.Format(ConstStrings.DownloadAndRestoreFinished, now));
            LogHelper.SaveToFile();

            CloseButton.IsEnabled = true;
            if (e.Error != null)
            {
                MessageBox.Show(this, e.Error.Message, ConstStrings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(this, string.Format(ConstStrings.DownloadAndRestoreFinished, now), ConstStrings.Information, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WinFormData.LoadFormLayout(this);
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            InitData();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (_worker.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            WinFormData.SaveFormLayout(this);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshBackupHistory();
        }

        private void DownloadAndRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            DownloadAndRestoreButton.IsEnabled = CloseButton.IsEnabled = false;
            ProgressBar.IsBusy = true;

            var arg = new
            {
                Database = (string)DatabaseComboBox.SelectedItem,
                Destination = (DestinationData)DestinationComboBox.SelectedValue,
                TargetDatabase = (string)TargerComboBox.SelectedItem,
                DeleteFilesOnSuccess = DeleteFilesCheckBox.IsChecked == true
            };

            _worker.RunWorkerAsync(arg);
        }

        private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (BackupHistoryData c in BackupHistoryGrid.ItemsSource)
            {
                c.IsSelected = true;
            }
        }

        private void SelectAllCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (BackupHistoryData c in BackupHistoryGrid.ItemsSource)
            {
                c.IsSelected = false;
            }
        }

        private void IsSelectedCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = (System.Windows.Controls.CheckBox)sender;
            var dataItem = (BackupHistoryData)BackupHistoryGrid.SelectedItem;
            dataItem.IsSelected = checkBox.IsChecked == true;
            if (dataItem.IsSelected)
            {
                BackupHistoryData lastDatabaseBackup = null, lastIncrementalBackup = null;
                List<BackupHistoryData> transactionLogBackups = null;
                if (dataItem.Type == "L")
                {
                    lastDatabaseBackup = backupHistory.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == dataItem.DatabaseBackupLsn);
                    lastIncrementalBackup = backupHistory.Where(x => x.Type == "I" && x.DatabaseBackupLsn == dataItem.DatabaseBackupLsn && string.CompareOrdinal(x.CheckpointLsn, dataItem.CheckpointLsn) < 0).OrderByDescending(x => x.CheckpointLsn).FirstOrDefault();
                    transactionLogBackups = backupHistory.Where(x => x.Type == "L" && x.DatabaseBackupLsn == dataItem.DatabaseBackupLsn && (lastIncrementalBackup == null || string.CompareOrdinal(x.CheckpointLsn, lastIncrementalBackup.CheckpointLsn) > 0) && string.CompareOrdinal(x.CheckpointLsn, dataItem.CheckpointLsn) < 0).ToList();
                }
                else if (dataItem.Type == "I")
                {
                    lastDatabaseBackup = backupHistory.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == dataItem.DatabaseBackupLsn);
                }
                if (lastDatabaseBackup != null)
                {
                    lastDatabaseBackup.IsSelected = true;
                }
                if (lastIncrementalBackup != null)
                {
                    lastIncrementalBackup.IsSelected = true;
                }
                if (transactionLogBackups != null)
                {
                    foreach (var transactionLogBackup in transactionLogBackups)
                    {
                        transactionLogBackup.IsSelected = true;
                    }
                }
            }
            else
            {
                if (dataItem.Type == "D")
                {
                    var all = backupHistory.Where(x => x.DatabaseBackupLsn == dataItem.CheckpointLsn).ToList();
                    foreach (var backup in all)
                    {
                        backup.IsSelected = false;
                    }
                }
                else if (dataItem.Type == "I")
                {
                    var all = backupHistory.Where(x => x.DatabaseBackupLsn == dataItem.DatabaseBackupLsn && string.CompareOrdinal(x.CheckpointLsn, dataItem.CheckpointLsn) > 0).ToList();
                    foreach (var backup in all)
                    {
                        backup.IsSelected = false;
                    }
                }
                else if (dataItem.Type == "L")
                {
                    var all = backupHistory.Where(x => x.DatabaseBackupLsn == dataItem.DatabaseBackupLsn && string.CompareOrdinal(x.CheckpointLsn, dataItem.CheckpointLsn) > 0).ToList();
                    foreach (var backup in all)
                    {
                        backup.IsSelected = false;
                    }
                }
            }

            SelectAllCheckBox.IsChecked = BackupHistoryGrid.ItemsSource.Cast<BackupHistoryData>().All(x => x.IsSelected) ? true : BackupHistoryGrid.ItemsSource.Cast<BackupHistoryData>().All(x => !x.IsSelected) ? false : (bool?)null;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
