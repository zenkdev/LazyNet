using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using Dekart.LazyNet.SQLBackup2Remote.Models;
using Dekart.LazyNet.SQLBackup2Remote.Properties;
using DevExpress.Mvvm.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Dekart.LazyNet.SQLBackup2Remote.Views
{
    public partial class RestoreBackupView : XtraForm
    {
        readonly Form _parent;
        readonly RestoreBackupViewModel _viewModel;
        // ReSharper disable once InconsistentNaming
        internal readonly JobData _job;

        public RestoreBackupView(Form parent, JobData job)
        {
            InitializeComponent();
            _parent = parent;
            _job = job;

            Icon = Icon.FromHandle(Resources.download_32x32.GetHicon());
            var fluentApi = mvvmContext.OfType<RestoreBackupViewModel>();
            fluentApi.SetItemsSourceBinding(
                Database.Properties, //Target 
                c => c.Items, //Items Selector 
                x => x.Databases, //Source Selector  
                (item, entity) => Equals(item.Value, entity), //Match Expression 
                entity => new ImageComboBoxItem { Value = entity, Description = entity }); //Create Expressio
            fluentApi.SetBinding(Database, e => e.Text, x => x.CurrentDatabase);

            fluentApi.SetItemsSourceBinding(
                TargetDatabase.Properties, //Target 
                c => c.Items, //Items Selector 
                x => x.TargetDatabases, //Source Selector  
                (item, entity) => Equals(item.Value, entity), //Match Expression 
                entity => new ImageComboBoxItem { Value = entity, Description = entity }); //Create Expressio
            fluentApi.SetBinding(TargetDatabase, e => e.Text, x => x.TargetDatabase);

            fluentApi.SetItemsSourceBinding(
                Destination.Properties, //Target 
                c => c.Items, //Items Selector 
                x => x.Destinations, //Source Selector  
                (item, entity) => Equals(item.Value, entity), //Match Expression 
                entity => new ImageComboBoxItem { Value = entity, Description = $"{entity.Path} ({entity.TypeName})" }); //Create Expressio
            fluentApi.SetBinding(Destination, e => e.EditValue, x => x.CurrentDestination);

            fluentApi.BindCommand(sbRefresh, x => x.RefreshBackupHistory());
            fluentApi.SetBinding(Date, e => e.DateTime, x => x.SelectedDate);
            fluentApi.SetBinding(DeleteFilesOnSuccess, e => e.EditValue, x => x.DeleteFilesOnSuccess, b => b, o => (bool?)o ?? false);

            // We want to show the Entities collection in grid and react on this collection external changes (Reload, server-side Filtering)
            fluentApi.SetBinding(gcMain, e => e.DataSource, x => x.BackupHistory);

            _viewModel = fluentApi.ViewModel;
        }

        #region Overrides of Form

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            WinFormData.LoadFormLayout(this);

            if (_parent != null)
            {
                Location = new Point(_parent.Left + (_parent.Width - Width) / 2, _parent.Top + (_parent.Height - Height) / 2);
            }

            InitData();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            WinFormData.SaveFormLayout(this);
            base.OnFormClosed(e);
        }

        #endregion

        void InitData()
        {
            try
            {
                _viewModel.Init(this);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ReportProgress(string text)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { ReportProgress(text); });
            }
            else
            {
                progressPanel1.Description = text;
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

        void SbOkClick(object sender, EventArgs e)
        {
            if (gvMain.GetSelectedRows().Length == 0)
            {
                XtraMessageBox.Show(this, ConstStrings.NoRecoveryArchiveSelected, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ReportProgress(ConstStrings.DownloadAndRestoreStarting);
                progressPanel1.Visible = true;
                LogHelper.WriteLine(Environment.NewLine + string.Format(ConstStrings.StartDownloadAndRestore, DateTime.Now));
                if (!string.IsNullOrEmpty(_job.FileName))
                {
                    LogHelper.WriteLine(string.Format(ConstStrings.JobName, _job.FileName) + Environment.NewLine);
                }
                backgroundWorker.RunWorkerAsync();
            }
        }

        void SbCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var database = _viewModel.CurrentDatabase;
            var destination = _viewModel.CurrentDestination;
            var targetDatabase = _viewModel.TargetDatabase;
            var deleteFilesOnSuccess = _viewModel.DeleteFilesOnSuccess;
            var backupDirectory = _viewModel.BackupDirectory;
            var tempDirectory = WinHelper.GetTempDirectory();

            var rows = new List<BackupHistoryViewModel>();
            foreach (var rowHandle in gvMain.GetSelectedRows())
            {
                var row = (BackupHistoryViewModel)gvMain.GetRow(rowHandle);

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

            var errors = "";
            LogHelper.WriteLine(string.Format(ConstStrings.RestoringDatabase, DateTime.Now, targetDatabase));
            ReportProgress(string.Format(ConstStrings.RestoringDatabaseProgress, targetDatabase, ""));
            using (var cn = DbHelper.GetNewOpenConnection(_job))
            {
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
                archives.ForEach(SafeDeleteFile);
                var backups = Directory.GetFiles(backupDirectory, "*.bak");
                backups.ForEach(SafeDeleteFile);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var now = DateTime.Now;
            progressPanel1.Visible = false;

            if (e.Error != null) LogHelper.WriteError(e.Error);
            LogHelper.WriteLine(string.Format(ConstStrings.DownloadAndRestoreFinished, now));
            LogHelper.SaveToFile();

            if (e.Error != null)
            {
                XtraMessageBox.Show(this, e.Error.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show(this, string.Format(ConstStrings.DownloadAndRestoreFinished, now), ConstStrings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gvMain_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var rowHandle = gvMain.GetRowHandle(e.ControllerRow);
            var row = (BackupHistoryViewModel)gvMain.GetRow(rowHandle);
            var backupHistory = _viewModel.BackupHistory;

            if (e.Action == CollectionChangeAction.Add)
            {
                BackupHistoryViewModel lastDatabaseBackup = null, lastIncrementalBackup = null;
                List<BackupHistoryViewModel> transactionLogBackups = null;
                if (row?.Type == "L")
                {
                    lastDatabaseBackup = backupHistory.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == row.DatabaseBackupLsn);
                    lastIncrementalBackup = backupHistory.Where(x => x.Type == "I" && x.DatabaseBackupLsn == row.DatabaseBackupLsn && string.CompareOrdinal(x.CheckpointLsn, row.CheckpointLsn) < 0).OrderByDescending(x => x.CheckpointLsn).FirstOrDefault();
                    transactionLogBackups = backupHistory.Where(x => x.Type == "L" && x.DatabaseBackupLsn == row.DatabaseBackupLsn && (lastIncrementalBackup == null || string.CompareOrdinal(x.CheckpointLsn, lastIncrementalBackup.CheckpointLsn) > 0) && string.CompareOrdinal(x.CheckpointLsn, row.CheckpointLsn) < 0).ToList();
                }
                else if (row?.Type == "I")
                {
                    lastDatabaseBackup = backupHistory.FirstOrDefault(x => x.Type == "D" && x.CheckpointLsn == row.DatabaseBackupLsn);
                }
                if (lastDatabaseBackup != null)
                {
                    gvMain.SelectRow(gvMain.GetRowHandle(backupHistory.IndexOf(lastDatabaseBackup)));
                }
                if (lastIncrementalBackup != null)
                {
                    gvMain.SelectRow(gvMain.GetRowHandle(backupHistory.IndexOf(lastIncrementalBackup)));
                }
                if (transactionLogBackups != null)
                {
                    foreach (var transactionLogBackup in transactionLogBackups)
                    {
                        gvMain.SelectRow(gvMain.GetRowHandle(backupHistory.IndexOf(transactionLogBackup)));
                    }
                }
            }
            else if (e.Action == CollectionChangeAction.Remove)
            {
                if (row?.Type == "D")
                {
                    var all = backupHistory.Where(x => x.DatabaseBackupLsn == row.CheckpointLsn).ToList();
                    foreach (var backup in all)
                    {
                        gvMain.UnselectRow(gvMain.GetRowHandle(backupHistory.IndexOf(backup)));
                    }
                }
                else if (row?.Type == "I")
                {
                    var all = backupHistory.Where(x => x.DatabaseBackupLsn == row.DatabaseBackupLsn && string.CompareOrdinal(x.CheckpointLsn, row.CheckpointLsn) > 0).ToList();
                    foreach (var backup in all)
                    {
                        gvMain.UnselectRow(gvMain.GetRowHandle(backupHistory.IndexOf(backup)));
                    }
                }
            }
        }
    }

}
