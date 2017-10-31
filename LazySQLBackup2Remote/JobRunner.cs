using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using WinSCP;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    public class JobRunner
    {
        // ReSharper disable InconsistentNaming
        const int ERROR_SUCCESS = 0;
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_BAD_ARGUMENTS = 160;
        const int ERROR_INTERNAL_ERROR = 1359;
        // ReSharper restore InconsistentNaming

        JobData _job;
        readonly DateTime _now = DateTime.Now, _utcNow = DateTime.UtcNow;

        public int RunBySchedule(string jobName, string type)
        {
            BackupType backupType;
            if (string.IsNullOrEmpty(jobName))
            {
                return ERROR_BAD_ARGUMENTS;
            }
            if (!Enum.TryParse(type, true, out backupType))
            {
                return ERROR_BAD_ARGUMENTS;
            }

            try
            {
                if (!File.Exists(jobName))
                {
                    return ERROR_FILE_NOT_FOUND;
                }

                LogHelper.WriteLine(Environment.NewLine + string.Format(ConstStrings.StartJob, _now));
                if (!string.IsNullOrEmpty(jobName))
                {
                    LogHelper.WriteLine(string.Format(ConstStrings.JobName, jobName) + Environment.NewLine);
                }
                var index = LogHelper.LogLength;

                var job = new JobData();
                job.Load(jobName);

                var dict = Run(job, backupType);

                var success = false;
                if (dict.Count > 0)
                {
                    success = dict.All(i => i.Value);

                    var str = ConstStrings.Summary + Environment.NewLine;
                    LogHelper.InsertText(index, str);
                    index += str.Length;

                    foreach (var pair in dict)
                    {
                        str = string.Format(pair.Value ? ConstStrings.DatabaseSuccess : ConstStrings.DatabaseFail, pair.Key) + Environment.NewLine;
                        LogHelper.InsertText(index, str);
                        index += str.Length;
                    }

                    LogHelper.InsertText(index, Environment.NewLine + ConstStrings.Details + Environment.NewLine);
                }

                if (job.SendEmails)
                {
                    var email = success ? job.OnSuccessEmailTo : job.OnFailureEmailTo;
                    var smtpServer = job.EmailSettings.SmtpServer;
                    var smtpPort = job.EmailSettings.SmtpPort;
                    var useAuthentication = job.EmailSettings.UseAuthentication;
                    var enableSsl = job.EmailSettings.EnableSsl;
                    var userName = job.EmailSettings.UserName;
                    var password = job.EmailSettings.Password;
                    var from = job.EmailSettings.From;

                    try
                    {
                        var to = email.Split(';', ',');
                        var subject = string.Format(success ? ConstStrings.EmailSubjectSuccess : ConstStrings.EmailSubjectFail, ConstStrings.ApplicationCaption, Path.GetFileNameWithoutExtension(jobName), Environment.MachineName);
                        var body = LogHelper.GetContent();
                        SendMail.Send(smtpServer, smtpPort, useAuthentication, enableSsl, userName, password, to, subject, body, from, null, false, null, success ? MailPriority.Normal : MailPriority.High);
                        LogHelper.WriteLine(string.Format(success ? ConstStrings.SuccessReportSent : ConstStrings.FailReportSent, email, smtpServer));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLine(string.Format(success ? ConstStrings.SuccessReportNotSent : ConstStrings.FailReportNotSent, email, smtpServer));
                        WinHelper.LogException(ex);
                    }
                }

                LogHelper.SaveToFile();
            }
            catch (Exception ex)
            {
                WinHelper.LogException(ConstStrings.RunJobFailure, ex);
                return ERROR_INTERNAL_ERROR;
            }

            return ERROR_SUCCESS;
        }

        public Dictionary<string, bool> Run(JobData job, BackupType backupType)
        {
            _job = job;

            var dict = new Dictionary<string, bool>();

            try
            {
                var databases = _job.Databases.ToArray();

                string backupDirectory;
                var tempDirectory = WinHelper.GetTempDirectory();

                LogHelper.WriteLine(string.Format(ConstStrings.ConnectingToSql, DateTime.Now, _job.ServerName));
                using (var cn = DbHelper.GetNewOpenConnection(_job))
                {
                    backupDirectory = DbHelper.GetBackupDirectory(cn);
                    if (job.BackupAllNonSystemDBs)
                    {
                        databases = DbHelper.GetDatabaseNames(false, cn).ToArray();
                    }
                }

                RemoveJunkBackups(backupDirectory);

                RunCustomSqlScriptBeforeBackup();

                foreach (var database in databases)
                {
                    // tempdb can't backed up
                    if (database.ToLower() == "tempdb") continue;

                    var backup = database + _now.ToString("yyyyMMddHHmmss");
                    switch (backupType)
                    {
                        case BackupType.Differential:
                            backup = $"{backup}diff";
                            break;
                        case BackupType.TransactionLog:
                            backup = $"{backup}log";
                            break;
                    }
                    backup = $"{backup}.bak";
                    var archive = Path.ChangeExtension(backup, ".zip");

                    dict[database] = BackupDatabase(database, backupDirectory, backup, backupType);
                    if (dict[database])
                    {
                        dict[database] = FileHelper.CompressFile(backupDirectory, backup, tempDirectory, archive);
                        if (dict[database])
                        {
                            // Copy archive to each destination
                            foreach (var destination in _job.Destinations)
                            {
                                bool upload;
                                switch (destination.Type)
                                {
                                    case 0:
                                        upload = FileHelper.UploadToLocalFolder(tempDirectory, archive, destination, database);
                                        break;
                                    default:
                                        upload = FileHelper.UploadToFtpServer(tempDirectory, archive, destination, database);
                                        break;
                                }
                                dict[database] = dict[database] & upload;
                            }
                        }
                    }

                    LogHelper.WriteLine(string.Format(ConstStrings.RemovingFrom, DateTime.Now, archive, tempDirectory));

                    try
                    {
                        // Delete archive
                        File.Delete(Path.Combine(tempDirectory, archive));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteError(ex);
                        dict[database] = false;
                    }
                }

                RunCustomSqlScriptAfterBackup();
                
                // Cleanup all destinations
                foreach (var destination in _job.Destinations)
                {
                    if (destination.Type == 0)
                    {
                        CleanupLocalFolder(destination);
                    }
                    else
                    {
                        CleanupFtpServer(destination);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }

            LogHelper.WriteLine(string.Format(ConstStrings.JobFinished, DateTime.Now));

            return dict;
        }

        void RemoveJunkBackups(string backupDirectory)
        {
            try
            {
                var fileNames = new List<string>(Directory.GetFiles(backupDirectory, "*.bak", SearchOption.TopDirectoryOnly));
                foreach (var fileName in fileNames)
                {
                    var fileInfo = new FileInfo(fileName);
                    if ((fileInfo.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                    {
                        LogHelper.WriteLine(string.Format(ConstStrings.RemovingJunkBackup, DateTime.Now, fileName));
                        fileInfo.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }

        void RunCustomSqlScriptBeforeBackup()
        {
            if (string.IsNullOrWhiteSpace(_job.BeforeBackupSqlScript)) return;

            LogHelper.WriteLine(string.Format(ConstStrings.RunningCustomSqlScript, DateTime.Now, ConstStrings.BeforeBackup));
            
            try
            {
                using (var cn = DbHelper.GetNewOpenConnection(_job))
                {
                    var cmd = new SqlCommand(_job.BeforeBackupSqlScript, cn) { CommandTimeout = 0 };
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }

        void RunCustomSqlScriptAfterBackup()
        {
            if (string.IsNullOrWhiteSpace(_job.AfterBackupSqlScript)) return;

            LogHelper.WriteLine(string.Format(ConstStrings.RunningCustomSqlScript, DateTime.Now, ConstStrings.AfterBackup));

            try
            {
                using (var cn = DbHelper.GetNewOpenConnection(_job))
                {
                    var cmd = new SqlCommand(_job.AfterBackupSqlScript, cn) { CommandTimeout = 0 };
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }

        bool BackupDatabase(string database, string path, string file, BackupType backupType)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.CreatingBackup, DateTime.Now, database, path, TextHelper.ConvertEnum(backupType.ToString())));

            string sql;

            switch (backupType)
            {
                case BackupType.Differential:
                    sql = $"BACKUP DATABASE [{database}] TO DISK = @Path WITH INIT, DIFFERENTIAL";
                    break;
                case BackupType.TransactionLog:
                    sql = $"BACKUP LOG [{database}] TO DISK = @Path WITH INIT";
                    break;
                default:
                    sql = $"BACKUP DATABASE [{database}] TO DISK = @Path WITH INIT";
                    break;
            }

            try
            {
                using (var cn = DbHelper.GetNewOpenConnection(_job))
                {
                    var cmd = new SqlCommand(sql, cn) { CommandTimeout = 0 };
                    cmd.Parameters.AddWithValue("@Path", Path.Combine(path, file));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }

            return true;
        }

        void CleanupLocalFolder(DestinationData dst)
        {
            if (dst.DeleteAfterMonths == 0 && dst.DeleteAfterDays == 0) return;

            LogHelper.WriteLine(string.Format(ConstStrings.Cleaning, DateTime.Now, dst.Path));
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, dst.Path));

            try
            {
                CleanupLocalFolderRecursively(dst.Path, "", dst.DeleteAfterMonths, dst.DeleteAfterDays);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, dst.Path));
            }
        }

        void CleanupLocalFolderRecursively(string root, string folder, int deleteAfterMonths, int deleteAfterDays)
        {
            var path = Path.Combine(root, folder);
            var files = Directory.GetFiles(path, "*.zip", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var dateTime = fileInfo.CreationTimeUtc.AddMonths(deleteAfterMonths).AddDays(deleteAfterDays);
                if (dateTime >= _utcNow) continue;

                LogHelper.WriteLine(string.Format(ConstStrings.RemovingFrom, DateTime.Now, fileInfo.Name, folder));
                fileInfo.Delete();
            }
            var directories = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            foreach (var directory in directories)
            {
                var temp = (folder + "\\" + Path.GetFileName(directory)).TrimStart('\\');
                CleanupLocalFolderRecursively(root, temp, deleteAfterMonths, deleteAfterDays);
            }
        }

        void CleanupFtpServer(DestinationData dst)
        {
            if (dst.DeleteAfterMonths == 0 && dst.DeleteAfterDays == 0) return;

            LogHelper.WriteLine(string.Format(ConstStrings.Cleaning, DateTime.Now, dst.Path));
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, dst.Path));

            // Setup session options
            var sessionOptions = new SessionOptions
                {
                    Protocol = dst.Protocol == 0 ? Protocol.Ftp : Protocol.Sftp,
                    HostName = dst.Path,
                    PortNumber = dst.Port,
                    UserName = dst.UserName,
                    Password = dst.Password,
                    GiveUpSecurityAndAcceptAnySshHostKey = true,
                    //SshHostKeyFingerprint = "ssh-rsa 1024 da:7d:21:d0:28:b6:ad:d8:76:35:58:d0:05:9b:b8:ce"
                };

            try
            {
                using (var session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    CleanupFtpServerRecursively(session, dst.RemoteFolder, "", dst.DeleteAfterMonths, dst.DeleteAfterDays);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, dst.Path));
            }
        }

        void CleanupFtpServerRecursively(Session session, string root, string folder, int deleteAfterMonths, int deleteAfterDays)
        {
            var path = Path.Combine(root, folder);

            var directories = new List<string>();
            var listDirectory = session.ListDirectory(path);
            foreach (RemoteFileInfo file in listDirectory.Files)
            {
                if (file.IsDirectory)
                {
                    if (file.Name != "." && file.Name != "..")
                    {
                        directories.Add(file.Name);
                    }
                    continue;
                }
                var temp1 = Path.GetExtension(file.Name);
                if (!string.Equals(temp1, ".zip", StringComparison.OrdinalIgnoreCase)) continue;

                var dateTime = file.LastWriteTime.AddMonths(deleteAfterMonths).AddDays(deleteAfterDays);
                if (dateTime >= _now) continue; // время всегда локальное

                LogHelper.WriteLine(string.Format(ConstStrings.RemovingFrom, DateTime.Now, file.Name, folder));
                var temp2 = Path.Combine(path, file.Name);
                var removeResult = session.RemoveFiles(temp2);

                // Throw on any error
                removeResult.Check();
            }

            foreach (var directory in directories)
            {
                var temp = (folder + "\\" + directory).TrimStart('\\');
                CleanupFtpServerRecursively(session, root, temp, deleteAfterMonths, deleteAfterDays);
            }
        }
    }

}
