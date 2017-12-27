using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using WinSCP;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public static class FileHelper
    {
        public static bool CompressFile(string from, string src, string to, string dst)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.Compressing, DateTime.Now, src, to));

            var srcPath = Path.Combine(from, src);
            var dstPath = Path.Combine(to, dst);

            try
            {
                // 2. Zip database backup into archive
                using (var zipFile = new ZipFile())
                {
                    zipFile.AddFile(srcPath, @"\");
                    zipFile.UseZip64WhenSaving = Zip64Option.AsNecessary;
                    zipFile.Save(dstPath);
                }

                // 3. Delete database backup
                File.Delete(srcPath);

                var size = new FileInfo(dstPath).Length;
                LogHelper.WriteLine(string.Format(new FileSizeFormatProvider(), ConstStrings.CompressionCompleted, DateTime.Now, dst, size));

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }

        public static bool ExtractFile(string from, string src, string to, string dst, EventHandler<ExtractProgressEventArgs> onProgressChanged = null)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.Extracting, DateTime.Now, src, to));

            var srcPath = Path.Combine(from, src);
            var dstPath = Path.Combine(to, dst);

            try
            {
                // 2. Zip database backup into archive
                using (var zipFile = ZipFile.Read(srcPath))
                {
                    if (onProgressChanged != null)
                        zipFile.ExtractProgress += onProgressChanged;

                    var entity = zipFile.Entries.FirstOrDefault(x => x.FileName == dst);
                    if (entity == null)
                    {
                        LogHelper.WriteLine(string.Format(ConstStrings.ZipFileNotFound, DateTime.Now, dst));
                        return false;
                    }

                    var dstFileInfo = new FileInfo(dstPath);
                    if (dstFileInfo.Exists && entity.UncompressedSize == dstFileInfo.Length)
                    {
                        LogHelper.WriteLine(string.Format(ConstStrings.LocalFileVerified, DateTime.Now));
                    }
                    else
                    {
                        entity.Extract(to, ExtractExistingFileAction.OverwriteSilently);
                        LogHelper.WriteLine(string.Format(new FileSizeFormatProvider(), ConstStrings.ExtractionCompleted, DateTime.Now, dst, entity.UncompressedSize));
                    }

                    File.SetAttributes(dstPath, FileAttributes.ReadOnly);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }

        public static List<BackupFile> ListLocalFolder(DestinationData data)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, data.Path));

            var result = new List<BackupFile>();

            try
            {
                var dir = new DirectoryInfo(data.Path);
                if (!dir.Exists)
                {
                    LogHelper.WriteLine(string.Format(ConstStrings.RemoteFolderNotFound, DateTime.Now, data.Path));
                }
                else
                {
                    var directories = dir.GetDirectories();
                    foreach (var subdir in directories)
                    {
                        result.AddRange(subdir.GetFiles("*.zip").Select(file => new BackupFile { Name = $"{subdir.Name}\\{file.Name}", CreationTime = file.CreationTime }));
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, data.Path));
            }

            return result;
        }

        public static bool UploadToLocalFolder(string from, string src, DestinationData to, string toPath, EventHandler<ProgressChangedEventArgs> onProgressChanged = null)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, to.Path));

            try
            {
                var dst = src;
                if (!string.IsNullOrEmpty(toPath))
                {
                    var dstPath = Path.Combine(to.Path, toPath);
                    if (!Directory.Exists(dstPath))
                    {
                        LogHelper.WriteLine(string.Format(ConstStrings.CreatingRemoteFolder, DateTime.Now, toPath));
                        Directory.CreateDirectory(dstPath);
                    }
                    dst = Path.Combine(toPath, dst);
                }

                LogHelper.WriteLine(string.Format(ConstStrings.Uploading, DateTime.Now, src, to.Path, dst));

                var srcFileName = Path.Combine(from, src);
                var dstFileName = Path.Combine(to.Path, dst);
                XCopy.Copy(srcFileName, dstFileName, true, true, onProgressChanged);

                if (new FileInfo(srcFileName).Length != new FileInfo(dstFileName).Length)
                {
                    return false;
                }

                LogHelper.WriteLine(string.Format(ConstStrings.RemoteFileVerified, DateTime.Now));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, to.Path));
            }

            return true;
        }

        public static bool DownloadFromLocalFolder(DestinationData from, string fromPath, string to, string dst, EventHandler<ProgressChangedEventArgs> onProgressChanged = null)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, from.Path));

            try
            {
                var src = from.Path;
                if (!string.IsNullOrEmpty(fromPath))
                {
                    src = Path.Combine(from.Path, fromPath);
                }
                var srcFileInfo = new FileInfo(Path.Combine(src, dst));
                var dstFileInfo = new FileInfo(Path.Combine(to, dst));

                if (!srcFileInfo.Exists)
                {
                    LogHelper.WriteLine(string.Format(ConstStrings.RemoteFileNotFound, DateTime.Now, srcFileInfo.FullName));
                    return false;
                }

                LogHelper.WriteLine(string.Format(ConstStrings.Downloading, DateTime.Now, dst, to, src));
                if (dstFileInfo.Exists && srcFileInfo.Length == dstFileInfo.Length)
                {
                    LogHelper.WriteLine(string.Format(ConstStrings.LocalFileVerified, DateTime.Now));
                }
                else
                {
                    XCopy.Copy(srcFileInfo.FullName, dstFileInfo.FullName, true, true, onProgressChanged);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, from.Path));
            }
        }

        public static List<BackupFile> ListFtpServer(DestinationData data)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, data.Path));

            var result = new List<BackupFile>();

            // Setup session options
            var sessionOptions = new SessionOptions
            {
                Protocol = data.Protocol == 0 ? Protocol.Ftp : Protocol.Sftp,
                HostName = data.Path,
                PortNumber = data.Port,
                UserName = data.UserName,
                Password = data.Password,
                GiveUpSecurityAndAcceptAnySshHostKey = true,
                //SshHostKeyFingerprint = "ssh-rsa 1024 da:7d:21:d0:28:b6:ad:d8:76:35:58:d0:05:9b:b8:ce"
            };

            try
            {
                using (var session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    if (!session.FileExists(data.Path))
                    {
                        LogHelper.WriteLine(string.Format(ConstStrings.RemoteFolderNotFound, DateTime.Now, data.Path));
                    }
                    else
                    {
                        var directories = session.ListDirectory(data.Path);
                        result.AddRange(from subdir in directories.Files.Where(x => x.IsDirectory) let files = session.ListDirectory(data.Path + "//" + subdir.Name + "//*.zip") from FileInfo file in files.Files select new BackupFile { Name = $"{subdir.Name}\\{file.Name}", CreationTime = file.CreationTime });
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, data.Path));
            }

            return result;
        }

        public static bool UploadToFtpServer(string from, string src, DestinationData to, string toPath)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, to.Path));

            // Setup session options
            var sessionOptions = new SessionOptions
            {
                Protocol = to.Protocol == 0 ? Protocol.Ftp : Protocol.Sftp,
                HostName = to.Path,
                PortNumber = to.Port,
                UserName = to.UserName,
                Password = to.Password,
                GiveUpSecurityAndAcceptAnySshHostKey = true,
                //SshHostKeyFingerprint = "ssh-rsa 1024 da:7d:21:d0:28:b6:ad:d8:76:35:58:d0:05:9b:b8:ce"
            };

            try
            {
                using (var session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    var dst = to.RemoteFolder + src;
                    if (!string.IsNullOrEmpty(toPath))
                    {
                        var dstPath = to.RemoteFolder + toPath + "/";
                        if (!session.FileExists(dstPath))
                        {
                            LogHelper.WriteLine(string.Format(ConstStrings.CreatingRemoteFolder, DateTime.Now, toPath));
                            session.CreateDirectory(dstPath);
                        }
                        dst = dstPath + src;
                    }

                    LogHelper.WriteLine(string.Format(ConstStrings.Uploading, DateTime.Now, src, to.Path, dst));

                    // Upload files
                    var transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                    var transferResult = session.PutFiles(Path.Combine(from, src), dst, false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    var locFileInfo = new FileInfo(Path.Combine(from, src));
                    var remFileInfo = session.GetFileInfo(dst);

                    if (locFileInfo.Length != remFileInfo.Length)
                    {
                        return false;
                    }
                    LogHelper.WriteLine(string.Format(ConstStrings.RemoteFileVerified, DateTime.Now));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, to.Path));
            }

            return true;
        }

        public static bool DownloadFromFtpServer(DestinationData from, string fromPath, string to, string dst)
        {
            LogHelper.WriteLine(string.Format(ConstStrings.ConnectingTo, DateTime.Now, from.Path));

            // Setup session options
            var sessionOptions = new SessionOptions
            {
                Protocol = from.Protocol == 0 ? Protocol.Ftp : Protocol.Sftp,
                HostName = from.Path,
                PortNumber = from.Port,
                UserName = from.UserName,
                Password = from.Password,
                GiveUpSecurityAndAcceptAnySshHostKey = true,
                //SshHostKeyFingerprint = "ssh-rsa 1024 da:7d:21:d0:28:b6:ad:d8:76:35:58:d0:05:9b:b8:ce"
            };

            try
            {
                using (var session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    var src = from.RemoteFolder;
                    if (!string.IsNullOrEmpty(fromPath))
                    {
                        src = from.RemoteFolder + fromPath + "/";
                    }
                    src += dst;

                    if (!session.FileExists(src))
                    {
                        LogHelper.WriteLine(string.Format(ConstStrings.RemoteFileNotFound, DateTime.Now, src));
                        return false;
                    }

                    LogHelper.WriteLine(string.Format(ConstStrings.Downloading, DateTime.Now, src, to, dst));

                    var srcFileInfo = session.GetFileInfo(src);
                    var dstFileInfo = new FileInfo(Path.Combine(to, dst));
                    if (dstFileInfo.Exists && srcFileInfo.Length == dstFileInfo.Length)
                    {
                        LogHelper.WriteLine(string.Format(ConstStrings.LocalFileVerified, DateTime.Now));
                    }
                    else
                    {
                        // Download files
                        var transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };
                        var transferResult = session.GetFiles(src, to, false, transferOptions);
                        // Throw on any error
                        transferResult.Check();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
            finally
            {
                LogHelper.WriteLine(string.Format(ConstStrings.DisconnectingFrom, DateTime.Now, from.Path));
            }
        }

        public class BackupFile
        {
            public string Name { get; set; }
            public DateTime CreationTime { get; set; }
        }

    }

}
