namespace Dekart.LazyNet {
    partial class AddFormBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pcFormButtons = new DevExpress.XtraEditors.PanelControl();
            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
            this.pcSeparator = new DevExpress.XtraEditors.PanelControl();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcFormButtons)).BeginInit();
            this.pcFormButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pcFormButtons
            // 
            this.pcFormButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcFormButtons.Controls.Add(this.sbSave);
            this.pcFormButtons.Controls.Add(this.pcSeparator);
            this.pcFormButtons.Controls.Add(this.sbCancel);
            this.pcFormButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcFormButtons.Location = new System.Drawing.Point(12, 238);
            this.pcFormButtons.Name = "pcFormButtons";
            this.pcFormButtons.Size = new System.Drawing.Size(368, 22);
            this.pcFormButtons.TabIndex = 1;
            // 
            // sbSave
            // 
            this.sbSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbSave.Location = new System.Drawing.Point(194, 0);
            this.sbSave.Name = "sbSave";
            this.sbSave.Size = new System.Drawing.Size(83, 22);
            this.sbSave.TabIndex = 0;
            this.sbSave.Text = "&Сохранить";
            this.sbSave.Click += new System.EventHandler(this.SbSaveClick);
            // 
            // pcSeparator
            // 
            this.pcSeparator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcSeparator.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcSeparator.Location = new System.Drawing.Point(277, 0);
            this.pcSeparator.Name = "pcSeparator";
            this.pcSeparator.Size = new System.Drawing.Size(8, 22);
            this.pcSeparator.TabIndex = 2;
            // 
            // sbCancel
            // 
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbCancel.Location = new System.Drawing.Point(285, 0);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(83, 22);
            this.sbCancel.TabIndex = 1;
            this.sbCancel.Text = "&Отмена";
            this.sbCancel.Click += new System.EventHandler(this.SbCancelClick);
            // 
            // lcMain
            // 
            this.lcMain.AllowCustomization = false;
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(12, 12);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 59, 250, 350);
            this.lcMain.Root = this.lcgRoot;
            this.lcMain.Size = new System.Drawing.Size(368, 226);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // lcgRoot
            // 
            this.lcgRoot.CustomizationFormText = "lcgRoot";
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "lcgMain";
            this.lcgRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 8);
            this.lcgRoot.Size = new System.Drawing.Size(368, 226);
            this.lcgRoot.Text = "lcgRoot";
            this.lcgRoot.TextVisible = false;
            // 
            // AddFormBase
            // 
            this.AcceptButton = this.sbSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbCancel;
            this.ClientSize = new System.Drawing.Size(392, 272);
            this.Controls.Add(this.lcMain);
            this.Controls.Add(this.pcFormButtons);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "AddFormBase";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AddFormBase";
            ((System.ComponentModel.ISupportInitialize)(this.pcFormButtons)).EndInit();
            this.pcFormButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcFormButtons;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraLayout.LayoutControl lcMain;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private DevExpress.XtraEditors.PanelControl pcSeparator;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbSave;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
    }
}
