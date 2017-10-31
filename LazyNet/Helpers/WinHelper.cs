using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Microsoft.Win32;

namespace Dekart.LazyNet.Helpers
{
    public static class WinHelper
    {
        static string _appName;
        private static RegistryKey _userAppDataRegistry;

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

        public static RegistryKey UserAppDataRegistry
        {
            get
            {
                if (_userAppDataRegistry == null)
                {
                    var subkey = $"software\\{AssemblyVersion.AssemblyCompany}\\{AssemblyVersion.AssemblyProduct}";
                    _userAppDataRegistry = Registry.CurrentUser.CreateSubKey(subkey);
                }
                Debug.Assert(_userAppDataRegistry != null, "UserAppDataRegistry != null");
                return _userAppDataRegistry;
            }
        }
        public static string ScheduleUserId
        {
            get { return (string) UserAppDataRegistry.GetValue("ScheduleUserId", string.Empty); }
            set { UserAppDataRegistry.SetValue("ScheduleUserId", value); }
        }

        public static string SchedulePassword
        {
            get { return CryptoHelper.Decrypt((string)UserAppDataRegistry.GetValue("SchedulePassword", string.Empty)); }
            set { UserAppDataRegistry.SetValue("SchedulePassword", CryptoHelper.Encrypt(value)); }
        }

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

        public static void LogException(Exception ex)
        {
            LogException("general error", ex);
        }

