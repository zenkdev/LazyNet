namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    partial class AddFtpDestinationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFtpDestinationForm));
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.teUserName = new DevExpress.XtraEditors.TextEdit();
            this.lciHost = new DevExpress.XtraLayout.LayoutControlItem();
            this.teHost = new DevExpress.XtraEditors.TextEdit();
            this.lcgAdvanced = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciProtocol = new DevExpress.XtraLayout.LayoutControlItem();
            this.cbProtocol = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lciPort = new DevExpress.XtraLayout.LayoutControlItem();
            this.sePort = new DevExpress.XtraEditors.SpinEdit();
            this.lciRemoteFolder = new DevExpress.XtraLayout.LayoutControlItem();
            this.teRemoteFolder = new DevExpress.XtraEditors.TextEdit();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.seDeleteAfterDays = new DevExpress.XtraEditors.SpinEdit();
            this.lciDeleteAfterDays = new DevExpress.XtraLayout.LayoutControlItem();
            this.seDeleteAfterMonths = new DevExpress.XtraEditors.SpinEdit();
            this.lciDeleteAfterMonths = new DevExpress.XtraLayout.LayoutControlItem();
            this.sliDeleteAfter = new DevExpress.XtraLayout.SimpleLabelItem();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAdvanced)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProtocol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProtocol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRemoteFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRemoteFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDeleteAfterDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDeleteAfterDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDeleteAfterMonths.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDeleteAfterMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliDeleteAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.teRemoteFolder);
            this.lcMain.Controls.Add(this.sePort);
            this.lcMain.Controls.Add(this.cbProtocol);
            this.lcMain.Controls.Add(this.pictureEdit1);
            this.lcMain.Controls.Add(this.seDeleteAfterMonths);
            this.lcMain.Controls.Add(this.seDeleteAfterDays);
            this.lcMain.Controls.Add(this.tePassword);
            this.lcMain.Controls.Add(this.teUserName);
            this.lcMain.Controls.Add(this.teHost);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(998, 180, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(460, 277);
            this.lcMain.GroupExpandChanged += new DevExpress.XtraLayout.Utils.LayoutGroupEventHandler(this.LcMainGroupExpandChanged);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgAdvanced,
            this.layoutControlItem1,
            this.layoutControlGroup1,
            this.emptySpaceItem3});
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Size = new System.Drawing.Size(460, 277);
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(215, 93);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.PasswordChar = '●';
            this.tePassword.Size = new System.Drawing.Size(243, 20);
            this.tePassword.StyleController = this.lcMain;
            this.tePassword.TabIndex = 4;
            // 
            // teUserName
            // 
            this.teUserName.Location = new System.Drawing.Point(215, 69);
            this.teUserName.Name = "teUserName";
            this.teUserName.Size = new System.Drawing.Size(243, 20);
            this.teUserName.StyleController = this.lcMain;
            this.teUserName.TabIndex = 3;
            // 
            // lciHost
            // 
            this.lciHost.Control = this.teHost;
            this.lciHost.CustomizationFormText = "Host address:";
            this.lciHost.Location = new System.Drawing.Point(0, 0);
            this.lciHost.Name = "lciHost";
            this.lciHost.Size = new System.Drawing.Size(355, 40);
            this.lciHost.Text = "Host address:";
            this.lciHost.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciHost.TextSize = new System.Drawing.Size(104, 13);
            // 
            // teHost
            // 
            this.teHost.Location = new System.Drawing.Point(107, 18);
            this.teHost.Name = "teHost";
            this.teHost.Size = new System.Drawing.Size(351, 20);
            this.teHost.StyleController = this.lcMain;
            this.teHost.TabIndex = 0;
            // 
            // lcgAdvanced
            // 
            this.lcgAdvanced.CustomizationFormText = "Advanced FTP settings";
            this.lcgAdvanced.ExpandButtonVisible = true;
            this.lcgAdvanced.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciProtocol,
            this.lciPort,
            this.lciRemoteFolder});
            this.lcgAdvanced.Location = new System.Drawing.Point(0, 149);
            this.lcgAdvanced.Name = "lcgAdvanced";
            this.lcgAdvanced.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignModeGroup.AlignLocal;
            this.lcgAdvanced.Size = new System.Drawing.Size(460, 94);
            this.lcgAdvanced.Text = "Advanced FTP settings";
            // 
            // lciProtocol
            // 
            this.lciProtocol.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciProtocol.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lciProtocol.Control = this.cbProtocol;
            this.lciProtocol.CustomizationFormText = "Protocol:";
            this.lciProtocol.Location = new System.Drawing.Point(0, 0);
            this.lciProtocol.Name = "lciProtocol";
            this.lciProtocol.Size = new System.Drawing.Size(337, 24);
            this.lciProtocol.Text = "Protocol:";
            this.lciProtocol.TextSize = new System.Drawing.Size(72, 13);
            // 
            // cbProtocol
            // 
            this.cbProtocol.Location = new System.Drawing.Point(89, 185);
            this.cbProtocol.Name = "cbProtocol";
            this.cbProtocol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbProtocol.Properties.Items.AddRange(new object[] {
            "FTP (Standard)",
            "SFTP (Secure FTP)"});
            this.cbProtocol.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbProtocol.Size = new System.Drawing.Size(258, 20);
            this.cbProtocol.StyleController = this.lcMain;
            this.cbProtocol.TabIndex = 6;
            this.cbProtocol.SelectedIndexChanged += new System.EventHandler(this.CbProtocolSelectedIndexChanged);
            // 
            // lciPort
            // 
            this.lciPort.Control = this.sePort;
            this.lciPort.CustomizationFormText = "Port:";
            this.lciPort.Location = new System.Drawing.Point(337, 0);
            this.lciPort.MaxSize = new System.Drawing.Size(99, 24);
            this.lciPort.MinSize = new System.Drawing.Size(99, 24);
            this.lciPort.Name = "lciPort";
            this.lciPort.Size = new System.Drawing.Size(99, 24);
            this.lciPort.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciPort.Text = "Port:";
            this.lciPort.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciPort.TextSize = new System.Drawing.Size(24, 13);
            this.lciPort.TextToControlDistance = 5;
            // 
            // sePort
            // 
            this.sePort.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sePort.Location = new System.Drawing.Point(380, 185);
            this.sePort.Name = "sePort";
            this.sePort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePort.Properties.IsFloatValue = false;
            this.sePort.Properties.Mask.EditMask = "N00";
            this.sePort.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.sePort.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sePort.Size = new System.Drawing.Size(66, 20);
            this.sePort.StyleController = this.lcMain;
            this.sePort.TabIndex = 7;
            // 
            // lciRemoteFolder
            // 
            this.lciRemoteFolder.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciRemoteFolder.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lciRemoteFolder.Control = this.teRemoteFolder;
            this.lciRemoteFolder.CustomizationFormText = "Remote folder:";
            this.lciRemoteFolder.Location = new System.Drawing.Point(0, 24);
            this.lciRemoteFolder.Name = "lciRemoteFolder";
            this.lciRemoteFolder.Size = new System.Drawing.Size(436, 24);
            this.lciRemoteFolder.Text = "Remote folder:";
            this.lciRemoteFolder.TextSize = new System.Drawing.Size(72, 13);
            // 
            // teRemoteFolder
            // 
            this.teRemoteFolder.Location = new System.Drawing.Point(89, 209);
            this.teRemoteFolder.Name = "teRemoteFolder";
            this.teRemoteFolder.Size = new System.Drawing.Size(357, 20);
            this.teRemoteFolder.StyleController = this.lcMain;
            this.teRemoteFolder.TabIndex = 8;
            // 
            // lciUserName
            // 
            this.lciUserName.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciUserName.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lciUserName.Control = this.teUserName;
            this.lciUserName.CustomizationFormText = "Username:";
            this.lciUserName.Location = new System.Drawing.Point(0, 67);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(355, 24);
            this.lciUserName.Text = "Username:";
            this.lciUserName.TextSize = new System.Drawing.Size(104, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciPassword.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lciPassword.Control = this.tePassword;
            this.lciPassword.CustomizationFormText = "Password:";
            this.lciPassword.Location = new System.Drawing.Point(0, 91);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(355, 24);
            this.lciPassword.Text = "Password:";
            this.lciPassword.TextSize = new System.Drawing.Size(104, 13);
            // 
            // seDeleteAfterDays
            // 
            this.seDeleteAfterDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seDeleteAfterDays.Location = new System.Drawing.Point(367, 127);
            this.seDeleteAfterDays.Name = "seDeleteAfterDays";
            this.seDeleteAfterDays.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seDeleteAfterDays.Properties.IsFloatValue = false;
            this.seDeleteAfterDays.Properties.Mask.EditMask = "N00";
            this.seDeleteAfterDays.Properties.MaxValue = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.seDeleteAfterDays.Size = new System.Drawing.Size(50, 20);
            this.seDeleteAfterDays.StyleController = this.lcMain;
            this.seDeleteAfterDays.TabIndex = 2;
            // 
            // lciDeleteAfterDays
            // 
            this.lciDeleteAfterDays.Control = this.seDeleteAfterDays;
            this.lciDeleteAfterDays.CustomizationFormText = "days";
            this.lciDeleteAfterDays.Location = new System.Drawing.Point(260, 125);
            this.lciDeleteAfterDays.MaxSize = new System.Drawing.Size(95, 24);
            this.lciDeleteAfterDays.MinSize = new System.Drawing.Size(95, 24);
            this.lciDeleteAfterDays.Name = "lciDeleteAfterDays";
            this.lciDeleteAfterDays.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 15, 2, 2);
            this.lciDeleteAfterDays.Size = new System.Drawing.Size(95, 24);
            this.lciDeleteAfterDays.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciDeleteAfterDays.Text = "days";
            this.lciDeleteAfterDays.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciDeleteAfterDays.TextLocation = DevExpress.Utils.Locations.Right;
            this.lciDeleteAfterDays.TextSize = new System.Drawing.Size(23, 13);
            this.lciDeleteAfterDays.TextToControlDistance = 5;
            // 
            // seDeleteAfterMonths
            // 
            this.seDeleteAfterMonths.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seDeleteAfterMonths.Location = new System.Drawing.Point(260, 127);
            this.seDeleteAfterMonths.Name = "seDeleteAfterMonths";
            this.seDeleteAfterMonths.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seDeleteAfterMonths.Properties.IsFloatValue = false;
            this.seDeleteAfterMonths.Properties.Mask.EditMask = "N00";
            this.seDeleteAfterMonths.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.seDeleteAfterMonths.Size = new System.Drawing.Size(50, 20);
            this.seDeleteAfterMonths.StyleController = this.lcMain;
            this.seDeleteAfterMonths.TabIndex = 1;
            // 
            // lciDeleteAfterMonths
            // 
            this.lciDeleteAfterMonths.Control = this.seDeleteAfterMonths;
            this.lciDeleteAfterMonths.CustomizationFormText = "months";
            this.lciDeleteAfterMonths.Location = new System.Drawing.Point(153, 125);
            this.lciDeleteAfterMonths.MaxSize = new System.Drawing.Size(107, 24);
            this.lciDeleteAfterMonths.MinSize = new System.Drawing.Size(107, 24);
            this.lciDeleteAfterMonths.Name = "lciDeleteAfterMonths";
            this.lciDeleteAfterMonths.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 15, 2, 2);
            this.lciDeleteAfterMonths.Size = new System.Drawing.Size(107, 24);
            this.lciDeleteAfterMonths.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciDeleteAfterMonths.Text = "months";
            this.lciDeleteAfterMonths.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciDeleteAfterMonths.TextLocation = DevExpress.Utils.Locations.Right;
            this.lciDeleteAfterMonths.TextSize = new System.Drawing.Size(35, 13);
            this.lciDeleteAfterMonths.TextToControlDistance = 5;
            // 
            // sliDeleteAfter
            // 
            this.sliDeleteAfter.AllowHotTrack = false;
            this.sliDeleteAfter.AppearanceItemCaption.Options.UseTextOptions = true;
            this.sliDeleteAfter.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.sliDeleteAfter.CustomizationFormText = "Delete backups after:";
            this.sliDeleteAfter.Location = new System.Drawing.Point(0, 125);
            this.sliDeleteAfter.Name = "sliDeleteAfter";
            this.sliDeleteAfter.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 15, 2, 2);
            this.sliDeleteAfter.Size = new System.Drawing.Size(153, 24);
            this.sliDeleteAfter.Text = "Delete backups after:";
            this.sliDeleteAfter.TextSize = new System.Drawing.Size(104, 13);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.Network_Drive;
            this.pictureEdit1.Location = new System.Drawing.Point(2, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(101, 101);
            this.pictureEdit1.StyleController = this.lcMain;
            this.pictureEdit1.TabIndex = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pictureEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(105, 105);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(105, 105);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(105, 149);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.simpleLabelItem1.CustomizationFormText = "e.g. FTPServer.com or ftp://FTPServer.com";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 40);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(355, 17);
            this.simpleLabelItem1.Text = "e.g. FTPServer.com or ftp://FTPServer.com";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(211, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciHost,
            this.simpleLabelItem1,
            this.sliDeleteAfter,
            this.lciDeleteAfterMonths,
            this.lciDeleteAfterDays,
            this.emptySpaceItem1,
            this.lciUserName,
            this.lciPassword,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(105, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(355, 149);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 57);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(355, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 115);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(355, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 243);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(460, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AddFtpDestinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(484, 341);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 206);
            this.Name = "AddFtpDestinationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FTP Settings";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAdvanced)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProtocol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProtocol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRemoteFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teRemoteFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDeleteAfterDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDeleteAfterDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDeleteAfterMonths.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDeleteAfterMonths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliDeleteAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem lciHost;
        private DevExpress.XtraEditors.TextEdit teUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlGroup lcgAdvanced;
        private DevExpress.XtraEditors.TextEdit teHost;
        private DevExpress.XtraEditors.SpinEdit seDeleteAfterMonths;
        private DevExpress.XtraEditors.SpinEdit seDeleteAfterDays;
        private DevExpress.XtraLayout.LayoutControlItem lciDeleteAfterDays;
        private DevExpress.XtraLayout.LayoutControlItem lciDeleteAfterMonths;
        private DevExpress.XtraLayout.SimpleLabelItem sliDeleteAfter;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SpinEdit sePort;
        private DevExpress.XtraEditors.ComboBoxEdit cbProtocol;
        private DevExpress.XtraLayout.LayoutControlItem lciProtocol;
        private DevExpress.XtraLayout.LayoutControlItem lciPort;
        private DevExpress.XtraEditors.TextEdit teRemoteFolder;
        private DevExpress.XtraLayout.LayoutControlItem lciRemoteFolder;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}