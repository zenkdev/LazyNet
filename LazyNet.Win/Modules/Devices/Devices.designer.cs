namespace Dekart.LazyNet.Win.Modules {
    partial class Devices {
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
            this.gcIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDeviceType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvList = new Dekart.LazyNet.Win.MyGridView();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSerial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDeviceState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDeviceState = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcBuyedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMAC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpdatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDeviceType1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.ucDeviceView = new Dekart.LazyNet.Win.Modules.DeviceView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
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
            this.bbiSystemInfo = new DevExpress.XtraBars.BarButtonItem();
            this.radialMenu1 = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcIcon
            // 
            this.gcIcon.Caption = "ТИП";
            this.gcIcon.ColumnEdit = this.riDeviceType;
            this.gcIcon.FieldName = "DeviceType";
            this.gcIcon.Image = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_16;
            this.gcIcon.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gcIcon.Name = "gcIcon";
            this.gcIcon.OptionsColumn.AllowEdit = false;
            this.gcIcon.OptionsColumn.AllowFocus = false;
            this.gcIcon.OptionsColumn.AllowSize = false;
            this.gcIcon.OptionsColumn.FixedWidth = true;
            this.gcIcon.OptionsColumn.ShowCaption = false;
            this.gcIcon.ToolTip = "Тип устройства";
            this.gcIcon.Visible = true;
            this.gcIcon.VisibleIndex = 0;
            this.gcIcon.Width = 47;
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
            // gcMain
            // 
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(0, 0);
            this.gcMain.MainView = this.gvList;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.riDeviceState,
            this.riDeviceType,
            this.riDeviceType1});
            this.gcMain.ShowOnlyPredefinedDetails = true;
            this.gcMain.Size = new System.Drawing.Size(595, 500);
            this.gcMain.TabIndex = 0;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIcon,
            this.gcName,
            this.gcSKU,
            this.gcSerial,
            this.gcSpecification,
            this.gcUser,
            this.gcDeviceState,
            this.gcBuyedOn,
            this.gcHostName,
            this.gcIP,
            this.gcMAC,
            this.gcRoom,
            this.gcCreatedOn,
            this.gcUpdatedOn});
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvList.GridControl = this.gcMain;
            this.gvList.GroupCount = 1;
            this.gvList.GroupFormat = "[#image]{1} {2}";
            this.gvList.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Id", null, "")});
            this.gvList.Name = "gvList";
            this.gvList.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvList.OptionsBehavior.AutoPopulateColumns = false;
            this.gvList.OptionsFind.AlwaysVisible = true;
            this.gvList.OptionsFind.ShowClearButton = false;
            this.gvList.OptionsFind.ShowFindButton = false;
            this.gvList.OptionsPrint.PrintHorzLines = false;
            this.gvList.OptionsPrint.PrintVertLines = false;
            this.gvList.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gvList.OptionsView.ShowGroupedColumns = true;
            this.gvList.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvList.OptionsView.ShowIndicator = false;
            this.gvList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvList.PreviewFieldName = "PlainText";
            this.gvList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcIcon, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvList_RowCellClick);
            this.gvList.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvList_PopupMenuShowing);
            this.gvList.ColumnPositionChanged += new System.EventHandler(this.gvList_ColumnPositionChanged);
            this.gvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvList_KeyDown);
            this.gvList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridView1MouseDown);
            this.gvList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridView1MouseMove);
            // 
            // gcName
            // 
            this.gcName.Caption = "УСТРОЙСТВО";
            this.gcName.FieldName = "Name";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowFocus = false;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 1;
            this.gcName.Width = 200;
            // 
            // gcSKU
            // 
            this.gcSKU.Caption = "ИНВЕНТАРНЫЙ №";
            this.gcSKU.FieldName = "SKU";
            this.gcSKU.Name = "gcSKU";
            this.gcSKU.OptionsColumn.AllowFocus = false;
            this.gcSKU.Visible = true;
            this.gcSKU.VisibleIndex = 2;
            this.gcSKU.Width = 100;
            // 
            // gcSerial
            // 
            this.gcSerial.Caption = "СЕРИЙНЫЙ №";
            this.gcSerial.FieldName = "Serial";
            this.gcSerial.Name = "gcSerial";
            this.gcSerial.OptionsColumn.AllowFocus = false;
            this.gcSerial.Visible = true;
            this.gcSerial.VisibleIndex = 3;
            this.gcSerial.Width = 100;
            // 
            // gcSpecification
            // 
            this.gcSpecification.Caption = "ХАРАКТЕРИСТИКИ";
            this.gcSpecification.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gcSpecification.FieldName = "Specification";
            this.gcSpecification.Name = "gcSpecification";
            this.gcSpecification.OptionsColumn.AllowFocus = false;
            this.gcSpecification.Visible = true;
            this.gcSpecification.VisibleIndex = 4;
            this.gcSpecification.Width = 250;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gcUser
            // 
            this.gcUser.AppearanceCell.BackColor = System.Drawing.Color.Yellow;
            this.gcUser.AppearanceCell.Options.UseBackColor = true;
            this.gcUser.Caption = "ВЛАДЕЛЕЦ";
            this.gcUser.FieldName = "User.FullName";
            this.gcUser.Name = "gcUser";
            this.gcUser.OptionsColumn.AllowFocus = false;
            this.gcUser.Visible = true;
            this.gcUser.VisibleIndex = 5;
            this.gcUser.Width = 150;
            // 
            // gcDeviceState
            // 
            this.gcDeviceState.Caption = "СТАТУС";
            this.gcDeviceState.ColumnEdit = this.riDeviceState;
            this.gcDeviceState.FieldName = "DeviceState";
            this.gcDeviceState.Name = "gcDeviceState";
            this.gcDeviceState.OptionsColumn.AllowFocus = false;
            this.gcDeviceState.Visible = true;
            this.gcDeviceState.VisibleIndex = 6;
            this.gcDeviceState.Width = 90;
            // 
            // riDeviceState
            // 
            this.riDeviceState.AutoHeight = false;
            this.riDeviceState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riDeviceState.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.riDeviceState.Name = "riDeviceState";
            // 
            // gcBuyedOn
            // 
            this.gcBuyedOn.Caption = "ДАТА ПОКУПКИ";
            this.gcBuyedOn.DisplayFormat.FormatString = "d";
            this.gcBuyedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcBuyedOn.FieldName = "BuyedOn";
            this.gcBuyedOn.Name = "gcBuyedOn";
            this.gcBuyedOn.OptionsColumn.AllowFocus = false;
            this.gcBuyedOn.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            this.gcBuyedOn.Visible = true;
            this.gcBuyedOn.VisibleIndex = 7;
            this.gcBuyedOn.Width = 90;
            // 
            // gcHostName
            // 
            this.gcHostName.Caption = "СЕТЕВОЕ ИМЯ";
            this.gcHostName.FieldName = "HostName";
            this.gcHostName.Name = "gcHostName";
            this.gcHostName.OptionsColumn.AllowFocus = false;
            this.gcHostName.Visible = true;
            this.gcHostName.VisibleIndex = 8;
            this.gcHostName.Width = 150;
            // 
            // gcIP
            // 
            this.gcIP.Caption = "IP АДРЕС";
            this.gcIP.FieldName = "IP";
            this.gcIP.FieldNameSortGroup = "IPInt";
            this.gcIP.Name = "gcIP";
            this.gcIP.OptionsColumn.AllowFocus = false;
            this.gcIP.Visible = true;
            this.gcIP.VisibleIndex = 9;
            this.gcIP.Width = 100;
            // 
            // gcMAC
            // 
            this.gcMAC.Caption = "MAC АДРЕС";
            this.gcMAC.FieldName = "MAC";
            this.gcMAC.Name = "gcMAC";
            this.gcMAC.OptionsColumn.AllowFocus = false;
            this.gcMAC.Visible = true;
            this.gcMAC.VisibleIndex = 10;
            this.gcMAC.Width = 100;
            // 
            // gcRoom
            // 
            this.gcRoom.AppearanceCell.BackColor = System.Drawing.Color.Yellow;
            this.gcRoom.AppearanceCell.Options.UseBackColor = true;
            this.gcRoom.Caption = "ПОМЕЩЕНИЕ";
            this.gcRoom.FieldName = "Room.Name";
            this.gcRoom.Name = "gcRoom";
            this.gcRoom.OptionsColumn.AllowFocus = false;
            // 
            // gcCreatedOn
            // 
            this.gcCreatedOn.Caption = "ДОБАВЛЕНО";
            this.gcCreatedOn.DisplayFormat.FormatString = "g";
            this.gcCreatedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreatedOn.FieldName = "CreatedOn";
            this.gcCreatedOn.Name = "gcCreatedOn";
            this.gcCreatedOn.OptionsColumn.AllowFocus = false;
            this.gcCreatedOn.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            // 
            // gcUpdatedOn
            // 
            this.gcUpdatedOn.Caption = "ИЗМЕНЕНО";
            this.gcUpdatedOn.DisplayFormat.FormatString = "g";
            this.gcUpdatedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcUpdatedOn.FieldName = "UpdatedOn";
            this.gcUpdatedOn.Name = "gcUpdatedOn";
            this.gcUpdatedOn.OptionsColumn.AllowFocus = false;
            this.gcUpdatedOn.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
            // 
            // riDeviceType1
            // 
            this.riDeviceType1.AutoHeight = false;
            this.riDeviceType1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riDeviceType1.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.riDeviceType1.Name = "riDeviceType1";
            // 
            // ucDeviceView
            // 
            this.ucDeviceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDeviceView.Location = new System.Drawing.Point(0, 0);
            this.ucDeviceView.Name = "ucDeviceView";
            this.ucDeviceView.ParentFormMain = null;
            this.ucDeviceView.Size = new System.Drawing.Size(400, 500);
            this.ucDeviceView.TabIndex = 1;
            this.ucDeviceView.ZoomFactor = 1F;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "LM-Viewer addess book (*.xml)|*.xml|Адресная книга Radmin (*.rpb)|*.rpb";
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            this.saveFileDialog1.Title = "Сохранить в файл";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gcMain);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.ucDeviceView);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(1000, 500);
            this.splitContainerControl.SplitterPosition = 400;
            this.splitContainerControl.TabIndex = 0;
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
            this.bbiTracert,
            this.bbiSystemInfo});
            this.barManager1.MaxItemId = 18;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1000, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 500);
            this.barDockControlBottom.Size = new System.Drawing.Size(1000, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 500);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1000, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 500);
            // 
            // bbiOpenWeb
            // 
            this.bbiOpenWeb.Caption = "HTTP";
            this.bbiOpenWeb.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_web_16;
            this.bbiOpenWeb.Id = 11;
            this.bbiOpenWeb.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_web_32;
            this.bbiOpenWeb.Name = "bbiOpenWeb";
            // 
            // bbiOpenRadmin
            // 
            this.bbiOpenRadmin.Caption = "Radmin";
            this.bbiOpenRadmin.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_radmin_16;
            this.bbiOpenRadmin.Id = 12;
            this.bbiOpenRadmin.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_radmin_32;
            this.bbiOpenRadmin.Name = "bbiOpenRadmin";
            // 
            // bbiOpenRomViewer
            // 
            this.bbiOpenRomViewer.Caption = "LM-Viewer";
            this.bbiOpenRomViewer.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_romviewer_16;
            this.bbiOpenRomViewer.Id = 13;
            this.bbiOpenRomViewer.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_romviewer_32;
            this.bbiOpenRomViewer.Name = "bbiOpenRomViewer";
            // 
            // bbiOpenMstsc
            // 
            this.bbiOpenMstsc.Caption = "RDP";
            this.bbiOpenMstsc.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_mstsc_16;
            this.bbiOpenMstsc.Id = 14;
            this.bbiOpenMstsc.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_mstsc_32;
            this.bbiOpenMstsc.Name = "bbiOpenMstsc";
            // 
            // bbiPing
            // 
            this.bbiPing.Caption = "Ping";
            this.bbiPing.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_16;
            this.bbiPing.Id = 15;
            this.bbiPing.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_32;
            this.bbiPing.Name = "bbiPing";
            // 
            // bbiTracert
            // 
            this.bbiTracert.Caption = "Tracert";
            this.bbiTracert.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_16;
            this.bbiTracert.Id = 16;
            this.bbiTracert.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_32;
            this.bbiTracert.Name = "bbiTracert";
            // 
            // bbiSystemInfo
            // 
            this.bbiSystemInfo.Caption = "System Info";
            this.bbiSystemInfo.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.info_32x32;
            this.bbiSystemInfo.Id = 17;
            this.bbiSystemInfo.Name = "bbiSystemInfo";
            // 
            // radialMenu1
            // 
            this.radialMenu1.AutoExpand = true;
            this.radialMenu1.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_32;
            this.radialMenu1.InnerRadius = 20;
            this.radialMenu1.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring;
            this.radialMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenWeb),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenRadmin),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenRomViewer),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpenMstsc),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPing),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiTracert),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSystemInfo)});
            this.radialMenu1.Manager = this.barManager1;
            this.radialMenu1.Name = "radialMenu1";
            // 
            // Devices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Devices";
            this.Size = new System.Drawing.Size(1000, 500);
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDeviceType1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMain;
        private DeviceView ucDeviceView;
        private DevExpress.XtraGrid.Columns.GridColumn gcIcon;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSerial;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpdatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn gcIP;
        private MyGridView gvList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraGrid.Columns.GridColumn gcMAC;
        private DevExpress.XtraGrid.Columns.GridColumn gcSKU;
        private DevExpress.XtraGrid.Columns.GridColumn gcSpecification;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gcHostName;
        private DevExpress.XtraGrid.Columns.GridColumn gcBuyedOn;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeviceState;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoom;
        private DevExpress.XtraGrid.Columns.GridColumn gcUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riDeviceState;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riDeviceType;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riDeviceType1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Ribbon.RadialMenu radialMenu1;
        private DevExpress.XtraBars.BarButtonItem bbiOpenWeb;
        private DevExpress.XtraBars.BarButtonItem bbiOpenRadmin;
        private DevExpress.XtraBars.BarButtonItem bbiOpenRomViewer;
        private DevExpress.XtraBars.BarButtonItem bbiOpenMstsc;
        private DevExpress.XtraBars.BarButtonItem bbiPing;
        private DevExpress.XtraBars.BarButtonItem bbiTracert;
        private DevExpress.XtraBars.BarButtonItem bbiSystemInfo;
    }
}
