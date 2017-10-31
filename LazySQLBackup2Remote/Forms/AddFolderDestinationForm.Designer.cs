namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    partial class AddFolderDestinationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFolderDestinationForm));
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.teUserName = new DevExpress.XtraEditors.TextEdit();
            this.lciPath = new DevExpress.XtraLayout.LayoutControlItem();
            this.tePath = new DevExpress.XtraEditors.TextEdit();
            this.lcgLogon = new DevExpress.XtraLayout.LayoutControlGroup();
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
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgLogon)).BeginInit();
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
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.pictureEdit1);
            this.lcMain.Controls.Add(this.seDeleteAfterMonths);
            this.lcMain.Controls.Add(this.seDeleteAfterDays);
            this.lcMain.Controls.Add(this.tePassword);
            this.lcMain.Controls.Add(this.teUserName);
            this.lcMain.Controls.Add(this.tePath);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(998, 180, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(460, 247);
            this.lcMain.GroupExpandChanged += new DevExpress.XtraLayout.Utils.LayoutGroupEventHandler(this.LcMainGroupExpandChanged);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgLogon,
            this.layoutControlItem1,
            this.layoutControlGroup1,
            this.emptySpaceItem2});
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Size = new System.Drawing.Size(460, 247);
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(72, 165);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.PasswordChar = '●';
            this.tePassword.Size = new System.Drawing.Size(374, 20);
            this.tePassword.StyleController = this.lcMain;
            this.tePassword.TabIndex = 4;
            // 
            // teUserName
            // 
            this.teUserName.Location = new System.Drawing.Point(72, 141);
            this.teUserName.Name = "teUserName";
            this.teUserName.Size = new System.Drawing.Size(374, 20);
            this.teUserName.StyleController = this.lcMain;
            this.teUserName.TabIndex = 3;
            // 
            // lciPath
            // 
            this.lciPath.Control = this.tePath;
            this.lciPath.CustomizationFormText = "Local/Network Folder:";
            this.lciPath.Location = new System.Drawing.Point(0, 0);
            this.lciPath.Name = "lciPath";
            this.lciPath.Size = new System.Drawing.Size(355, 40);
            this.lciPath.Text = "Local/Network Folder:";
            this.lciPath.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciPath.TextSize = new System.Drawing.Size(105, 13);
            // 
            // tePath
            // 
            this.tePath.Location = new System.Drawing.Point(107, 18);
            this.tePath.Name = "tePath";
            this.tePath.Size = new System.Drawing.Size(351, 20);
            this.tePath.StyleController = this.lcMain;
            this.tePath.TabIndex = 0;
            // 
            // lcgLogon
            // 
            this.lcgLogon.CustomizationFormText = "Log on to the server";
            this.lcgLogon.ExpandButtonVisible = true;
            this.lcgLogon.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciUserName,
            this.lciPassword});
            this.lcgLogon.Location = new System.Drawing.Point(0, 105);
            this.lcgLogon.Name = "lcgLogon";
            this.lcgLogon.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignModeGroup.AlignLocal;
            this.lcgLogon.Size = new System.Drawing.Size(460, 94);
            this.lcgLogon.Text = "Log on to the server";
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.teUserName;
            this.lciUserName.CustomizationFormText = "User name:";
            this.lciUserName.Location = new System.Drawing.Point(0, 0);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(436, 24);
            this.lciUserName.Text = "User name:";
            this.lciUserName.TextSize = new System.Drawing.Size(55, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.tePassword;
            this.lciPassword.CustomizationFormText = "Password:";
            this.lciPassword.Location = new System.Drawing.Point(0, 24);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(436, 24);
            this.lciPassword.Text = "Password:";
            this.lciPassword.TextSize = new System.Drawing.Size(55, 13);
            // 
            // seDeleteAfterDays
            // 
            this.seDeleteAfterDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seDeleteAfterDays.Location = new System.Drawing.Point(367, 83);
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
            this.lciDeleteAfterDays.Location = new System.Drawing.Point(260, 81);
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
            this.seDeleteAfterMonths.Location = new System.Drawing.Point(260, 83);
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
            this.lciDeleteAfterMonths.Location = new System.Drawing.Point(153, 81);
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
            this.sliDeleteAfter.Location = new System.Drawing.Point(0, 81);
            this.sliDeleteAfter.Name = "sliDeleteAfter";
            this.sliDeleteAfter.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 15, 2, 2);
            this.sliDeleteAfter.Size = new System.Drawing.Size(153, 24);
            this.sliDeleteAfter.Text = "Delete backups after:";
            this.sliDeleteAfter.TextSize = new System.Drawing.Size(105, 13);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.Network_Folder;
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
            this.layoutControlItem1.Size = new System.Drawing.Size(105, 105);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.simpleLabelItem1.CustomizationFormText = "Enter drive:\\path or \\\\unc\\path here";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 40);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(355, 17);
            this.simpleLabelItem1.Text = "Enter drive:\\path or \\\\unc\\path here";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(175, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPath,
            this.simpleLabelItem1,
            this.sliDeleteAfter,
            this.lciDeleteAfterMonths,
            this.lciDeleteAfterDays,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(105, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(355, 105);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 57);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(355, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 199);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(460, 40);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AddFolderDestinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 206);
            this.Name = "AddFolderDestinationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local/Network folder/External HDD/NAS";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgLogon)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem lciPath;
        private DevExpress.XtraEditors.TextEdit teUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlGroup lcgLogon;
        private DevExpress.XtraEditors.TextEdit tePath;
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
    }
}