namespace Dekart.LazyNet.Win.Modules {
    partial class Software
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Software));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.xcSoftware = new DevExpress.Xpo.XPCollection(this.components);
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSKU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuyedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiredOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAvailable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xcSoftware)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // lcMain
            // 
            this.lcMain.AllowCustomization = false;
            this.lcMain.Controls.Add(this.gcMain);
            resources.ApplyResources(this.lcMain, "lcMain");
            this.lcMain.LayoutVersion = "30062014";
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.layoutControlGroup1;
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.xcSoftware;
            resources.ApplyResources(this.gcMain, "gcMain");
            this.gcMain.MainView = this.gvList;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riTextEdit});
            this.gcMain.ShowOnlyPredefinedDetails = true;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            this.gcMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvList_KeyDown);
            // 
            // xcSoftware
            // 
            this.xcSoftware.LoadingEnabled = false;
            this.xcSoftware.ObjectType = typeof(Dekart.LazyNet.SoftwareObject);
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSKU,
            this.colName,
            this.colCompany,
            this.colBuyedOn,
            this.colExpiredOn,
            this.colSerial,
            this.colUsed,
            this.colAvailable,
            this.gridColumn1});
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = 0;
            this.gvList.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
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
            this.gvList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSKU, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvList_RowCellClick);
            this.gvList.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gvList_FocusedRowObjectChanged);
            // 
            // colSKU
            // 
            resources.ApplyResources(this.colSKU, "colSKU");
            this.colSKU.FieldName = "SKU";
            this.colSKU.Name = "colSKU";
            this.colSKU.OptionsColumn.AllowFocus = false;
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowFocus = false;
            // 
            // colCompany
            // 
            resources.ApplyResources(this.colCompany, "colCompany");
            this.colCompany.FieldName = "Company";
            this.colCompany.Name = "colCompany";
            this.colCompany.OptionsColumn.AllowFocus = false;
            // 
            // colBuyedOn
            // 
            resources.ApplyResources(this.colBuyedOn, "colBuyedOn");
            this.colBuyedOn.FieldName = "BuyedOn";
            this.colBuyedOn.Name = "colBuyedOn";
            this.colBuyedOn.OptionsColumn.AllowFocus = false;
            // 
            // colExpiredOn
            // 
            resources.ApplyResources(this.colExpiredOn, "colExpiredOn");
            this.colExpiredOn.FieldName = "ExpiredOn";
            this.colExpiredOn.Name = "colExpiredOn";
            this.colExpiredOn.OptionsColumn.AllowFocus = false;
            // 
            // colSerial
            // 
            resources.ApplyResources(this.colSerial, "colSerial");
            this.colSerial.FieldName = "Serial";
            this.colSerial.Name = "colSerial";
            this.colSerial.OptionsColumn.AllowFocus = false;
            // 
            // colUsed
            // 
            resources.ApplyResources(this.colUsed, "colUsed");
            this.colUsed.ColumnEdit = this.riTextEdit;
            this.colUsed.FieldName = "Used";
            this.colUsed.Name = "colUsed";
            this.colUsed.OptionsColumn.AllowFocus = false;
            // 
            // riTextEdit
            // 
            resources.ApplyResources(this.riTextEdit, "riTextEdit");
            this.riTextEdit.Name = "riTextEdit";
            this.riTextEdit.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.MinPowerSpinEdit_CustomDisplayText);
            // 
            // colAvailable
            // 
            resources.ApplyResources(this.colAvailable, "colAvailable");
            this.colAvailable.ColumnEdit = this.riTextEdit;
            this.colAvailable.FieldName = "Available";
            this.colAvailable.Name = "colAvailable";
            this.colAvailable.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = ((System.Drawing.Color)(resources.GetObject("gridColumn1.AppearanceCell.BackColor")));
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "Device.Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlGroup1.Size = new System.Drawing.Size(942, 434);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcMain;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(930, 422);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Software
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Name = "Software";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xcSoftware)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Xpo.XPCollection xcSoftware;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colSKU;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompany;
        private DevExpress.XtraGrid.Columns.GridColumn colBuyedOn;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiredOn;
        private DevExpress.XtraGrid.Columns.GridColumn colSerial;
        private DevExpress.XtraGrid.Columns.GridColumn colUsed;
        private DevExpress.XtraGrid.Columns.GridColumn colAvailable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riTextEdit;

    }
}
