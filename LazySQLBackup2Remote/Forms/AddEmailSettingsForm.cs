using System;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddEmailSettingsForm : AddFormBase
    {
        readonly string[] _to;

        public AddEmailSettingsForm(Form parent, EmailSettingsData editObject, IDXMenuManager manager, string []to)
            : base(parent, editObject, manager)
        {
            InitializeComponent();
            _to = to;
        }

        /// <summary>EmailSettings</summary>
        EmailSettingsData EmailSettings => EditObject as EmailSettingsData;

        protected override void InitData()
        {
            teFrom.Text = EmailSettings.From;
            teSmtpServer.Text = EmailSettings.SmtpServer;
            seSmtpPort.Value = EmailSettings.SmtpPort;
            cbUseAuthentication.Checked = EmailSettings.UseAuthentication;
            if (cbUseAuthentication.Checked)
            {
                cbEnableSsl.Enabled = teUserName.Enabled = tePassword.Enabled = true;
                cbEnableSsl.Checked = EmailSettings.EnableSsl;
                teUserName.Text = EmailSettings.UserName;
                tePassword.Text = EmailSettings.Password;
            }
            else
            {
                cbEnableSsl.Enabled = teUserName.Enabled = tePassword.Enabled = false;
                cbEnableSsl.Checked = false;
                teUserName.Text = tePassword.Text = null;
            }
        }

        protected override bool ValidateData(bool hideOnSuccessMessage)
        {
            if (!base.ValidateData(hideOnSuccessMessage)) return false;

            try
            {
                if (!hideOnSuccessMessage)
                {
                    var subject = string.Format(ConstStrings.EmailSubject, ConstStrings.ApplicationCaption);
                    SendMail.Send(teSmtpServer.Text, Convert.ToInt32(seSmtpPort.Value), cbUseAuthentication.Checked, cbEnableSsl.Checked, teUserName.Text, tePassword.Text, _to, subject, ConstStrings.EmailBody, teFrom.Text, "");
                    XtraMessageBox.Show(this, ConstStrings.EmailError, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        protected override void SaveData()
        {
            EmailSettings.From = teFrom.Text;
            EmailSettings.SmtpServer = teSmtpServer.Text;
            EmailSettings.SmtpPort = Convert.ToInt32(seSmtpPort.Value);
            EmailSettings.UseAuthentication = cbUseAuthentication.Checked;
            EmailSettings.EnableSsl = cbEnableSsl.Checked;
            EmailSettings.UserName = teUserName.Text;
            EmailSettings.Password = tePassword.Text;
        }

        void CbUseAuthenticationCheckedChanged(object sender, EventArgs e)
        {
            cbEnableSsl.Enabled = teUserName.Enabled = tePassword.Enabled = cbUseAuthentication.Checked;
            if (!cbUseAuthentication.Checked)
            {
                cbEnableSsl.Checked = false;
                teUserName.Text = tePassword.Text = null;
            }
        }
    }
}
