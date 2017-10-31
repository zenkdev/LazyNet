namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    partial class AddConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddConnectionForm));
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.teUserName = new DevExpress.XtraEditors.TextEdit();
            this.cbSQLAuthentication = new DevExpress.XtraEditors.CheckEdit();
            this.cbIntegratedSecurity = new DevExpress.XtraEditors.CheckEdit();
            this.cbServerName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lciServerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgLogon = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciIntegratedSecurity = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSQLAuthentication = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSQLAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIntegratedSecurity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgLogon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIntegratedSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSQLAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.tePassword);
            this.lcMain.Controls.Add(this.teUserName);
            this.lcMain.Controls.Add(this.cbSQLAuthentication);
            this.lcMain.Controls.Add(this.cbIntegratedSecurity);
            this.lcMain.Controls.Add(this.cbServerName);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 59, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(410, 197);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciServerName,
            this.lcgLogon,
            this.emptySpaceItem1});
            this.lcgRoot.Size = new System.Drawing.Size(410, 197);
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(72, 144);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.PasswordChar = '●';
            this.tePassword.Size = new System.Drawing.Size(324, 20);
            this.tePassword.StyleController = this.lcMain;
            this.tePassword.TabIndex = 8;
            // 
            // teUserName
            // 
            this.teUserName.Location = new System.Drawing.Point(72, 120);
            this.teUserName.Name = "teUserName";
            this.teUserName.Size = new System.Drawing.Size(324, 20);
            this.teUserName.StyleController = this.lcMain;
            this.teUserName.TabIndex = 7;
            // 
            // cbSQLAuthentication
            // 
            this.cbSQLAuthentication.Location = new System.Drawing.Point(14, 97);
            this.cbSQLAuthentication.Name = "cbSQLAuthentication";
            this.cbSQLAuthentication.Properties.Caption = "Use SQL Server Authenctication";
            this.cbSQLAuthentication.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.cbSQLAuthentication.Properties.RadioGroupIndex = 0;
            this.cbSQLAuthentication.Size = new System.Drawing.Size(382, 19);
            this.cbSQLAuthentication.StyleController = this.lcMain;
            this.cbSQLAuthentication.TabIndex = 6;
            this.cbSQLAuthentication.TabStop = false;
            // 
            // cbIntegratedSecurity
            // 
            this.cbIntegratedSecurity.EditValue = true;
            this.cbIntegratedSecurity.Location = new System.Drawing.Point(14, 74);
            this.cbIntegratedSecurity.Name = "cbIntegratedSecurity";
            this.cbIntegratedSecurity.Properties.Caption = "Use Windows Authentication";
            this.cbIntegratedSecurity.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.cbIntegratedSecurity.Properties.RadioGroupIndex = 0;
            this.cbIntegratedSecurity.Size = new System.Drawing.Size(382, 19);
            this.cbIntegratedSecurity.StyleController = this.lcMain;
            this.cbIntegratedSecurity.TabIndex = 5;
            this.cbIntegratedSecurity.CheckedChanged += new System.EventHandler(this.CbIntegratedSecurityCheckedChanged);
            // 
            // cbServerName
            // 
            this.cbServerName.Location = new System.Drawing.Point(2, 18);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbServerName.Size = new System.Drawing.Size(406, 20);
            this.cbServerName.StyleController = this.lcMain;
            this.cbServerName.TabIndex = 4;
            this.cbServerName.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.CbServerNameQueryPopUp);
            // 
            // lciServerName
            // 
            this.lciServerName.Control = this.cbServerName;
            this.lciServerName.CustomizationFormText = "Server Name:";
            this.lciServerName.Location = new System.Drawing.Point(0, 0);
            this.lciServerName.Name = "lciServerName";
            this.lciServerName.Size = new System.Drawing.Size(410, 40);
            this.lciServerName.Text = "Server Name:";
            this.lciServerName.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciServerName.TextSize = new System.Drawing.Size(66, 13);
            // 
            // lcgLogon
            // 
            this.lcgLogon.CustomizationFormText = "Log on to the server";
            this.lcgLogon.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciIntegratedSecurity,
            this.lciSQLAuthentication,
            this.lciUserName,
            this.lciPassword});
            this.lcgLogon.Location = new System.Drawing.Point(0, 40);
            this.lcgLogon.Name = "lcgLogon";
            this.lcgLogon.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignModeGroup.AlignLocal;
            this.lcgLogon.Size = new System.Drawing.Size(410, 138);
            this.lcgLogon.Text = "Log on to the server";
            // 
            // lciIntegratedSecurity
            // 
            this.lciIntegratedSecurity.Control = this.cbIntegratedSecurity;
            this.lciIntegratedSecurity.CustomizationFormText = "lciIntegratedSecurity";
            this.lciIntegratedSecurity.Location = new System.Drawing.Point(0, 0);
            this.lciIntegratedSecurity.Name = "lciIntegratedSecurity";
            this.lciIntegratedSecurity.Size = new System.Drawing.Size(386, 23);
            this.lciIntegratedSecurity.TextSize = new System.Drawing.Size(0, 0);
            this.lciIntegratedSecurity.TextVisible = false;
            // 
            // lciSQLAuthentication
            // 
            this.lciSQLAuthentication.Control = this.cbSQLAuthentication;
            this.lciSQLAuthentication.CustomizationFormText = "lciSQLAuthentication";
            this.lciSQLAuthentication.Location = new System.Drawing.Point(0, 23);
            this.lciSQLAuthentication.Name = "lciSQLAuthentication";
            this.lciSQLAuthentication.Size = new System.Drawing.Size(386, 23);
            this.lciSQLAuthentication.TextSize = new System.Drawing.Size(0, 0);
            this.lciSQLAuthentication.TextVisible = false;
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.teUserName;
            this.lciUserName.CustomizationFormText = "User name:";
            this.lciUserName.Location = new System.Drawing.Point(0, 46);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(386, 24);
            this.lciUserName.Text = "User name:";
            this.lciUserName.TextSize = new System.Drawing.Size(55, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.tePassword;
            this.lciPassword.CustomizationFormText = "Password:";
            this.lciPassword.Location = new System.Drawing.Point(0, 70);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(386, 24);
            this.lciPassword.Text = "Password:";
            this.lciPassword.TextSize = new System.Drawing.Size(55, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 178);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(410, 11);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AddConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 206);
            this.Name = "AddConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to SQL Server / Azure";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSQLAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIntegratedSecurity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciServerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgLogon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIntegratedSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSQLAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cbServerName;
        private DevExpress.XtraLayout.LayoutControlItem lciServerName;
        private DevExpress.XtraEditors.CheckEdit cbIntegratedSecurity;
        private DevExpress.XtraLayout.LayoutControlItem lciIntegratedSecurity;
        private DevExpress.XtraEditors.TextEdit teUserName;
        private DevExpress.XtraEditors.CheckEdit cbSQLAuthentication;
        private DevExpress.XtraLayout.LayoutControlItem lciSQLAuthentication;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlGroup lcgLogon;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}