namespace Dekart.LazyNet.Win
{
    partial class AddPhotoLibrary
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lciCategory = new DevExpress.XtraLayout.LayoutControlItem();
            this.mruCategory = new DevExpress.XtraEditors.MRUEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPicture = new DevExpress.XtraLayout.LayoutControlItem();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mruCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.teName);
            this.lcMain.Controls.Add(this.mruCategory);
            this.lcMain.Controls.Add(this.pictureEdit1);
            this.lcMain.LayoutVersion = "22102014";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 59, 318, 456);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.OptionsPrint.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcMain.OptionsPrint.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcMain.Size = new System.Drawing.Size(368, 212);
            // 
            // lcgRoot
            // 
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciName,
            this.lciCategory,
            this.lciPicture,
            this.simpleSeparator1,
            this.emptySpaceItem1});
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Size = new System.Drawing.Size(368, 212);
            // 
            // lciCategory
            // 
            this.lciCategory.Control = this.mruCategory;
            this.lciCategory.CustomizationFormText = "Имя группы:";
            this.lciCategory.Location = new System.Drawing.Point(0, 24);
            this.lciCategory.Name = "lciCategory";
            this.lciCategory.Size = new System.Drawing.Size(368, 24);
            this.lciCategory.Text = "Имя группы:";
            this.lciCategory.TextSize = new System.Drawing.Size(89, 13);
            // 
            // mruCategory
            // 
            this.mruCategory.Location = new System.Drawing.Point(95, 26);
            this.mruCategory.Name = "mruCategory";
            this.mruCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mruCategory.Properties.ValidateOnEnterKey = false;
            this.mruCategory.Size = new System.Drawing.Size(271, 20);
            this.mruCategory.StyleController = this.lcMain;
            this.mruCategory.TabIndex = 7;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(95, 2);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(271, 20);
            this.teName.StyleController = this.lcMain;
            this.teName.TabIndex = 0;
            // 
            // lciName
            // 
            this.lciName.Control = this.teName;
            this.lciName.CustomizationFormText = "Имя фотографии:";
            this.lciName.Location = new System.Drawing.Point(0, 0);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(368, 24);
            this.lciName.Text = "Имя фотографии:";
            this.lciName.TextSize = new System.Drawing.Size(89, 13);
            // 
            // lciPicture
            // 
            this.lciPicture.Control = this.pictureEdit1;
            this.lciPicture.CustomizationFormText = "Комментарий:";
            this.lciPicture.Location = new System.Drawing.Point(0, 60);
            this.lciPicture.Name = "lciPicture";
            this.lciPicture.Size = new System.Drawing.Size(144, 144);
            this.lciPicture.Text = "Комментарий:";
            this.lciPicture.TextSize = new System.Drawing.Size(0, 0);
            this.lciPicture.TextVisible = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(2, 62);
            this.pictureEdit1.MaximumSize = new System.Drawing.Size(140, 140);
            this.pictureEdit1.MinimumSize = new System.Drawing.Size(140, 140);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(140, 140);
            this.pictureEdit1.StyleController = this.lcMain;
            this.pictureEdit1.TabIndex = 12;
            this.pictureEdit1.TabStop = true;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 48);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(368, 12);
            this.simpleSeparator1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 5, 5);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(144, 60);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(224, 144);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // AddPhotoLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 258);
            this.MinimumSize = new System.Drawing.Size(306, 206);
            this.Name = "AddPhotoLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление фотографии в галерею";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mruCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciCategory;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private DevExpress.XtraLayout.LayoutControlItem lciPicture;
        private DevExpress.XtraEditors.MRUEdit mruCategory;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.TextEdit teName;
    }
}
