using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.XtraEditors;
using Microsoft.Win32.TaskScheduler;

namespace Dekart.LazyNet.Win.UserControls
{
    [ToolboxItem(true)]
    public partial class SchedulerControl : RibbonApplicationUserControl
    {
        public SchedulerControl()
        {
            InitializeComponent();
        }

        public void RefreshState()
        {
            bool found = false;
            string lastRun = "";
            try
            {
                using (var ts = new TaskService())
                {
                    var tasks = ts.FindAllTasks(new Wildcard(WinHelper.AppName + "*"), false);
                    foreach (var task in tasks)
                    {
                        var td = task.Definition;

                        var execAction = td.Actions.FirstOrDefault(a => a.ActionType == TaskActionType.Execute) as ExecAction;
                        if (execAction != null && execAction.Path == Application.ExecutablePath)
                        {
                            found = true;
                            lastRun = task.LastRunTime.ToString("G");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lcTaskStatus.Text = found ? $"<color=blue>Задание зарегистрировано</color><br><size=-2>Время прошлого запуска: {lastRun}" : "<color=red>Задание не зарегистрировано";
        }

        private void sbOpenLog_Click(object sender, EventArgs e)
        {
            try
            {
                var path = WinHelper.GetDataDirectory() + "\\" + WinHelper.AppName + "_log.txt";
                ObjectHelper.StartProcess(path);
            }
            catch
            {
                // ignored
            }
        }

        private void sbCreateTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WinHelper.ScheduleUserId) || string.IsNullOrWhiteSpace(WinHelper.SchedulePassword))
            {
                using (var form = new TaskSchedulerAccountForm())
                {
                    if (form.ShowDialog(this) != DialogResult.OK) return;
                    WinHelper.ScheduleUserId = form.Username;
                    WinHelper.SchedulePassword = form.Password;
                }
            }
            else
            {
                try
                {
                    string domain, username;
                    var split = WinHelper.ScheduleUserId.Split('\\');
                    if (split.Length > 1)
                    {
                        domain = split[0];
                        username = split[1];
                    }
                    else
                    {
                        domain = null;
                        username = split[0];
                    }
                    WinHelper.LogonUser(username, domain, WinHelper.SchedulePassword);
                }
                catch
                {
                    using (var form = new TaskSchedulerAccountForm())
                    {
                        if (form.ShowDialog(this) != DialogResult.OK) return;
                        WinHelper.ScheduleUserId = form.Username;
                        WinHelper.SchedulePassword = form.Password;
                    }
                }
            }

            try
            {
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    var taskName = WinHelper.AppName;

                    var identity = WindowsIdentity.GetCurrent();
                    var author = identity != null ? identity.Name : "";

                    // Create a new task definition and assign properties
                    var td = ts.NewTask();
                    td.RegistrationInfo.Author = author;

                    var trigger = new DailyTrigger();
                    trigger.SetRepetition(new TimeSpan(1, 0, 0), new TimeSpan(12, 0, 0));
                    trigger.StartBoundary = DateTime.Today.AddHours(9);
                    td.Triggers.Add(trigger);

                    // Create an action that will launch Notepad whenever the trigger fires
                    td.Actions.Add(new ExecAction(Application.ExecutablePath, "-runjob"));

                    LogHelper.WriteLine($"{DateTime.Now:G} Creating task {WinHelper.AppName}.", true);

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition(taskName, td, TaskCreation.CreateOrUpdate, WinHelper.ScheduleUserId, WinHelper.SchedulePassword, TaskLogonType.Password);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RefreshState();
            }
        }

        private void sbDeleteJob_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    LogHelper.WriteLine($"{DateTime.Now:G} Deleting task {WinHelper.AppName}.", true);
                    // Remove the task
                    ts.RootFolder.DeleteTask(WinHelper.AppName, false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RefreshState();
            }
        }
    }
}
