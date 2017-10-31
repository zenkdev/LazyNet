namespace Dekart.LazyNet.Win
{
    partial class SsMain
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes of the resources (other than memory) used by the <see cref="T:System.Windows.Forms.Form"/>.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SsMain));
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.lcCopyright = new DevExpress.XtraEditors.LabelControl();
            this.lcHeader = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.picturePoweredBy = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoweredBy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(23, 231);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(404, 12);
            this.marqueeProgressBarControl1.TabIndex = 5;
            // 
            // lcCopyright
            // 
            this.lcCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lcCopyright.Location = new System.Drawing.Point(23, 276);
            this.lcCopyright.Name = "lcCopyright";
            this.lcCopyright.Size = new System.Drawing.Size(91, 13);
            this.lcCopyright.TabIndex = 6;
            this.lcCopyright.Text = "Copyright © 2002-";
            // 
            // lcHeader
            // 
            this.lcHeader.Location = new System.Drawing.Point(23, 206);
            this.lcHeader.Name = "lcHeader";
            this.lcHeader.Size = new System.Drawing.Size(50, 13);
            this.lcHeader.TabIndex = 7;
            this.lcHeader.Text = "Starting...";
            // 
            // pictureEdit
            // 
            this.pictureEdit.EditValue = ((object)(resources.GetObject("pictureEdit.EditValue")));
            this.pictureEdit.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.AllowFocused = false;
            this.pictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit.Properties.ShowMenu = false;
            this.pictureEdit.Size = new System.Drawing.Size(426, 180);
            this.pictureEdit.TabIndex = 9;
            // 
            // picturePoweredBy
            // 
            this.picturePoweredBy.EditValue = ((object)(resources.GetObject("picturePoweredBy.EditValue")));
            this.picturePoweredBy.Location = new System.Drawing.Point(305, 267);
            this.picturePoweredBy.Name = "picturePoweredBy";
            this.picturePoweredBy.Properties.AllowFocused = false;
            this.picturePoweredBy.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picturePoweredBy.Properties.Appearance.Options.UseBackColor = true;
            this.picturePoweredBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picturePoweredBy.Properties.ShowMenu = false;
            this.picturePoweredBy.Size = new System.Drawing.Size(123, 30);
            this.picturePoweredBy.TabIndex = 8;
            // 
            // SsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 320);
            this.Controls.Add(this.pictureEdit);
            this.Controls.Add(this.picturePoweredBy);
            this.Controls.Add(this.lcHeader);
            this.Controls.Add(this.lcCopyright);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Name = "SsMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoweredBy.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl lcCopyright;
        private DevExpress.XtraEditors.LabelControl lcHeader;
        private DevExpress.XtraEditors.PictureEdit picturePoweredBy;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
    }
}