using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.Helpers
{
    public interface IExceptionProcesser
    {
        void Process(Exception exc);
    }

    public class ExceptionProcesser : IExceptionProcesser
    {
        readonly IWin32Window _owner;
        public ExceptionProcesser(IWin32Window owner)
        {
            _owner = owner;
        }

        /// <summary> Process the exception </summary>
        public void Process(Exception exc)
        {
            //todo:
            //if (exc is DevExpress.Xpo.DB.Exceptions.LockingException)
            //{
            //    XtraMessageBox.Show(_owner, ErrorStrings.LockingExceptionError, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else if (exc is ObjectDisposedException)
            //{
            //    XtraMessageBox.Show(_owner, exc.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else if (exc is UnauthorizedAccessException)
            //{
            //    XtraMessageBox.Show(_owner, exc.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    var sqlException = exc as SqlException;
            //    if (sqlException != null)
            //    {
            //        var sb1 = new StringBuilder();
            //        var sb2 = new StringBuilder();
            //        foreach (SqlError error in sqlException.Errors)
            //        {
            //            if (error.Class == 16 && error.State == 1)
            //            {
            //                if (sb1.Length > 0) sb1.Append(Environment.NewLine);
            //                sb1.Append(error.Message);
            //            }
            //            else
            //            {
            //                if (sb2.Length > 0) sb2.Append(Environment.NewLine);
            //                sb2.Append(error.Message);
            //            }
            //        }
            //        if (sb1.Length > 0) XtraMessageBox.Show(_owner, sb1.ToString(), ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        if (sb2.Length > 0) LogManager.Instance.InsertLog(LogTypeEnum.Error, sb2.ToString());
            //    }
            //    else
            //    {
            Logger.Error(exc.Message, exc);
            XtraMessageBox.Show(_owner, exc.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }
    }
}