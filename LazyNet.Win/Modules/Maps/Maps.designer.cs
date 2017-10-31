namespace Dekart.LazyNet.Win.Modules {
    partial class Maps {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maps));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.pictureEdit = new Dekart.LazyNet.DrawingControl();
            this.imageListBoxControl1 = new DevExpress.XtraEditors.ImageListBoxControl();
            this.icDevices = new DevExpress.Utils.ImageCollection(this.components);
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiOpenWeb = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenRadmin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenRomViewer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenMstsc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPing = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTracert = new DevExpress.XtraBars.BarButtonItem();
            this.radialMenu1 = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            resources.ApplyResources(this.splitContainerControl, "splitContainerControl");
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.pictureEdit);
            resources.ApplyResources(this.splitContainerControl.Panel1, "splitContainerControl.Panel1");
            this.splitContainerControl.Panel2.Controls.Add(this.imageListBoxControl1);
            resources.ApplyResources(this.splitContainerControl.Panel2, "splitContainerControl.Panel2");
            this.splitContainerControl.SplitterPosition = 200;
            // 
            // pictureEdit
            // 
            this.pictureEdit.AllowDrop = true;
            resources.ApplyResources(this.pictureEdit, "pictureEdit");
            this.pictureEdit.Image = null;
            this.pictureEdit.InitialImage = null;
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Origin = new System.Drawing.Point(0, 0);
            this.pictureEdit.PanButton = System.Windows.Forms.MouseButtons.Right;
            this.pictureEdit.PanMode = true;
            this.pictureEdit.ScrollbarsVisible = true;
            this.pictureEdit.StretchImageToFit = false;
            this.pictureEdit.ZoomFactor = 1D;
            this.pictureEdit.ZoomOnMouseWheel = true;
            this.pictureEdit.DrawingBoardPaint += new System.Windows.Forms.PaintEventHandler(this.PictureEdit1Paint);
            this.pictureEdit.DrawingBoardMouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureEdit1MouseDown);
            this.pictureEdit.DrawingBoardMouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureEdit1MouseMove);
            this.pictureEdit.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureEdit1DragDrop);
            this.pictureEdit.DragOver += new System.Windows.Forms.DragEventHandler(this.PictureEdit1DragOver);
            this.pictureEdit.DragLeave += new System.EventHandler(this.PictureEdit1DragLeave);
            this.pictureEdit.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.PictureEdit1GiveFeedback);
            // 
            // imageListBoxControl1
            // 
            this.imageListBoxControl1.DisplayMember = "Name";
            resources.ApplyResources(this.imageListBoxControl1, "imageListBoxControl1");
            this.imageListBoxControl1.ImageIndexMember = "ImageIndex";
            this.imageListBoxControl1.ImageList = this.icDevices;
            this.imageListBoxControl1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem(((object)(resources.GetObject("imageListBoxControl1.Items"))))});
            this.imageListBoxControl1.Name = "imageListBoxControl1";
            this.imageListBoxControl1.ValueMember = "Id";
            this.imageListBoxControl1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.ImageListBoxControl1GiveFeedback);
            this.imageListBoxControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageListBoxControl1MouseDown);
            this.imageListBoxControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageListBoxControl1MouseMove);
            // 
            // icDevices
            // 
            resources.ApplyResources(this.icDevices, "icDevices");
            this.icDevices.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icDevices.ImageStream")));
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "OpenFileDialog1";
            resources.ApplyResources(this.ofdImage, "ofdImage");
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiOpenWeb,
            this.bbiOpenRadmin,
            this.bbiOpenRomViewer,
            this.bbiOpenMstsc,
            this.bbiPing,
            this.bbiTracert});
            this.barManager1.MaxItemId = 17;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // bbiOpenWeb
            // 
            resources.ApplyResources(this.bbiOpenWeb, "bbiOpenWeb");
            this.bbiOpenWeb.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_web_16;
            this.bbiOpenWeb.Id = 11;
            this.bbiOpenWeb.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_web_32;
            this.bbiOpenWeb.Name = "bbiOpenWeb";
            // 
            // bbiOpenRadmin
            // 
            resources.ApplyResources(this.bbiOpenRadmin, "bbiOpenRadmin");
            this.bbiOpenRadmin.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_radmin_16;
            this.bbiOpenRadmin.Id = 12;
            this.bbiOpenRadmin.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_radmin_32;
            this.bbiOpenRadmin.Name = "bbiOpenRadmin";
            // 
            // bbiOpenRomViewer
            // 
            resources.ApplyResources(this.bbiOpenRomViewer, "bbiOpenRomViewer");
            this.bbiOpenRomViewer.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_romviewer_16;
            this.bbiOpenRomViewer.Id = 13;
            this.bbiOpenRomViewer.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_romviewer_32;
            this.bbiOpenRomViewer.Name = "bbiOpenRomViewer";
            // 
            // bbiOpenMstsc
            // 
            resources.ApplyResources(this.bbiOpenMstsc, "bbiOpenMstsc");
            this.bbiOpenMstsc.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_mstsc_16;
            this.bbiOpenMstsc.Id = 14;
            this.bbiOpenMstsc.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_mstsc_32;
            this.bbiOpenMstsc.Name = "bbiOpenMstsc";
            // 
            // bbiPing
            // 
            resources.ApplyResources(this.bbiPing, "bbiPing");
            this.bbiPing.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_16;
            this.bbiPing.Id = 15;
            this.bbiPing.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_32;
            this.bbiPing.Name = "bbiPing";
            // 
            // bbiTracert
            // 
            resources.ApplyResources(this.bbiTracert, "bbiTracert");
            this.bbiTracert.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_16;
            this.bbiTracert.Id = 16;
            this.bbiTracert.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_32;
            this.bbiTracert.Name = "bbiTracert";
            // 
            // radialMenu1
            // 
            this.radialMenu1.AutoExpand = true;
            this.radialMenu1.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_32;
            this.radialMenu1.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring;
            this.radialMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenWeb),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenRadmin),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenRomViewer),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenMstsc),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPing),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiTracert)});
            this.radialMenu1.Manager = this.barManager1;
            this.radialMenu1.Name = "radialMenu1";
            // 
            // Maps
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Maps";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DrawingControl pictureEdit;
        private DevExpress.XtraEditors.ImageListBoxControl imageListBoxControl1;
        private DevExpress.Utils.ImageCollection icDevices;
        internal System.Windows.Forms.OpenFileDialog ofdImage;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiOpenWeb;
        private DevExpress.XtraBars.BarButtonItem bbiOpenRadmin;
        private DevExpress.XtraBars.BarButtonItem bbiOpenRomViewer;
        private DevExpress.XtraBars.BarButtonItem bbiOpenMstsc;
        private DevExpress.XtraBars.BarButtonItem bbiPing;
        private DevExpress.XtraBars.BarButtonItem bbiTracert;
        private DevExpress.XtraBars.Ribbon.RadialMenu radialMenu1;

    }
}
