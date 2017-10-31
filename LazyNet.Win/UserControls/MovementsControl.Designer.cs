namespace Dekart.LazyNet.Win.UserControls
{
    partial class MovementsControl
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
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCreatedOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOldRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNewRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcOldUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNewUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridEditBar = new GridEditBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMain
            // 
            this.gcMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(0, 31);
            this.gcMain.MainView = this.gvList;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gcMain.ShowOnlyPredefinedDetails = true;
            this.gcMain.Size = new System.Drawing.Size(849, 329);
            this.gcMain.TabIndex = 1;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList});
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCreatedOn,
            this.gcOldRoom,
            this.gcNewRoom,
            this.gcOldUser,
            this.gcNewUser,
            this.gcNote});
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvList.GridControl = this.gcMain;
            this.gvList.GroupFormat = "[#image]{1} {2}";
            this.gvList.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Subject", null, "({0} items)")});
            this.gvList.Name = "gvList";
            this.gvList.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvList.OptionsCustomization.AllowFilter = false;
            this.gvList.OptionsCustomization.AllowGroup = false;
            this.gvList.OptionsFind.AllowFindPanel = false;
            this.gvList.OptionsMenu.EnableFooterMenu = false;
            this.gvList.OptionsPrint.PrintHorzLines = false;
            this.gvList.OptionsPrint.PrintVertLines = false;
            this.gvList.OptionsView.RowAutoHeight = true;
            this.gvList.OptionsView.ShowGroupedColumns = true;
            this.gvList.OptionsView.ShowGroupPanel = false;
            this.gvList.OptionsView.ShowIndicator = false;
            this.gvList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcCreatedOn, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvList_RowCellClick);
            this.gvList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvList_CellValueChanged);
            this.gvList.RowCountChanged += new System.EventHandler(this.gvList_RowCountChanged);
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
            this.gcCreatedOn.Width = 100;
            // 
            // gcOldRoom
            // 
            this.gcOldRoom.Caption = "СТАРОЕ ПОМЕЩЕНИЕ";
            this.gcOldRoom.FieldName = "OldRoom.Name";
            this.gcOldRoom.Name = "gcOldRoom";
            this.gcOldRoom.OptionsColumn.AllowEdit = false;
            this.gcOldRoom.OptionsColumn.AllowMove = false;
            this.gcOldRoom.OptionsColumn.AllowShowHide = false;
            this.gcOldRoom.OptionsColumn.ReadOnly = true;
            this.gcOldRoom.Tag = "ReadOnly";
            this.gcOldRoom.Visible = true;
            this.gcOldRoom.VisibleIndex = 1;
            this.gcOldRoom.Width = 150;
            // 
            // gcNewRoom
            // 
            this.gcNewRoom.Caption = "НОВОЕ ПОМЕЩЕНИЕ";
            this.gcNewRoom.FieldName = "NewRoom.Name";
            this.gcNewRoom.Name = "gcNewRoom";
            this.gcNewRoom.OptionsColumn.AllowEdit = false;
            this.gcNewRoom.OptionsColumn.AllowMove = false;
            this.gcNewRoom.OptionsColumn.AllowShowHide = false;
            this.gcNewRoom.OptionsColumn.ReadOnly = true;
            this.gcNewRoom.Tag = "ReadOnly";
            this.gcNewRoom.Visible = true;
            this.gcNewRoom.VisibleIndex = 2;
            this.gcNewRoom.Width = 150;
            // 
            // gcOldUser
            // 
            this.gcOldUser.Caption = "СТАРЫЙ ВЛАДЕЛЕЦ";
            this.gcOldUser.FieldName = "OldUser.FullName";
            this.gcOldUser.Name = "gcOldUser";
            this.gcOldUser.OptionsColumn.AllowEdit = false;
            this.gcOldUser.OptionsColumn.AllowMove = false;
            this.gcOldUser.OptionsColumn.AllowShowHide = false;
            this.gcOldUser.OptionsColumn.ReadOnly = true;
            this.gcOldUser.Tag = "ReadOnly";
            this.gcOldUser.Visible = true;
            this.gcOldUser.VisibleIndex = 3;
            this.gcOldUser.Width = 150;
            // 
            // gcNewUser
            // 
            this.gcNewUser.Caption = "НОВЫЙ ВЛАДЕЛЕЦ";
            this.gcNewUser.FieldName = "NewUser.FullName";
            this.gcNewUser.Name = "gcNewUser";
            this.gcNewUser.OptionsColumn.AllowEdit = false;
            this.gcNewUser.OptionsColumn.AllowMove = false;
            this.gcNewUser.OptionsColumn.AllowShowHide = false;
            this.gcNewUser.OptionsColumn.ReadOnly = true;
            this.gcNewUser.Tag = "ReadOnly";
            this.gcNewUser.Visible = true;
            this.gcNewUser.VisibleIndex = 4;
            this.gcNewUser.Width = 150;
            // 
            // gcNote
            // 
            this.gcNote.Caption = "ЗАМЕТКИ";
            this.gcNote.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gcNote.FieldName = "Note";
            this.gcNote.Name = "gcNote";
            this.gcNote.OptionsColumn.AllowEdit = false;
            this.gcNote.OptionsColumn.AllowMove = false;
            this.gcNote.OptionsColumn.AllowShowHide = false;
            this.gcNote.OptionsColumn.ReadOnly = true;
            this.gcNote.Tag = "ReadOnly";
            this.gcNote.Visible = true;
            this.gcNote.VisibleIndex = 5;
            this.gcNote.Width = 147;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridEditBar
            // 
            this.gridEditBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridEditBar.Location = new System.Drawing.Point(0, 0);
            this.gridEditBar.Name = "gridEditBar";
            this.gridEditBar.Size = new System.Drawing.Size(849, 31);
            this.gridEditBar.TabIndex = 0;
            this.gridEditBar.AddRecord += new System.EventHandler(this.gridEditBar_AddRecord);
            this.gridEditBar.DeleteRecord += new System.EventHandler(this.gridEditBar_DeleteRecord);
            // 
            // MovementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcMain);
            this.Controls.Add(this.gridEditBar);
            this.Name = "MovementsControl";
            this.Size = new System.Drawing.Size(849, 360);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreatedOn;
        private DevExpress.XtraGrid.Columns.GridColumn gcOldRoom;
        private DevExpress.XtraGrid.Columns.GridColumn gcNote;
        private DevExpress.XtraGrid.Columns.GridColumn gcNewRoom;
        private DevExpress.XtraGrid.Columns.GridColumn gcOldUser;
        private GridEditBarControl gridEditBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gcNewUser;
    }
}
