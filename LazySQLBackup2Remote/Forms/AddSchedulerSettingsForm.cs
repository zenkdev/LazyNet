using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Controls;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddSchedulerSettingsForm : AddFormBase
    {
        readonly Form _parentForm;

        public AddSchedulerSettingsForm(Form parent, JobData editObject, IDXMenuManager manager)
            : base(parent, editObject, manager)
        {
            InitializeComponent();

            _parentForm = parent;
        }

        protected override bool TestButtonVisible { get { return false; } }

        /// <summary>Job</summary>
        JobData Job { get { return EditObject as JobData; } }

        protected override void InitData()
        {
            teScheduleUserId.Text = Job.ScheduleUserId;
            gcFull.DataSource = Job.FullBackupSchedule;
            gcDiff.DataSource = Job.DiffBackupSchedule;
            gcTran.DataSource = Job.TranBackupSchedule;
        }

        protected override void SaveData()
        {
            var userId = teScheduleUserId.Text.Trim();
            if (Job.ScheduleUserId == userId) return;

            Job.ScheduleUserId = userId;
            Job.SchedulePassword = null;
            if (!Job.ScheduleThisJob) return;
            using (var form = new TaskSchedulerAccountForm())
            {
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    form.Username = userId;
                }

                if (form.ShowDialog(this) != DialogResult.OK) return;
                Job.ScheduleUserId = form.Username;
                Job.SchedulePassword = form.Password;
            }
        }

        void GridViewCustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == gcFullDetail || e.Column == gcDiffDetail || e.Column == gcTranDetail)
            {
                e.Value = e.Row.ToString();
            }
        }

        ScheduleData CurrentFullSchedule { get { return gvFull.GetRow(gvFull.FocusedRowHandle) as ScheduleData; } }

        void HlAddFullOpenLink(object sender, OpenLinkEventArgs e)
        {
            using (var form = new AddScheduleForm(_parentForm, null, lcMain.MenuManager))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;

                Job.FullBackupSchedule.Add(form.Schedule);
            }
        }

        void RbiFullDeleteButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentFullSchedule == null || gvFull.RowCount < 2) return;
            Job.FullBackupSchedule.Remove(CurrentFullSchedule);
        }

        void RbiFullEditButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentFullSchedule == null) return;

            using (var form = new AddScheduleForm(_parentForm, CurrentFullSchedule, lcMain.MenuManager))
                form.ShowDialog(this);
        }

        ScheduleData CurrentDiffSchedule { get { return gvDiff.GetRow(gvDiff.FocusedRowHandle) as ScheduleData; } }

        void HlAddDiffOpenLink(object sender, OpenLinkEventArgs e)
        {
            using (var form = new AddScheduleForm(_parentForm, null, lcMain.MenuManager))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;

                Job.DiffBackupSchedule.Add(form.Schedule);
            }
        }

        void RbiDiffDeleteButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentDiffSchedule == null) return;
            Job.DiffBackupSchedule.Remove(CurrentDiffSchedule);
        }

        void RbiDiffEditButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentDiffSchedule == null) return;

            using (var form = new AddScheduleForm(_parentForm, CurrentDiffSchedule, lcMain.MenuManager))
                form.ShowDialog(this);
        }

        ScheduleData CurrentTranSchedule { get { return gvTran.GetRow(gvTran.FocusedRowHandle) as ScheduleData; } }

        void HlAddTranOpenLink(object sender, OpenLinkEventArgs e)
        {
            using (var form = new AddScheduleForm(_parentForm, null, lcMain.MenuManager))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;

                Job.TranBackupSchedule.Add(form.Schedule);
            }
        }

        void RbiTranDeleteButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentTranSchedule == null) return;
            Job.TranBackupSchedule.Remove(CurrentTranSchedule);
        }

        void RbiTranEditButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (CurrentTranSchedule == null) return;

            using (var form = new AddScheduleForm(_parentForm, CurrentTranSchedule, lcMain.MenuManager))
                form.ShowDialog(this);
        }

        void SbSetAsCurrentUserClick(object sender, System.EventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent();
            if (identity != null)
            {
                teScheduleUserId.Text = identity.Name;
            }
        }
    }
}
