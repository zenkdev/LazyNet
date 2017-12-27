using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Deployment.Application;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        void AppStartingUp(object sender, StartupEventArgs e)
        {
            var runJob = false;
            var args = e.Args;
            string jobName = null;
            string type = null;

            LogHelper.WriteLine($">> start application {DateTime.Now:G}");

            if (AppDomain.CurrentDomain?.SetupInformation?.ActivationArguments?.ActivationData != null)
            {
                args = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
            }

            if (args.Length > 0)
            {
                if (args[0].ToLower() == "-runjob")
                {
                    if (args.Length > 1)
                    {
                        jobName = args[1];
                    }
                    if (args.Length > 2)
                    {
                        type = args[2];
                        runJob = true;
                    }
                }
                else
                {
                    jobName = args[0];
                }
            }

            jobName = WinHelper.NormalizePath(jobName);
            LogHelper.WriteLine($"JobName = {jobName}" + Environment.NewLine);

            if (runJob)
            {
                LogHelper.SaveToFile();
                var exitCode = new JobRunner().RunBySchedule(jobName, type);
                Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                Application.Current.Shutdown(exitCode);
            }
            else
            {
                SetAddRemoveProgramsIcon();

                UpdateWindowsScheduler();

                LogHelper.SaveToFile();

                //run form - time taking operation
                MainWindow mainWindow = new MainWindow(jobName);
                mainWindow.Show();
            }
        }

        void AppUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            LogHelper.WriteError(e.Exception);
            LogHelper.SaveToFile();
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
                    var executablePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                    var iconSourcePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(executablePath), "AppIcon.ico");
                    if (!System.IO.File.Exists(iconSourcePath))
                        return;

                    var myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    // ReSharper disable once PossibleNullReferenceException
                    var mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    foreach (var keyName in mySubKeyNames)
                    {
                        var myKey = myUninstallKey.OpenSubKey(keyName, true);
                        // ReSharper disable once PossibleNullReferenceException
                        var myValue = myKey.GetValue("DisplayName");
                        if (myValue != null && myValue.ToString() == "LazySQLBackup2Remote")
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

        static void UpdateWindowsScheduler()
        {
            try
            {
                var executablePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                using (var ts = new TaskService())
                {
                    var tasks = ts.FindAllTasks(new Wildcard(WinHelper.AppName + "*"), false);
                    foreach (var task in tasks)
                    {
                        var td = task.Definition;
                        var fileName = td.RegistrationInfo.Description;

                        var execAction = td.Actions.FirstOrDefault(a => a.ActionType == TaskActionType.Execute) as ExecAction;
                        if (execAction == null || execAction.Path == executablePath) continue;

                        LogHelper.WriteLine($"Updating task {task.Name}.");
                        LogHelper.WriteLine(string.Format(ConstStrings.JobName, fileName));

                        var data = new JobData();
                        data.Load(fileName);

                        LogHelper.WriteLine($"Updating path from '{execAction.Path}' to '{executablePath}'.");

                        execAction.Path = executablePath;
                        ts.RootFolder.RegisterTaskDefinition(task.Name, td, TaskCreation.CreateOrUpdate, data.ScheduleUserId, data.SchedulePassword, TaskLogonType.Password);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }

    }
}
