using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class RunJobForm : XtraForm
    {
        readonly Form _parent;
        readonly JobData _job;

        public RunJobForm(Form parent, JobData job)
        {
            InitializeComponent();
            _parent = parent;
            _job = job;
        }

        /// <summary>OnLoad override</summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_parent != null)
            {
                Location = new Point(_parent.Left + (_parent.Width - Width)/2, _parent.Top + (_parent.Height - Height)/2);
            }
            bwRunJob.RunWorkerAsync();
        }

        /// <summary>OnClosing override</summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = bwRunJob.IsBusy;
        }


        void BwRunJobDoWork(object sender, DoWorkEventArgs e)
        {
            LogHelper.TextChanged += LogHelperTextChanged;
            new JobRunner().Run(_job, BackupType.Full);
        }

        void LogHelperTextChanged(string text)
        {
            if (tbOutput.InvokeRequired)
            {
                tbOutput.Invoke(new TextChangedEventHandler(LogHelperTextChanged), text);
            }
            else
            {
                tbOutput.AppendText(text + Environment.NewLine);
            }
        }

        void BwRunJobRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LogHelper.TextChanged -= LogHelperTextChanged;
            sbStop.Enabled = false;
            progressPanel1.Visible = false;
            sbClose.Enabled = true;
        }
    }
}
