using System;
using System.Configuration;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;

namespace Dekart.LazyNet.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            SetCulture(new CultureInfo("ru-RU"));

            LogHelper.WriteLine($">> start application {DateTime.Now:G}", true);

            string[] arguments;
            try
            {
                arguments = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
            }
            catch
            {
                arguments = args;
            }

            if (arguments != null && arguments.Length > 0)
            {
                if (arguments[0].ToLower() == "-runjob")
                {
                    LogHelper.SaveToFile();
                    Environment.ExitCode = JobRunner.RunBySchedule();
                    return Environment.ExitCode;
                }
            }

            bool exit;
            using (WinHelper.SingleInstanceApplicationGuard(AssemblyVersion.AssemblyProduct, out exit))
            {
                if (exit) return 0;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //специальные инструкции для DevEx
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 8);
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");

                Application.ThreadException += ApplicationThreadException;

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(null, typeof (SsMain), true, true, false, 1000);

                SetAddRemoveProgramsIcon();

                // make the DXDisplayName attribute load resources via a standard resource fallback process
                //DXDisplayNameAttribute.UseResourceManager = true;

                var connectionString = ConfigurationManager.ConnectionStrings["XpoDefault.ConnectionString"].ConnectionString;
                //connectionString = DbUtils.ChangeApplicationName(connectionString, AssemblyVersion.AssemblyProduct);
                // xpo default
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.SchemaAlreadyExists);

#pragma warning disable 618
                SimpleDataLayer.SuppressReentrancyAndThreadSafetyCheck = true;
#pragma warning restore 618

                var session = new Session(XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema));

                // update schema
                session.UpdateSchema();

                if (!InteractiveLogon(session))
                {
                    using (var form = new LoginForm(session))
                    {
                        if (form.ShowDialog() != DialogResult.OK)
                        {
                            return 0;
                        }
                    }
                }

                // update task
                UpdateWindowsScheduler();

                Application.Run(new MainForm());
            }
            return 0;
        }
        static void SetCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture ?? culture;
        }
        static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.Error(e.Exception.Message, e.Exception);
        }

        /// <summary>
        /// set the icon in add/remove programs for all GoldMail products (because this code is only in Akamai for now)
        /// </summary>
        static void SetAddRemoveProgramsIcon()
        {
            //only run if deployed 
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    var iconSourcePath = Path.Combine(Application.StartupPath, "AppIcon.ico");
                    if (!File.Exists(iconSourcePath))
                        return;

                    var myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    // ReSharper disable once PossibleNullReferenceException
                    var mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    foreach (var keyName in mySubKeyNames)
                    {
                        var myKey = myUninstallKey.OpenSubKey(keyName, true);
                        // ReSharper disable once PossibleNullReferenceException
                        var myValue = myKey.GetValue("DisplayName");
                        if (myValue != null && myValue.ToString() == AssemblyVersion.AssemblyProduct)
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        static bool InteractiveLogon(Session session)
        {
            if (string.IsNullOrEmpty(Environment.UserDomainName))
            {
                return false;
            }

            var userAccount = Environment.UserDomainName + @"\" + Environment.UserName;

            //проверяем пользователя в базе
            User user;
            try
            {
                user = session.FindObject<User>(CriteriaOperator.Parse("UserName=? And IsAdmin=?", userAccount, true));
                if (user == null)
                {
                    if (AdHelper.IsCurrentUserAdmin())
                    {
                        user = AdHelper.CreateWindowsUser(session, userAccount, true);
                    }
                    else
                    {
                        throw new Exception(string.Format(ConstStrings.UserNotFoundError, userAccount));
                    }
                }
                else if (user.UserState == UserStateEnum.Terminated)
                {
                    throw new Exception(string.Format(ConstStrings.UserTerminatedError, userAccount));
                }
            }
            catch (Exception exc)
            {
                Logger.Error(exc.Message, exc);
                //ошибка доступа, производим обычный вход
                return false;
            }

            //меняем секьюрити инфо
            DataHelper.CurrentUser = user;

            return true;
        }

        public static bool ExecuteClickOnce(string productName, string publisherName = "Декарт")
        {
            // We build a command line, using the companyName\applicationName
            var shortcutName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), publisherName, productName + ".appref-ms");

            try
            {
                if (File.Exists(shortcutName))
                {
                    Process process = new Process { StartInfo = new ProcessStartInfo { FileName = shortcutName } };
                    process.Start();
                }
                else
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = Path.Combine(Properties.Settings.Default.LazyNet_Win_publish_url, productName, "setup.exe"),
                        LoadUserProfile = true
                    };
                    Process.Start(startInfo);
                }
            }
            catch
            {
                return false;
            }

            return true; //exitCode;
        }

        static void UpdateWindowsScheduler()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var tasks = ts.FindAllTasks(new Wildcard(WinHelper.AppName), false);
                    foreach (var task in tasks)
                    {
                        var td = task.Definition;

                        var execAction = td.Actions.FirstOrDefault(a => a.ActionType == TaskActionType.Execute) as ExecAction;
                        if (execAction != null && execAction.Path != Application.ExecutablePath)
                        {
                            if (string.IsNullOrEmpty(WinHelper.ScheduleUserId))
                            {
                                LogHelper.WriteLine($"{DateTime.Now:G} Updating task {task.Name} failed. Invalid used id.", true);
                                continue;
                            }

                            if (string.IsNullOrEmpty(WinHelper.SchedulePassword))
                            {
                                LogHelper.WriteLine($"{DateTime.Now:G} Updating task {task.Name} failed. Invalid password.", true);
                                continue;
                            }

                            LogHelper.WriteLine($"{DateTime.Now:G} Updating task {task.Name} path from '{execAction.Path}' to '{Application.ExecutablePath}'.", true);

                            execAction.Path = Application.ExecutablePath;
                            ts.RootFolder.RegisterTaskDefinition(task.Name, td, TaskCreation.CreateOrUpdate, WinHelper.ScheduleUserId, WinHelper.SchedulePassword, TaskLogonType.Password);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex, true);
            }
        }
    }
}
