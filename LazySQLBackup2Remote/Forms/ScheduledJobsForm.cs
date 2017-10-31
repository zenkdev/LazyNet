using System;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.XtraEditors;
using Microsoft.Win32.TaskScheduler;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class ScheduledJobsForm : XtraForm
    {
        public ScheduledJobsForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitData();
        }

        void InitData()
        {
            try
            {
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    var tasks = ts.FindAllTasks(new Wildcard(WinHelper.AppName + "*"), false);
                    gcJobs.DataSource = tasks;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Task CurrentTask => gvJobs.GetRow(gvJobs.FocusedRowHandle) as Task;

        void SbDeleteClick(object sender, EventArgs e)
        {
            if (CurrentTask == null) return;

            if (XtraMessageBox.Show(this, string.Format(ConstStrings.DeleteScheduledJob, CurrentTask.Name), ConstStrings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    ts.RootFolder.DeleteTask(CurrentTask.Name);
                    InitData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SbCloseClick(object sender, EventArgs e)
        {
            Close();
        }

    }
}
