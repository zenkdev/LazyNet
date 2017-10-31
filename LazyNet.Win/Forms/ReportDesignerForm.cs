using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;

namespace Dekart.LazyNet.Win
{
    public partial class ReportDesignerForm : RibbonForm
    {
        bool _showCloseDialog = true;
        DialogResult _returnResult = DialogResult.Cancel;
        public ReportDesignerForm()
        {
            InitializeComponent();

            Icon = ImagesHelper.AppIcon;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            workspaceManager.LoadWorkspace("Default", GetWorkspacePath("default.wrk"));
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_showCloseDialog)
            {
                _showCloseDialog = e.CloseReason != CloseReason.ApplicationExitCall &&
                                   e.CloseReason != CloseReason.TaskManagerClosing &&
                                   e.CloseReason != CloseReason.WindowsShutDown;
            }
            CloseForm();
            e.Cancel = _returnResult != DialogResult.OK;
        }
        void CloseForm()
        {
            if (_showCloseDialog)
            {
                var result = ActiveXRDesignPanel.SaveChangedReport();
                if (result == DialogResult.Cancel) return;
            }
            _returnResult = DialogResult.OK;
            workspaceManager.SaveWorkspace("Default", GetWorkspacePath("default.wrk"));
            Cursor.Current = Cursors.Default;
            Dispose();
        }

        public void OpenReport(XtraReport newReport)
        {
            reportDesigner.OpenReport(newReport);
        }
        public void CreateNewReport()
        {
            reportDesigner.CreateNewReport();
        }
        public XRDesignPanel ActiveXRDesignPanel
        {
            get { return reportDesigner.ActiveDesignPanel; }
        }

        static string GetWorkspacePath(string fileName)
        {
            var asm = Assembly.GetExecutingAssembly();
            var dirName = Path.GetDirectoryName(asm.Location);
            // ReSharper disable once AssignNullToNotNullAttribute
            return Path.Combine(dirName, fileName);
        }
    }
}
