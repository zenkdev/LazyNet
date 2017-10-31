using System;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.XtraSplashScreen;
using Microsoft.Win32.TaskScheduler;

namespace Dekart.LazyNet.SQLBackup2Remote
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var runJob = false;
            var @params = args;
            string jobName = null;
            string type = null;

            LogHelper.WriteLine($">> start application {DateTime.Now:G}");

            try
            {
                if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null)
                    @params = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
            }
            catch
            {
                // ignored
            }

            if (@params.Length > 0)
            {
                if (@params[0].ToLower() == "-runjob")
                {
                    runJob = true;
                    if (@params.Length > 1)
                    {
                        jobName = @params[1];
                    }
                    if (@params.Length > 2)
                    {
                        type = @params[2];
                    }
                }
                else
                {
                    jobName = @params[0];
                }
            }

            jobName = WinHelper.NormalizePath(jobName);
            LogHelper.WriteLine($"JobName = {jobName}" + Environment.NewLine);

            if (runJob)
            {
                LogHelper.SaveToFile();
                Environment.ExitCode = new JobRunner().RunBySchedule(jobName, type);
            }
            else
            {
                DevExpress.UserSkins.BonusSkins.Register();
                DevExpress.Skins.SkinManager.EnableFormSkins();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SplashScreenManager.ShowForm((Form)null, typeof(DxSplashScreen), true, true);

                UpdateWindowsScheduler();

                LogHelper.SaveToFile();

                Application.Run(new AppMainForm(jobName));
            }
        }

        static void UpdateWindowsScheduler()
        {
            try
            {
                using (var ts = new TaskService())
                {
                    var tasks = ts.FindAllTasks(new Wildcard(WinHelper.AppName + "*"), false);
                    foreach (var task in tasks)
                    {
                        var td = task.Definition;
                        var fileName = td.RegistrationInfo.Description;

                        var execAction = td.Actions.FirstOrDefault(a => a.ActionType == TaskActionType.Execute) as ExecAction;
                        if (execAction == null || execAction.Path == Application.ExecutablePath) continue;

                        LogHelper.WriteLine($"Updating task {task.Name}.");
                        LogHelper.WriteLine(string.Format(ConstStrings.JobName, fileName));

                        var data = new JobData();
                        data.Load(fileName);

                        LogHelper.WriteLine($"Updating path from '{execAction.Path}' to '{Application.ExecutablePath}'.");

                        execAction.Path = Application.ExecutablePath;
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
