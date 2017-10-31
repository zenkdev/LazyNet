using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.Helpers
{
    public static class ObjectHelper
    {
        public static void OpenExportedFile(string fileName)
        {
            if (XtraMessageBox.Show(ConstStrings.ExportFileOpen, ConstStrings.Export, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var process = new Process();
                try
                {
                    process.StartInfo.FileName = fileName;
                    process.Start();
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch { }
                // ReSharper restore EmptyGeneralCatchClause
            }
        }
        public static void ShowExportErrorMessage()
        {
            XtraMessageBox.Show(ConstStrings.ExportError, ConstStrings.Export, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static string GetFileName(string extension, string filter, string fileName = "")
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = filter;
                dialog.FileName = fileName;
                dialog.DefaultExt = extension;
                if (dialog.ShowDialog() == DialogResult.OK)
                    return dialog.FileName;
            }
            return String.Empty;
        }
        public static void ShowWebSite(string url)
        {
            if (url == null) return;
            var processName = GetCorrectUrl(url);
            if (processName.Length == 0) return;
            StartProcess(processName);
        }
        public static string GetCorrectUrl(string url)
        {
            var ret = url.Replace(" ", String.Empty);
            if (ret.Length == 0) return String.Empty;
            const string protocol = "http://";
            const string protocol2 = "https://";
            if (ret.IndexOf(protocol, StringComparison.Ordinal) != 0 && ret.IndexOf(protocol2, StringComparison.Ordinal) != 0)
                ret = protocol + ret;
            return ret;
        }
        public static void StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool SafeDelete(IWin32Window owner, LazyNetBaseObject obj, bool commitSession)
        {
            var uow = (UnitOfWork)obj.Session;
            if (!obj.AllowDelete)
            {
                if (!obj.SafeDelete())
                {
                    XtraMessageBox.Show(owner, ConstStrings.ObjectCanNotBeDeleted, ConstStrings.Warning, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            else
            {
                obj.Delete();
            }
            if (commitSession)
            {
                var exc = SessionHelper.CommitSession(uow, new ExceptionProcesser(owner));
                return exc == null;
            }
            return true;
        }
        public static bool DeleteObject(IWin32Window owner, XPBaseObject obj, bool commitSession)
        {
            var uow = (UnitOfWork) obj.Session;
            obj.Delete();
            if (commitSession)
            {
                var exc = SessionHelper.CommitSession(uow, new ExceptionProcesser(owner));
                return exc == null;
            }
            return true;
        }
    }

}
