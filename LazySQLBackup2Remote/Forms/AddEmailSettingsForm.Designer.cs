namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    partial class AddEmailSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmailSettingsForm));
            this.teFrom = new DevExpress.XtraEditors.TextEdit();
            this.lciFrom = new DevExpress.XtraLayout.LayoutControlItem();
            this.teSmtpServer = new DevExpress.XtraEditors.TextEdit();
            this.lciSmtpServer = new DevExpress.XtraLayout.LayoutControlItem();
            this.seSmtpPort = new DevExpress.XtraEditors.SpinEdit();
            this.lciSmtpPort = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbUseAuthentication = new DevExpress.XtraEditors.CheckEdit();
            this.lciUseAuthentication = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbEnableSsl = new DevExpress.XtraEditors.CheckEdit();
            this.lciEnableSsl = new DevExpress.XtraLayout.LayoutControlItem();
            this.teUserName = new DevExpress.XtraEditors.TextEdit();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSmtpServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSmtpServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSmtpPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSmtpPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUseAuthentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUseAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableSsl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEnableSsl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.tePassword);
            this.lcMain.Controls.Add(this.teUserName);
            this.lcMain.Controls.Add(this.cbEnableSsl);
            this.lcMain.Controls.Add(this.cbUseAuthentication);
            this.lcMain.Controls.Add(this.seSmtpPort);
            this.lcMain.Controls.Add(this.teSmtpServer);
            this.lcMain.Controls.Add(this.teFrom);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1235, 183, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(410, 147);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciFrom,
            this.lciSmtpServer,
            this.lciSmtpPort,
            this.lciUseAuthentication,
            this.lciUserName,
            this.lciPassword,
            this.lciEnableSsl,
            this.emptySpaceItem1});
            this.lcgRoot.Size = new System.Drawing.Size(410, 147);
            // 
            // teFrom
            // 
            this.teFrom.Location = new System.Drawing.Point(100, 2);
            this.teFrom.Name = "teFrom";
            this.teFrom.Size = new System.Drawing.Size(308, 20);
            this.teFrom.StyleController = this.lcMain;
            this.teFrom.TabIndex = 4;
            // 
            // lciFrom
            // 
            this.lciFrom.Control = this.teFrom;
            this.lciFrom.CustomizationFormText = "From e-mail:";
            this.lciFrom.Location = new System.Drawing.Point(0, 0);
            this.lciFrom.Name = "lciFrom";
            this.lciFrom.Size = new System.Drawing.Size(410, 24);
            this.lciFrom.Text = "From e-mail:";
            this.lciFrom.TextSize = new System.Drawing.Size(94, 13);
            // 
            // teSmtpServer
            // 
            this.teSmtpServer.Location = new System.Drawing.Point(100, 26);
            this.teSmtpServer.Name = "teSmtpServer";
            this.teSmtpServer.Size = new System.Drawing.Size(142, 20);
            this.teSmtpServer.StyleController = this.lcMain;
            this.teSmtpServer.TabIndex = 5;
            // 
            // lciSmtpServer
            // 
            this.lciSmtpServer.Control = this.teSmtpServer;
            this.lciSmtpServer.CustomizationFormText = "SMTP mail Server:";
            this.lciSmtpServer.Location = new System.Drawing.Point(0, 24);
            this.lciSmtpServer.Name = "lciSmtpServer";
            this.lciSmtpServer.Size = new System.Drawing.Size(244, 24);
            this.lciSmtpServer.Text = "SMTP mail Server:";
            this.lciSmtpServer.TextSize = new System.Drawing.Size(94, 13);
            // 
            // seSmtpPort
            // 
            this.seSmtpPort.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seSmtpPort.Location = new System.Drawing.Point(358, 26);
            this.seSmtpPort.Name = "seSmtpPort";
            this.seSmtpPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSmtpPort.Properties.IsFloatValue = false;
            this.seSmtpPort.Properties.Mask.EditMask = "N00";
            this.seSmtpPort.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.seSmtpPort.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seSmtpPort.Size = new System.Drawing.Size(50, 20);
            this.seSmtpPort.StyleController = this.lcMain;
            this.seSmtpPort.TabIndex = 6;
            // 
            // lciSmtpPort
            // 
            this.lciSmtpPort.Control = this.seSmtpPort;
            this.lciSmtpPort.CustomizationFormText = "Port (25 is default):";
            this.lciSmtpPort.Location = new System.Drawing.Point(244, 24);
            this.lciSmtpPort.MaxSize = new System.Drawing.Size(166, 24);
            this.lciSmtpPort.MinSize = new System.Drawing.Size(166, 24);
            this.lciSmtpPort.Name = "lciSmtpPort";
            this.lciSmtpPort.Padding = new DevExpress.XtraLayout.Utils.Padding(15, 2, 2, 2);
            this.lciSmtpPort.Size = new System.Drawing.Size(166, 24);
            this.lciSmtpPort.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSmtpPort.Text = "Port (25 is default):";
            this.lciSmtpPort.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSmtpPort.TextSize = new System.Drawing.Size(94, 13);
            this.lciSmtpPort.TextToControlDistance = 5;
            // 
            // cbUseAuthentication
            // 
            this.cbUseAuthentication.Location = new System.Drawing.Point(100, 50);
            this.cbUseAuthentication.Name = "cbUseAuthentication";
            this.cbUseAuthentication.Properties.Caption = "My server requires authentication";
            this.cbUseAuthentication.Size = new System.Drawing.Size(230, 19);
            this.cbUseAuthentication.StyleController = this.lcMain;
            this.cbUseAuthentication.TabIndex = 7;
            this.cbUseAuthentication.CheckedChanged += new System.EventHandler(this.CbUseAuthenticationCheckedChanged);
            // 
            // lciUseAuthentication
            // 
            this.lciUseAuthentication.Control = this.cbUseAuthentication;
            this.lciUseAuthentication.CustomizationFormText = " ";
            this.lciUseAuthentication.Location = new System.Drawing.Point(0, 48);
            this.lciUseAuthentication.Name = "lciUseAuthentication";
            this.lciUseAuthentication.Size = new System.Drawing.Size(332, 23);
            this.lciUseAuthentication.Text = " ";
            this.lciUseAuthentication.TextSize = new System.Drawing.Size(94, 13);
            // 
            // cbEnableSsl
            // 
            this.cbEnableSsl.Location = new System.Drawing.Point(334, 50);
            this.cbEnableSsl.Name = "cbEnableSsl";
            this.cbEnableSsl.Properties.Caption = "Enable SSL";
            this.cbEnableSsl.Size = new System.Drawing.Size(74, 19);
            this.cbEnableSsl.StyleController = this.lcMain;
            this.cbEnableSsl.TabIndex = 8;
            // 
            // lciEnableSsl
            // 
            this.lciEnableSsl.Control = this.cbEnableSsl;
            this.lciEnableSsl.CustomizationFormText = "lciEnableSsl";
            this.lciEnableSsl.Location = new System.Drawing.Point(332, 48);
            this.lciEnableSsl.MaxSize = new System.Drawing.Size(78, 23);
            this.lciEnableSsl.MinSize = new System.Drawing.Size(78, 23);
            this.lciEnableSsl.Name = "lciEnableSsl";
            this.lciEnableSsl.Size = new System.Drawing.Size(78, 23);
            this.lciEnableSsl.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciEnableSsl.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciEnableSsl.TextSize = new System.Drawing.Size(0, 0);
            this.lciEnableSsl.TextToControlDistance = 0;
            this.lciEnableSsl.TextVisible = false;
            // 
            // teUserName
            // 
            this.teUserName.Location = new System.Drawing.Point(100, 73);
            this.teUserName.Name = "teUserName";
            this.teUserName.Size = new System.Drawing.Size(308, 20);
            this.teUserName.StyleController = this.lcMain;
            this.teUserName.TabIndex = 9;
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.teUserName;
            this.lciUserName.CustomizationFormText = "User Name / E-Mail:";
            this.lciUserName.Location = new System.Drawing.Point(0, 71);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(410, 24);
            this.lciUserName.Text = "User Name / E-Mail:";
            this.lciUserName.TextSize = new System.Drawing.Size(94, 13);
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(100, 97);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.PasswordChar = '●';
            this.tePassword.Size = new System.Drawing.Size(308, 20);
            this.tePassword.StyleController = this.lcMain;
            this.tePassword.TabIndex = 10;
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.tePassword;
            this.lciPassword.CustomizationFormText = "Password:";
            this.lciPassword.Location = new System.Drawing.Point(0, 95);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(410, 24);
            this.lciPassword.Text = "Password:";
            this.lciPassword.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 119);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(410, 20);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AddEmailSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 206);
            this.Name = "AddEmailSettingsForm";
            this.Text = "E-mail Settings";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSmtpServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSmtpServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSmtpPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSmtpPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUseAuthentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUseAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEnableSsl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEnableSsl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.TextEdit teUserName;
        private DevExpress.XtraEditors.CheckEdit cbEnableSsl;
        private DevExpress.XtraEditors.CheckEdit cbUseAuthentication;
        private DevExpress.XtraEditors.SpinEdit seSmtpPort;
        private DevExpress.XtraEditors.TextEdit teSmtpServer;
        private DevExpress.XtraEditors.TextEdit teFrom;
        private DevExpress.XtraLayout.LayoutControlItem lciFrom;
        private DevExpress.XtraLayout.LayoutControlItem lciSmtpServer;
        private DevExpress.XtraLayout.LayoutControlItem lciSmtpPort;
        private DevExpress.XtraLayout.LayoutControlItem lciUseAuthentication;
        private DevExpress.XtraLayout.LayoutControlItem lciEnableSsl;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}