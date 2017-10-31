using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddConnectionForm : AddFormBase
    {
        List<string> _items;

        public AddConnectionForm(Form parent, JobData editObject, IDXMenuManager manager)
            : base(parent, editObject, manager)
        {
            InitializeComponent();
        }

        JobData Job => EditObject as JobData;

        protected override void InitData()
        {
            cbServerName.Text = Job.ServerName;
            if (Job.IntegratedSecurity)
            {
                cbIntegratedSecurity.Checked = true;
            }
            else
            {
                cbSQLAuthentication.Checked = true;
            }
            if (cbIntegratedSecurity.Checked)
            {
                teUserName.Enabled = false;
                tePassword.Enabled = false;
            }
            else
            {
                teUserName.Text = Job.UserName;
                tePassword.Text = Job.Password;
            }
        }

        protected override bool ValidateData(bool hideOnSuccessMessage)
        {
            if (!base.ValidateData(hideOnSuccessMessage)) return false;

            try
            {
                var conn = DbHelper.GetNewOpenConnection(cbServerName.Text, cbIntegratedSecurity.Checked, teUserName.Text, tePassword.Text);
                conn.Close();

                if (!hideOnSuccessMessage)
                {
                    XtraMessageBox.Show(this, "Test connection succeeded", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        protected override void SaveData()
        {
            Job.ServerName = cbServerName.Text;
            Job.IntegratedSecurity = cbIntegratedSecurity.Checked;
            Job.UserName = teUserName.Text;
            Job.Password = tePassword.Text;
        }

        void CbIntegratedSecurityCheckedChanged(object sender, EventArgs e)
        {
            teUserName.Enabled = tePassword.Enabled = !cbIntegratedSecurity.Checked;
            if (cbIntegratedSecurity.Checked) teUserName.EditValue = tePassword.EditValue = null;
        }

        void CbServerNameQueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_items != null) return;

            var cursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _items = DbHelper.GetDataSources();
                cbServerName.Properties.Items.AddRange(_items);
            }
            finally
            {
                Cursor.Current = cursor;
            }
        }
    }
}
