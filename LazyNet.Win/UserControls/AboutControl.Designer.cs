namespace Dekart.LazyNet.Win.UserControls
{
    partial class AboutControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.logo = new DevExpress.XtraEditors.PictureEdit();
            this.buttonsPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.descriptionLabel = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.logo);
            this.layoutControl1.Controls.Add(this.buttonsPanel);
            this.layoutControl1.Controls.Add(this.descriptionLabel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1019, 246, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(892, 475);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // logo
            // 
            this.logo.Cursor = System.Windows.Forms.Cursors.Default;
            this.logo.EditValue = ((object)(resources.GetObject("logo.EditValue")));
            this.logo.Location = new System.Drawing.Point(12, 382);
            this.logo.MinimumSize = new System.Drawing.Size(0, 81);
            this.logo.Name = "logo";
            this.logo.Properties.AllowFocused = false;
            this.logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.logo.Properties.Appearance.Options.UseBackColor = true;
            this.logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logo.Properties.PictureAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.logo.Properties.ShowMenu = false;
            this.logo.Properties.ZoomAccelerationFactor = 1D;
            this.logo.Size = new System.Drawing.Size(868, 81);
            this.logo.StyleController = this.layoutControl1;
            this.logo.TabIndex = 19;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.AllowGlyphSkinning = false;
            this.buttonsPanel.AppearanceButton.Hovered.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.buttonsPanel.AppearanceButton.Hovered.Options.UseFont = true;
            this.buttonsPanel.AppearanceButton.Normal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonsPanel.AppearanceButton.Normal.Options.UseFont = true;
            this.buttonsPanel.AppearanceButton.Pressed.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.buttonsPanel.AppearanceButton.Pressed.Options.UseFont = true;
            this.buttonsPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", ((System.Drawing.Image)(resources.GetObject("buttonsPanel.Buttons"))), -1, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, null, "ProCom 2018", -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", ((System.Drawing.Image)(resources.GetObject("buttonsPanel.Buttons1"))), -1, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, null, "ProStore 2015", -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", ((System.Drawing.Image)(resources.GetObject("buttonsPanel.Buttons2"))), -1, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, null, "Protect 2015", -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", ((System.Drawing.Image)(resources.GetObject("buttonsPanel.Buttons3"))), -1, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, null, "Provizor", -1, false, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Button", ((System.Drawing.Image)(resources.GetObject("buttonsPanel.Buttons4"))), -1, DevExpress.XtraBars.Docking2010.ImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, null, "ZebriNet 2015", -1, false, false)});
            this.buttonsPanel.Location = new System.Drawing.Point(12, 210);
            this.buttonsPanel.MaximumSize = new System.Drawing.Size(0, 128);
            this.buttonsPanel.MinimumSize = new System.Drawing.Size(0, 168);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(868, 168);
            this.buttonsPanel.TabIndex = 18;
            this.buttonsPanel.Text = "windowsUIButtonPanel1";
            this.buttonsPanel.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.buttonsPanel_ButtonClick);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AllowHtmlString = true;
            this.descriptionLabel.Appearance.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.descriptionLabel.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.descriptionLabel.Appearance.Options.UseFont = true;
            this.descriptionLabel.Appearance.Options.UseImageAlign = true;
            this.descriptionLabel.Appearance.Options.UseTextOptions = true;
            this.descriptionLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.descriptionLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.descriptionLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.descriptionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 12);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(868, 194);
            this.descriptionLabel.StyleController = this.layoutControl1;
            this.descriptionLabel.TabIndex = 17;
            this.descriptionLabel.Text = "Sales SuperHero";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(892, 475);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.descriptionLabel;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(25, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(872, 198);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buttonsPanel;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 198);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(872, 172);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.logo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 370);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(872, 85);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // AboutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "AboutControl";
            this.Size = new System.Drawing.Size(892, 475);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl descriptionLabel;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel buttonsPanel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PictureEdit logo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
