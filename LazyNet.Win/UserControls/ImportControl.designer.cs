namespace Dekart.LazyNet.Win.UserControls {
    partial class ImportControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ImportButton = new DevExpress.XtraEditors.SimpleButton();
            this.teDomain = new DevExpress.XtraEditors.TextEdit();
            this.refreshButton = new DevExpress.XtraEditors.SimpleButton();
            this.backstageViewLabel1 = new BackstageViewLabel();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciImportLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrinter = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciImportButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciRefreshButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDeviceType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOperatingSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManagedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDomain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrinter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRefreshButton)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.layoutControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlControl);
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ImportButton);
            this.layoutControl1.Controls.Add(this.teDomain);
            this.layoutControl1.Controls.Add(this.refreshButton);
            this.layoutControl1.Controls.Add(this.backstageViewLabel1);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(784, 204, 648, 350);
            this.layoutControl1.Root = this.Root;
            // 
            // ImportButton
            // 
            this.ImportButton.Image = ((System.Drawing.Image)(resources.GetObject("ImportButton.Image")));
            this.ImportButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            resources.ApplyResources(this.ImportButton, "ImportButton");
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.StyleController = this.layoutControl1;
            this.ImportButton.Click += new System.EventHandler(this.ImportButtonClick);
            // 
            // teDomain
            // 
            resources.ApplyResources(this.teDomain, "teDomain");
            this.teDomain.Name = "teDomain";
            this.teDomain.Properties.Appearance.Options.UseTextOptions = true;
            this.teDomain.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.teDomain.StyleController = this.layoutControl1;
            // 
            // refreshButton
            // 
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            resources.ApplyResources(this.refreshButton, "refreshButton");
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.StyleController = this.layoutControl1;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // backstageViewLabel1
            // 
            this.backstageViewLabel1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backstageViewLabel1.Appearance.Font")));
            resources.ApplyResources(this.backstageViewLabel1, "backstageViewLabel1");
            this.backstageViewLabel1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.backstageViewLabel1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.backstageViewLabel1.LineVisible = true;
            this.backstageViewLabel1.Name = "backstageViewLabel1";
            this.backstageViewLabel1.ShowLineShadow = false;
            this.backstageViewLabel1.StyleController = this.layoutControl1;
            // 
            // Root
            // 
            resources.ApplyResources(this.Root, "Root");
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciImportLabel,
            this.lciPrinter,
            this.emptySpaceItem1,
            this.lciImportButton,
            this.emptySpaceItem3,
            this.lciRefreshButton});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(325, 600);
            this.Root.TextVisible = false;
            // 
            // lciImportLabel
            // 
            this.lciImportLabel.Control = this.backstageViewLabel1;
            resources.ApplyResources(this.lciImportLabel, "lciImportLabel");
            this.lciImportLabel.Location = new System.Drawing.Point(86, 0);
            this.lciImportLabel.MaxSize = new System.Drawing.Size(0, 36);
            this.lciImportLabel.MinSize = new System.Drawing.Size(14, 36);
            this.lciImportLabel.Name = "lciImportLabel";
            this.lciImportLabel.Size = new System.Drawing.Size(219, 36);
            this.lciImportLabel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciImportLabel.TextSize = new System.Drawing.Size(0, 0);
            this.lciImportLabel.TextVisible = false;
            // 
            // lciPrinter
            // 
            this.lciPrinter.Control = this.teDomain;
            resources.ApplyResources(this.lciPrinter, "lciPrinter");
            this.lciPrinter.Location = new System.Drawing.Point(86, 36);
            this.lciPrinter.Name = "lciPrinter";
            this.lciPrinter.Size = new System.Drawing.Size(219, 44);
            this.lciPrinter.TextSize = new System.Drawing.Size(0, 0);
            this.lciPrinter.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 80);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(305, 420);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciImportButton
            // 
            this.lciImportButton.Control = this.ImportButton;
            resources.ApplyResources(this.lciImportButton, "lciImportButton");
            this.lciImportButton.Location = new System.Drawing.Point(0, 500);
            this.lciImportButton.MaxSize = new System.Drawing.Size(86, 80);
            this.lciImportButton.MinSize = new System.Drawing.Size(86, 80);
            this.lciImportButton.Name = "lciImportButton";
            this.lciImportButton.Size = new System.Drawing.Size(86, 80);
            this.lciImportButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciImportButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciImportButton.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem3, "emptySpaceItem3");
            this.emptySpaceItem3.Location = new System.Drawing.Point(86, 500);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(219, 80);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciRefreshButton
            // 
            this.lciRefreshButton.Control = this.refreshButton;
            resources.ApplyResources(this.lciRefreshButton, "lciRefreshButton");
            this.lciRefreshButton.Location = new System.Drawing.Point(0, 0);
            this.lciRefreshButton.MaxSize = new System.Drawing.Size(86, 80);
            this.lciRefreshButton.MinSize = new System.Drawing.Size(86, 80);
            this.lciRefreshButton.Name = "lciRefreshButton";
            this.lciRefreshButton.Size = new System.Drawing.Size(86, 80);
            this.lciRefreshButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciRefreshButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciRefreshButton.TextVisible = false;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.gridControl1);
            resources.ApplyResources(this.pnlControl, "pnlControl");
            this.pnlControl.Name = "pnlControl";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riDeviceType});
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIcon,
            this.gcName,
            this.gcRoom,
            this.gcHostName,
            this.gcOperatingSystem,
            this.gcManagedBy});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIcon, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView1_CustomColumnSort);
            // 
            // gcIcon
            // 
            this.gcIcon.ColumnEdit = this.riDeviceType;
            this.gcIcon.FieldName = "DeviceType";
            this.gcIcon.Name = "gcIcon";
            this.gcIcon.OptionsColumn.AllowEdit = false;
            this.gcIcon.OptionsColumn.AllowFocus = false;
            this.gcIcon.OptionsColumn.AllowSize = false;
            this.gcIcon.OptionsColumn.FixedWidth = true;
            this.gcIcon.OptionsColumn.ShowCaption = false;
            this.gcIcon.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            resources.ApplyResources(this.gcIcon, "gcIcon");
            // 
            // riDeviceType
            // 
            resources.ApplyResources(this.riDeviceType, "riDeviceType");
            this.riDeviceType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riDeviceType.Buttons"))))});
            this.riDeviceType.Name = "riDeviceType";
            // 
            // gcName
            // 
            resources.ApplyResources(this.gcName, "gcName");
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.OptionsColumn.AllowFocus = false;
            this.gcName.OptionsColumn.ReadOnly = true;
            // 
            // gcRoom
            // 
            resources.ApplyResources(this.gcRoom, "gcRoom");
            this.gcRoom.FieldName = "Room";
            this.gcRoom.Name = "gcRoom";
            this.gcRoom.OptionsColumn.AllowEdit = false;
            this.gcRoom.OptionsColumn.AllowFocus = false;
            this.gcRoom.OptionsColumn.ReadOnly = true;
            // 
            // gcHostName
            // 
            resources.ApplyResources(this.gcHostName, "gcHostName");
            this.gcHostName.FieldName = "HostName";
            this.gcHostName.Name = "gcHostName";
            this.gcHostName.OptionsColumn.AllowEdit = false;
            this.gcHostName.OptionsColumn.AllowFocus = false;
            this.gcHostName.OptionsColumn.ReadOnly = true;
            // 
            // gcOperatingSystem
            // 
            resources.ApplyResources(this.gcOperatingSystem, "gcOperatingSystem");
            this.gcOperatingSystem.FieldName = "OperatingSystem";
            this.gcOperatingSystem.Name = "gcOperatingSystem";
            this.gcOperatingSystem.OptionsColumn.AllowEdit = false;
            this.gcOperatingSystem.OptionsColumn.AllowFocus = false;
            this.gcOperatingSystem.OptionsColumn.ReadOnly = true;
            // 
            // gcManagedBy
            // 
            resources.ApplyResources(this.gcManagedBy, "gcManagedBy");
            this.gcManagedBy.FieldName = "ManagedBy";
            this.gcManagedBy.Name = "gcManagedBy";
            this.gcManagedBy.OptionsColumn.AllowEdit = false;
            this.gcManagedBy.OptionsColumn.AllowFocus = false;
            this.gcManagedBy.OptionsColumn.ReadOnly = true;
            // 
            // ImportControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImportControl";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teDomain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrinter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciImportButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRefreshButton)).EndInit();
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SimpleButton refreshButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private BackstageViewLabel backstageViewLabel1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lciRefreshButton;
        private DevExpress.XtraLayout.LayoutControlItem lciImportLabel;
        private DevExpress.XtraEditors.TextEdit teDomain;
        private DevExpress.XtraLayout.LayoutControlItem lciPrinter;
        private System.Windows.Forms.Panel pnlControl;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcHostName;
        private DevExpress.XtraGrid.Columns.GridColumn gcOperatingSystem;
        private DevExpress.XtraGrid.Columns.GridColumn gcManagedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoom;
        private DevExpress.XtraEditors.SimpleButton ImportButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciImportButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gcIcon;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riDeviceType;
    }
}
