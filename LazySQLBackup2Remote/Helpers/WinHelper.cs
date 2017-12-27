using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public static class WinHelper
    {
        static string _appName;

        // app name
        public static string AppName
        {
            get
            {
                if (_appName == null)
                {
                    var codeBase = Assembly.GetEntryAssembly().CodeBase;
                    _appName = Path.GetFileNameWithoutExtension(codeBase);
                }
                return _appName;
            }
        }

        // ReSharper disable InconsistentNaming
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        // ReSharper restore InconsistentNaming

        // obtains user token
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        // closes open handes returned by LogonUser
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        // returns data directory for application
        public static string GetDataDirectory()
        {
            var dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppName);
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            return dataDirectory;
        }

        // returns temp directory for application
        public static string GetTempDirectory()
        {
            var tempDirectory = Path.Combine(Path.GetTempPath(), AppName);
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            return tempDirectory;
        }

        public static bool? ShowDialog(this Window window, Window owner)
        {
            window.Owner = owner;
            return window.ShowDialog();
        }

        public static void LogException(Exception ex)
        {
            LogException("general error", ex);
        }

        public static void LogException(string errorMsg, Exception ex)
        {
            if (string.Equals(ConfigurationManager.AppSettings["LogErrors"], bool.FalseString, StringComparison.OrdinalIgnoreCase)) return;

            var builder = new StringBuilder();
            builder.Append("\n\n");
            builder.Append("Error in " + ConstStrings.ApplicationCaption + ": ");
            builder.Append(errorMsg);
            builder.Append("\n\n");
            builder.Append(ex);
            try
            {
                EventLog.WriteEntry("LazySQLBackup2Remote", builder.ToString(), EventLogEntryType.Error);
            }
            catch
            {
                // ignored
            }
        }

        public static string NormalizePath(string path)
        {
            if (path != null && path.StartsWith("file://", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    return new Uri(path).LocalPath;
                }
                catch
                {
                    // ignored
                }
            }

            return path;
        }

        public static void WriteLog(string content)
        {
            try
            {
                var path = GetDataDirectory() + "\\" + AppName + "_log.txt";
                string prev = null;
                if (File.Exists(path))
                {
                    prev = Environment.NewLine + Environment.NewLine + File.ReadAllText(path);
                }
                File.WriteAllText(path, content + prev);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }
    }

}
