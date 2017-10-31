namespace Dekart.LazyNet.SQLBackup2Remote.Views
{
    partial class RestoreBackupView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreBackupView));
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition5 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition6 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            this.pcButtons = new DevExpress.XtraEditors.PanelControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.sbOk = new DevExpress.XtraEditors.SimpleButton();
            this.pcSeparator = new DevExpress.XtraEditors.PanelControl();
            this.sbClose = new DevExpress.XtraEditors.SimpleButton();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatabaseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colFinishDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstLsn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastLsn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheckpointLsn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackupLsn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TargetDatabase = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.DeleteFilesOnSuccess = new DevExpress.XtraEditors.ToggleSwitch();
            this.Date = new DevExpress.XtraEditors.DateEdit();
            this.sbRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.Database = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.Destination = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.HeaderGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTargetDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDestination = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDeleteFilesOnSuccess = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pcButtons)).BeginInit();
            this.pcButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteFilesOnSuccess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Database.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Destination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTargetDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeleteFilesOnSuccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // pcButtons
            // 
            resources.ApplyResources(this.pcButtons, "pcButtons");
            this.pcButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcButtons.Controls.Add(this.progressPanel1);
            this.pcButtons.Controls.Add(this.sbOk);
            this.pcButtons.Controls.Add(this.pcSeparator);
            this.pcButtons.Controls.Add(this.sbClose);
            this.pcButtons.Name = "pcButtons";
            // 
            // progressPanel1
            // 
            resources.ApplyResources(this.progressPanel1, "progressPanel1");
            this.progressPanel1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("progressPanel1.Appearance.BackColor")));
            this.progressPanel1.Appearance.FontSizeDelta = ((int)(resources.GetObject("progressPanel1.Appearance.FontSizeDelta")));
            this.progressPanel1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("progressPanel1.Appearance.FontStyleDelta")));
            this.progressPanel1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("progressPanel1.Appearance.GradientMode")));
            this.progressPanel1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("progressPanel1.Appearance.Image")));
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
            this.progressPanel1.AppearanceCaption.FontSizeDelta = ((int)(resources.GetObject("resource.FontSizeDelta")));
            this.progressPanel1.AppearanceCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("resource.FontStyleDelta")));
            this.progressPanel1.AppearanceCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("resource.GradientMode")));
            this.progressPanel1.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font1")));
            this.progressPanel1.AppearanceDescription.FontSizeDelta = ((int)(resources.GetObject("resource.FontSizeDelta1")));
            this.progressPanel1.AppearanceDescription.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("resource.FontStyleDelta1")));
            this.progressPanel1.AppearanceDescription.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("resource.GradientMode1")));
            this.progressPanel1.AppearanceDescription.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.ShowCaption = false;
            // 
            // sbOk
            // 
            resources.ApplyResources(this.sbOk, "sbOk");
            this.sbOk.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("sbOk.Appearance.Font")));
            this.sbOk.Appearance.FontSizeDelta = ((int)(resources.GetObject("sbOk.Appearance.FontSizeDelta")));
            this.sbOk.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("sbOk.Appearance.FontStyleDelta")));
            this.sbOk.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("sbOk.Appearance.GradientMode")));
            this.sbOk.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbOk.Appearance.Image")));
            this.sbOk.Appearance.Options.UseFont = true;
            this.sbOk.Image = ((System.Drawing.Image)(resources.GetObject("sbOk.Image")));
            this.sbOk.Name = "sbOk";
            this.sbOk.Click += new System.EventHandler(this.SbOkClick);
            // 
            // pcSeparator
            // 
            resources.ApplyResources(this.pcSeparator, "pcSeparator");
            this.pcSeparator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcSeparator.Name = "pcSeparator";
            // 
            // sbClose
            // 
            resources.ApplyResources(this.sbClose, "sbClose");
            this.sbClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("sbClose.Appearance.Font")));
            this.sbClose.Appearance.FontSizeDelta = ((int)(resources.GetObject("sbClose.Appearance.FontSizeDelta")));
            this.sbClose.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("sbClose.Appearance.FontStyleDelta")));
            this.sbClose.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("sbClose.Appearance.GradientMode")));
            this.sbClose.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbClose.Appearance.Image")));
            this.sbClose.Appearance.Options.UseFont = true;
            this.sbClose.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.close_32x32;
            this.sbClose.Name = "sbClose";
            this.sbClose.Click += new System.EventHandler(this.SbCloseClick);
            // 
            // gcMain
            // 
            resources.ApplyResources(this.gcMain, "gcMain");
            this.gcMain.EmbeddedNavigator.AccessibleDescription = resources.GetString("gcMain.EmbeddedNavigator.AccessibleDescription");
            this.gcMain.EmbeddedNavigator.AccessibleName = resources.GetString("gcMain.EmbeddedNavigator.AccessibleName");
            this.gcMain.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gcMain.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gcMain.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gcMain.EmbeddedNavigator.Anchor")));
            this.gcMain.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gcMain.EmbeddedNavigator.BackgroundImage")));
            this.gcMain.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gcMain.EmbeddedNavigator.BackgroundImageLayout")));
            this.gcMain.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gcMain.EmbeddedNavigator.ImeMode")));
            this.gcMain.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gcMain.EmbeddedNavigator.MaximumSize")));
            this.gcMain.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gcMain.EmbeddedNavigator.TextLocation")));
            this.gcMain.EmbeddedNavigator.ToolTip = resources.GetString("gcMain.EmbeddedNavigator.ToolTip");
            this.gcMain.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gcMain.EmbeddedNavigator.ToolTipIconType")));
            this.gcMain.EmbeddedNavigator.ToolTipTitle = resources.GetString("gcMain.EmbeddedNavigator.ToolTipTitle");
            this.gcMain.MainView = this.gvMain;
            this.gcMain.Name = "gcMain";
            this.gcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riDateEdit});
            this.gcMain.ShowOnlyPredefinedDetails = true;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // gvMain
            // 
            resources.ApplyResources(this.gvMain, "gvMain");
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colBackupType,
            this.colServer,
            this.colDatabaseName,
            this.colStartDate,
            this.colFinishDate,
            this.colFirstLsn,
            this.colLastLsn,
            this.colCheckpointLsn,
            this.colBackupLsn});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsCustomization.AllowFilter = false;
            this.gvMain.OptionsCustomization.AllowGroup = false;
            this.gvMain.OptionsMenu.EnableColumnMenu = false;
            this.gvMain.OptionsMenu.EnableFooterMenu = false;
            this.gvMain.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvMain.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gvMain.OptionsSelection.MultiSelect = true;
            this.gvMain.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvMain.OptionsView.ShowGroupPanel = false;
            this.gvMain.OptionsView.ShowIndicator = false;
            this.gvMain.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvMain_SelectionChanged);
            // 
            // colName
            // 
            resources.ApplyResources(this.colName, "colName");
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            // 
            // colBackupType
            // 
            resources.ApplyResources(this.colBackupType, "colBackupType");
            this.colBackupType.FieldName = "BackupType";
            this.colBackupType.Name = "colBackupType";
            // 
            // colServer
            // 
            resources.ApplyResources(this.colServer, "colServer");
            this.colServer.FieldName = "Server";
            this.colServer.Name = "colServer";
            // 
            // colDatabaseName
            // 
            resources.ApplyResources(this.colDatabaseName, "colDatabaseName");
            this.colDatabaseName.FieldName = "DatabaseName";
            this.colDatabaseName.Name = "colDatabaseName";
            // 
            // colStartDate
            // 
            resources.ApplyResources(this.colStartDate, "colStartDate");
            this.colStartDate.ColumnEdit = this.riDateEdit;
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            // 
            // riDateEdit
            // 
            resources.ApplyResources(this.riDateEdit, "riDateEdit");
            this.riDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riDateEdit.Buttons"))))});
            this.riDateEdit.CalendarTimeProperties.AccessibleDescription = resources.GetString("riDateEdit.CalendarTimeProperties.AccessibleDescription");
            this.riDateEdit.CalendarTimeProperties.AccessibleName = resources.GetString("riDateEdit.CalendarTimeProperties.AccessibleName");
            this.riDateEdit.CalendarTimeProperties.AutoHeight = ((bool)(resources.GetObject("riDateEdit.CalendarTimeProperties.AutoHeight")));
            this.riDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riDateEdit.CalendarTimeProperties.Buttons"))))});
            this.riDateEdit.CalendarTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.AutoComplete")));
            this.riDateEdit.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.BeepOnError")));
            this.riDateEdit.CalendarTimeProperties.Mask.EditMask = resources.GetString("riDateEdit.CalendarTimeProperties.Mask.EditMask");
            this.riDateEdit.CalendarTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.IgnoreMaskBlank")));
            this.riDateEdit.CalendarTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.MaskType")));
            this.riDateEdit.CalendarTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.PlaceHolder")));
            this.riDateEdit.CalendarTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.SaveLiteral")));
            this.riDateEdit.CalendarTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.ShowPlaceHolders")));
            this.riDateEdit.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("riDateEdit.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.riDateEdit.CalendarTimeProperties.NullValuePrompt = resources.GetString("riDateEdit.CalendarTimeProperties.NullValuePrompt");
            this.riDateEdit.CalendarTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("riDateEdit.CalendarTimeProperties.NullValuePromptShowForEmptyValue")));
            this.riDateEdit.DisplayFormat.FormatString = "G";
            this.riDateEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.riDateEdit.EditFormat.FormatString = "G";
            this.riDateEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.riDateEdit.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("riDateEdit.Mask.AutoComplete")));
            this.riDateEdit.Mask.BeepOnError = ((bool)(resources.GetObject("riDateEdit.Mask.BeepOnError")));
            this.riDateEdit.Mask.EditMask = resources.GetString("riDateEdit.Mask.EditMask");
            this.riDateEdit.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("riDateEdit.Mask.IgnoreMaskBlank")));
            this.riDateEdit.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("riDateEdit.Mask.MaskType")));
            this.riDateEdit.Mask.PlaceHolder = ((char)(resources.GetObject("riDateEdit.Mask.PlaceHolder")));
            this.riDateEdit.Mask.SaveLiteral = ((bool)(resources.GetObject("riDateEdit.Mask.SaveLiteral")));
            this.riDateEdit.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("riDateEdit.Mask.ShowPlaceHolders")));
            this.riDateEdit.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("riDateEdit.Mask.UseMaskAsDisplayFormat")));
            this.riDateEdit.Name = "riDateEdit";
            this.riDateEdit.NullDate = new System.DateTime(((long)(0)));
            // 
            // colFinishDate
            // 
            resources.ApplyResources(this.colFinishDate, "colFinishDate");
            this.colFinishDate.ColumnEdit = this.riDateEdit;
            this.colFinishDate.FieldName = "FinishDate";
            this.colFinishDate.Name = "colFinishDate";
            // 
            // colFirstLsn
            // 
            resources.ApplyResources(this.colFirstLsn, "colFirstLsn");
            this.colFirstLsn.FieldName = "FirstLsn";
            this.colFirstLsn.Name = "colFirstLsn";
            // 
            // colLastLsn
            // 
            resources.ApplyResources(this.colLastLsn, "colLastLsn");
            this.colLastLsn.FieldName = "LastLsn";
            this.colLastLsn.Name = "colLastLsn";
            // 
            // colCheckpointLsn
            // 
            resources.ApplyResources(this.colCheckpointLsn, "colCheckpointLsn");
            this.colCheckpointLsn.FieldName = "CheckpointLsn";
            this.colCheckpointLsn.Name = "colCheckpointLsn";
            // 
            // colBackupLsn
            // 
            resources.ApplyResources(this.colBackupLsn, "colBackupLsn");
            this.colBackupLsn.FieldName = "DatabaseBackupLsn";
            this.colBackupLsn.Name = "colBackupLsn";
            // 
            // TargetDatabase
            // 
            resources.ApplyResources(this.TargetDatabase, "TargetDatabase");
            this.TargetDatabase.Name = "TargetDatabase";
            this.TargetDatabase.Properties.AccessibleDescription = resources.GetString("TargetDatabase.Properties.AccessibleDescription");
            this.TargetDatabase.Properties.AccessibleName = resources.GetString("TargetDatabase.Properties.AccessibleName");
            this.TargetDatabase.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("TargetDatabase.Properties.Appearance.FontSizeDelta")));
            this.TargetDatabase.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("TargetDatabase.Properties.Appearance.FontStyleDelta")));
            this.TargetDatabase.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("TargetDatabase.Properties.Appearance.GradientMode")));
            this.TargetDatabase.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("TargetDatabase.Properties.Appearance.Image")));
            this.TargetDatabase.Properties.Appearance.Options.UseFont = true;
            this.TargetDatabase.Properties.AutoHeight = ((bool)(resources.GetObject("TargetDatabase.Properties.AutoHeight")));
            this.TargetDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("TargetDatabase.Properties.Buttons"))))});
            this.TargetDatabase.Properties.GlyphAlignment = ((DevExpress.Utils.HorzAlignment)(resources.GetObject("TargetDatabase.Properties.GlyphAlignment")));
            this.TargetDatabase.Properties.NullValuePrompt = resources.GetString("TargetDatabase.Properties.NullValuePrompt");
            this.TargetDatabase.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("TargetDatabase.Properties.NullValuePromptShowForEmptyValue")));
            this.TargetDatabase.StyleController = this.lcMain;
            // 
            // lcMain
            // 
            resources.ApplyResources(this.lcMain, "lcMain");
            this.lcMain.AllowCustomization = false;
            this.lcMain.Appearance.DisabledLayoutGroupCaption.FontSizeDelta = ((int)(resources.GetObject("lcMain.Appearance.DisabledLayoutGroupCaption.FontSizeDelta")));
            this.lcMain.Appearance.DisabledLayoutGroupCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lcMain.Appearance.DisabledLayoutGroupCaption.FontStyleDelta")));
            this.lcMain.Appearance.DisabledLayoutGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lcMain.Appearance.DisabledLayoutGroupCaption.GradientMode")));
            this.lcMain.Appearance.DisabledLayoutGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("lcMain.Appearance.DisabledLayoutGroupCaption.Image")));
            this.lcMain.Appearance.DisabledLayoutItem.FontSizeDelta = ((int)(resources.GetObject("lcMain.Appearance.DisabledLayoutItem.FontSizeDelta")));
            this.lcMain.Appearance.DisabledLayoutItem.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lcMain.Appearance.DisabledLayoutItem.FontStyleDelta")));
            this.lcMain.Appearance.DisabledLayoutItem.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lcMain.Appearance.DisabledLayoutItem.GradientMode")));
            this.lcMain.Appearance.DisabledLayoutItem.Image = ((System.Drawing.Image)(resources.GetObject("lcMain.Appearance.DisabledLayoutItem.Image")));
            this.lcMain.Controls.Add(this.DeleteFilesOnSuccess);
            this.lcMain.Controls.Add(this.Date);
            this.lcMain.Controls.Add(this.sbRefresh);
            this.lcMain.Controls.Add(this.TargetDatabase);
            this.lcMain.Controls.Add(this.gcMain);
            this.lcMain.Controls.Add(this.Database);
            this.lcMain.Controls.Add(this.Destination);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1195, 179, 509, 521);
            this.lcMain.OptionsPrint.AppearanceGroupCaption.FontSizeDelta = ((int)(resources.GetObject("lcMain.OptionsPrint.AppearanceGroupCaption.FontSizeDelta")));
            this.lcMain.OptionsPrint.AppearanceGroupCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lcMain.OptionsPrint.AppearanceGroupCaption.FontStyleDelta")));
            this.lcMain.OptionsPrint.AppearanceGroupCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lcMain.OptionsPrint.AppearanceGroupCaption.GradientMode")));
            this.lcMain.OptionsPrint.AppearanceGroupCaption.Image = ((System.Drawing.Image)(resources.GetObject("lcMain.OptionsPrint.AppearanceGroupCaption.Image")));
            this.lcMain.OptionsPrint.AppearanceItemCaption.FontSizeDelta = ((int)(resources.GetObject("lcMain.OptionsPrint.AppearanceItemCaption.FontSizeDelta")));
            this.lcMain.OptionsPrint.AppearanceItemCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lcMain.OptionsPrint.AppearanceItemCaption.FontStyleDelta")));
            this.lcMain.OptionsPrint.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lcMain.OptionsPrint.AppearanceItemCaption.GradientMode")));
            this.lcMain.OptionsPrint.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("lcMain.OptionsPrint.AppearanceItemCaption.Image")));
            this.lcMain.Root = this.lcgRoot;
            // 
            // DeleteFilesOnSuccess
            // 
            resources.ApplyResources(this.DeleteFilesOnSuccess, "DeleteFilesOnSuccess");
            this.DeleteFilesOnSuccess.Name = "DeleteFilesOnSuccess";
            this.DeleteFilesOnSuccess.Properties.AccessibleDescription = resources.GetString("DeleteFilesOnSuccess.Properties.AccessibleDescription");
            this.DeleteFilesOnSuccess.Properties.AccessibleName = resources.GetString("DeleteFilesOnSuccess.Properties.AccessibleName");
            this.DeleteFilesOnSuccess.Properties.AutoHeight = ((bool)(resources.GetObject("DeleteFilesOnSuccess.Properties.AutoHeight")));
            this.DeleteFilesOnSuccess.Properties.OffText = resources.GetString("DeleteFilesOnSuccess.Properties.OffText");
            this.DeleteFilesOnSuccess.Properties.OnText = resources.GetString("DeleteFilesOnSuccess.Properties.OnText");
            this.DeleteFilesOnSuccess.StyleController = this.lcMain;
            // 
            // Date
            // 
            resources.ApplyResources(this.Date, "Date");
            this.Date.Name = "Date";
            this.Date.Properties.AccessibleDescription = resources.GetString("Date.Properties.AccessibleDescription");
            this.Date.Properties.AccessibleName = resources.GetString("Date.Properties.AccessibleName");
            this.Date.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.Date.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("Date.Properties.Appearance.Font")));
            this.Date.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("Date.Properties.Appearance.FontSizeDelta")));
            this.Date.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("Date.Properties.Appearance.FontStyleDelta")));
            this.Date.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("Date.Properties.Appearance.GradientMode")));
            this.Date.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("Date.Properties.Appearance.Image")));
            this.Date.Properties.Appearance.Options.UseFont = true;
            this.Date.Properties.AutoHeight = ((bool)(resources.GetObject("Date.Properties.AutoHeight")));
            this.Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("Date.Properties.Buttons"))))});
            this.Date.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("Date.Properties.CalendarTimeProperties.AccessibleDescription");
            this.Date.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("Date.Properties.CalendarTimeProperties.AccessibleName");
            this.Date.Properties.CalendarTimeProperties.AutoHeight = ((bool)(resources.GetObject("Date.Properties.CalendarTimeProperties.AutoHeight")));
            this.Date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("Date.Properties.CalendarTimeProperties.Buttons"))))});
            this.Date.Properties.CalendarTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.AutoComplete")));
            this.Date.Properties.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.BeepOnError")));
            this.Date.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("Date.Properties.CalendarTimeProperties.Mask.EditMask");
            this.Date.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank")));
            this.Date.Properties.CalendarTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.MaskType")));
            this.Date.Properties.CalendarTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.PlaceHolder")));
            this.Date.Properties.CalendarTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.SaveLiteral")));
            this.Date.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders")));
            this.Date.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("Date.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.Date.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("Date.Properties.CalendarTimeProperties.NullValuePrompt");
            this.Date.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Date.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue")));
            this.Date.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("Date.Properties.Mask.AutoComplete")));
            this.Date.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("Date.Properties.Mask.BeepOnError")));
            this.Date.Properties.Mask.EditMask = resources.GetString("Date.Properties.Mask.EditMask");
            this.Date.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("Date.Properties.Mask.IgnoreMaskBlank")));
            this.Date.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Date.Properties.Mask.MaskType")));
            this.Date.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("Date.Properties.Mask.PlaceHolder")));
            this.Date.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("Date.Properties.Mask.SaveLiteral")));
            this.Date.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("Date.Properties.Mask.ShowPlaceHolders")));
            this.Date.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("Date.Properties.Mask.UseMaskAsDisplayFormat")));
            this.Date.Properties.NullValuePrompt = resources.GetString("Date.Properties.NullValuePrompt");
            this.Date.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Date.Properties.NullValuePromptShowForEmptyValue")));
            this.Date.StyleController = this.lcMain;
            // 
            // sbRefresh
            // 
            resources.ApplyResources(this.sbRefresh, "sbRefresh");
            this.sbRefresh.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("sbRefresh.Appearance.Font")));
            this.sbRefresh.Appearance.FontSizeDelta = ((int)(resources.GetObject("sbRefresh.Appearance.FontSizeDelta")));
            this.sbRefresh.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("sbRefresh.Appearance.FontStyleDelta")));
            this.sbRefresh.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("sbRefresh.Appearance.GradientMode")));
            this.sbRefresh.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbRefresh.Appearance.Image")));
            this.sbRefresh.Appearance.Options.UseFont = true;
            this.sbRefresh.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.refresh_32x32;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.StyleController = this.lcMain;
            // 
            // Database
            // 
            resources.ApplyResources(this.Database, "Database");
            this.Database.Name = "Database";
            this.Database.Properties.AccessibleDescription = resources.GetString("Database.Properties.AccessibleDescription");
            this.Database.Properties.AccessibleName = resources.GetString("Database.Properties.AccessibleName");
            this.Database.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("Database.Properties.Appearance.FontSizeDelta")));
            this.Database.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("Database.Properties.Appearance.FontStyleDelta")));
            this.Database.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("Database.Properties.Appearance.GradientMode")));
            this.Database.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("Database.Properties.Appearance.Image")));
            this.Database.Properties.Appearance.Options.UseFont = true;
            this.Database.Properties.AutoHeight = ((bool)(resources.GetObject("Database.Properties.AutoHeight")));
            this.Database.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("Database.Properties.Buttons"))))});
            this.Database.Properties.GlyphAlignment = ((DevExpress.Utils.HorzAlignment)(resources.GetObject("Database.Properties.GlyphAlignment")));
            this.Database.Properties.NullValuePrompt = resources.GetString("Database.Properties.NullValuePrompt");
            this.Database.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Database.Properties.NullValuePromptShowForEmptyValue")));
            this.Database.StyleController = this.lcMain;
            // 
            // Destination
            // 
            resources.ApplyResources(this.Destination, "Destination");
            this.Destination.Name = "Destination";
            this.Destination.Properties.AccessibleDescription = resources.GetString("Destination.Properties.AccessibleDescription");
            this.Destination.Properties.AccessibleName = resources.GetString("Destination.Properties.AccessibleName");
            this.Destination.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("Destination.Properties.Appearance.FontSizeDelta")));
            this.Destination.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("Destination.Properties.Appearance.FontStyleDelta")));
            this.Destination.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("Destination.Properties.Appearance.GradientMode")));
            this.Destination.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("Destination.Properties.Appearance.Image")));
            this.Destination.Properties.Appearance.Options.UseFont = true;
            this.Destination.Properties.AutoHeight = ((bool)(resources.GetObject("Destination.Properties.AutoHeight")));
            this.Destination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("Destination.Properties.Buttons"))))});
            this.Destination.Properties.GlyphAlignment = ((DevExpress.Utils.HorzAlignment)(resources.GetObject("Destination.Properties.GlyphAlignment")));
            this.Destination.Properties.NullValuePrompt = resources.GetString("Destination.Properties.NullValuePrompt");
            this.Destination.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Destination.Properties.NullValuePromptShowForEmptyValue")));
            this.Destination.StyleController = this.lcMain;
            // 
            // lcgRoot
            // 
            this.lcgRoot.AppearanceItemCaption.Font = ((System.Drawing.Font)(resources.GetObject("lcgRoot.AppearanceItemCaption.Font")));
            this.lcgRoot.AppearanceItemCaption.FontSizeDelta = ((int)(resources.GetObject("lcgRoot.AppearanceItemCaption.FontSizeDelta")));
            this.lcgRoot.AppearanceItemCaption.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lcgRoot.AppearanceItemCaption.FontStyleDelta")));
            this.lcgRoot.AppearanceItemCaption.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lcgRoot.AppearanceItemCaption.GradientMode")));
            this.lcgRoot.AppearanceItemCaption.Image = ((System.Drawing.Image)(resources.GetObject("lcgRoot.AppearanceItemCaption.Image")));
            this.lcgRoot.AppearanceItemCaption.Options.UseFont = true;
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForGrid,
            this.HeaderGroup});
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 8);
            this.lcgRoot.Size = new System.Drawing.Size(702, 313);
            this.lcgRoot.TextVisible = false;
            // 
            // ItemForGrid
            // 
            resources.ApplyResources(this.ItemForGrid, "ItemForGrid");
            this.ItemForGrid.Control = this.gcMain;
            this.ItemForGrid.Location = new System.Drawing.Point(0, 122);
            this.ItemForGrid.Name = "ItemForGrid";
            this.ItemForGrid.Size = new System.Drawing.Size(702, 183);
            this.ItemForGrid.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForGrid.TextVisible = false;
            // 
            // HeaderGroup
            // 
            this.HeaderGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.HeaderGroup.GroupBordersVisible = false;
            this.HeaderGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTargetDatabase,
            this.ItemForDatabase,
            this.ItemForDestination,
            this.ItemForRefresh,
            this.ItemForDeleteFilesOnSuccess,
            this.ItemForDate});
            this.HeaderGroup.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.HeaderGroup.Location = new System.Drawing.Point(0, 0);
            this.HeaderGroup.Name = "HeaderGroup";
            columnDefinition4.SizeType = System.Windows.Forms.SizeType.AutoSize;
            columnDefinition4.Width = 348D;
            columnDefinition5.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition5.Width = 200D;
            columnDefinition6.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition6.Width = 150D;
            this.HeaderGroup.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition4,
            columnDefinition5,
            columnDefinition6});
            rowDefinition4.Height = 34D;
            rowDefinition4.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition5.Height = 42D;
            rowDefinition5.SizeType = System.Windows.Forms.SizeType.AutoSize;
            rowDefinition6.Height = 34D;
            rowDefinition6.SizeType = System.Windows.Forms.SizeType.AutoSize;
            this.HeaderGroup.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition4,
            rowDefinition5,
            rowDefinition6});
            this.HeaderGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 8);
            this.HeaderGroup.Size = new System.Drawing.Size(702, 122);
            this.HeaderGroup.TextVisible = false;
            // 
            // ItemForTargetDatabase
            // 
            resources.ApplyResources(this.ItemForTargetDatabase, "ItemForTargetDatabase");
            this.ItemForTargetDatabase.Control = this.TargetDatabase;
            this.ItemForTargetDatabase.Location = new System.Drawing.Point(0, 76);
            this.ItemForTargetDatabase.Name = "ItemForTargetDatabase";
            this.ItemForTargetDatabase.OptionsTableLayoutItem.RowIndex = 2;
            this.ItemForTargetDatabase.Size = new System.Drawing.Size(348, 34);
            this.ItemForTargetDatabase.TextSize = new System.Drawing.Size(102, 17);
            // 
            // ItemForDatabase
            // 
            resources.ApplyResources(this.ItemForDatabase, "ItemForDatabase");
            this.ItemForDatabase.Control = this.Database;
            this.ItemForDatabase.Location = new System.Drawing.Point(0, 0);
            this.ItemForDatabase.Name = "ItemForDatabase";
            this.ItemForDatabase.Size = new System.Drawing.Size(348, 34);
            this.ItemForDatabase.TextSize = new System.Drawing.Size(102, 17);
            // 
            // ItemForDestination
            // 
            resources.ApplyResources(this.ItemForDestination, "ItemForDestination");
            this.ItemForDestination.Control = this.Destination;
            this.ItemForDestination.Location = new System.Drawing.Point(0, 34);
            this.ItemForDestination.Name = "ItemForDestination";
            this.ItemForDestination.OptionsTableLayoutItem.ColumnSpan = 2;
            this.ItemForDestination.OptionsTableLayoutItem.RowIndex = 1;
            this.ItemForDestination.Size = new System.Drawing.Size(548, 42);
            this.ItemForDestination.TextSize = new System.Drawing.Size(102, 17);
            // 
            // ItemForRefresh
            // 
            resources.ApplyResources(this.ItemForRefresh, "ItemForRefresh");
            this.ItemForRefresh.Control = this.sbRefresh;
            this.ItemForRefresh.Location = new System.Drawing.Point(548, 34);
            this.ItemForRefresh.Name = "ItemForRefresh";
            this.ItemForRefresh.OptionsTableLayoutItem.ColumnIndex = 2;
            this.ItemForRefresh.OptionsTableLayoutItem.RowIndex = 1;
            this.ItemForRefresh.Size = new System.Drawing.Size(150, 42);
            this.ItemForRefresh.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForRefresh.TextVisible = false;
            // 
            // ItemForDeleteFilesOnSuccess
            // 
            resources.ApplyResources(this.ItemForDeleteFilesOnSuccess, "ItemForDeleteFilesOnSuccess");
            this.ItemForDeleteFilesOnSuccess.Control = this.DeleteFilesOnSuccess;
            this.ItemForDeleteFilesOnSuccess.Location = new System.Drawing.Point(348, 76);
            this.ItemForDeleteFilesOnSuccess.Name = "ItemForDeleteFilesOnSuccess";
            this.ItemForDeleteFilesOnSuccess.OptionsTableLayoutItem.ColumnIndex = 1;
            this.ItemForDeleteFilesOnSuccess.OptionsTableLayoutItem.ColumnSpan = 2;
            this.ItemForDeleteFilesOnSuccess.OptionsTableLayoutItem.RowIndex = 2;
            this.ItemForDeleteFilesOnSuccess.Size = new System.Drawing.Size(350, 34);
            this.ItemForDeleteFilesOnSuccess.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForDeleteFilesOnSuccess.TextSize = new System.Drawing.Size(230, 17);
            this.ItemForDeleteFilesOnSuccess.TextToControlDistance = 5;
            // 
            // ItemForDate
            // 
            resources.ApplyResources(this.ItemForDate, "ItemForDate");
            this.ItemForDate.Control = this.Date;
            this.ItemForDate.Location = new System.Drawing.Point(348, 0);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.OptionsTableLayoutItem.ColumnIndex = 1;
            this.ItemForDate.Size = new System.Drawing.Size(200, 34);
            this.ItemForDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForDate.TextSize = new System.Drawing.Size(53, 17);
            this.ItemForDate.TextToControlDistance = 5;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(Dekart.LazyNet.SQLBackup2Remote.Models.RestoreBackupViewModel);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // RestoreBackupView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcMain);
            this.Controls.Add(this.pcButtons);
            this.Name = "RestoreBackupView";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pcButtons)).EndInit();
            this.pcButtons.ResumeLayout(false);
            this.pcButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeleteFilesOnSuccess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Database.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Destination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTargetDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeleteFilesOnSuccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcButtons;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit riDateEdit;
        private DevExpress.XtraEditors.SimpleButton sbRefresh;
        private DevExpress.XtraEditors.ImageComboBoxEdit Destination;
        private DevExpress.XtraEditors.ImageComboBoxEdit Database;
        private DevExpress.XtraGrid.Columns.GridColumn colBackupType;
        private DevExpress.XtraGrid.Columns.GridColumn colServer;
        private DevExpress.XtraGrid.Columns.GridColumn colDatabaseName;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishDate;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.ImageComboBoxEdit TargetDatabase;
        private DevExpress.XtraEditors.PanelControl pcSeparator;
        private DevExpress.XtraEditors.SimpleButton sbOk;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstLsn;
        private DevExpress.XtraGrid.Columns.GridColumn colLastLsn;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckpointLsn;
        private DevExpress.XtraGrid.Columns.GridColumn colBackupLsn;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private DevExpress.XtraLayout.LayoutControlItem ItemForGrid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDatabase;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRefresh;
        private DevExpress.XtraLayout.LayoutControlGroup HeaderGroup;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTargetDatabase;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDestination;
        private DevExpress.XtraEditors.DateEdit Date;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraEditors.ToggleSwitch DeleteFilesOnSuccess;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeleteFilesOnSuccess;
    }
}