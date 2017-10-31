using DevExpress.Xpo;

namespace Dekart.LazyNet.Win.Modules {
    partial class Users {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riGender = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riIsAdmin = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHireDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMobilePhone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riPhoto = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.lvCards = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colPhoto = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colPhoto = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colFullName1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colFullName1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colTitle1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colAddress1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colWorkPhone1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colMobilePhone = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.colEmail1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_colEmail1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.item1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ucUserView = new Dekart.LazyNet.Win.Modules.UserView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riIsAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFullName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAddress1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMobilePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEmail1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            resources.ApplyResources(this.splitContainerControl, "splitContainerControl");
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gcMain);
            resources.ApplyResources(this.splitContainerControl.Panel1, "splitContainerControl.Panel1");
            this.splitContainerControl.Panel2.Controls.Add(this.ucUserView);
            resources.ApplyResources(this.splitContainerControl.Panel2, "splitContainerControl.Panel2");
            this.splitContainerControl.SplitterPosition = 420;
            // 
            // gcMain
            // 
            resources.ApplyResources(this.gcMain, "gcMain");
            this.gcMain.MainView = this.gvList;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riGender,
            this.riIsAdmin,
            this.riPhoto});
            this.gcMain.ShowOnlyPredefinedDetails = true;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvList,
            this.lvCards});
            // 
            // gvList
            // 
            this.gvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGender,
            this.colDepartment,
            this.colFullName,
            this.colIsAdmin,
            this.colTitle,
            this.colWorkPhone,
            this.colEmail,
            this.colBirthDate,
            this.colHireDate,
            this.colMobilePhone1});
            this.gvList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvList.GridControl = this.gcMain;
            this.gvList.GroupCount = 1;
            resources.ApplyResources(this.gvList, "gvList");
            this.gvList.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(((DevExpress.Data.SummaryItemType)(resources.GetObject("gvList.GroupSummary"))), resources.GetString("gvList.GroupSummary1"), ((DevExpress.XtraGrid.Columns.GridColumn)(resources.GetObject("gvList.GroupSummary2"))), resources.GetString("gvList.GroupSummary3"))});
            this.gvList.Name = "gvList";
            this.gvList.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvList.OptionsBehavior.Editable = false;
            this.gvList.OptionsFind.AlwaysVisible = true;
            this.gvList.OptionsFind.FindNullPrompt = "Поиск людей (Ctrl + F)";
            this.gvList.OptionsFind.ShowClearButton = false;
            this.gvList.OptionsFind.ShowFindButton = false;
            this.gvList.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gvList.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gvList.OptionsView.ShowIndicator = false;
            this.gvList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartment, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvList_RowCellClick);
            this.gvList.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gvList_FocusedRowObjectChanged);
            this.gvList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvList_KeyDown);
            // 
            // colGender
            // 
            resources.ApplyResources(this.colGender, "colGender");
            this.colGender.ColumnEdit = this.riGender;
            this.colGender.FieldName = "Gender";
            this.colGender.Image = global::Dekart.LazyNet.Win.Properties.Resources.icon_prefix_16;
            this.colGender.Name = "colGender";
            this.colGender.OptionsColumn.AllowFocus = false;
            this.colGender.OptionsColumn.AllowMove = false;
            this.colGender.OptionsColumn.AllowSize = false;
            this.colGender.OptionsColumn.FixedWidth = true;
            this.colGender.OptionsColumn.ShowCaption = false;
            // 
            // riGender
            // 
            resources.ApplyResources(this.riGender, "riGender");
            this.riGender.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riGender.Buttons"))))});
            this.riGender.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.riGender.Name = "riGender";
            // 
            // colDepartment
            // 
            resources.ApplyResources(this.colDepartment, "colDepartment");
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsColumn.AllowFocus = false;
            // 
            // colFullName
            // 
            resources.ApplyResources(this.colFullName, "colFullName");
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowFocus = false;
            // 
            // colIsAdmin
            // 
            resources.ApplyResources(this.colIsAdmin, "colIsAdmin");
            this.colIsAdmin.ColumnEdit = this.riIsAdmin;
            this.colIsAdmin.FieldName = "IsAdmin";
            this.colIsAdmin.Name = "colIsAdmin";
            this.colIsAdmin.OptionsColumn.AllowFocus = false;
            // 
            // riIsAdmin
            // 
            resources.ApplyResources(this.riIsAdmin, "riIsAdmin");
            this.riIsAdmin.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.riIsAdmin.Name = "riIsAdmin";
            this.riIsAdmin.ShowText = false;
            // 
            // colTitle
            // 
            resources.ApplyResources(this.colTitle, "colTitle");
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.OptionsColumn.AllowFocus = false;
            // 
            // colWorkPhone
            // 
            resources.ApplyResources(this.colWorkPhone, "colWorkPhone");
            this.colWorkPhone.FieldName = "WorkPhone";
            this.colWorkPhone.Name = "colWorkPhone";
            this.colWorkPhone.OptionsColumn.AllowFocus = false;
            // 
            // colEmail
            // 
            resources.ApplyResources(this.colEmail, "colEmail");
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowFocus = false;
            // 
            // colBirthDate
            // 
            resources.ApplyResources(this.colBirthDate, "colBirthDate");
            this.colBirthDate.DisplayFormat.FormatString = "d";
            this.colBirthDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.OptionsColumn.AllowFocus = false;
            // 
            // colHireDate
            // 
            resources.ApplyResources(this.colHireDate, "colHireDate");
            this.colHireDate.DisplayFormat.FormatString = "d";
            this.colHireDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHireDate.FieldName = "HireDate";
            this.colHireDate.Name = "colHireDate";
            this.colHireDate.OptionsColumn.AllowFocus = false;
            // 
            // colMobilePhone1
            // 
            resources.ApplyResources(this.colMobilePhone1, "colMobilePhone1");
            this.colMobilePhone1.FieldName = "MobilePhone";
            this.colMobilePhone1.Name = "colMobilePhone1";
            this.colMobilePhone1.OptionsColumn.AllowFocus = false;
            // 
            // riPhoto
            // 
            this.riPhoto.Name = "riPhoto";
            this.riPhoto.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.riPhoto.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            // 
            // lvCards
            // 
            resources.ApplyResources(this.lvCards, "lvCards");
            this.lvCards.CardMinSize = new System.Drawing.Size(292, 183);
            this.lvCards.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colPhoto,
            this.colFullName1,
            this.colTitle1,
            this.colWorkPhone1,
            this.colEmail1});
            this.lvCards.GridControl = this.gcMain;
            this.lvCards.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colFullName1});
            this.lvCards.Name = "lvCards";
            this.lvCards.OptionsBehavior.AllowExpandCollapse = false;
            this.lvCards.OptionsBehavior.AllowRuntimeCustomization = false;
            this.lvCards.OptionsBehavior.Editable = false;
            this.lvCards.OptionsBehavior.ReadOnly = true;
            this.lvCards.OptionsFind.AlwaysVisible = true;
            this.lvCards.OptionsFind.FindNullPrompt = "Поиск людей (Ctrl + F)";
            this.lvCards.OptionsFind.ShowClearButton = false;
            this.lvCards.OptionsFind.ShowFindButton = false;
            this.lvCards.OptionsItemText.TextToControlDistance = 2;
            this.lvCards.OptionsMultiRecordMode.MultiRowScrollBarOrientation = DevExpress.XtraGrid.Views.Layout.ScrollBarOrientation.Vertical;
            this.lvCards.OptionsView.AllowHotTrackFields = false;
            this.lvCards.OptionsView.FocusRectStyle = DevExpress.XtraGrid.Views.Layout.FocusRectStyle.None;
            this.lvCards.OptionsView.ShowCardLines = false;
            this.lvCards.OptionsView.ShowHeaderPanel = false;
            this.lvCards.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.lvCards.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.lvCards.TemplateCard = this.layoutViewCard1;
            this.lvCards.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvCards_MouseDown);
            // 
            // colPhoto
            // 
            this.colPhoto.ColumnEdit = this.riPhoto;
            this.colPhoto.FieldName = "PhotoExists";
            this.colPhoto.LayoutViewField = this.layoutViewField_colPhoto;
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.OptionsColumn.AllowFocus = false;
            this.colPhoto.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPhoto.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_colPhoto
            // 
            this.layoutViewField_colPhoto.EditorPreferredWidth = 106;
            this.layoutViewField_colPhoto.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colPhoto.MaxSize = new System.Drawing.Size(120, 136);
            this.layoutViewField_colPhoto.MinSize = new System.Drawing.Size(120, 136);
            this.layoutViewField_colPhoto.Name = "layoutViewField_colPhoto";
            this.layoutViewField_colPhoto.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 12, 2, 2);
            this.layoutViewField_colPhoto.Size = new System.Drawing.Size(120, 139);
            this.layoutViewField_colPhoto.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_colPhoto.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colPhoto.TextVisible = false;
            // 
            // colFullName1
            // 
            this.colFullName1.FieldName = "FullName";
            this.colFullName1.LayoutViewField = this.layoutViewField_colFullName1;
            this.colFullName1.Name = "colFullName1";
            this.colFullName1.OptionsColumn.AllowFocus = false;
            // 
            // layoutViewField_colFullName1
            // 
            this.layoutViewField_colFullName1.EditorPreferredWidth = 20;
            this.layoutViewField_colFullName1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colFullName1.Name = "layoutViewField_colFullName1";
            this.layoutViewField_colFullName1.Size = new System.Drawing.Size(286, 139);
            this.layoutViewField_colFullName1.TextSize = new System.Drawing.Size(67, 13);
            // 
            // colTitle1
            // 
            resources.ApplyResources(this.colTitle1, "colTitle1");
            this.colTitle1.FieldName = "Title";
            this.colTitle1.LayoutViewField = this.layoutViewField_colAddress1;
            this.colTitle1.Name = "colTitle1";
            this.colTitle1.OptionsColumn.AllowFocus = false;
            this.colTitle1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTitle1.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_colAddress1
            // 
            this.layoutViewField_colAddress1.EditorPreferredWidth = 162;
            this.layoutViewField_colAddress1.Location = new System.Drawing.Point(120, 0);
            this.layoutViewField_colAddress1.Name = "layoutViewField_colAddress1";
            this.layoutViewField_colAddress1.Size = new System.Drawing.Size(166, 39);
            this.layoutViewField_colAddress1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutViewField_colAddress1.TextSize = new System.Drawing.Size(113, 13);
            // 
            // colWorkPhone1
            // 
            resources.ApplyResources(this.colWorkPhone1, "colWorkPhone1");
            this.colWorkPhone1.FieldName = "WorkPhone";
            this.colWorkPhone1.LayoutViewField = this.layoutViewField_colMobilePhone;
            this.colWorkPhone1.Name = "colWorkPhone1";
            this.colWorkPhone1.OptionsColumn.AllowFocus = false;
            this.colWorkPhone1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colWorkPhone1.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_colMobilePhone
            // 
            this.layoutViewField_colMobilePhone.EditorPreferredWidth = 162;
            this.layoutViewField_colMobilePhone.Location = new System.Drawing.Point(120, 39);
            this.layoutViewField_colMobilePhone.Name = "layoutViewField_colMobilePhone";
            this.layoutViewField_colMobilePhone.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 2);
            this.layoutViewField_colMobilePhone.Size = new System.Drawing.Size(166, 45);
            this.layoutViewField_colMobilePhone.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutViewField_colMobilePhone.TextSize = new System.Drawing.Size(113, 13);
            // 
            // colEmail1
            // 
            resources.ApplyResources(this.colEmail1, "colEmail1");
            this.colEmail1.FieldName = "Email";
            this.colEmail1.LayoutViewField = this.layoutViewField_colEmail1;
            this.colEmail1.Name = "colEmail1";
            this.colEmail1.OptionsColumn.AllowFocus = false;
            this.colEmail1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colEmail1.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_colEmail1
            // 
            this.layoutViewField_colEmail1.EditorPreferredWidth = 162;
            this.layoutViewField_colEmail1.Location = new System.Drawing.Point(120, 84);
            this.layoutViewField_colEmail1.Name = "layoutViewField_colEmail1";
            this.layoutViewField_colEmail1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 2);
            this.layoutViewField_colEmail1.Size = new System.Drawing.Size(166, 45);
            this.layoutViewField_colEmail1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutViewField_colEmail1.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutViewCard1
            // 
            resources.ApplyResources(this.layoutViewCard1, "layoutViewCard1");
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colAddress1,
            this.layoutViewField_colEmail1,
            this.layoutViewField_colPhoto,
            this.item1,
            this.layoutViewField_colMobilePhone});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 2;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            // 
            // item1
            // 
            this.item1.AllowHotTrack = false;
            resources.ApplyResources(this.item1, "item1");
            this.item1.Location = new System.Drawing.Point(120, 129);
            this.item1.Name = "item1";
            this.item1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.item1.Size = new System.Drawing.Size(166, 10);
            this.item1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ucUserView
            // 
            resources.ApplyResources(this.ucUserView, "ucUserView");
            this.ucUserView.Name = "ucUserView";
            this.ucUserView.ParentFormMain = null;
            this.ucUserView.ZoomFactor = 1F;
            // 
            // Users
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl);
            this.Name = "Users";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riIsAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFullName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAddress1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colMobilePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEmail1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvList;
        private UserView ucUserView;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Views.Layout.LayoutView lvCards;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colIsAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colHireDate;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colMobilePhone1;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colPhoto;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colFullName1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colTitle1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colEmail1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colWorkPhone1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riGender;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch riIsAdmin;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPhoto;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colFullName1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAddress1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colMobilePhone;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colEmail1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.EmptySpaceItem item1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit riPhoto;
    }
}
