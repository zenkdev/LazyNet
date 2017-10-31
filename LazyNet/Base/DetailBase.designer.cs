namespace Dekart.LazyNet
{
    partial class DetailBase
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
            this.components = new System.ComponentModel.Container();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.pmExport = new DevExpress.XtraBars.PopupMenu(this.components);
            this.rcMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.AllowCustomization = false;
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 54);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgRoot;
            this.lcMain.Size = new System.Drawing.Size(591, 368);
            this.lcMain.TabIndex = 0;
            // 
            // lcgRoot
            // 
            this.lcgRoot.CustomizationFormText = "lcgRoot";
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "lcgRoot";
            this.lcgRoot.Size = new System.Drawing.Size(591, 368);
            this.lcgRoot.TextVisible = false;
            // 
            // dxValidationProvider
            // 
            this.dxValidationProvider.ValidateHiddenControls = false;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Сохранить";
            this.bbiSave.Glyph = global::Dekart.LazyNet.Properties.Resources.icon_save_16;
            this.bbiSave.Hint = "Сохранить изменения";
            this.bbiSave.Id = 1;
            this.bbiSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.bbiSave.LargeGlyph = global::Dekart.LazyNet.Properties.Resources.icon_save_32;
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Сохранить и закрыть";
            this.bbiSaveAndClose.Glyph = global::Dekart.LazyNet.Properties.Resources.icon_save_close_16;
            this.bbiSaveAndClose.Hint = "Сохранить изменения и закрыть окно";
            this.bbiSaveAndClose.Id = 2;
            this.bbiSaveAndClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.S));
            this.bbiSaveAndClose.LargeGlyph = global::Dekart.LazyNet.Properties.Resources.icon_save_close_32;
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Закрыть";
            this.bbiClose.Glyph = global::Dekart.LazyNet.Properties.Resources.icon_close_16;
            this.bbiClose.Hint = "Закрыть окно";
            this.bbiClose.Id = 3;
            this.bbiClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4));
            this.bbiClose.LargeGlyph = global::Dekart.LazyNet.Properties.Resources.icon_close_32;
            this.bbiClose.Name = "bbiClose";
            // 
            // pmExport
            // 
            this.pmExport.AllowRibbonQATMenu = false;
            this.pmExport.Name = "pmExport";
            this.pmExport.Ribbon = this.rcMain;
            // 
            // rcMain
            // 
            this.rcMain.ApplicationButtonDropDownControl = this.applicationMenu;
            this.rcMain.ExpandCollapseItem.Id = 0;
            this.rcMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcMain.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiClose});
            this.rcMain.Location = new System.Drawing.Point(0, 0);
            this.rcMain.MaxItemId = 35;
            this.rcMain.Name = "rcMain";
            this.rcMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.rcMain.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.rcMain.Size = new System.Drawing.Size(591, 54);
            this.rcMain.StatusBar = this.bStatusBar;
            // 
            // applicationMenu
            // 
            this.applicationMenu.ItemLinks.Add(this.bbiSave);
            this.applicationMenu.ItemLinks.Add(this.bbiSaveAndClose);
            this.applicationMenu.ItemLinks.Add(this.bbiClose, true);
            this.applicationMenu.Name = "applicationMenu";
            this.applicationMenu.Ribbon = this.rcMain;
            // 
            // bStatusBar
            // 
            this.bStatusBar.Location = new System.Drawing.Point(0, 422);
            this.bStatusBar.Name = "bStatusBar";
            this.bStatusBar.Ribbon = this.rcMain;
            this.bStatusBar.Size = new System.Drawing.Size(591, 23);
            // 
            // DetailBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 445);
            this.Controls.Add(this.lcMain);
            this.Controls.Add(this.bStatusBar);
            this.Controls.Add(this.rcMain);
            this.Name = "DetailBase";
            this.Ribbon = this.rcMain;
            this.StatusBar = this.bStatusBar;
            this.Text = "DetailBase";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>For design purposes</summary>
        protected DevExpress.XtraLayout.LayoutControl lcMain;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraBars.BarButtonItem bbiSave;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.PopupMenu pmExport;
        /// <summary>For design purposes</summary>
        protected DevExpress.XtraBars.Ribbon.RibbonControl rcMain;
        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar bStatusBar;
        protected DevExpress.XtraBars.PopupMenu applicationMenu;
    }
}