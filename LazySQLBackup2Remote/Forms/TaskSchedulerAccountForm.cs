using System;
using System.Security.Principal;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    /// <summary> TaskSchedulerAccountForm </summary>
    public partial class TaskSchedulerAccountForm : XtraForm
    {
        /// <summary> TaskSchedulerAccountForm </summary>
        public TaskSchedulerAccountForm()
        {
            InitializeComponent();
            var identity = WindowsIdentity.GetCurrent();
            teUsername.Text = identity.Name;
            lcError.Text = string.Empty;
        }

        public string Username { set { teUsername.Text = value; } get { return teUsername.Text; } }
        public string Password => bePassword.Text;

        void SbLoginClick(object sender, EventArgs e)
        {
            lcError.Text = string.Empty;
            
            try
            {
                var token = IntPtr.Zero;
                string domain, username;
                var split = teUsername.Text.Split('\\');
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
                if (!WinHelper.LogonUser(username, domain, bePassword.Text, WinHelper.LOGON32_LOGON_INTERACTIVE, WinHelper.LOGON32_PROVIDER_DEFAULT, ref token))
                {
                    throw new WinApiException(WinHelper.GetLastError());
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exc)
            {
                lcError.Text = exc.Message;
            }
        }

        void BePasswordMouseDown(object sender, MouseEventArgs e)
        {
            var viewInfo = (ButtonEditViewInfo)bePassword.GetViewInfo();
            var hitInfo = viewInfo.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == EditHitTest.Button && e.Button == MouseButtons.Left)
            {
                bePassword.Properties.UseSystemPasswordChar = false;
            }
        }

        void BePasswordMouseUp(object sender, MouseEventArgs e)
        {
            bePassword.Properties.UseSystemPasswordChar = true;
        }

    }
}