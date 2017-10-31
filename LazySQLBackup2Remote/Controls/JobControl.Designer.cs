
namespace Dekart.LazyNet.SQLBackup2Remote.Controls
{
    partial class JobControl
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobControl));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.hlAfterBackup = new DevExpress.XtraEditors.HyperLinkEdit();
            this.hlBeforeBackup = new DevExpress.XtraEditors.HyperLinkEdit();
            this.lcCustomSQLScripts = new DevExpress.XtraEditors.LabelControl();
            this.lcServerName = new DevExpress.XtraEditors.LabelControl();
            this.sbSchedulerSettings = new DevExpress.XtraEditors.SimpleButton();
            this.sbEmailSettings = new DevExpress.XtraEditors.SimpleButton();
            this.teNextFullBackupStart = new DevExpress.XtraEditors.TimeEdit();
            this.cbScheduleThisJob = new DevExpress.XtraEditors.CheckEdit();
            this.teOnFailureMailTo = new DevExpress.XtraEditors.TextEdit();
            this.teOnSuccessMailTo = new DevExpress.XtraEditors.TextEdit();
            this.cbSendEmails = new DevExpress.XtraEditors.CheckEdit();
            this.gcDestinations = new DevExpress.XtraGrid.GridControl();
            this.advMain = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcDelete = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.beDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcPath = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gcEdit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.beEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.hlAddDestination = new DevExpress.XtraEditors.HyperLinkEdit();
            this.sbRunNow = new DevExpress.XtraEditors.SimpleButton();
            this.lbDatabases = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.cbShowSystemDatabases = new DevExpress.XtraEditors.CheckEdit();
            this.cbBackupAllNonSystemDBs = new DevExpress.XtraEditors.CheckEdit();
            this.sbConnect = new DevExpress.XtraEditors.SimpleButton();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciConnect = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBackupAllNonSystemDBs = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciShowSystemDatabases = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDatabases = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCustomSQLScripts = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgOptions = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgDestinations = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAddDestination = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDestinations = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciRunNow = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgSendEmails = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSendEmails = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOnSuccessMailTo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOnFailureMailTo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmailSettings = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgSchedule = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciScheduleThisJob = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNextFullBackupStart = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSchedulerSettings = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hlAfterBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlBeforeBackup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNextFullBackupStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbScheduleThisJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOnFailureMailTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOnSuccessMailTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSendEmails.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDestinations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlAddDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbShowSystemDatabases.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBackupAllNonSystemDBs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupAllNonSystemDBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciShowSystemDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomSQLScripts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDestinations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDestinations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRunNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSendEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSendEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOnSuccessMailTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOnFailureMailTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmailSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciScheduleThisJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNextFullBackupStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSchedulerSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.AllowCustomization = false;
            this.lcMain.Controls.Add(this.hlAfterBackup);
            this.lcMain.Controls.Add(this.hlBeforeBackup);
            this.lcMain.Controls.Add(this.lcCustomSQLScripts);
            this.lcMain.Controls.Add(this.lcServerName);
            this.lcMain.Controls.Add(this.sbSchedulerSettings);
            this.lcMain.Controls.Add(this.sbEmailSettings);
            this.lcMain.Controls.Add(this.teNextFullBackupStart);
            this.lcMain.Controls.Add(this.cbScheduleThisJob);
            this.lcMain.Controls.Add(this.teOnFailureMailTo);
            this.lcMain.Controls.Add(this.teOnSuccessMailTo);
            this.lcMain.Controls.Add(this.cbSendEmails);
            this.lcMain.Controls.Add(this.gcDestinations);
            this.lcMain.Controls.Add(this.hlAddDestination);
            this.lcMain.Controls.Add(this.sbRunNow);
            this.lcMain.Controls.Add(this.lbDatabases);
            this.lcMain.Controls.Add(this.cbShowSystemDatabases);
            this.lcMain.Controls.Add(this.cbBackupAllNonSystemDBs);
            this.lcMain.Controls.Add(this.sbConnect);
            resources.ApplyResources(this.lcMain, "lcMain");
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2846, 121, 593, 660);
            this.lcMain.Root = this.lcgRoot;
            // 
            // hlAfterBackup
            // 
            resources.ApplyResources(this.hlAfterBackup, "hlAfterBackup");
            this.hlAfterBackup.Name = "hlAfterBackup";
            this.hlAfterBackup.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("hlAfterBackup.Properties.Appearance.BackColor")));
            this.hlAfterBackup.Properties.Appearance.Options.UseBackColor = true;
            this.hlAfterBackup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hlAfterBackup.StyleController = this.lcMain;
            this.hlAfterBackup.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hlAfterBackup_OpenLink);
            // 
            // hlBeforeBackup
            // 
            resources.ApplyResources(this.hlBeforeBackup, "hlBeforeBackup");
            this.hlBeforeBackup.Name = "hlBeforeBackup";
            this.hlBeforeBackup.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("hlBeforeBackup.Properties.Appearance.BackColor")));
            this.hlBeforeBackup.Properties.Appearance.Options.UseBackColor = true;
            this.hlBeforeBackup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hlBeforeBackup.StyleController = this.lcMain;
            this.hlBeforeBackup.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hlBeforeBackup_OpenLink);
            // 
            // lcCustomSQLScripts
            // 
            resources.ApplyResources(this.lcCustomSQLScripts, "lcCustomSQLScripts");
            this.lcCustomSQLScripts.Name = "lcCustomSQLScripts";
            this.lcCustomSQLScripts.StyleController = this.lcMain;
            // 
            // lcServerName
            // 
            this.lcServerName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lcServerName.Appearance.Font")));
            this.lcServerName.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.lcServerName, "lcServerName");
            this.lcServerName.Name = "lcServerName";
            this.lcServerName.StyleController = this.lcMain;
            // 
            // sbSchedulerSettings
            // 
            this.sbSchedulerSettings.AutoWidthInLayoutControl = true;
            this.sbSchedulerSettings.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.properties_32x32;
            resources.ApplyResources(this.sbSchedulerSettings, "sbSchedulerSettings");
            this.sbSchedulerSettings.Name = "sbSchedulerSettings";
            this.sbSchedulerSettings.StyleController = this.lcMain;
            this.sbSchedulerSettings.Click += new System.EventHandler(this.SbSchedulerSettingsClick);
            // 
            // sbEmailSettings
            // 
            this.sbEmailSettings.AutoWidthInLayoutControl = true;
            this.sbEmailSettings.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.properties_32x32;
            resources.ApplyResources(this.sbEmailSettings, "sbEmailSettings");
            this.sbEmailSettings.Name = "sbEmailSettings";
            this.sbEmailSettings.StyleController = this.lcMain;
            this.sbEmailSettings.Click += new System.EventHandler(this.SbEmailSettingsClick);
            // 
            // teNextFullBackupStart
            // 
            resources.ApplyResources(this.teNextFullBackupStart, "teNextFullBackupStart");
            this.teNextFullBackupStart.Name = "teNextFullBackupStart";
            this.teNextFullBackupStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("teNextFullBackupStart.Properties.Buttons"))))});
            this.teNextFullBackupStart.Properties.Mask.EditMask = resources.GetString("teNextFullBackupStart.Properties.Mask.EditMask");
            this.teNextFullBackupStart.StyleController = this.lcMain;
            // 
            // cbScheduleThisJob
            // 
            resources.ApplyResources(this.cbScheduleThisJob, "cbScheduleThisJob");
            this.cbScheduleThisJob.Name = "cbScheduleThisJob";
            this.cbScheduleThisJob.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cbScheduleThisJob.Properties.Appearance.Font")));
            this.cbScheduleThisJob.Properties.Appearance.Options.UseFont = true;
            this.cbScheduleThisJob.Properties.Caption = resources.GetString("cbScheduleThisJob.Properties.Caption");
            this.cbScheduleThisJob.StyleController = this.lcMain;
            // 
            // teOnFailureMailTo
            // 
            resources.ApplyResources(this.teOnFailureMailTo, "teOnFailureMailTo");
            this.teOnFailureMailTo.Name = "teOnFailureMailTo";
            this.teOnFailureMailTo.StyleController = this.lcMain;
            // 
            // teOnSuccessMailTo
            // 
            resources.ApplyResources(this.teOnSuccessMailTo, "teOnSuccessMailTo");
            this.teOnSuccessMailTo.Name = "teOnSuccessMailTo";
            this.teOnSuccessMailTo.StyleController = this.lcMain;
            // 
            // cbSendEmails
            // 
            resources.ApplyResources(this.cbSendEmails, "cbSendEmails");
            this.cbSendEmails.Name = "cbSendEmails";
            this.cbSendEmails.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cbSendEmails.Properties.Appearance.Font")));
            this.cbSendEmails.Properties.Appearance.Options.UseFont = true;
            this.cbSendEmails.Properties.Caption = resources.GetString("cbSendEmails.Properties.Caption");
            this.cbSendEmails.StyleController = this.lcMain;
            this.cbSendEmails.CheckedChanged += new System.EventHandler(this.CbSendEmailsCheckedChanged);
            // 
            // gcDestinations
            // 
            resources.ApplyResources(this.gcDestinations, "gcDestinations");
            this.gcDestinations.MainView = this.advMain;
            this.gcDestinations.Name = "gcDestinations";
            this.gcDestinations.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.beDelete,
            this.beEdit});
            this.gcDestinations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advMain});
            // 
            // advMain
            // 
            this.advMain.ActiveFilterEnabled = false;
            this.advMain.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.advMain.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gcDelete,
            this.gcType,
            this.gcPath,
            this.gcEdit});
            this.advMain.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.advMain.GridControl = this.gcDestinations;
            this.advMain.Name = "advMain";
            this.advMain.OptionsCustomization.AllowFilter = false;
            this.advMain.OptionsCustomization.AllowGroup = false;
            this.advMain.OptionsCustomization.AllowSort = false;
            this.advMain.OptionsMenu.EnableColumnMenu = false;
            this.advMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.advMain.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.advMain.OptionsView.ColumnAutoWidth = true;
            this.advMain.OptionsView.ShowBands = false;
            this.advMain.OptionsView.ShowColumnHeaders = false;
            this.advMain.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.advMain.OptionsView.ShowGroupPanel = false;
            this.advMain.OptionsView.ShowIndicator = false;
            this.advMain.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridBand1
            // 
            resources.ApplyResources(this.gridBand1, "gridBand1");
            this.gridBand1.Columns.Add(this.gcDelete);
            this.gridBand1.VisibleIndex = 0;
            // 
            // gcDelete
            // 
            resources.ApplyResources(this.gcDelete, "gcDelete");
            this.gcDelete.ColumnEdit = this.beDelete;
            this.gcDelete.Name = "gcDelete";
            this.gcDelete.OptionsColumn.FixedWidth = true;
            this.gcDelete.RowCount = 2;
            // 
            // beDelete
            // 
            resources.ApplyResources(this.beDelete, "beDelete");
            this.beDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beDelete.Buttons"))), resources.GetString("beDelete.Buttons1"), ((int)(resources.GetObject("beDelete.Buttons2"))), ((bool)(resources.GetObject("beDelete.Buttons3"))), ((bool)(resources.GetObject("beDelete.Buttons4"))), ((bool)(resources.GetObject("beDelete.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("beDelete.Buttons6"))), global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.delete_32x32, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("beDelete.Buttons7"), ((object)(resources.GetObject("beDelete.Buttons8"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("beDelete.Buttons9"))), ((bool)(resources.GetObject("beDelete.Buttons10"))))});
            this.beDelete.Name = "beDelete";
            this.beDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.beDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BeDeleteButtonClick);
            // 
            // gridBand2
            // 
            resources.ApplyResources(this.gridBand2, "gridBand2");
            this.gridBand2.Columns.Add(this.gcType);
            this.gridBand2.Columns.Add(this.gcPath);
            this.gridBand2.VisibleIndex = 1;
            // 
            // gcType
            // 
            this.gcType.FieldName = "TypeName";
            this.gcType.Name = "gcType";
            this.gcType.OptionsColumn.AllowEdit = false;
            this.gcType.OptionsColumn.ReadOnly = true;
            resources.ApplyResources(this.gcType, "gcType");
            // 
            // gcPath
            // 
            resources.ApplyResources(this.gcPath, "gcPath");
            this.gcPath.FieldName = "Path";
            this.gcPath.Name = "gcPath";
            this.gcPath.OptionsColumn.AllowEdit = false;
            this.gcPath.OptionsColumn.ReadOnly = true;
            this.gcPath.RowIndex = 1;
            // 
            // gridBand3
            // 
            resources.ApplyResources(this.gridBand3, "gridBand3");
            this.gridBand3.Columns.Add(this.gcEdit);
            this.gridBand3.VisibleIndex = 2;
            // 
            // gcEdit
            // 
            resources.ApplyResources(this.gcEdit, "gcEdit");
            this.gcEdit.ColumnEdit = this.beEdit;
            this.gcEdit.Name = "gcEdit";
            this.gcEdit.OptionsColumn.FixedWidth = true;
            this.gcEdit.RowCount = 2;
            // 
            // beEdit
            // 
            resources.ApplyResources(this.beEdit, "beEdit");
            this.beEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("beEdit.Buttons"))), resources.GetString("beEdit.Buttons1"), ((int)(resources.GetObject("beEdit.Buttons2"))), ((bool)(resources.GetObject("beEdit.Buttons3"))), ((bool)(resources.GetObject("beEdit.Buttons4"))), ((bool)(resources.GetObject("beEdit.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("beEdit.Buttons6"))), global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.properties_32x32, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, resources.GetString("beEdit.Buttons7"), ((object)(resources.GetObject("beEdit.Buttons8"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("beEdit.Buttons9"))), ((bool)(resources.GetObject("beEdit.Buttons10"))))});
            this.beEdit.Name = "beEdit";
            this.beEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.beEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BeEditButtonClick);
            // 
            // hlAddDestination
            // 
            resources.ApplyResources(this.hlAddDestination, "hlAddDestination");
            this.hlAddDestination.Name = "hlAddDestination";
            this.hlAddDestination.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("hlAddDestination.Properties.Appearance.BackColor")));
            this.hlAddDestination.Properties.Appearance.Options.UseBackColor = true;
            this.hlAddDestination.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hlAddDestination.Properties.ReadOnly = true;
            this.hlAddDestination.StyleController = this.lcMain;
            this.hlAddDestination.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.HlAddDestinationOpenLink);
            // 
            // sbRunNow
            // 
            this.sbRunNow.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("sbRunNow.Appearance.Font")));
            this.sbRunNow.Appearance.Options.UseFont = true;
            this.sbRunNow.AutoWidthInLayoutControl = true;
            this.sbRunNow.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.next_32x32;
            resources.ApplyResources(this.sbRunNow, "sbRunNow");
            this.sbRunNow.Name = "sbRunNow";
            this.sbRunNow.StyleController = this.lcMain;
            this.sbRunNow.Click += new System.EventHandler(this.SbRunNowClick);
            // 
            // lbDatabases
            // 
            this.lbDatabases.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.lbDatabases, "lbDatabases");
            this.lbDatabases.Name = "lbDatabases";
            this.lbDatabases.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.lbDatabases.StyleController = this.lcMain;
            this.lbDatabases.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.LbDatabasesItemCheck);
            // 
            // cbShowSystemDatabases
            // 
            resources.ApplyResources(this.cbShowSystemDatabases, "cbShowSystemDatabases");
            this.cbShowSystemDatabases.Name = "cbShowSystemDatabases";
            this.cbShowSystemDatabases.Properties.Caption = resources.GetString("cbShowSystemDatabases.Properties.Caption");
            this.cbShowSystemDatabases.StyleController = this.lcMain;
            this.cbShowSystemDatabases.CheckedChanged += new System.EventHandler(this.CbShowSystemDatabasesCheckedChanged);
            // 
            // cbBackupAllNonSystemDBs
            // 
            resources.ApplyResources(this.cbBackupAllNonSystemDBs, "cbBackupAllNonSystemDBs");
            this.cbBackupAllNonSystemDBs.Name = "cbBackupAllNonSystemDBs";
            this.cbBackupAllNonSystemDBs.Properties.Caption = resources.GetString("cbBackupAllNonSystemDBs.Properties.Caption");
            this.cbBackupAllNonSystemDBs.StyleController = this.lcMain;
            this.cbBackupAllNonSystemDBs.CheckedChanged += new System.EventHandler(this.CbBackupAllNonSystemDBsCheckedChanged);
            // 
            // sbConnect
            // 
            this.sbConnect.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("sbConnect.Appearance.Font")));
            this.sbConnect.Appearance.Options.UseFont = true;
            this.sbConnect.AutoWidthInLayoutControl = true;
            this.sbConnect.Image = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.managedatasource_32x32;
            resources.ApplyResources(this.sbConnect, "sbConnect");
            this.sbConnect.Name = "sbConnect";
            this.sbConnect.StyleController = this.lcMain;
            this.sbConnect.Click += new System.EventHandler(this.SbConnectClick);
            // 
            // lcgRoot
            // 
            resources.ApplyResources(this.lcgRoot, "lcgRoot");
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgMain,
            this.lcgOptions});
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "Root";
            this.lcgRoot.Size = new System.Drawing.Size(734, 562);
            this.lcgRoot.TextVisible = false;
            // 
            // lcgMain
            // 
            resources.ApplyResources(this.lcgMain, "lcgMain");
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciConnect,
            this.lciBackupAllNonSystemDBs,
            this.lciShowSystemDatabases,
            this.lciDatabases,
            this.layoutControlItem1,
            this.lciCustomSQLScripts,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Size = new System.Drawing.Size(239, 542);
            // 
            // lciConnect
            // 
            this.lciConnect.Control = this.sbConnect;
            resources.ApplyResources(this.lciConnect, "lciConnect");
            this.lciConnect.Location = new System.Drawing.Point(0, 17);
            this.lciConnect.Name = "lciConnect";
            this.lciConnect.Size = new System.Drawing.Size(239, 42);
            this.lciConnect.TextSize = new System.Drawing.Size(0, 0);
            this.lciConnect.TextVisible = false;
            // 
            // lciBackupAllNonSystemDBs
            // 
            this.lciBackupAllNonSystemDBs.Control = this.cbBackupAllNonSystemDBs;
            resources.ApplyResources(this.lciBackupAllNonSystemDBs, "lciBackupAllNonSystemDBs");
            this.lciBackupAllNonSystemDBs.Location = new System.Drawing.Point(0, 59);
            this.lciBackupAllNonSystemDBs.Name = "lciBackupAllNonSystemDBs";
            this.lciBackupAllNonSystemDBs.Size = new System.Drawing.Size(239, 23);
            this.lciBackupAllNonSystemDBs.TextSize = new System.Drawing.Size(0, 0);
            this.lciBackupAllNonSystemDBs.TextVisible = false;
            // 
            // lciShowSystemDatabases
            // 
            this.lciShowSystemDatabases.Control = this.cbShowSystemDatabases;
            resources.ApplyResources(this.lciShowSystemDatabases, "lciShowSystemDatabases");
            this.lciShowSystemDatabases.Location = new System.Drawing.Point(0, 82);
            this.lciShowSystemDatabases.Name = "lciShowSystemDatabases";
            this.lciShowSystemDatabases.Size = new System.Drawing.Size(239, 23);
            this.lciShowSystemDatabases.TextSize = new System.Drawing.Size(0, 0);
            this.lciShowSystemDatabases.TextVisible = false;
            // 
            // lciDatabases
            // 
            this.lciDatabases.Control = this.lbDatabases;
            resources.ApplyResources(this.lciDatabases, "lciDatabases");
            this.lciDatabases.Location = new System.Drawing.Point(0, 105);
            this.lciDatabases.Name = "lciDatabases";
            this.lciDatabases.Size = new System.Drawing.Size(239, 398);
            this.lciDatabases.TextSize = new System.Drawing.Size(0, 0);
            this.lciDatabases.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lcServerName;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(239, 17);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lciCustomSQLScripts
            // 
            this.lciCustomSQLScripts.Control = this.lcCustomSQLScripts;
            this.lciCustomSQLScripts.Location = new System.Drawing.Point(0, 503);
            this.lciCustomSQLScripts.Name = "lciCustomSQLScripts";
            this.lciCustomSQLScripts.Size = new System.Drawing.Size(239, 17);
            this.lciCustomSQLScripts.TextSize = new System.Drawing.Size(0, 0);
            this.lciCustomSQLScripts.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.hlBeforeBackup;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 520);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(122, 22);
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.hlAfterBackup;
            this.layoutControlItem4.Location = new System.Drawing.Point(122, 520);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(117, 22);
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // lcgOptions
            // 
            resources.ApplyResources(this.lcgOptions, "lcgOptions");
            this.lcgOptions.GroupBordersVisible = false;
            this.lcgOptions.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgDestinations,
            this.lciRunNow,
            this.lcgSendEmails,
            this.emptySpaceItem1,
            this.lcgSchedule});
            this.lcgOptions.Location = new System.Drawing.Point(239, 0);
            this.lcgOptions.Name = "lcgOptions";
            this.lcgOptions.Size = new System.Drawing.Size(475, 542);
            this.lcgOptions.TextVisible = false;
            // 
            // lcgDestinations
            // 
            this.lcgDestinations.AppearanceGroup.Font = ((System.Drawing.Font)(resources.GetObject("lcgDestinations.AppearanceGroup.Font")));
            this.lcgDestinations.AppearanceGroup.Options.UseFont = true;
            this.lcgDestinations.CaptionImage = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.publish_32x32;
            resources.ApplyResources(this.lcgDestinations, "lcgDestinations");
            this.lcgDestinations.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAddDestination,
            this.lciDestinations,
            this.emptySpaceItem2});
            this.lcgDestinations.Location = new System.Drawing.Point(0, 0);
            this.lcgDestinations.Name = "lcgDestinations";
            this.lcgDestinations.Size = new System.Drawing.Size(475, 216);
            // 
            // lciAddDestination
            // 
            this.lciAddDestination.Control = this.hlAddDestination;
            resources.ApplyResources(this.lciAddDestination, "lciAddDestination");
            this.lciAddDestination.Location = new System.Drawing.Point(0, 130);
            this.lciAddDestination.MaxSize = new System.Drawing.Size(154, 22);
            this.lciAddDestination.MinSize = new System.Drawing.Size(154, 22);
            this.lciAddDestination.Name = "lciAddDestination";
            this.lciAddDestination.Size = new System.Drawing.Size(154, 22);
            this.lciAddDestination.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciAddDestination.TextSize = new System.Drawing.Size(0, 0);
            this.lciAddDestination.TextVisible = false;
            // 
            // lciDestinations
            // 
            this.lciDestinations.Control = this.gcDestinations;
            resources.ApplyResources(this.lciDestinations, "lciDestinations");
            this.lciDestinations.Location = new System.Drawing.Point(0, 0);
            this.lciDestinations.Name = "lciDestinations";
            this.lciDestinations.Size = new System.Drawing.Size(451, 130);
            this.lciDestinations.TextSize = new System.Drawing.Size(0, 0);
            this.lciDestinations.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem2, "emptySpaceItem2");
            this.emptySpaceItem2.Location = new System.Drawing.Point(154, 130);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(297, 22);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciRunNow
            // 
            this.lciRunNow.Control = this.sbRunNow;
            resources.ApplyResources(this.lciRunNow, "lciRunNow");
            this.lciRunNow.Location = new System.Drawing.Point(363, 500);
            this.lciRunNow.Name = "lciRunNow";
            this.lciRunNow.Size = new System.Drawing.Size(112, 42);
            this.lciRunNow.TextSize = new System.Drawing.Size(0, 0);
            this.lciRunNow.TextVisible = false;
            // 
            // lcgSendEmails
            // 
            this.lcgSendEmails.AppearanceGroup.Font = ((System.Drawing.Font)(resources.GetObject("lcgSendEmails.AppearanceGroup.Font")));
            this.lcgSendEmails.AppearanceGroup.Options.UseFont = true;
            this.lcgSendEmails.CaptionImage = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.mail_32x32;
            resources.ApplyResources(this.lcgSendEmails, "lcgSendEmails");
            this.lcgSendEmails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSendEmails,
            this.lciOnSuccessMailTo,
            this.lciOnFailureMailTo,
            this.lciEmailSettings});
            this.lcgSendEmails.Location = new System.Drawing.Point(0, 216);
            this.lcgSendEmails.Name = "lcgSendEmails";
            this.lcgSendEmails.Size = new System.Drawing.Size(475, 154);
            // 
            // lciSendEmails
            // 
            this.lciSendEmails.Control = this.cbSendEmails;
            resources.ApplyResources(this.lciSendEmails, "lciSendEmails");
            this.lciSendEmails.Location = new System.Drawing.Point(0, 0);
            this.lciSendEmails.Name = "lciSendEmails";
            this.lciSendEmails.Size = new System.Drawing.Size(407, 42);
            this.lciSendEmails.TextSize = new System.Drawing.Size(0, 0);
            this.lciSendEmails.TextVisible = false;
            // 
            // lciOnSuccessMailTo
            // 
            this.lciOnSuccessMailTo.Control = this.teOnSuccessMailTo;
            resources.ApplyResources(this.lciOnSuccessMailTo, "lciOnSuccessMailTo");
            this.lciOnSuccessMailTo.Location = new System.Drawing.Point(0, 42);
            this.lciOnSuccessMailTo.Name = "lciOnSuccessMailTo";
            this.lciOnSuccessMailTo.Size = new System.Drawing.Size(451, 24);
            this.lciOnSuccessMailTo.TextSize = new System.Drawing.Size(103, 13);
            // 
            // lciOnFailureMailTo
            // 
            this.lciOnFailureMailTo.Control = this.teOnFailureMailTo;
            resources.ApplyResources(this.lciOnFailureMailTo, "lciOnFailureMailTo");
            this.lciOnFailureMailTo.Location = new System.Drawing.Point(0, 66);
            this.lciOnFailureMailTo.Name = "lciOnFailureMailTo";
            this.lciOnFailureMailTo.Size = new System.Drawing.Size(451, 24);
            this.lciOnFailureMailTo.TextSize = new System.Drawing.Size(103, 13);
            // 
            // lciEmailSettings
            // 
            this.lciEmailSettings.Control = this.sbEmailSettings;
            resources.ApplyResources(this.lciEmailSettings, "lciEmailSettings");
            this.lciEmailSettings.Location = new System.Drawing.Point(407, 0);
            this.lciEmailSettings.Name = "lciEmailSettings";
            this.lciEmailSettings.Size = new System.Drawing.Size(44, 42);
            this.lciEmailSettings.TextSize = new System.Drawing.Size(0, 0);
            this.lciEmailSettings.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 500);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(363, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgSchedule
            // 
            this.lcgSchedule.AppearanceGroup.Font = ((System.Drawing.Font)(resources.GetObject("lcgSchedule.AppearanceGroup.Font")));
            this.lcgSchedule.AppearanceGroup.Options.UseFont = true;
            this.lcgSchedule.CaptionImage = global::Dekart.LazyNet.SQLBackup2Remote.Properties.Resources.task_32x32;
            resources.ApplyResources(this.lcgSchedule, "lcgSchedule");
            this.lcgSchedule.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciScheduleThisJob,
            this.lciNextFullBackupStart,
            this.lciSchedulerSettings});
            this.lcgSchedule.Location = new System.Drawing.Point(0, 370);
            this.lcgSchedule.Name = "lcgSchedule";
            this.lcgSchedule.Size = new System.Drawing.Size(475, 130);
            // 
            // lciScheduleThisJob
            // 
            this.lciScheduleThisJob.Control = this.cbScheduleThisJob;
            resources.ApplyResources(this.lciScheduleThisJob, "lciScheduleThisJob");
            this.lciScheduleThisJob.Location = new System.Drawing.Point(0, 0);
            this.lciScheduleThisJob.Name = "lciScheduleThisJob";
            this.lciScheduleThisJob.Size = new System.Drawing.Size(407, 42);
            this.lciScheduleThisJob.TextSize = new System.Drawing.Size(0, 0);
            this.lciScheduleThisJob.TextVisible = false;
            // 
            // lciNextFullBackupStart
            // 
            this.lciNextFullBackupStart.Control = this.teNextFullBackupStart;
            resources.ApplyResources(this.lciNextFullBackupStart, "lciNextFullBackupStart");
            this.lciNextFullBackupStart.Location = new System.Drawing.Point(0, 42);
            this.lciNextFullBackupStart.Name = "lciNextFullBackupStart";
            this.lciNextFullBackupStart.Size = new System.Drawing.Size(451, 24);
            this.lciNextFullBackupStart.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciNextFullBackupStart.TextSize = new System.Drawing.Size(120, 13);
            this.lciNextFullBackupStart.TextToControlDistance = 5;
            // 
            // lciSchedulerSettings
            // 
            this.lciSchedulerSettings.Control = this.sbSchedulerSettings;
            resources.ApplyResources(this.lciSchedulerSettings, "lciSchedulerSettings");
            this.lciSchedulerSettings.Location = new System.Drawing.Point(407, 0);
            this.lciSchedulerSettings.Name = "lciSchedulerSettings";
            this.lciSchedulerSettings.Size = new System.Drawing.Size(44, 42);
            this.lciSchedulerSettings.TextSize = new System.Drawing.Size(0, 0);
            this.lciSchedulerSettings.TextVisible = false;
            // 
            // JobControl
            // 
            this.Controls.Add(this.lcMain);
            this.Name = "JobControl";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hlAfterBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlBeforeBackup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNextFullBackupStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbScheduleThisJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOnFailureMailTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teOnSuccessMailTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSendEmails.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDestinations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlAddDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbShowSystemDatabases.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBackupAllNonSystemDBs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackupAllNonSystemDBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciShowSystemDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCustomSQLScripts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDestinations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDestinations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRunNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSendEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSendEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOnSuccessMailTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOnFailureMailTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmailSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciScheduleThisJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNextFullBackupStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSchedulerSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private DevExpress.XtraEditors.SimpleButton sbRunNow;
        private DevExpress.XtraEditors.CheckedListBoxControl lbDatabases;
        private DevExpress.XtraEditors.CheckEdit cbShowSystemDatabases;
        private DevExpress.XtraEditors.CheckEdit cbBackupAllNonSystemDBs;
        private DevExpress.XtraEditors.SimpleButton sbConnect;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlItem lciConnect;
        private DevExpress.XtraLayout.LayoutControlItem lciBackupAllNonSystemDBs;
        private DevExpress.XtraLayout.LayoutControlItem lciShowSystemDatabases;
        private DevExpress.XtraLayout.LayoutControlItem lciDatabases;
        private DevExpress.XtraLayout.LayoutControlGroup lcgOptions;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDestinations;
        private DevExpress.XtraLayout.LayoutControlItem lciRunNow;
        private DevExpress.XtraEditors.HyperLinkEdit hlAddDestination;
        private DevExpress.XtraLayout.LayoutControlItem lciAddDestination;
        private DevExpress.XtraGrid.GridControl gcDestinations;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advMain;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit beDelete;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcType;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcPath;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit beEdit;
        private DevExpress.XtraLayout.LayoutControlItem lciDestinations;
        private DevExpress.XtraEditors.TextEdit teOnFailureMailTo;
        private DevExpress.XtraEditors.TextEdit teOnSuccessMailTo;
        private DevExpress.XtraEditors.CheckEdit cbSendEmails;
        private DevExpress.XtraLayout.LayoutControlItem lciSendEmails;
        private DevExpress.XtraLayout.LayoutControlItem lciOnSuccessMailTo;
        private DevExpress.XtraLayout.LayoutControlItem lciOnFailureMailTo;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSendEmails;
        private DevExpress.XtraEditors.CheckEdit cbScheduleThisJob;
        private DevExpress.XtraLayout.LayoutControlItem lciScheduleThisJob;
        private DevExpress.XtraEditors.TimeEdit teNextFullBackupStart;
        private DevExpress.XtraLayout.LayoutControlItem lciNextFullBackupStart;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSchedule;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraEditors.SimpleButton sbEmailSettings;
        private DevExpress.XtraLayout.LayoutControlItem lciEmailSettings;
        private DevExpress.XtraEditors.SimpleButton sbSchedulerSettings;
        private DevExpress.XtraLayout.LayoutControlItem lciSchedulerSettings;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.LabelControl lcServerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.HyperLinkEdit hlAfterBackup;
        private DevExpress.XtraEditors.HyperLinkEdit hlBeforeBackup;
        private DevExpress.XtraEditors.LabelControl lcCustomSQLScripts;
        private DevExpress.XtraLayout.LayoutControlItem lciCustomSQLScripts;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;

    }
}
