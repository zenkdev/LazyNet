using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Design;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Dekart.LazyNet.Win
{
    public partial class ReportViewForm : RibbonForm, IFormWithLayoutManager
    {
        DialogResult _returnResult = DialogResult.Cancel;
        XtraReport _fReport;
        string _fileName = string.Empty;
        readonly Form _parent;

        public ReportViewForm(Form parent)
        {
            InitializeComponent();

            _parent = parent;
            Icon = ImagesHelper.AppIcon;
            bbiDesigner.ItemClick += (s1, e1) => { EditReport(); };
        }

        public XtraReport Report
        {
            get { return _fReport; }
            set
            {
                if (_fReport == value) return;

                if (_fReport != null)
                {
                    printControl.DocumentSource = null;
                    _fReport.Dispose();
                }
                _fReport = value;
                if (_fReport == null)
                    return;
                _fileName = GetReportPath(_fReport, "repx");
                printControl.DocumentSource = _fReport;
                printControl.PrintingSystem.AddCommandHandler(new OpenSaveCommandHandler(this, _fReport.DataSource));
                //printControl.PrintingSystem = _fReport.PrintingSystem;
                //_fReport.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
                //_fReport.PrintingSystem.AddCommandHandler(new OpenSaveCommandHandler(this, _fReport.DataSource));
                Invalidate();
                Update();
            }
        }
        public virtual FormLayoutManager LayoutManager
        {
            get
            {
                var frm = _parent as IFormWithLayoutManager;
                if (frm != null)
                    return frm.LayoutManager;
                return null;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
                if (LayoutManager != null)
                    LayoutManager.RestoreFormLayout(new FormLayoutInfo(this, null, ribbon.Toolbar));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseForm();
            e.Cancel = _returnResult != DialogResult.OK;
        }

        void CloseForm()
        {
            _returnResult = DialogResult.OK;
            if (LayoutManager != null)
                LayoutManager.SaveFormLayout(new FormLayoutInfo(this, null, ribbon.Toolbar));
            Cursor.Current = Cursors.Default;
            Dispose();
        }
        void EditReport()
        {
            var saveFileName = GetReportPath(_fReport, "sav");
            _fReport.PrintingSystem.ExecCommand(PrintingSystemCommand.StopPageBuilding);
            _fReport.SaveLayout(saveFileName);
            using (var newReport = XtraReport.FromFile(saveFileName, true))
            {
                var designForm = new ReportDesignerForm();
                designForm.OpenReport(newReport);
                designForm.ActiveXRDesignPanel.FileName = _fileName;
                ShowDesignerForm(designForm, this);
                if (designForm.ActiveXRDesignPanel != null && designForm.ActiveXRDesignPanel.FileName != _fileName && File.Exists(designForm.ActiveXRDesignPanel.FileName))
                    File.Copy(designForm.ActiveXRDesignPanel.FileName, _fileName, true);
                designForm.Dispose();
            }
            if (File.Exists(_fileName))
            {
                var dataSource = _fReport.DataSource;
                _fReport.LoadLayout(_fileName);
                try
                {
                    _fReport.DataSource = dataSource;
                    _fReport.CreateDocument(true);
                }
                catch (Exception ex)
                {
                    Form form = FindForm();
                    if (form != null)
                        XtraMessageBox.Show(LookAndFeel.ParentLookAndFeel, form, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _fReport.LoadLayout(saveFileName);
                    _fReport.CreateDocument(true);
                }
                finally
                {
                    File.Delete(_fileName);
                }
            }
            File.Delete(saveFileName);
            //InitializeControls();
        }
        void ShowDesignerForm(Form designForm, Form parentForm)
        {
            designForm.MinimumSize = parentForm.MinimumSize;
            if (parentForm.WindowState == FormWindowState.Normal)
            {
                designForm.StartPosition = FormStartPosition.Manual;
                designForm.Bounds = parentForm.Bounds;
            }
            designForm.WindowState = parentForm.WindowState;
            parentForm.Visible = false;

            designForm.ShowDialog(parentForm);
            
            parentForm.Visible = true;
            parentForm.MinimumSize = designForm.MinimumSize;
            if (designForm.WindowState == FormWindowState.Normal)
            {
                parentForm.StartPosition = FormStartPosition.Manual;
                parentForm.Bounds = designForm.Bounds;
            }
            parentForm.WindowState = designForm.WindowState;
        }
        static string GetReportPath(XtraReport fReport, string ext)
        {
            var asm = Assembly.GetExecutingAssembly();
            var repName = fReport.Name;
            if (repName.Length == 0)
                repName = fReport.GetType().Name;
            var dirName = Path.GetDirectoryName(asm.Location);
            // ReSharper disable once AssignNullToNotNullAttribute
            return Path.Combine(dirName, repName + "." + ext);
        }
    }

    class OpenSaveCommandHandler : ICommandHandler
    {
        readonly ReportViewForm _form;
        readonly object _dataSource;
        public OpenSaveCommandHandler(ReportViewForm form, object dataSource)
        {
            _form = form;
            _dataSource = dataSource;
        }

        public virtual void HandleCommand(PrintingSystemCommand command, object[] args, IPrintControl control, ref bool handled)
        {
            if (!CanHandleCommand(command, control)) return;

            handled = true;

            if (command == PrintingSystemCommand.Open)
            {
                var ofd = new OpenFileDialog
                {
                    DefaultExt = "repx",
                    CheckFileExists = true,
                    SupportMultiDottedExtensions = true,
                    Filter = ConstStrings.ReportFilter
                };
                if (ofd.ShowDialog(_form) != DialogResult.OK) return;
                var newReport = XtraReport.FromFile(ofd.FileName, true);
                newReport.DataSource = _dataSource;
                newReport.CreateDocument(true);
                _form.Report = newReport;
            }
            else if (command == PrintingSystemCommand.Save)
            {
                var sfd = new SaveFileDialog
                {
                    DefaultExt = "repx",
                    SupportMultiDottedExtensions = true,
                    Filter = ConstStrings.ReportFilter,
                    FileName = control.PrintingSystem.Document.Name
                };
                if (sfd.ShowDialog(_form) == DialogResult.OK)
                {
                    _form.Report.SaveLayout(sfd.FileName);
                }
            }
        }

        public virtual bool CanHandleCommand(PrintingSystemCommand command, IPrintControl control)
        {
            return command == PrintingSystemCommand.Open || command == PrintingSystemCommand.Save;
        }
    }
}