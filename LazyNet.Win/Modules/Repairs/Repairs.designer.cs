using Dekart.LazyNet.Win.Controls;

namespace Dekart.LazyNet.Win.Modules {
    partial class Repairs {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repairs));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.xcRepairs = new DevExpress.Xpo.XPCollection(this.components);
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRepairType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riRepairType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcDevice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.xcDevices = new DevExpress.Xpo.XPCollection(this.components);
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Item1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Group1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xcRepairs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riRepairType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xcDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.AllowCustomization = false;
            this.lcMain.Controls.Add(this.gcMain);
            resources.ApplyResources(this.lcMain, "lcMain");
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(717, 447, 450, 350);
            this.lcMain.Root = this.layoutControlGroup1;
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.xcRepairs;
            resources.ApplyResources(this.gcMain, "gcMain");
            this.gcMain.MainView = this.gvList;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riRepairType});
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // xcRepairs
            // 
            this.xcRepairs.LoadingEnabled = false;
            this.xcRepairs.ObjectType = typeof(Dekart.LazyNet.Repair);
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCreatedOn,
            this.gcRepairType,
            this.gcDevice,
            this.gcCustomer,
            this.gcAmount,
            this.gcRoom});
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvList.GridControl = this.gcMain;
            this.gvList.GroupCount = 1;
            resources.ApplyResources(this.gvList, "gvList");
            this.gvList.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gvList.GroupSummary"))), resources.GetString("gvList.GroupSummary1"), ((DevExpress.XtraGrid.Columns.GridColumn)(resources.GetObject("gvList.GroupSummary2"))), resources.GetString("gvList.GroupSummary3"))});
            this.gvList.Name = "gvList";
            this.gvList.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvList.OptionsBehavior.AutoPopulateColumns = false;
            this.gvList.OptionsBehavior.Editable = false;
            this.gvList.OptionsDetail.EnableMasterViewMode = false;
            this.gvList.OptionsFind.AlwaysVisible = true;
            this.gvList.OptionsFind.ShowClearButton = false;
            this.gvList.OptionsFind.ShowFindButton = false;
            this.gvList.OptionsPrint.PrintHorzLines = false;
            this.gvList.OptionsPrint.PrintVertLines = false;
            this.gvList.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gvList.OptionsView.RowAutoHeight = true;
            this.gvList.OptionsView.ShowFooter = true;
            this.gvList.OptionsView.ShowGroupedColumns = true;
            this.gvList.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvList.OptionsView.ShowIndicator = false;
            this.gvList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvList.PreviewFieldName = "PlainText";
            this.gvList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcCreatedOn, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvList_RowCellClick);
            this.gvList.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gvList_FocusedRowObjectChanged);
            this.gvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvList_KeyDown);
            // 
            // gcCreatedOn
            // 
            resources.ApplyResources(this.gcCreatedOn, "gcCreatedOn");
            this.gcCreatedOn.DisplayFormat.FormatString = "d";
            this.gcCreatedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreatedOn.FieldName = "CreatedOn";
            this.gcCreatedOn.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateRange;
            this.gcCreatedOn.Name = "gcCreatedOn";
            this.gcCreatedOn.OptionsColumn.AllowEdit = false;
            this.gcCreatedOn.OptionsColumn.AllowMove = false;
            this.gcCreatedOn.OptionsColumn.FixedWidth = true;
            // 
            // gcRepairType
            // 
            resources.ApplyResources(this.gcRepairType, "gcRepairType");
            this.gcRepairType.ColumnEdit = this.riRepairType;
            this.gcRepairType.FieldName = "RepairType";
            this.gcRepairType.Name = "gcRepairType";
            this.gcRepairType.OptionsColumn.AllowEdit = false;
            // 
            // riRepairType
            // 
            resources.ApplyResources(this.riRepairType, "riRepairType");
            this.riRepairType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riRepairType.Buttons"))))});
            this.riRepairType.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.riRepairType.Name = "riRepairType";
            // 
            // gcDevice
            // 
            this.gcDevice.AppearanceCell.BackColor = ((System.Drawing.Color)(resources.GetObject("gcDevice.AppearanceCell.BackColor")));
            this.gcDevice.AppearanceCell.Options.UseBackColor = true;
            resources.ApplyResources(this.gcDevice, "gcDevice");
            this.gcDevice.FieldName = "Device.Name";
            this.gcDevice.Name = "gcDevice";
            this.gcDevice.OptionsColumn.AllowEdit = false;
            // 
            // gcCustomer
            // 
            resources.ApplyResources(this.gcCustomer, "gcCustomer");
            this.gcCustomer.FieldName = "Customer";
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.OptionsColumn.AllowEdit = false;
            // 
            // gcAmount
            // 
            resources.ApplyResources(this.gcAmount, "gcAmount");
            this.gcAmount.DisplayFormat.FormatString = "c";
            this.gcAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcAmount.FieldName = "Amount";
            this.gcAmount.Name = "gcAmount";
            this.gcAmount.OptionsColumn.AllowEdit = false;
            this.gcAmount.OptionsColumn.FixedWidth = true;
            this.gcAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gcAmount.Summary"))), resources.GetString("gcAmount.Summary1"), resources.GetString("gcAmount.Summary2"))});
            // 
            // gcRoom
            // 
            this.gcRoom.AppearanceCell.BackColor = ((System.Drawing.Color)(resources.GetObject("gcRoom.AppearanceCell.BackColor")));
            this.gcRoom.AppearanceCell.Options.UseBackColor = true;
            resources.ApplyResources(this.gcRoom, "gcRoom");
            this.gcRoom.FieldName = "Device.Room.Name";
            this.gcRoom.Name = "gcRoom";
            this.gcRoom.OptionsColumn.AllowEdit = false;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1041, 540);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcMain;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(1029, 528);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // xcDevices
            // 
            this.xcDevices.LoadingEnabled = false;
            this.xcDevices.ObjectType = typeof(Dekart.LazyNet.Device);
            // 
            // layoutViewCard1
            // 
            resources.ApplyResources(this.layoutViewCard1, "layoutViewCard1");
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Item1,
            this.emptySpaceItem1,
            this.Group1});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            // 
            // Item1
            // 
            this.Item1.AllowHotTrack = false;
            resources.ApplyResources(this.Item1, "Item1");
            this.Item1.Location = new System.Drawing.Point(0, 0);
            this.Item1.MaxSize = new System.Drawing.Size(0, 10);
            this.Item1.MinSize = new System.Drawing.Size(10, 10);
            this.Item1.Name = "Item1";
            this.Item1.Size = new System.Drawing.Size(266, 58);
            this.Item1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.Item1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 58);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 10);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 10);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(266, 52);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Group1
            // 
            resources.ApplyResources(this.Group1, "Group1");
            this.Group1.Location = new System.Drawing.Point(0, 110);
            this.Group1.Name = "Group1";
            this.Group1.Size = new System.Drawing.Size(266, 139);
            // 
            // Repairs
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "Repairs";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xcRepairs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riRepairType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xcDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.EmptySpaceItem Item1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup Group1;
        private DevExpress.Xpo.XPCollection xcRepairs;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn gcDevice;
        private DevExpress.XtraGrid.Columns.GridColumn gcRepairType;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gcAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riRepairType;
        private DevExpress.Xpo.XPCollection xcDevices;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoom;
    }
}
