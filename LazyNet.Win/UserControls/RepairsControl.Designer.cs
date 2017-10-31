namespace Dekart.LazyNet.Win.UserControls
{
    partial class RepairsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRepairType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riRepairType = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gcPlainText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riPlainText = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gebRepairs = new Dekart.LazyNet.GridEditBarControl();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riRepairType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPlainText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(0, 31);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riPlainText,
            this.riRepairType,
            this.repositoryItemButtonEdit1});
            this.gcMain.ShowOnlyPredefinedDetails = true;
            this.gcMain.Size = new System.Drawing.Size(849, 329);
            this.gcMain.TabIndex = 1;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCreatedOn,
            this.gcRepairType,
            this.gcPlainText,
            this.gcCustomer,
            this.gcAmount});
            this.gvMain.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.GroupFormat = "[#image]{1} {2}";
            this.gvMain.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Subject", null, "({0} items)")});
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gvMain.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvMain.OptionsCustomization.AllowFilter = false;
            this.gvMain.OptionsCustomization.AllowGroup = false;
            this.gvMain.OptionsFind.AllowFindPanel = false;
            this.gvMain.OptionsPrint.PrintHorzLines = false;
            this.gvMain.OptionsPrint.PrintVertLines = false;
            this.gvMain.OptionsView.RowAutoHeight = true;
            this.gvMain.OptionsView.ShowFooter = true;
            this.gvMain.OptionsView.ShowGroupedColumns = true;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            this.gvMain.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvMain.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvMain.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcCreatedOn, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvMain.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvMain_RowCellClick);
            this.gvMain.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvMain_CellValueChanged);
            this.gvMain.RowCountChanged += new System.EventHandler(this.gvMain_RowCountChanged);
            // 
            // gcCreatedOn
            // 
            this.gcCreatedOn.Caption = "ДАТА";
            this.gcCreatedOn.DisplayFormat.FormatString = "d";
            this.gcCreatedOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreatedOn.FieldName = "CreatedOn";
            this.gcCreatedOn.Name = "gcCreatedOn";
            this.gcCreatedOn.OptionsColumn.AllowEdit = false;
            this.gcCreatedOn.OptionsColumn.AllowMove = false;
            this.gcCreatedOn.OptionsColumn.AllowShowHide = false;
            this.gcCreatedOn.OptionsColumn.FixedWidth = true;
            this.gcCreatedOn.OptionsColumn.ReadOnly = true;
            this.gcCreatedOn.Tag = "ReadOnly";
            this.gcCreatedOn.Visible = true;
            this.gcCreatedOn.VisibleIndex = 0;
            this.gcCreatedOn.Width = 90;
            // 
            // gcRepairType
            // 
            this.gcRepairType.Caption = "ВИД РЕМОНТА";
            this.gcRepairType.ColumnEdit = this.riRepairType;
            this.gcRepairType.FieldName = "RepairType";
            this.gcRepairType.Name = "gcRepairType";
            this.gcRepairType.OptionsColumn.AllowEdit = false;
            this.gcRepairType.OptionsColumn.AllowMove = false;
            this.gcRepairType.OptionsColumn.AllowShowHide = false;
            this.gcRepairType.OptionsColumn.FixedWidth = true;
            this.gcRepairType.OptionsColumn.ReadOnly = true;
            this.gcRepairType.Tag = "ReadOnly";
            this.gcRepairType.Visible = true;
            this.gcRepairType.VisibleIndex = 1;
            this.gcRepairType.Width = 150;
            // 
            // riRepairType
            // 
            this.riRepairType.AutoHeight = false;
            this.riRepairType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riRepairType.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.riRepairType.Name = "riRepairType";
            // 
            // gcPlainText
            // 
            this.gcPlainText.Caption = "ЗАМЕТКИ";
            this.gcPlainText.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gcPlainText.FieldName = "PlainText";
            this.gcPlainText.Name = "gcPlainText";
            this.gcPlainText.OptionsColumn.AllowEdit = false;
            this.gcPlainText.OptionsColumn.AllowMove = false;
            this.gcPlainText.OptionsColumn.AllowShowHide = false;
            this.gcPlainText.OptionsColumn.ReadOnly = true;
            this.gcPlainText.Tag = "ReadOnly";
            this.gcPlainText.Visible = true;
            this.gcPlainText.VisibleIndex = 2;
            this.gcPlainText.Width = 287;
            // 
            // riPlainText
            // 
            this.riPlainText.Name = "riPlainText";
            // 
            // gcCustomer
            // 
            this.gcCustomer.Caption = "ОРГАНИЗАЦИЯ";
            this.gcCustomer.FieldName = "Customer";
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.OptionsColumn.AllowEdit = false;
            this.gcCustomer.OptionsColumn.AllowMove = false;
            this.gcCustomer.OptionsColumn.AllowShowHide = false;
            this.gcCustomer.OptionsColumn.FixedWidth = true;
            this.gcCustomer.OptionsColumn.ReadOnly = true;
            this.gcCustomer.Tag = "ReadOnly";
            this.gcCustomer.Visible = true;
            this.gcCustomer.VisibleIndex = 3;
            this.gcCustomer.Width = 200;
            // 
            // gcAmount
            // 
            this.gcAmount.Caption = "СТОИМОСТЬ";
            this.gcAmount.DisplayFormat.FormatString = "c";
            this.gcAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcAmount.FieldName = "Amount";
            this.gcAmount.Name = "gcAmount";
            this.gcAmount.OptionsColumn.AllowEdit = false;
            this.gcAmount.OptionsColumn.AllowMove = false;
            this.gcAmount.OptionsColumn.AllowShowHide = false;
            this.gcAmount.OptionsColumn.FixedWidth = true;
            this.gcAmount.OptionsColumn.ReadOnly = true;
            this.gcAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:c2}")});
            this.gcAmount.Tag = "ReadOnly";
            this.gcAmount.Visible = true;
            this.gcAmount.VisibleIndex = 4;
            this.gcAmount.Width = 110;
            // 
            // gebRepairs
            // 
            this.gebRepairs.Dock = System.Windows.Forms.DockStyle.Top;
            this.gebRepairs.Location = new System.Drawing.Point(0, 0);
            this.gebRepairs.Name = "gebRepairs";
            this.gebRepairs.Size = new System.Drawing.Size(849, 31);
            this.gebRepairs.TabIndex = 0;
            this.gebRepairs.AddRecord += new System.EventHandler(this.gebRepairs_AddRecord);
            this.gebRepairs.DeleteRecord += new System.EventHandler(this.gebRepairs_DeleteRecord);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // RepairsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcMain);
            this.Controls.Add(this.gebRepairs);
            this.Name = "RepairsControl";
            this.Size = new System.Drawing.Size(849, 360);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riRepairType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPlainText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn gcRepairType;
        private DevExpress.XtraGrid.Columns.GridColumn gcPlainText;
        private DevExpress.XtraGrid.Columns.GridColumn gcCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gcAmount;
        private GridEditBarControl gebRepairs;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit riPlainText;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riRepairType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}