        public static void LogException(string errorMsg, Exception ex)
        {
            if (ConfigurationManager.AppSettings["LogErrors"] == "false") return;

            var builder = new StringBuilder();
            builder.Append("\n\n");
            builder.Append("Error in " + AppName + ": ");
            builder.Append(errorMsg);
            builder.Append("\n\n");
            builder.Append(ex);
            try
            {
                EventLog.WriteEntry(AppName, builder.ToString(), EventLogEntryType.Error);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>Sets from client size</summary>
        public static void SetFormClientSize(Rectangle workingArea, Form form, int width, int height)
        {
            form.ClientSize = new Size(Math.Min(workingArea.Width - 20, width), Math.Min(workingArea.Height - 20, height));
            form.Location = new Point(workingArea.X + (workingArea.Width - form.Width) / 2, workingArea.Y + (workingArea.Height - form.Height) / 2);
        }

        public static void InitializePropertyDefaultValues(this object obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                AttributeCollection attributes = TypeDescriptor.GetProperties(obj)[prop.Name].Attributes;
                DefaultValueAttribute dAttribute = (DefaultValueAttribute)attributes[typeof(DefaultValueAttribute)];
                if (dAttribute != null)
                    prop.SetValue(obj, dAttribute.Value, null);
            }
        }

        [SecuritySafeCritical]
        public static IDisposable SingleInstanceApplicationGuard(string applicationName, out bool exit)
        {
            Mutex mutex = new Mutex(true, applicationName);
            if (mutex.WaitOne(0, false))
            {
                exit = false;
            }
            else
            {
                var currentProcess = Process.GetCurrentProcess();
                var currentProcessName = StringsHelper.RemoveFromEndIfNeeded(currentProcess.ProcessName, ".vshost");
                foreach (Process process in Process.GetProcessesByName(currentProcessName))
                {
                    if (process.Id != currentProcess.Id && process.MainWindowHandle != IntPtr.Zero)
                    {
                        var hwnd = process.MainWindowHandle;
                        if (IsTeamViewerRunning(process) && !IsMinimized(hwnd))
                        {
                            hwnd = Import.GetWindow(hwnd, Import.GW_HWNDNEXT);
                        }
                        Import.SetForegroundWindow(hwnd);
                        Import.ShowWindowAsync(hwnd, IsMaxmimized(hwnd) ? Import.SW_SHOWMAXIMIZED : Import.SW_RESTORE);
                        break;
                    }
                }
                exit = true;
            }
            return mutex;
        }

        public static IntPtr LogonUser(string username, string domain, string password)
        {
            var token = IntPtr.Zero;
            if (!Import.LogonUser(username, domain, password, Import.LOGON32_LOGON_INTERACTIVE, Import.LOGON32_PROVIDER_DEFAULT, ref token))
            {
                throw new Exception($"WinApi exception. Error code:{Import.GetLastError()}.");
            }

            return token;
        }

        static bool IsTeamViewerRunning(Process process)
        {
            return string.IsNullOrEmpty(process.MainWindowTitle) && Process.GetProcessesByName("teamviewer").Any();
        }

        [SecuritySafeCritical]
        private static bool IsMaxmimized(IntPtr hwnd)
        {
            Import.WINDOWPLACEMENT lpwndpl = new Import.WINDOWPLACEMENT();
            lpwndpl.length = Marshal.SizeOf(lpwndpl);
            if (!Import.GetWindowPlacement(hwnd, ref lpwndpl))
                return false;
            return lpwndpl.showCmd == Import.SW_SHOWMAXIMIZED;
        }

        [SecuritySafeCritical]
        private static bool IsMinimized(IntPtr hwnd)
        {
            Import.WINDOWPLACEMENT lpwndpl = new Import.WINDOWPLACEMENT();
            lpwndpl.length = Marshal.SizeOf(lpwndpl);
            if (!Import.GetWindowPlacement(hwnd, ref lpwndpl))
                return false;
            return lpwndpl.showCmd == Import.SW_SHOWMINIMIZED;
        }

        private static class Import
        {
            [DllImport("User32.dll", SetLastError = true)]
            // ReSharper disable once UnusedMember.Local
            public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern bool ShowWindowAsync(IntPtr hWnd, uint nCmdShow);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

            // obtains user token
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern int GetLastError();

            // ReSharper disable InconsistentNaming
            public const int LOGON32_PROVIDER_DEFAULT = 0;
            public const int LOGON32_LOGON_INTERACTIVE = 2;

            //public const uint GW_HWNDFIRST = 0;
            //public const uint GW_HWNDLAST = 1;
            public const uint GW_HWNDNEXT = 2;
            //public const uint GW_HWNDPREV = 3;
            //public const uint GW_OWNER = 4;
            //public const uint GW_CHILD = 5;
            //public const uint GW_ENABLEDPOPUP = 6;

            //public const uint SW_HIDE = 0;
            //public const uint SW_SHOWNORMAL = 1;
            public const uint SW_SHOWMINIMIZED = 2;
            public const uint SW_SHOWMAXIMIZED = 3;
            //public const uint SW_SHOWNOACTIVATE = 4;
            //public const uint SW_SHOW = 5;
            //public const uint SW_MINIMIZE = 6;
            //public const uint SW_SHOWMINNOACTIVE = 7;
            //public const uint SW_SHOWNA = 8;
            public const uint SW_RESTORE = 9;
            //public const uint SW_SHOWDEFAULT = 10;
            //public const uint SW_FORCEMINIMIZE = 11;
            // ReSharper restore InconsistentNaming

            [SuppressMessage("ReSharper", "InconsistentNaming")]
            [SuppressMessage("ReSharper", "NotAccessedField.Local")]
            public struct WINDOWPLACEMENT
            {
#pragma warning disable 169
#pragma warning disable 649
                public int length;
                public int flags;
                public uint showCmd;
                public Point ptMinPosition;
                public Point ptMaxPosition;
                public Rectangle rcNormalPosition;
#pragma warning restore 649
#pragma warning restore 169
            }
        }

        public static void CloseCustomizationForm(Control control)
        {
            if (control == null) return;
            CloseElements(control);
        }

        private static void CloseElements(Control control)
        {
            foreach (Control ctrl in control.Controls)
                CloseElements(ctrl);
            BaseView view = GetBaseViewByControl(control);
            if (view != null)
            {
                foreach (BaseView bView in view.GridControl.Views)
                {
                    var gridView = bView as GridView;
                    gridView?.DestroyCustomization();
                }
            }
            LayoutControl layout = GetLayoutControlByControl(control);
            layout?.HideCustomizationForm();
        }

        private static BaseView GetBaseViewByControl(Control control)
        {
            return control?.Controls.OfType<GridControl>().Select(cntl => cntl.MainView).FirstOrDefault();
        }

        private static LayoutControl GetLayoutControlByControl(Control control)
        {
            return control?.Controls.OfType<LayoutControl>().FirstOrDefault();
        }
    }

}
