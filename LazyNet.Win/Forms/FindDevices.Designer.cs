namespace Dekart.LazyNet.Win
{
    partial class FindDevices
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
            Dekart.LazyNet.IPv4Addr iPv4Addr1 = new Dekart.LazyNet.IPv4Addr();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindDevices));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.seThreads = new DevExpress.XtraEditors.SpinEdit();
            this.ipAddressTo = new Dekart.LazyNet.IPAddressEdit();
            this.ipAddressFrom = new Dekart.LazyNet.IPAddressEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDeviceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDeviceType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIPAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMACAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcManufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFrom = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTo = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.bvbiExit = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.rcMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFind = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImportManufacturers = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAddDevice = new DevExpress.XtraBars.BarButtonItem();
            this.beiProgressBar = new DevExpress.XtraBars.BarEditItem();
            this.riProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.bsiInfo = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.bwAddDevice = new System.ComponentModel.BackgroundWorker();
            this.bwImport = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seThreads.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riProgressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.AllowCustomization = false;
            this.lcMain.Controls.Add(this.seThreads);
            this.lcMain.Controls.Add(this.ipAddressTo);
            this.lcMain.Controls.Add(this.ipAddressFrom);
            this.lcMain.Controls.Add(this.gridControl);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.LayoutVersion = "26122014";
            this.lcMain.Location = new System.Drawing.Point(0, 143);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1032, 254, 250, 350);
            this.lcMain.Root = this.lcgRoot;
            this.lcMain.Size = new System.Drawing.Size(967, 456);
            this.lcMain.TabIndex = 0;
            // 
            // seThreads
            // 
            this.seThreads.EditValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.seThreads.Location = new System.Drawing.Point(12, 144);
            this.seThreads.Name = "seThreads";
            this.seThreads.Properties.Appearance.Options.UseTextOptions = true;
            this.seThreads.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.seThreads.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seThreads.Properties.IsFloatValue = false;
            this.seThreads.Properties.Mask.EditMask = "N00";
            this.seThreads.Properties.MaxValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.seThreads.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seThreads.Size = new System.Drawing.Size(164, 20);
            this.seThreads.StyleController = this.lcMain;
            this.seThreads.TabIndex = 3;
            // 
            // ipAddressTo
            // 
            this.ipAddressTo.EditValue = iPv4Addr1;
            this.ipAddressTo.IPAddress = "";
            this.ipAddressTo.Location = new System.Drawing.Point(12, 86);
            this.ipAddressTo.Name = "ipAddressTo";
            this.ipAddressTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ipAddressTo.Properties.DisplayFormat.FormatString = "d.h.m.s";
            this.ipAddressTo.Properties.EditFormat.FormatString = "d.h.m.s";
            this.ipAddressTo.Properties.Mask.EditMask = "d.h.m.s";
            this.ipAddressTo.Size = new System.Drawing.Size(164, 20);
            this.ipAddressTo.StyleController = this.lcMain;
            this.ipAddressTo.TabIndex = 2;
            // 
            // ipAddressFrom
            // 
            this.ipAddressFrom.EditValue = iPv4Addr1;
            this.ipAddressFrom.IPAddress = "";
            this.ipAddressFrom.Location = new System.Drawing.Point(12, 28);
            this.ipAddressFrom.Name = "ipAddressFrom";
            this.ipAddressFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ipAddressFrom.Properties.DisplayFormat.FormatString = "d.h.m.s";
            this.ipAddressFrom.Properties.EditFormat.FormatString = "d.h.m.s";
            this.ipAddressFrom.Properties.Mask.EditMask = "d.h.m.s";
            this.ipAddressFrom.Size = new System.Drawing.Size(164, 20);
            this.ipAddressFrom.StyleController = this.lcMain;
            this.ipAddressFrom.TabIndex = 0;
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.Location = new System.Drawing.Point(180, 12);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riDeviceType});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(775, 432);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDeviceType,
            this.gcName,
            this.gcHostName,
            this.gcIPAddress,
            this.gcMACAddress,
            this.gcManufacturer});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableFooterMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIPAddress, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_RowCellStyle);
            this.gridView.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView_CustomColumnSort);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // gcDeviceType
            // 
            this.gcDeviceType.Caption = "ТИП";
            this.gcDeviceType.ColumnEdit = this.riDeviceType;
            this.gcDeviceType.FieldName = "DeviceType";
            this.gcDeviceType.Image = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_16;
            this.gcDeviceType.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gcDeviceType.Name = "gcDeviceType";
            this.gcDeviceType.OptionsColumn.AllowSize = false;
            this.gcDeviceType.OptionsColumn.FixedWidth = true;
            this.gcDeviceType.OptionsColumn.ShowCaption = false;
            this.gcDeviceType.Visible = true;
            this.gcDeviceType.VisibleIndex = 1;
            this.gcDeviceType.Width = 47;
            // 
            // riDeviceType
            // 
            this.riDeviceType.AutoHeight = false;
            this.riDeviceType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riDeviceType.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.riDeviceType.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.riDeviceType.Name = "riDeviceType";
            // 
            // gcName
            // 
            this.gcName.Caption = "УСТРОЙСТВО";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.OptionsColumn.AllowFocus = false;
            this.gcName.OptionsColumn.ReadOnly = true;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 2;
            this.gcName.Width = 182;
            // 
            // gcHostName
            // 
            this.gcHostName.Caption = "СЕТЕВОЕ ИМЯ";
            this.gcHostName.FieldName = "HostName";
            this.gcHostName.Name = "gcHostName";
            this.gcHostName.OptionsColumn.AllowFocus = false;
            this.gcHostName.OptionsColumn.ReadOnly = true;
            this.gcHostName.Visible = true;
            this.gcHostName.VisibleIndex = 3;
            this.gcHostName.Width = 244;
            // 
            // gcIPAddress
            // 
            this.gcIPAddress.Caption = "IP АДРЕС";
            this.gcIPAddress.FieldName = "IP";
            this.gcIPAddress.Name = "gcIPAddress";
            this.gcIPAddress.OptionsColumn.AllowFocus = false;
            this.gcIPAddress.OptionsColumn.ReadOnly = true;
            this.gcIPAddress.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gcIPAddress.Visible = true;
            this.gcIPAddress.VisibleIndex = 4;
            // 
            // gcMACAddress
            // 
            this.gcMACAddress.Caption = "MAC АДРЕС";
            this.gcMACAddress.FieldName = "MAC";
            this.gcMACAddress.Name = "gcMACAddress";
            this.gcMACAddress.OptionsColumn.AllowFocus = false;
            this.gcMACAddress.OptionsColumn.ReadOnly = true;
            this.gcMACAddress.Visible = true;
            this.gcMACAddress.VisibleIndex = 5;
            // 
            // gcManufacturer
            // 
            this.gcManufacturer.Caption = "ПРОИЗВОДИТЕЛЬ";
            this.gcManufacturer.FieldName = "Manufacturer";
            this.gcManufacturer.Name = "gcManufacturer";
            this.gcManufacturer.OptionsColumn.AllowFocus = false;
            this.gcManufacturer.OptionsColumn.ReadOnly = true;
            this.gcManufacturer.Visible = true;
            this.gcManufacturer.VisibleIndex = 6;
            // 
            // lcgRoot
            // 
            this.lcgRoot.CustomizationFormText = "lcgRoot";
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGrid,
            this.lciFrom,
            this.lciTo,
            this.emptySpaceItem3,
            this.layoutControlItem3});
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Size = new System.Drawing.Size(967, 456);
            this.lcgRoot.TextVisible = false;
            // 
            // lciGrid
            // 
            this.lciGrid.Control = this.gridControl;
            this.lciGrid.CustomizationFormText = "lciGrid";
            this.lciGrid.Location = new System.Drawing.Point(168, 0);
            this.lciGrid.Name = "lciGrid";
            this.lciGrid.Size = new System.Drawing.Size(779, 436);
            this.lciGrid.TextSize = new System.Drawing.Size(0, 0);
            this.lciGrid.TextVisible = false;
            // 
            // lciFrom
            // 
            this.lciFrom.Control = this.ipAddressFrom;
            this.lciFrom.Location = new System.Drawing.Point(0, 0);
            this.lciFrom.MaxSize = new System.Drawing.Size(168, 58);
            this.lciFrom.MinSize = new System.Drawing.Size(168, 58);
            this.lciFrom.Name = "lciFrom";
            this.lciFrom.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 20);
            this.lciFrom.Size = new System.Drawing.Size(168, 58);
            this.lciFrom.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciFrom.Text = "Начальный адрес";
            this.lciFrom.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciFrom.TextSize = new System.Drawing.Size(105, 13);
            // 
            // lciTo
            // 
            this.lciTo.Control = this.ipAddressTo;
            this.lciTo.Location = new System.Drawing.Point(0, 58);
            this.lciTo.MaxSize = new System.Drawing.Size(168, 58);
            this.lciTo.MinSize = new System.Drawing.Size(168, 58);
            this.lciTo.Name = "lciTo";
            this.lciTo.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 20);
            this.lciTo.Size = new System.Drawing.Size(168, 58);
            this.lciTo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTo.Text = "Конечный адрес";
            this.lciTo.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciTo.TextSize = new System.Drawing.Size(105, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 174);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(168, 262);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.seThreads;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(168, 58);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(168, 58);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 20);
            this.layoutControlItem3.Size = new System.Drawing.Size(168, 58);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Количество потоков";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(105, 13);
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Items.Add(this.bvbiExit);
            this.backstageViewControl1.Location = new System.Drawing.Point(250, 150);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.Ribbon = this.rcMain;
            this.backstageViewControl1.SelectedTab = null;
            this.backstageViewControl1.Size = new System.Drawing.Size(573, 431);
            this.backstageViewControl1.TabIndex = 3;
            this.backstageViewControl1.Text = "backstageViewControl1";
            // 
            // bvbiExit
            // 
            this.bvbiExit.Caption = "Выход";
            this.bvbiExit.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_delete_16;
            this.bvbiExit.Name = "bvbiExit";
            this.bvbiExit.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.bvbiExit_ItemClick);
            // 
            // rcMain
            // 
            this.rcMain.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.rcMain.ExpandCollapseItem.Id = 0;
            this.rcMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcMain.ExpandCollapseItem,
            this.bbiClose,
            this.bbiFind,
            this.bbiImportManufacturers,
            this.bbiAddDevice,
            this.beiProgressBar,
            this.bsiInfo});
            this.rcMain.Location = new System.Drawing.Point(0, 0);
            this.rcMain.MaxItemId = 7;
            this.rcMain.Name = "rcMain";
            this.rcMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.rcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riProgressBar});
            this.rcMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.rcMain.Size = new System.Drawing.Size(967, 143);
            this.rcMain.StatusBar = this.ribbonStatusBar1;
            this.rcMain.Toolbar.ItemLinks.Add(this.bbiFind);
            this.rcMain.Toolbar.ItemLinks.Add(this.bbiClose);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Закрыть окно";
            this.bbiClose.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiClose.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_close_16;
            this.bbiClose.Id = 1;
            this.bbiClose.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_close_32;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bbiFind
            // 
            this.bbiFind.Caption = "Найти устройства";
            this.bbiFind.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFind.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_network_find_16;
            this.bbiFind.Id = 2;
            this.bbiFind.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_network_find_32;
            this.bbiFind.Name = "bbiFind";
            this.bbiFind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFind_ItemClick);
            // 
            // bbiImportManufacturers
            // 
            this.bbiImportManufacturers.Caption = "Загрузить производителей";
            this.bbiImportManufacturers.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiImportManufacturers.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_import_16;
            this.bbiImportManufacturers.Id = 3;
            this.bbiImportManufacturers.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_import_32;
            this.bbiImportManufacturers.Name = "bbiImportManufacturers";
            toolTipItem1.Text = "Загрузить список организаций из Интернета";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiImportManufacturers.SuperTip = superToolTip1;
            this.bbiImportManufacturers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImportManufacturers_ItemClick);
            // 
            // bbiAddDevice
            // 
            this.bbiAddDevice.Caption = "Добавить устройства";
            this.bbiAddDevice.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiAddDevice.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAddDevice.Glyph")));
            this.bbiAddDevice.Id = 4;
            this.bbiAddDevice.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAddDevice.LargeGlyph")));
            this.bbiAddDevice.Name = "bbiAddDevice";
            this.bbiAddDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddDevice_ItemClick);
            // 
            // beiProgressBar
            // 
            this.beiProgressBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.beiProgressBar.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.beiProgressBar.Edit = this.riProgressBar;
            this.beiProgressBar.Id = 5;
            this.beiProgressBar.Name = "beiProgressBar";
            this.beiProgressBar.Width = 150;
            // 
            // riProgressBar
            // 
            this.riProgressBar.Name = "riProgressBar";
            this.riProgressBar.ShowTitle = true;
            // 
            // bsiInfo
            // 
            this.bsiInfo.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.bsiInfo.Id = 6;
            this.bsiInfo.Name = "bsiInfo";
            this.bsiInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ГЛАВНАЯ";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiFind);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAddDevice);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiImportManufacturers, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Действия";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Окно";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.beiProgressBar);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsiInfo);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 599);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.rcMain;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(967, 31);
            // 
            // bwAddDevice
            // 
            this.bwAddDevice.WorkerReportsProgress = true;
            this.bwAddDevice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwAddDevice_DoWork);
            this.bwAddDevice.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwAddDevice_ProgressChanged);
            this.bwAddDevice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwAddDevice_RunWorkerCompleted);
            // 
            // bwImport
            // 
            this.bwImport.WorkerReportsProgress = true;
            this.bwImport.WorkerSupportsCancellation = true;
            this.bwImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImport_DoWork);
            this.bwImport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwImport_ProgressChanged);
            this.bwImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwImport_RunWorkerCompleted);
            // 
            // FindDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 630);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.lcMain);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.rcMain);
            this.Name = "FindDevices";
            this.Ribbon = this.rcMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Поиск устройств в сети";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seThreads.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddressFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riProgressBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraLayout.LayoutControlItem lciGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeviceType;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcIPAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcManufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn gcMACAddress;
        private IPAddressEdit ipAddressFrom;
        private DevExpress.XtraLayout.LayoutControlItem lciFrom;
        private IPAddressEdit ipAddressTo;
        private DevExpress.XtraLayout.LayoutControlItem lciTo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SpinEdit seThreads;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private System.ComponentModel.BackgroundWorker bwAddDevice;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riDeviceType;
        private DevExpress.XtraBars.Ribbon.RibbonControl rcMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiFind;
        private DevExpress.XtraBars.BarButtonItem bbiImportManufacturers;
        private DevExpress.XtraBars.BarButtonItem bbiAddDevice;
        private DevExpress.XtraBars.BarEditItem beiProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar riProgressBar;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem bsiInfo;
        private System.ComponentModel.BackgroundWorker bwImport;
        private DevExpress.XtraGrid.Columns.GridColumn gcHostName;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbiExit;
    }
}