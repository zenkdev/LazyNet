using Dekart.LazyNet.Win.Modules;
using Dekart.LazyNet.Win.UserControls;

namespace Dekart.LazyNet.Win
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Skins.SkinPaddingEdges skinPaddingEdges1 = new DevExpress.Skins.SkinPaddingEdges();
            DevExpress.Skins.SkinPaddingEdges skinPaddingEdges2 = new DevExpress.Skins.SkinPaddingEdges();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.Animation.Transition transition1 = new DevExpress.Utils.Animation.Transition();
            DevExpress.Utils.Animation.SlideFadeTransition slideFadeTransition1 = new DevExpress.Utils.Animation.SlideFadeTransition();
            this.pcMain = new DevExpress.XtraEditors.PanelControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.bvccAbout = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.aboutControl = new Dekart.LazyNet.Win.UserControls.AboutControl();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.importControl1 = new Dekart.LazyNet.Win.UserControls.ImportControl();
            this.backstageViewClientControl3 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.printControl1 = new Dekart.LazyNet.Win.UserControls.PrintControl();
            this.backstageViewClientControl4 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.exportControl1 = new Dekart.LazyNet.Win.UserControls.ExportControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.schedulerControl1 = new Dekart.LazyNet.Win.UserControls.SchedulerControl();
            this.bvtiAbout = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bvbiSaveAs = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.bvtiImport = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bvtiPrint = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bvtiExport = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bvtiScheduler = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bvbiOptions = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.bvbiExit = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.rcMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.sharedImageCollection1 = new DevExpress.Utils.SharedImageCollection(this.components);
            this.bbiNewDevice = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFindDevices = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenRadmin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenRomViewer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenMstsc = new DevExpress.XtraBars.BarButtonItem();
            this.galleryDeviceQuickReports = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.bbiNewUser = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBringToFront = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSendToBack = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMapBackground = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewRepair = new DevExpress.XtraBars.BarButtonItem();
            this.bsiNewItem = new DevExpress.XtraBars.BarSubItem();
            this.bbiNewSoftware = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteItem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditItem = new DevExpress.XtraBars.BarButtonItem();
            this.bciShowList = new DevExpress.XtraBars.BarCheckItem();
            this.bciShowCards = new DevExpress.XtraBars.BarCheckItem();
            this.bciShowCount = new DevExpress.XtraBars.BarCheckItem();
            this.bbiCreateFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRenameFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMoveFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCreateMap = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRenameMap = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteMap = new DevExpress.XtraBars.BarButtonItem();
            this.bsiNavigation = new DevExpress.XtraBars.BarSubItem();
            this.bsiFolderPane = new DevExpress.XtraBars.BarSubItem();
            this.bciFolderNormal = new DevExpress.XtraBars.BarCheckItem();
            this.bciFolderMinimized = new DevExpress.XtraBars.BarCheckItem();
            this.bciFolderOff = new DevExpress.XtraBars.BarCheckItem();
            this.bsiDataPane = new DevExpress.XtraBars.BarSubItem();
            this.bciDataRight = new DevExpress.XtraBars.BarCheckItem();
            this.bciDataBottom = new DevExpress.XtraBars.BarCheckItem();
            this.bciDataOff = new DevExpress.XtraBars.BarCheckItem();
            this.bsiPreview = new DevExpress.XtraBars.BarSubItem();
            this.bciPreviewOff = new DevExpress.XtraBars.BarCheckItem();
            this.bciPreview1 = new DevExpress.XtraBars.BarCheckItem();
            this.bciPreview2 = new DevExpress.XtraBars.BarCheckItem();
            this.bciPreview3 = new DevExpress.XtraBars.BarCheckItem();
            this.rgbiSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.bbiCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseSearch = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetColumnsToDefault = new DevExpress.XtraBars.BarButtonItem();
            this.bsiColumns = new DevExpress.XtraBars.BarSubItem();
            this.bbiNameColumn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSKUColumn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSerialColumn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserColumn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIPColumn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMACColumn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClearFilter = new DevExpress.XtraBars.BarButtonItem();
            this.bsiInfo = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNormal = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReading = new DevExpress.XtraBars.BarButtonItem();
            this.beiZoom = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            this.bbiOpenWeb = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPing = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTracert = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCustomFilter = new DevExpress.XtraBars.BarButtonItem();
            this.rpcSearch = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.rpSearch = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgFilterActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgFilterColumns = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbgFilterClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpDevices = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgDevicesNew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgDevicesDelete = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgDevicesActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgDevicesQuickReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpUsers = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgUsersNew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgUsersDelete = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgUsersActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgUsersCurrentView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgUsersFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpRepairs = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgRepairsNew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgRepairsDelete = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgRepairsActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgRepairsFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpMaps = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgMapsDelete = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgMapsActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpSoftware = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSoftwareNew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSoftwareDelete = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSoftwareActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSoftwareFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpView = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgLayout = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.prgAppearance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgWindow = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.nbMain = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgDevices = new DevExpress.XtraNavBar.NavBarGroup();
            this.ControlForDevicesNavBarGroup = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucDevicesTree = new Dekart.LazyNet.Win.Modules.DevicesTree();
            this.ControlForUsersNavBarGroup = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucUsersFilter = new Dekart.LazyNet.Win.Modules.UsersFilter();
            this.ControlForRepairsNavBarGroup = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucRepairsFilter = new Dekart.LazyNet.Win.Modules.RepairsFilter();
            this.ControlForMapsNavBarGroup = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucMaps = new Dekart.LazyNet.Win.Controls.MapsControl();
            this.ControlForSoftwareNavBarGroup = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucSoftwareFilter = new Dekart.LazyNet.Win.Modules.SoftwareFilter();
            this.nbgSoftware = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbgRepairs = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbgMaps = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbgUsers = new DevExpress.XtraNavBar.NavBarGroup();
            this.pmDeviceTree = new DevExpress.XtraBars.PopupMenu(this.components);
            this.pmMapTree = new DevExpress.XtraBars.PopupMenu(this.components);
            this.officeNavigationBar = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.transitionManager = new DevExpress.Utils.Animation.TransitionManager();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.notificationsManager = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).BeginInit();
            this.pcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            this.bvccAbout.SuspendLayout();
            this.backstageViewClientControl2.SuspendLayout();
            this.backstageViewClientControl3.SuspendLayout();
            this.backstageViewClientControl4.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbMain)).BeginInit();
            this.nbMain.SuspendLayout();
            this.ControlForDevicesNavBarGroup.SuspendLayout();
            this.ControlForUsersNavBarGroup.SuspendLayout();
            this.ControlForRepairsNavBarGroup.SuspendLayout();
            this.ControlForMapsNavBarGroup.SuspendLayout();
            this.ControlForSoftwareNavBarGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmDeviceTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMapTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // pcMain
            // 
            this.pcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcMain.Controls.Add(this.backstageViewControl1);
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(0, 0);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(908, 400);
            this.pcMain.TabIndex = 1;
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.bvccAbout);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl2);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl3);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl4);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Items.Add(this.bvtiAbout);
            this.backstageViewControl1.Items.Add(this.bvbiSaveAs);
            this.backstageViewControl1.Items.Add(this.bvtiImport);
            this.backstageViewControl1.Items.Add(this.bvtiPrint);
            this.backstageViewControl1.Items.Add(this.bvtiExport);
            this.backstageViewControl1.Items.Add(this.bvtiScheduler);
            this.backstageViewControl1.Items.Add(this.bvbiOptions);
            this.backstageViewControl1.Items.Add(this.bvbiExit);
            this.backstageViewControl1.Location = new System.Drawing.Point(25, 20);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.Ribbon = this.rcMain;
            this.backstageViewControl1.SelectedTab = this.bvtiAbout;
            this.backstageViewControl1.SelectedTabIndex = 0;
            this.backstageViewControl1.Size = new System.Drawing.Size(1016, 558);
            this.backstageViewControl1.TabIndex = 0;
            this.backstageViewControl1.Text = "backstageViewControl1";
            this.backstageViewControl1.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.BackstageViewControl1ItemClick);
            // 
            // bvccAbout
            // 
            this.bvccAbout.Controls.Add(this.aboutControl);
            this.bvccAbout.Location = new System.Drawing.Point(133, 63);
            this.bvccAbout.Name = "bvccAbout";
            this.bvccAbout.Size = new System.Drawing.Size(882, 494);
            this.bvccAbout.TabIndex = 0;
            // 
            // aboutControl
            // 
            this.aboutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutControl.ForeColor = System.Drawing.Color.Transparent;
            this.aboutControl.Location = new System.Drawing.Point(0, 0);
            this.aboutControl.Name = "aboutControl";
            this.aboutControl.Size = new System.Drawing.Size(882, 494);
            this.aboutControl.TabIndex = 0;
            // 
            // backstageViewClientControl2
            // 
            this.backstageViewClientControl2.Controls.Add(this.importControl1);
            this.backstageViewClientControl2.Location = new System.Drawing.Point(133, 63);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Padding = new System.Windows.Forms.Padding(20, 20, 20, 200);
            this.backstageViewClientControl2.Size = new System.Drawing.Size(882, 494);
            this.backstageViewClientControl2.TabIndex = 1;
            // 
            // importControl1
            // 
            this.importControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importControl1.ForeColor = System.Drawing.Color.Transparent;
            this.importControl1.Location = new System.Drawing.Point(20, 20);
            this.importControl1.Name = "importControl1";
            this.importControl1.Size = new System.Drawing.Size(842, 274);
            this.importControl1.TabIndex = 0;
            // 
            // backstageViewClientControl3
            // 
            this.backstageViewClientControl3.Controls.Add(this.printControl1);
            this.backstageViewClientControl3.Location = new System.Drawing.Point(133, 63);
            this.backstageViewClientControl3.Name = "backstageViewClientControl3";
            this.backstageViewClientControl3.Size = new System.Drawing.Size(882, 494);
            this.backstageViewClientControl3.TabIndex = 2;
            // 
            // printControl1
            // 
            this.printControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl1.ForeColor = System.Drawing.Color.Transparent;
            this.printControl1.Location = new System.Drawing.Point(0, 0);
            this.printControl1.Name = "printControl1";
            this.printControl1.Size = new System.Drawing.Size(882, 494);
            this.printControl1.TabIndex = 0;
            // 
            // backstageViewClientControl4
            // 
            this.backstageViewClientControl4.Controls.Add(this.exportControl1);
            this.backstageViewClientControl4.Location = new System.Drawing.Point(133, 63);
            this.backstageViewClientControl4.Name = "backstageViewClientControl4";
            this.backstageViewClientControl4.Size = new System.Drawing.Size(882, 494);
            this.backstageViewClientControl4.TabIndex = 3;
            // 
            // exportControl1
            // 
            this.exportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportControl1.ForeColor = System.Drawing.Color.Transparent;
            this.exportControl1.Location = new System.Drawing.Point(0, 0);
            this.exportControl1.Name = "exportControl1";
            this.exportControl1.Size = new System.Drawing.Size(882, 494);
            this.exportControl1.TabIndex = 0;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.schedulerControl1);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(133, 63);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(882, 494);
            this.backstageViewClientControl1.TabIndex = 4;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.ForeColor = System.Drawing.Color.Transparent;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(882, 494);
            this.schedulerControl1.TabIndex = 0;
            // 
            // bvtiAbout
            // 
            this.bvtiAbout.Caption = "Сведения";
            this.bvtiAbout.ContentControl = this.bvccAbout;
            this.bvtiAbout.Name = "bvtiAbout";
            this.bvtiAbout.Selected = true;
            // 
            // bvbiSaveAs
            // 
            this.bvbiSaveAs.Caption = "Сохранить как";
            this.bvbiSaveAs.Name = "bvbiSaveAs";
            // 
            // bvtiImport
            // 
            this.bvtiImport.Caption = "Импорт";
            this.bvtiImport.ContentControl = this.backstageViewClientControl2;
            this.bvtiImport.Name = "bvtiImport";
            this.bvtiImport.Selected = false;
            this.bvtiImport.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.BvtiImportSelectedChanged);
            // 
            // bvtiPrint
            // 
            this.bvtiPrint.Caption = "Печать";
            this.bvtiPrint.ContentControl = this.backstageViewClientControl3;
            this.bvtiPrint.Name = "bvtiPrint";
            this.bvtiPrint.Selected = false;
            this.bvtiPrint.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.BvtiPrintSelectedChanged);
            // 
            // bvtiExport
            // 
            this.bvtiExport.Caption = "Экспорт";
            this.bvtiExport.ContentControl = this.backstageViewClientControl4;
            this.bvtiExport.Name = "bvtiExport";
            this.bvtiExport.Selected = false;
            // 
            // bvtiScheduler
            // 
            this.bvtiScheduler.Caption = "Планировщик";
            this.bvtiScheduler.ContentControl = this.backstageViewClientControl1;
            this.bvtiScheduler.Name = "bvtiScheduler";
            this.bvtiScheduler.Selected = false;
            this.bvtiScheduler.SelectedChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.bvtiScheduler_SelectedChanged);
            // 
            // bvbiOptions
            // 
            this.bvbiOptions.Caption = "Параметры";
            this.bvbiOptions.Name = "bvbiOptions";
            this.bvbiOptions.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.bvbiOptions_ItemClick);
            // 
            // bvbiExit
            // 
            this.bvbiExit.Caption = "Выход";
            this.bvbiExit.Name = "bvbiExit";
            this.bvbiExit.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.BvbiExitItemClick);
            // 
            // rcMain
            // 
            this.rcMain.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.rcMain.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Устройства", new System.Guid("ab7304c8-4231-4c6b-b739-a68c0019c9f5")),
            new DevExpress.XtraBars.BarManagerCategory("Пользователи", new System.Guid("2e57362f-091f-459b-902e-f54e9e917755")),
            new DevExpress.XtraBars.BarManagerCategory("Feeds", new System.Guid("fc068f83-501a-4507-a796-fa3e2b0498e3")),
            new DevExpress.XtraBars.BarManagerCategory("Tasks", new System.Guid("fa04234b-cc0f-4b1d-b932-895f4a568ccf"))});
            this.rcMain.ExpandCollapseItem.Id = 0;
            this.rcMain.Images = this.sharedImageCollection1;
            this.rcMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcMain.ExpandCollapseItem,
            this.bbiNewDevice,
            this.bbiFindDevices,
            this.bbiOpenRadmin,
            this.bbiOpenRomViewer,
            this.bbiOpenMstsc,
            this.galleryDeviceQuickReports,
            this.bbiNewUser,
            this.bbiBringToFront,
            this.bbiSendToBack,
            this.bbiMapBackground,
            this.bbiNewRepair,
            this.bsiNewItem,
            this.bbiDeleteItem,
            this.bbiEditItem,
            this.bciShowList,
            this.bciShowCards,
            this.bciShowCount,
            this.bbiCreateFolder,
            this.bbiRenameFolder,
            this.bbiMoveFolder,
            this.bbiDeleteFolder,
            this.bbiCreateMap,
            this.bbiRenameMap,
            this.bbiDeleteMap,
            this.bsiNavigation,
            this.bsiFolderPane,
            this.bciFolderNormal,
            this.bciFolderMinimized,
            this.bciFolderOff,
            this.bsiDataPane,
            this.bciDataRight,
            this.bciDataBottom,
            this.bciDataOff,
            this.bsiPreview,
            this.bciPreviewOff,
            this.bciPreview1,
            this.bciPreview2,
            this.bciPreview3,
            this.rgbiSkins,
            this.bbiCloseAll,
            this.bbiCloseSearch,
            this.bbiResetColumnsToDefault,
            this.bsiColumns,
            this.bbiNameColumn,
            this.bbiSerialColumn,
            this.bbiIPColumn,
            this.bbiUserColumn,
            this.bbiDate,
            this.bbiClearFilter,
            this.bsiInfo,
            this.bbiNormal,
            this.bbiReading,
            this.beiZoom,
            this.bbiOpenWeb,
            this.bbiPing,
            this.bbiTracert,
            this.bbiSKUColumn,
            this.bbiMACColumn,
            this.bbiCustomFilter,
            this.bbiNewSoftware});
            this.rcMain.Location = new System.Drawing.Point(0, 0);
            this.rcMain.MaxItemId = 70;
            this.rcMain.Name = "rcMain";
            this.rcMain.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.rpcSearch});
            this.rcMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpDevices,
            this.rpUsers,
            this.rpRepairs,
            this.rpMaps,
            this.rpSoftware,
            this.rpView});
            this.rcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemZoomTrackBar1,
            this.repositoryItemSpinEdit1});
            this.rcMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.rcMain.Size = new System.Drawing.Size(1114, 147);
            this.rcMain.StatusBar = this.ribbonStatusBar;
            this.rcMain.TransparentEditors = true;
            this.rcMain.BeforeApplicationButtonContentControlShow += new System.EventHandler(this.RcMainBeforeApplicationButtonContentControlShow);
            this.rcMain.ShowCustomizationMenu += new DevExpress.XtraBars.Ribbon.RibbonCustomizationMenuEventHandler(this.RcMainShowCustomizationMenu);
            // 
            // sharedImageCollection1
            // 
            // 
            // 
            // 
            this.sharedImageCollection1.ImageSource.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("sharedImageCollection1.ImageSource.ImageStream")));
            this.sharedImageCollection1.ParentControl = this;
            // 
            // bbiNewDevice
            // 
            this.bbiNewDevice.Caption = "Новое устройство";
            this.bbiNewDevice.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiNewDevice.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_16;
            this.bbiNewDevice.Id = 45;
            this.bbiNewDevice.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_32;
            this.bbiNewDevice.Name = "bbiNewDevice";
            // 
            // bbiFindDevices
            // 
            this.bbiFindDevices.Caption = "Найти устройства";
            this.bbiFindDevices.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFindDevices.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_network_find_16;
            this.bbiFindDevices.Id = 49;
            this.bbiFindDevices.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_network_find_32;
            this.bbiFindDevices.Name = "bbiFindDevices";
            toolTipItem1.Text = "Найти новые устройства в сети";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiFindDevices.SuperTip = superToolTip1;
            // 
            // bbiOpenRadmin
            // 
            this.bbiOpenRadmin.Caption = "Radmin";
            this.bbiOpenRadmin.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiOpenRadmin.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_radmin_16;
            this.bbiOpenRadmin.Id = 59;
            this.bbiOpenRadmin.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_radmin_32;
            this.bbiOpenRadmin.Name = "bbiOpenRadmin";
            this.bbiOpenRadmin.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            toolTipItem2.Text = "Подключиться к устройству используя Radmin";
            superToolTip2.Items.Add(toolTipItem2);
            this.bbiOpenRadmin.SuperTip = superToolTip2;
            // 
            // bbiOpenRomViewer
            // 
            this.bbiOpenRomViewer.Caption = "LM-Viewer";
            this.bbiOpenRomViewer.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiOpenRomViewer.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_romviewer_16;
            this.bbiOpenRomViewer.Id = 60;
            this.bbiOpenRomViewer.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_romviewer_32;
            this.bbiOpenRomViewer.Name = "bbiOpenRomViewer";
            this.bbiOpenRomViewer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // bbiOpenMstsc
            // 
            this.bbiOpenMstsc.Caption = "RDP";
            this.bbiOpenMstsc.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiOpenMstsc.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_mstsc_16;
            this.bbiOpenMstsc.Id = 61;
            this.bbiOpenMstsc.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_mstsc_32;
            this.bbiOpenMstsc.Name = "bbiOpenMstsc";
            this.bbiOpenMstsc.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            toolTipItem3.Text = "Подключиться к устройству используя удаленный рабочий стол";
            superToolTip3.Items.Add(toolTipItem3);
            this.bbiOpenMstsc.SuperTip = superToolTip3;
            // 
            // galleryDeviceQuickReports
            // 
            this.galleryDeviceQuickReports.Caption = "Быстрые отчеты";
            this.galleryDeviceQuickReports.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            // 
            // 
            // 
            this.galleryDeviceQuickReports.Gallery.ColumnCount = 2;
            this.galleryDeviceQuickReports.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            skinPaddingEdges1.Bottom = -3;
            skinPaddingEdges1.Top = -3;
            this.galleryDeviceQuickReports.Gallery.ItemImagePadding = skinPaddingEdges1;
            skinPaddingEdges2.Bottom = -1;
            skinPaddingEdges2.Top = -1;
            this.galleryDeviceQuickReports.Gallery.ItemTextPadding = skinPaddingEdges2;
            this.galleryDeviceQuickReports.Gallery.ShowItemText = true;
            this.galleryDeviceQuickReports.Id = 50;
            this.galleryDeviceQuickReports.Name = "galleryDeviceQuickReports";
            // 
            // bbiNewUser
            // 
            this.bbiNewUser.Caption = "Новый контакт";
            this.bbiNewUser.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiNewUser.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_user_16;
            this.bbiNewUser.Id = 54;
            this.bbiNewUser.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_user_32;
            this.bbiNewUser.Name = "bbiNewUser";
            // 
            // bbiBringToFront
            // 
            this.bbiBringToFront.Caption = "На передний план";
            this.bbiBringToFront.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiBringToFront.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiBringToFront.Glyph")));
            this.bbiBringToFront.Id = 51;
            this.bbiBringToFront.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiBringToFront.LargeGlyph")));
            this.bbiBringToFront.Name = "bbiBringToFront";
            // 
            // bbiSendToBack
            // 
            this.bbiSendToBack.Caption = "На задний план";
            this.bbiSendToBack.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiSendToBack.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSendToBack.Glyph")));
            this.bbiSendToBack.Id = 52;
            this.bbiSendToBack.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiSendToBack.LargeGlyph")));
            this.bbiSendToBack.Name = "bbiSendToBack";
            // 
            // bbiMapBackground
            // 
            this.bbiMapBackground.Caption = "Сменить фоновый рисунок";
            this.bbiMapBackground.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiMapBackground.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiMapBackground.Glyph")));
            this.bbiMapBackground.Id = 53;
            this.bbiMapBackground.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiMapBackground.LargeGlyph")));
            this.bbiMapBackground.Name = "bbiMapBackground";
            // 
            // bbiNewRepair
            // 
            this.bbiNewRepair.Caption = "Новый ремонт";
            this.bbiNewRepair.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiNewRepair.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_new_repair_16;
            this.bbiNewRepair.Id = 58;
            this.bbiNewRepair.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_new_repair_32;
            this.bbiNewRepair.Name = "bbiNewRepair";
            // 
            // bsiNewItem
            // 
            this.bsiNewItem.Caption = "Новый элемент";
            this.bsiNewItem.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiNewItem.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_new_item_16;
            this.bsiNewItem.Id = 46;
            this.bsiNewItem.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_new_item_32;
            this.bsiNewItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewDevice),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewRepair),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNewSoftware)});
            this.bsiNewItem.Name = "bsiNewItem";
            // 
            // bbiNewSoftware
            // 
            this.bbiNewSoftware.Caption = "Новое ПО";
            this.bbiNewSoftware.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiNewSoftware.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_new_software_16;
            this.bbiNewSoftware.Id = 69;
            this.bbiNewSoftware.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_new_software_32;
            this.bbiNewSoftware.Name = "bbiNewSoftware";
            // 
            // bbiDeleteItem
            // 
            this.bbiDeleteItem.Caption = "Удалить";
            this.bbiDeleteItem.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiDeleteItem.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_delete_16;
            this.bbiDeleteItem.Id = 47;
            this.bbiDeleteItem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.bbiDeleteItem.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_delete_32;
            this.bbiDeleteItem.Name = "bbiDeleteItem";
            toolTipItem4.Text = "Удалить элемент (Ctrl+D)";
            superToolTip4.Items.Add(toolTipItem4);
            this.bbiDeleteItem.SuperTip = superToolTip4;
            // 
            // bbiEditItem
            // 
            this.bbiEditItem.Caption = "Изменить";
            this.bbiEditItem.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiEditItem.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_edit_16;
            this.bbiEditItem.Id = 48;
            this.bbiEditItem.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_edit_32;
            this.bbiEditItem.Name = "bbiEditItem";
            toolTipItem5.Text = "Изменить элемент";
            superToolTip5.Items.Add(toolTipItem5);
            this.bbiEditItem.SuperTip = superToolTip5;
            // 
            // bciShowList
            // 
            this.bciShowList.BindableChecked = true;
            this.bciShowList.Caption = "Список";
            this.bciShowList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bciShowList.Checked = true;
            this.bciShowList.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_list_16;
            this.bciShowList.GroupIndex = 5;
            this.bciShowList.Id = 55;
            this.bciShowList.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_list_32;
            this.bciShowList.Name = "bciShowList";
            this.bciShowList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnButtonItemOnItemClick);
            // 
            // bciShowCards
            // 
            this.bciShowCards.Caption = "Карточки";
            this.bciShowCards.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bciShowCards.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_card_16;
            this.bciShowCards.GroupIndex = 5;
            this.bciShowCards.Id = 56;
            this.bciShowCards.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_card_32;
            this.bciShowCards.Name = "bciShowCards";
            this.bciShowCards.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnButtonItemOnItemClick);
            // 
            // bciShowCount
            // 
            this.bciShowCount.Caption = "Показать количество объектов";
            this.bciShowCount.CloseSubMenuOnClick = false;
            this.bciShowCount.Id = 2;
            this.bciShowCount.Name = "bciShowCount";
            this.bciShowCount.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.BciShowCountCheckedChanged);
            // 
            // bbiCreateFolder
            // 
            this.bbiCreateFolder.Caption = "Создать папку...";
            this.bbiCreateFolder.Id = 18;
            this.bbiCreateFolder.ImageIndex = 3;
            this.bbiCreateFolder.Name = "bbiCreateFolder";
            this.bbiCreateFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiCreateFolderItemClick);
            // 
            // bbiRenameFolder
            // 
            this.bbiRenameFolder.Caption = "Переименовать папку";
            this.bbiRenameFolder.Id = 19;
            this.bbiRenameFolder.ImageIndex = 4;
            this.bbiRenameFolder.Name = "bbiRenameFolder";
            this.bbiRenameFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiRenameFolderItemClick);
            // 
            // bbiMoveFolder
            // 
            this.bbiMoveFolder.Caption = "Переместить папку";
            this.bbiMoveFolder.Id = 20;
            this.bbiMoveFolder.ImageIndex = 6;
            this.bbiMoveFolder.Name = "bbiMoveFolder";
            this.bbiMoveFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiMoveFolderItemClick);
            // 
            // bbiDeleteFolder
            // 
            this.bbiDeleteFolder.Caption = "Удалить папку";
            this.bbiDeleteFolder.Id = 21;
            this.bbiDeleteFolder.ImageIndex = 5;
            this.bbiDeleteFolder.Name = "bbiDeleteFolder";
            this.bbiDeleteFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiDeleteFolderItemClick);
            // 
            // bbiCreateMap
            // 
            this.bbiCreateMap.Caption = "Создать план...";
            this.bbiCreateMap.Id = 28;
            this.bbiCreateMap.ImageIndex = 3;
            this.bbiCreateMap.Name = "bbiCreateMap";
            this.bbiCreateMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiCreateMapItemClick);
            // 
            // bbiRenameMap
            // 
            this.bbiRenameMap.Caption = "Переименовать план";
            this.bbiRenameMap.Id = 28;
            this.bbiRenameMap.ImageIndex = 4;
            this.bbiRenameMap.Name = "bbiRenameMap";
            this.bbiRenameMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiRenameMapItemClick);
            // 
            // bbiDeleteMap
            // 
            this.bbiDeleteMap.Caption = "Удалить план";
            this.bbiDeleteMap.Id = 30;
            this.bbiDeleteMap.ImageIndex = 5;
            this.bbiDeleteMap.Name = "bbiDeleteMap";
            this.bbiDeleteMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiDeleteMapItemClick);
            // 
            // bsiNavigation
            // 
            this.bsiNavigation.Caption = "Навигация";
            this.bsiNavigation.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_navigate_16;
            this.bsiNavigation.Id = 12;
            this.bsiNavigation.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_navigate_32;
            this.bsiNavigation.Name = "bsiNavigation";
            // 
            // bsiFolderPane
            // 
            this.bsiFolderPane.Caption = "Область папок";
            this.bsiFolderPane.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_folder_panel_16;
            this.bsiFolderPane.Id = 3;
            this.bsiFolderPane.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_folder_panel_32;
            this.bsiFolderPane.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bciFolderNormal),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciFolderMinimized),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciFolderOff)});
            this.bsiFolderPane.Name = "bsiFolderPane";
            // 
            // bciFolderNormal
            // 
            this.bciFolderNormal.BindableChecked = true;
            this.bciFolderNormal.Caption = "Обычный вид";
            this.bciFolderNormal.Checked = true;
            this.bciFolderNormal.GroupIndex = 15;
            this.bciFolderNormal.Id = 4;
            this.bciFolderNormal.Name = "bciFolderNormal";
            this.bciFolderNormal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bciFolderNormal_ItemClick);
            // 
            // bciFolderMinimized
            // 
            this.bciFolderMinimized.Caption = "Свернуть";
            this.bciFolderMinimized.GroupIndex = 15;
            this.bciFolderMinimized.Id = 5;
            this.bciFolderMinimized.Name = "bciFolderMinimized";
            this.bciFolderMinimized.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bciFolderMinimized_ItemClick);
            // 
            // bciFolderOff
            // 
            this.bciFolderOff.Caption = "Отсутствует";
            this.bciFolderOff.GroupIndex = 15;
            this.bciFolderOff.Id = 6;
            this.bciFolderOff.Name = "bciFolderOff";
            this.bciFolderOff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bciFolderOff_ItemClick);
            // 
            // bsiDataPane
            // 
            this.bsiDataPane.Caption = "Область данных";
            this.bsiDataPane.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiDataPane.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_data_panel_16;
            this.bsiDataPane.Id = 7;
            this.bsiDataPane.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_data_panel_32;
            this.bsiDataPane.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bciDataRight),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciDataBottom),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciDataOff)});
            this.bsiDataPane.Name = "bsiDataPane";
            // 
            // bciDataRight
            // 
            this.bciDataRight.BindableChecked = true;
            this.bciDataRight.Caption = "Справа";
            this.bciDataRight.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bciDataRight.Checked = true;
            this.bciDataRight.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_panel_right_16;
            this.bciDataRight.GroupIndex = 16;
            this.bciDataRight.Id = 8;
            this.bciDataRight.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_panel_right_32;
            this.bciDataRight.Name = "bciDataRight";
            // 
            // bciDataBottom
            // 
            this.bciDataBottom.Caption = "Снизу";
            this.bciDataBottom.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_panel_bottom_16;
            this.bciDataBottom.GroupIndex = 16;
            this.bciDataBottom.Id = 9;
            this.bciDataBottom.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_panel_bottom_32;
            this.bciDataBottom.Name = "bciDataBottom";
            // 
            // bciDataOff
            // 
            this.bciDataOff.Caption = "Отключена";
            this.bciDataOff.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_panel_off_16;
            this.bciDataOff.GroupIndex = 16;
            this.bciDataOff.Id = 10;
            this.bciDataOff.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_panel_off_32;
            this.bciDataOff.Name = "bciDataOff";
            // 
            // bsiPreview
            // 
            this.bsiPreview.Caption = "Просмотр деталей";
            this.bsiPreview.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiPreview.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_view_panel_16;
            this.bsiPreview.Id = 41;
            this.bsiPreview.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_view_panel_32;
            this.bsiPreview.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bciPreviewOff),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciPreview1),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciPreview2),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciPreview3)});
            this.bsiPreview.Name = "bsiPreview";
            // 
            // bciPreviewOff
            // 
            this.bciPreviewOff.BindableChecked = true;
            this.bciPreviewOff.Caption = "Отсутствует";
            this.bciPreviewOff.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bciPreviewOff.Checked = true;
            this.bciPreviewOff.GroupIndex = 17;
            this.bciPreviewOff.Id = 42;
            this.bciPreviewOff.Name = "bciPreviewOff";
            this.bciPreviewOff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnPreviewBarItemItemClick);
            // 
            // bciPreview1
            // 
            this.bciPreview1.Caption = "1 строка";
            this.bciPreview1.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bciPreview1.GroupIndex = 17;
            this.bciPreview1.Id = 43;
            this.bciPreview1.Name = "bciPreview1";
            this.bciPreview1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnPreviewBarItemItemClick);
            // 
            // bciPreview2
            // 
            this.bciPreview2.Caption = "2 строки";
            this.bciPreview2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bciPreview2.GroupIndex = 17;
            this.bciPreview2.Id = 44;
            this.bciPreview2.Name = "bciPreview2";
            this.bciPreview2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnPreviewBarItemItemClick);
            // 
            // bciPreview3
            // 
            this.bciPreview3.Caption = "3 строки";
            this.bciPreview3.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bciPreview3.GroupIndex = 17;
            this.bciPreview3.Id = 45;
            this.bciPreview3.Name = "bciPreview3";
            this.bciPreview3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OnPreviewBarItemItemClick);
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Caption = "Темы";
            this.rgbiSkins.Id = 1;
            this.rgbiSkins.Name = "rgbiSkins";
            // 
            // bbiCloseAll
            // 
            this.bbiCloseAll.Caption = "Закрыть все окна";
            this.bbiCloseAll.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiCloseAll.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_close_all_16;
            this.bbiCloseAll.Id = 57;
            this.bbiCloseAll.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_close_all_32;
            this.bbiCloseAll.Name = "bbiCloseAll";
            this.bbiCloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCloseAll_ItemClick);
            // 
            // bbiCloseSearch
            // 
            this.bbiCloseSearch.Caption = "Закрыть поиск";
            this.bbiCloseSearch.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_close_16;
            this.bbiCloseSearch.Id = 17;
            this.bbiCloseSearch.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_close_32;
            this.bbiCloseSearch.Name = "bbiCloseSearch";
            // 
            // bbiResetColumnsToDefault
            // 
            this.bbiResetColumnsToDefault.Caption = "Сбросить по умолчанию";
            this.bbiResetColumnsToDefault.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiResetColumnsToDefault.Glyph")));
            this.bbiResetColumnsToDefault.Id = 23;
            this.bbiResetColumnsToDefault.Name = "bbiResetColumnsToDefault";
            // 
            // bsiColumns
            // 
            this.bsiColumns.Caption = "Искать в колонках";
            this.bsiColumns.Id = 24;
            this.bsiColumns.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNameColumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSKUColumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSerialColumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUserColumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiIPColumn),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiMACColumn)});
            this.bsiColumns.Name = "bsiColumns";
            // 
            // bbiNameColumn
            // 
            this.bbiNameColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiNameColumn.Caption = "Наименование";
            this.bbiNameColumn.CloseSubMenuOnClick = false;
            this.bbiNameColumn.Id = 25;
            this.bbiNameColumn.Name = "bbiNameColumn";
            // 
            // bbiSKUColumn
            // 
            this.bbiSKUColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiSKUColumn.Caption = "Инвентарный №";
            this.bbiSKUColumn.CloseSubMenuOnClick = false;
            this.bbiSKUColumn.Id = 65;
            this.bbiSKUColumn.Name = "bbiSKUColumn";
            // 
            // bbiSerialColumn
            // 
            this.bbiSerialColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiSerialColumn.Caption = "Серийный №";
            this.bbiSerialColumn.CloseSubMenuOnClick = false;
            this.bbiSerialColumn.Id = 26;
            this.bbiSerialColumn.Name = "bbiSerialColumn";
            // 
            // bbiUserColumn
            // 
            this.bbiUserColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiUserColumn.Caption = "Владелец";
            this.bbiUserColumn.CloseSubMenuOnClick = false;
            this.bbiUserColumn.Id = 27;
            this.bbiUserColumn.Name = "bbiUserColumn";
            // 
            // bbiIPColumn
            // 
            this.bbiIPColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiIPColumn.Caption = "IP адрес";
            this.bbiIPColumn.CloseSubMenuOnClick = false;
            this.bbiIPColumn.Id = 13;
            this.bbiIPColumn.Name = "bbiIPColumn";
            // 
            // bbiMACColumn
            // 
            this.bbiMACColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiMACColumn.Caption = "MAC адрес";
            this.bbiMACColumn.CloseSubMenuOnClick = false;
            this.bbiMACColumn.Id = 66;
            this.bbiMACColumn.Name = "bbiMACColumn";
            // 
            // bbiDate
            // 
            this.bbiDate.ActAsDropDown = true;
            this.bbiDate.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiDate.Caption = "Дата покупки";
            this.bbiDate.Id = 14;
            this.bbiDate.Name = "bbiDate";
            // 
            // bbiClearFilter
            // 
            this.bbiClearFilter.Caption = "Очистить фильтр";
            this.bbiClearFilter.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_delete_16;
            this.bbiClearFilter.Id = 15;
            this.bbiClearFilter.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_delete_32;
            this.bbiClearFilter.Name = "bbiClearFilter";
            // 
            // bsiInfo
            // 
            this.bsiInfo.Id = 16;
            this.bsiInfo.Name = "bsiInfo";
            this.bsiInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiNormal
            // 
            this.bbiNormal.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiNormal.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.bbiNormal.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiNormal.Down = true;
            this.bbiNormal.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_normal_bottom_16;
            this.bbiNormal.GroupIndex = 16;
            this.bbiNormal.Hint = "Normal";
            this.bbiNormal.Id = 39;
            this.bbiNormal.Name = "bbiNormal";
            this.bbiNormal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNormal_ItemClick);
            // 
            // bbiReading
            // 
            this.bbiReading.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiReading.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.bbiReading.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiReading.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_reading_bottom_16;
            this.bbiReading.GroupIndex = 16;
            this.bbiReading.Hint = "Reading";
            this.bbiReading.Id = 40;
            this.bbiReading.Name = "bbiReading";
            this.bbiReading.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReading_ItemClick);
            // 
            // beiZoom
            // 
            this.beiZoom.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.beiZoom.Edit = this.repositoryItemZoomTrackBar1;
            this.beiZoom.EditValue = 10;
            this.beiZoom.EditWidth = 150;
            this.beiZoom.Id = 38;
            this.beiZoom.Name = "beiZoom";
            // 
            // repositoryItemZoomTrackBar1
            // 
            this.repositoryItemZoomTrackBar1.Alignment = DevExpress.Utils.VertAlignment.Center;
            this.repositoryItemZoomTrackBar1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemZoomTrackBar1.Maximum = 19;
            this.repositoryItemZoomTrackBar1.Middle = 10;
            this.repositoryItemZoomTrackBar1.Minimum = 1;
            this.repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            this.repositoryItemZoomTrackBar1.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            // 
            // bbiOpenWeb
            // 
            this.bbiOpenWeb.Caption = "HTTP";
            this.bbiOpenWeb.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_web_16;
            this.bbiOpenWeb.Id = 62;
            this.bbiOpenWeb.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_web_32;
            this.bbiOpenWeb.Name = "bbiOpenWeb";
            this.bbiOpenWeb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            toolTipItem6.Text = "Открыть сайт устройства";
            superToolTip6.Items.Add(toolTipItem6);
            this.bbiOpenWeb.SuperTip = superToolTip6;
            // 
            // bbiPing
            // 
            this.bbiPing.Caption = "Ping";
            this.bbiPing.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_16;
            this.bbiPing.Id = 63;
            this.bbiPing.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_32;
            this.bbiPing.Name = "bbiPing";
            this.bbiPing.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            toolTipItem7.Text = "Проверить устройство использую команду Ping";
            superToolTip7.Items.Add(toolTipItem7);
            this.bbiPing.SuperTip = superToolTip7;
            // 
            // bbiTracert
            // 
            this.bbiTracert.Caption = "Tracert";
            this.bbiTracert.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_16;
            this.bbiTracert.Id = 64;
            this.bbiTracert.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_connect_cmd_32;
            this.bbiTracert.Name = "bbiTracert";
            this.bbiTracert.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            toolTipItem8.Text = "Запустить средство диагностики Tracert";
            superToolTip8.Items.Add(toolTipItem8);
            this.bbiTracert.SuperTip = superToolTip8;
            // 
            // bbiCustomFilter
            // 
            this.bbiCustomFilter.Caption = "Пользовательский фильтр";
            this.bbiCustomFilter.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiCustomFilter.Glyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_filter_16;
            this.bbiCustomFilter.Id = 68;
            this.bbiCustomFilter.LargeGlyph = global::Dekart.LazyNet.Win.Properties.Resources.icon_filter_32;
            this.bbiCustomFilter.Name = "bbiCustomFilter";
            this.bbiCustomFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCustomFilter_ItemClick);
            // 
            // rpcSearch
            // 
            this.rpcSearch.Color = System.Drawing.Color.DarkOrange;
            this.rpcSearch.Name = "rpcSearch";
            this.rpcSearch.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpSearch});
            this.rpcSearch.Text = "Настройки поиска";
            this.rpcSearch.Visible = false;
            // 
            // rpSearch
            // 
            this.rpSearch.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgFilterActions,
            this.rpgFilterColumns,
            this.rbgFilterClose});
            this.rpSearch.Name = "rpSearch";
            this.rpSearch.Text = "ПОИСК";
            this.rpSearch.Visible = false;
            // 
            // rpgFilterActions
            // 
            this.rpgFilterActions.ItemLinks.Add(this.bbiDate);
            this.rpgFilterActions.ItemLinks.Add(this.bbiClearFilter);
            this.rpgFilterActions.Name = "rpgFilterActions";
            this.rpgFilterActions.ShowCaptionButton = false;
            this.rpgFilterActions.Text = "Действия фильтра";
            // 
            // rpgFilterColumns
            // 
            this.rpgFilterColumns.ItemLinks.Add(this.bsiColumns);
            this.rpgFilterColumns.ItemLinks.Add(this.bbiResetColumnsToDefault);
            this.rpgFilterColumns.Name = "rpgFilterColumns";
            this.rpgFilterColumns.ShowCaptionButton = false;
            this.rpgFilterColumns.Text = "Колонки фильтра";
            // 
            // rbgFilterClose
            // 
            this.rbgFilterClose.AllowTextClipping = false;
            this.rbgFilterClose.ItemLinks.Add(this.bbiCloseSearch);
            this.rbgFilterClose.Name = "rbgFilterClose";
            this.rbgFilterClose.ShowCaptionButton = false;
            this.rbgFilterClose.Text = "Закрыть";
            // 
            // rpDevices
            // 
            this.rpDevices.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgDevicesNew,
            this.rpgDevicesDelete,
            this.rpgDevicesActions,
            this.rpgDevicesQuickReports});
            this.rpDevices.Name = "rpDevices";
            this.rpDevices.Text = "УСТРОЙСТВА";
            // 
            // rpgDevicesNew
            // 
            this.rpgDevicesNew.ItemLinks.Add(this.bbiNewDevice);
            this.rpgDevicesNew.ItemLinks.Add(this.bsiNewItem);
            this.rpgDevicesNew.Name = "rpgDevicesNew";
            this.rpgDevicesNew.ShowCaptionButton = false;
            this.rpgDevicesNew.Text = "Создать";
            // 
            // rpgDevicesDelete
            // 
            this.rpgDevicesDelete.ItemLinks.Add(this.bbiDeleteItem);
            this.rpgDevicesDelete.Name = "rpgDevicesDelete";
            this.rpgDevicesDelete.ShowCaptionButton = false;
            this.rpgDevicesDelete.Text = "Удалить";
            // 
            // rpgDevicesActions
            // 
            this.rpgDevicesActions.ItemLinks.Add(this.bbiEditItem);
            this.rpgDevicesActions.ItemLinks.Add(this.bbiFindDevices);
            this.rpgDevicesActions.ItemLinks.Add(this.bbiOpenWeb, true);
            this.rpgDevicesActions.ItemLinks.Add(this.bbiOpenRadmin);
            this.rpgDevicesActions.ItemLinks.Add(this.bbiOpenRomViewer);
            this.rpgDevicesActions.ItemLinks.Add(this.bbiOpenMstsc);
            this.rpgDevicesActions.ItemLinks.Add(this.bbiPing);
            this.rpgDevicesActions.ItemLinks.Add(this.bbiTracert);
            this.rpgDevicesActions.Name = "rpgDevicesActions";
            this.rpgDevicesActions.ShowCaptionButton = false;
            this.rpgDevicesActions.Text = "Действия";
            // 
            // rpgDevicesQuickReports
            // 
            this.rpgDevicesQuickReports.ItemLinks.Add(this.galleryDeviceQuickReports);
            this.rpgDevicesQuickReports.Name = "rpgDevicesQuickReports";
            this.rpgDevicesQuickReports.ShowCaptionButton = false;
            this.rpgDevicesQuickReports.Text = "Быстрые отчеты";
            // 
            // rpUsers
            // 
            this.rpUsers.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgUsersNew,
            this.rpgUsersDelete,
            this.rpgUsersActions,
            this.rpgUsersCurrentView,
            this.rpgUsersFilter});
            this.rpUsers.Name = "rpUsers";
            this.rpUsers.Text = "ЛЮДИ";
            // 
            // rpgUsersNew
            // 
            this.rpgUsersNew.ItemLinks.Add(this.bbiNewUser);
            this.rpgUsersNew.ItemLinks.Add(this.bsiNewItem);
            this.rpgUsersNew.Name = "rpgUsersNew";
            this.rpgUsersNew.ShowCaptionButton = false;
            this.rpgUsersNew.Text = "Создать";
            // 
            // rpgUsersDelete
            // 
            this.rpgUsersDelete.ItemLinks.Add(this.bbiDeleteItem);
            this.rpgUsersDelete.Name = "rpgUsersDelete";
            this.rpgUsersDelete.ShowCaptionButton = false;
            this.rpgUsersDelete.Text = "Удалить";
            // 
            // rpgUsersActions
            // 
            this.rpgUsersActions.ItemLinks.Add(this.bbiEditItem);
            this.rpgUsersActions.Name = "rpgUsersActions";
            this.rpgUsersActions.ShowCaptionButton = false;
            this.rpgUsersActions.Text = "Действия";
            // 
            // rpgUsersCurrentView
            // 
            this.rpgUsersCurrentView.ItemLinks.Add(this.bciShowList);
            this.rpgUsersCurrentView.ItemLinks.Add(this.bciShowCards);
            this.rpgUsersCurrentView.Name = "rpgUsersCurrentView";
            this.rpgUsersCurrentView.ShowCaptionButton = false;
            this.rpgUsersCurrentView.Text = "Текущее представление";
            // 
            // rpgUsersFilter
            // 
            this.rpgUsersFilter.ItemLinks.Add(this.bbiCustomFilter);
            this.rpgUsersFilter.Name = "rpgUsersFilter";
            this.rpgUsersFilter.ShowCaptionButton = false;
            this.rpgUsersFilter.Text = "Фильтр";
            // 
            // rpRepairs
            // 
            this.rpRepairs.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgRepairsNew,
            this.rpgRepairsDelete,
            this.rpgRepairsActions,
            this.rpgRepairsFilter});
            this.rpRepairs.Name = "rpRepairs";
            this.rpRepairs.Text = "РЕМОНТЫ И ОБСЛУЖВАНИЯ";
            // 
            // rpgRepairsNew
            // 
            this.rpgRepairsNew.ItemLinks.Add(this.bbiNewRepair);
            this.rpgRepairsNew.ItemLinks.Add(this.bsiNewItem);
            this.rpgRepairsNew.Name = "rpgRepairsNew";
            this.rpgRepairsNew.ShowCaptionButton = false;
            this.rpgRepairsNew.Text = "Создать";
            // 
            // rpgRepairsDelete
            // 
            this.rpgRepairsDelete.ItemLinks.Add(this.bbiDeleteItem);
            this.rpgRepairsDelete.Name = "rpgRepairsDelete";
            this.rpgRepairsDelete.ShowCaptionButton = false;
            this.rpgRepairsDelete.Text = "Удалить";
            // 
            // rpgRepairsActions
            // 
            this.rpgRepairsActions.ItemLinks.Add(this.bbiEditItem);
            this.rpgRepairsActions.Name = "rpgRepairsActions";
            this.rpgRepairsActions.ShowCaptionButton = false;
            this.rpgRepairsActions.Text = "Действия";
            // 
            // rpgRepairsFilter
            // 
            this.rpgRepairsFilter.ItemLinks.Add(this.bbiCustomFilter);
            this.rpgRepairsFilter.Name = "rpgRepairsFilter";
            this.rpgRepairsFilter.ShowCaptionButton = false;
            this.rpgRepairsFilter.Text = "Фильтр";
            // 
            // rpMaps
            // 
            this.rpMaps.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgMapsDelete,
            this.rpgMapsActions});
            this.rpMaps.Name = "rpMaps";
            this.rpMaps.Text = "ПЛАНЫ";
            // 
            // rpgMapsDelete
            // 
            this.rpgMapsDelete.ItemLinks.Add(this.bbiDeleteItem);
            this.rpgMapsDelete.Name = "rpgMapsDelete";
            this.rpgMapsDelete.ShowCaptionButton = false;
            this.rpgMapsDelete.Text = "Удалить";
            // 
            // rpgMapsActions
            // 
            this.rpgMapsActions.ItemLinks.Add(this.bbiBringToFront);
            this.rpgMapsActions.ItemLinks.Add(this.bbiSendToBack);
            this.rpgMapsActions.ItemLinks.Add(this.bbiMapBackground, true);
            this.rpgMapsActions.Name = "rpgMapsActions";
            this.rpgMapsActions.ShowCaptionButton = false;
            this.rpgMapsActions.Text = "Действия";
            // 
            // rpSoftware
            // 
            this.rpSoftware.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSoftwareNew,
            this.rpgSoftwareDelete,
            this.rpgSoftwareActions,
            this.rpgSoftwareFilter});
            this.rpSoftware.Name = "rpSoftware";
            this.rpSoftware.Text = "ПРОГРАММНОЕ ОБЕСПЕЧЕНИЕ";
            // 
            // rpgSoftwareNew
            // 
            this.rpgSoftwareNew.ItemLinks.Add(this.bbiNewSoftware);
            this.rpgSoftwareNew.ItemLinks.Add(this.bsiNewItem);
            this.rpgSoftwareNew.Name = "rpgSoftwareNew";
            this.rpgSoftwareNew.ShowCaptionButton = false;
            this.rpgSoftwareNew.Text = "Создать";
            // 
            // rpgSoftwareDelete
            // 
            this.rpgSoftwareDelete.ItemLinks.Add(this.bbiDeleteItem);
            this.rpgSoftwareDelete.Name = "rpgSoftwareDelete";
            this.rpgSoftwareDelete.ShowCaptionButton = false;
            this.rpgSoftwareDelete.Text = "Удалить";
            // 
            // rpgSoftwareActions
            // 
            this.rpgSoftwareActions.ItemLinks.Add(this.bbiEditItem);
            this.rpgSoftwareActions.Name = "rpgSoftwareActions";
            this.rpgSoftwareActions.ShowCaptionButton = false;
            this.rpgSoftwareActions.Text = "Действия";
            // 
            // rpgSoftwareFilter
            // 
            this.rpgSoftwareFilter.ItemLinks.Add(this.bbiCustomFilter);
            this.rpgSoftwareFilter.Name = "rpgSoftwareFilter";
            this.rpgSoftwareFilter.ShowCaptionButton = false;
            this.rpgSoftwareFilter.Text = "Фильтр";
            // 
            // rpView
            // 
            this.rpView.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgNavigation,
            this.rpgLayout,
            this.prgAppearance,
            this.rpgWindow});
            this.rpView.Name = "rpView";
            this.rpView.Text = "ВИД";
            // 
            // rpgNavigation
            // 
            this.rpgNavigation.AllowTextClipping = false;
            this.rpgNavigation.ItemLinks.Add(this.bsiNavigation);
            this.rpgNavigation.Name = "rpgNavigation";
            this.rpgNavigation.ShowCaptionButton = false;
            this.rpgNavigation.Text = "Навигация";
            // 
            // rpgLayout
            // 
            this.rpgLayout.ItemLinks.Add(this.bsiFolderPane);
            this.rpgLayout.ItemLinks.Add(this.bsiDataPane);
            this.rpgLayout.ItemLinks.Add(this.bsiPreview);
            this.rpgLayout.Name = "rpgLayout";
            this.rpgLayout.ShowCaptionButton = false;
            this.rpgLayout.Text = "Макет";
            // 
            // prgAppearance
            // 
            this.prgAppearance.ItemLinks.Add(this.rgbiSkins);
            this.prgAppearance.Name = "prgAppearance";
            this.prgAppearance.ShowCaptionButton = false;
            this.prgAppearance.Text = "Внешний вид";
            // 
            // rpgWindow
            // 
            this.rpgWindow.ItemLinks.Add(this.bbiCloseAll);
            this.rpgWindow.Name = "rpgWindow";
            this.rpgWindow.ShowCaptionButton = false;
            this.rpgWindow.Text = "Окно";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.bbiNormal);
            this.ribbonStatusBar.ItemLinks.Add(this.bbiReading);
            this.ribbonStatusBar.ItemLinks.Add(this.beiZoom, true);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 592);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.rcMain;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1114, 23);
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 147);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.nbMain);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.pcMain);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(1114, 400);
            this.splitContainerControl.SplitterPosition = 200;
            this.splitContainerControl.TabIndex = 0;
            this.splitContainerControl.Text = "splitContainerControl1";
            this.splitContainerControl.SplitterMoved += new System.EventHandler(this.splitContainerControl1_SplitterMoved);
            this.splitContainerControl.SplitterMoving += new DevExpress.XtraEditors.SplitMovingEventHandler(this.splitContainerControl1_SplitterMoving);
            // 
            // nbMain
            // 
            this.nbMain.ActiveGroup = this.nbgDevices;
            this.nbMain.Controls.Add(this.ControlForDevicesNavBarGroup);
            this.nbMain.Controls.Add(this.ControlForUsersNavBarGroup);
            this.nbMain.Controls.Add(this.ControlForRepairsNavBarGroup);
            this.nbMain.Controls.Add(this.ControlForMapsNavBarGroup);
            this.nbMain.Controls.Add(this.ControlForSoftwareNavBarGroup);
            this.nbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nbMain.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgDevices,
            this.nbgSoftware,
            this.nbgRepairs,
            this.nbgMaps,
            this.nbgUsers});
            this.nbMain.Location = new System.Drawing.Point(0, 0);
            this.nbMain.MenuManager = this.rcMain;
            this.nbMain.Name = "nbMain";
            this.nbMain.NavigationPaneGroupClientHeight = 320;
            this.nbMain.OptionsNavPane.ExpandedWidth = 200;
            this.nbMain.Size = new System.Drawing.Size(200, 400);
            this.nbMain.TabIndex = 2;
            this.nbMain.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            this.nbMain.NavPaneStateChanged += new System.EventHandler(this.NbMainNavPaneStateChanged);
            this.nbMain.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbMain_ActiveGroupChanged);
            // 
            // nbgDevices
            // 
            this.nbgDevices.Caption = "Devices";
            this.nbgDevices.ControlContainer = this.ControlForDevicesNavBarGroup;
            this.nbgDevices.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.nbgDevices.Expanded = true;
            this.nbgDevices.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.nbgDevices.GroupClientHeight = 80;
            this.nbgDevices.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgDevices.LargeImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_32;
            this.nbgDevices.Name = "nbgDevices";
            this.nbgDevices.SmallImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_device_16;
            // 
            // ControlForDevicesNavBarGroup
            // 
            this.ControlForDevicesNavBarGroup.Controls.Add(this.ucDevicesTree);
            this.ControlForDevicesNavBarGroup.Name = "ControlForDevicesNavBarGroup";
            this.ControlForDevicesNavBarGroup.Size = new System.Drawing.Size(198, 331);
            this.ControlForDevicesNavBarGroup.TabIndex = 0;
            // 
            // ucDevicesTree
            // 
            this.ucDevicesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDevicesTree.Location = new System.Drawing.Point(0, 0);
            this.ucDevicesTree.Name = "ucDevicesTree";
            this.ucDevicesTree.ParentFormMain = null;
            this.ucDevicesTree.Size = new System.Drawing.Size(198, 331);
            this.ucDevicesTree.TabIndex = 0;
            this.ucDevicesTree.DataSourceChanged += new Dekart.LazyNet.DataSourceChangedEventHandler(this.OnDataSourceChanged);
            this.ucDevicesTree.ShowMenu += new System.Windows.Forms.MouseEventHandler(this.ucDevicesTree_ShowMenu);
            this.ucDevicesTree.UcTreeDragDrop += new Dekart.LazyNet.UcTreeDragDropEventHandler(this.ucDevicesTree_UcTreeDragDrop);
            // 
            // ControlForUsersNavBarGroup
            // 
            this.ControlForUsersNavBarGroup.Controls.Add(this.ucUsersFilter);
            this.ControlForUsersNavBarGroup.Name = "ControlForUsersNavBarGroup";
            this.ControlForUsersNavBarGroup.Size = new System.Drawing.Size(200, 320);
            this.ControlForUsersNavBarGroup.TabIndex = 2;
            // 
            // ucUsersFilter
            // 
            this.ucUsersFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucUsersFilter.Location = new System.Drawing.Point(0, 0);
            this.ucUsersFilter.Name = "ucUsersFilter";
            this.ucUsersFilter.ParentFormMain = null;
            this.ucUsersFilter.Size = new System.Drawing.Size(200, 320);
            this.ucUsersFilter.TabIndex = 0;
            this.ucUsersFilter.DataSourceChanged += new Dekart.LazyNet.DataSourceChangedEventHandler(this.OnDataSourceChanged);
            // 
            // ControlForRepairsNavBarGroup
            // 
            this.ControlForRepairsNavBarGroup.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ControlForRepairsNavBarGroup.Appearance.Options.UseBackColor = true;
            this.ControlForRepairsNavBarGroup.Controls.Add(this.ucRepairsFilter);
            this.ControlForRepairsNavBarGroup.Name = "ControlForRepairsNavBarGroup";
            this.ControlForRepairsNavBarGroup.Size = new System.Drawing.Size(200, 320);
            this.ControlForRepairsNavBarGroup.TabIndex = 6;
            // 
            // ucRepairsFilter
            // 
            this.ucRepairsFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRepairsFilter.Location = new System.Drawing.Point(0, 0);
            this.ucRepairsFilter.Name = "ucRepairsFilter";
            this.ucRepairsFilter.ParentFormMain = null;
            this.ucRepairsFilter.Size = new System.Drawing.Size(200, 320);
            this.ucRepairsFilter.TabIndex = 3;
            this.ucRepairsFilter.DataSourceChanged += new Dekart.LazyNet.DataSourceChangedEventHandler(this.OnDataSourceChanged);
            // 
            // ControlForMapsNavBarGroup
            // 
            this.ControlForMapsNavBarGroup.Controls.Add(this.ucMaps);
            this.ControlForMapsNavBarGroup.Name = "ControlForMapsNavBarGroup";
            this.ControlForMapsNavBarGroup.Size = new System.Drawing.Size(200, 320);
            this.ControlForMapsNavBarGroup.TabIndex = 5;
            // 
            // ucMaps
            // 
            this.ucMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMaps.Location = new System.Drawing.Point(0, 0);
            this.ucMaps.Name = "ucMaps";
            this.ucMaps.ParentFormMain = null;
            this.ucMaps.Size = new System.Drawing.Size(200, 320);
            this.ucMaps.TabIndex = 0;
            this.ucMaps.DataSourceChanged += new Dekart.LazyNet.DataSourceChangedEventHandler(this.OnDataSourceChanged);
            this.ucMaps.ShowMenu += new System.Windows.Forms.MouseEventHandler(this.UcMapTreeShowMenu);
            // 
            // ControlForSoftwareNavBarGroup
            // 
            this.ControlForSoftwareNavBarGroup.Controls.Add(this.ucSoftwareFilter);
            this.ControlForSoftwareNavBarGroup.Name = "ControlForSoftwareNavBarGroup";
            this.ControlForSoftwareNavBarGroup.Size = new System.Drawing.Size(200, 320);
            this.ControlForSoftwareNavBarGroup.TabIndex = 3;
            // 
            // ucSoftwareFilter
            // 
            this.ucSoftwareFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSoftwareFilter.Location = new System.Drawing.Point(0, 0);
            this.ucSoftwareFilter.Name = "ucSoftwareFilter";
            this.ucSoftwareFilter.ParentFormMain = null;
            this.ucSoftwareFilter.Size = new System.Drawing.Size(200, 320);
            this.ucSoftwareFilter.TabIndex = 0;
            this.ucSoftwareFilter.DataSourceChanged += new Dekart.LazyNet.DataSourceChangedEventHandler(this.OnDataSourceChanged);
            // 
            // nbgSoftware
            // 
            this.nbgSoftware.Caption = "Software";
            this.nbgSoftware.ControlContainer = this.ControlForSoftwareNavBarGroup;
            this.nbgSoftware.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.nbgSoftware.GroupClientHeight = 320;
            this.nbgSoftware.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgSoftware.LargeImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_software_32;
            this.nbgSoftware.Name = "nbgSoftware";
            this.nbgSoftware.SmallImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_software_16;
            // 
            // nbgRepairs
            // 
            this.nbgRepairs.Caption = "Repairs";
            this.nbgRepairs.ControlContainer = this.ControlForRepairsNavBarGroup;
            this.nbgRepairs.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.nbgRepairs.GroupClientHeight = 80;
            this.nbgRepairs.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgRepairs.LargeImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_repair_32;
            this.nbgRepairs.Name = "nbgRepairs";
            this.nbgRepairs.SmallImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_repair_16;
            // 
            // nbgMaps
            // 
            this.nbgMaps.Caption = "Maps";
            this.nbgMaps.ControlContainer = this.ControlForMapsNavBarGroup;
            this.nbgMaps.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.nbgMaps.GroupClientHeight = 80;
            this.nbgMaps.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgMaps.LargeImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_map_32;
            this.nbgMaps.Name = "nbgMaps";
            this.nbgMaps.SmallImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_map_16;
            // 
            // nbgUsers
            // 
            this.nbgUsers.Caption = "Users";
            this.nbgUsers.ControlContainer = this.ControlForUsersNavBarGroup;
            this.nbgUsers.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.nbgUsers.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Large;
            this.nbgUsers.GroupClientHeight = 80;
            this.nbgUsers.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgUsers.LargeImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_user_32;
            this.nbgUsers.Name = "nbgUsers";
            this.nbgUsers.SmallImage = global::Dekart.LazyNet.Win.Properties.Resources.icon_nav_user_16;
            // 
            // pmDeviceTree
            // 
            this.pmDeviceTree.ItemLinks.Add(this.bciShowCount, true);
            this.pmDeviceTree.ItemLinks.Add(this.bbiCreateFolder, true);
            this.pmDeviceTree.ItemLinks.Add(this.bbiRenameFolder, true);
            this.pmDeviceTree.ItemLinks.Add(this.bbiMoveFolder);
            this.pmDeviceTree.ItemLinks.Add(this.bbiDeleteFolder);
            this.pmDeviceTree.Name = "pmDeviceTree";
            this.pmDeviceTree.Ribbon = this.rcMain;
            // 
            // pmMapTree
            // 
            this.pmMapTree.ItemLinks.Add(this.bciShowCount);
            this.pmMapTree.ItemLinks.Add(this.bbiCreateMap, true);
            this.pmMapTree.ItemLinks.Add(this.bbiRenameMap, true);
            this.pmMapTree.ItemLinks.Add(this.bbiDeleteMap);
            this.pmMapTree.Name = "pmMapTree";
            this.pmMapTree.Ribbon = this.rcMain;
            // 
            // officeNavigationBar
            // 
            this.officeNavigationBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.officeNavigationBar.Location = new System.Drawing.Point(0, 547);
            this.officeNavigationBar.MenuManager = this.rcMain;
            this.officeNavigationBar.Name = "officeNavigationBar";
            this.officeNavigationBar.Size = new System.Drawing.Size(1114, 45);
            this.officeNavigationBar.TabIndex = 2;
            this.officeNavigationBar.Text = "officeNavigationBar1";
            // 
            // transitionManager
            // 
            transition1.Control = this.pcMain;
            slideFadeTransition1.Parameters.Background = System.Drawing.Color.Empty;
            transition1.TransitionType = slideFadeTransition1;
            this.transitionManager.Transitions.Add(transition1);
            // 
            // alertControl
            // 
            this.alertControl.AllowHtmlText = true;
            this.alertControl.ShowPinButton = false;
            this.alertControl.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertControl_AlertClick);
            // 
            // notificationsManager
            // 
            this.notificationsManager.ApplicationId = "42b1c66e-1ec3-4b17-9116-38296312cf1d";
            this.notificationsManager.ApplicationName = "LazyNet.Win";
            this.notificationsManager.Activated += new System.EventHandler<DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs>(this.notificationsManager_Activated);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 615);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.officeNavigationBar);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.rcMain);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Ribbon = this.rcMain;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "LazyNet";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).EndInit();
            this.pcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            this.bvccAbout.ResumeLayout(false);
            this.backstageViewClientControl2.ResumeLayout(false);
            this.backstageViewClientControl3.ResumeLayout(false);
            this.backstageViewClientControl4.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1.ImageSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharedImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemZoomTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbMain)).EndInit();
            this.nbMain.ResumeLayout(false);
            this.ControlForDevicesNavBarGroup.ResumeLayout(false);
            this.ControlForUsersNavBarGroup.ResumeLayout(false);
            this.ControlForRepairsNavBarGroup.ResumeLayout(false);
            this.ControlForMapsNavBarGroup.ResumeLayout(false);
            this.ControlForSoftwareNavBarGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmDeviceTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMapTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rcMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraNavBar.NavBarControl nbMain;
        private DevExpress.XtraNavBar.NavBarGroup nbgDevices;
        private DevExpress.XtraEditors.PanelControl pcMain;
        private DevExpress.XtraNavBar.NavBarGroup nbgUsers;
        private DevExpress.XtraNavBar.NavBarGroup nbgSoftware;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer ControlForDevicesNavBarGroup;
        private DevicesTree ucDevicesTree;
        private DevExpress.XtraBars.BarButtonItem bbiNewDevice;
        private DevExpress.XtraBars.BarSubItem bsiNewItem;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteItem;
        private DevExpress.XtraBars.BarButtonItem bbiEditItem;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpView;
        private DevExpress.XtraBars.RibbonGalleryBarItem rgbiSkins;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgNavigation;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup prgAppearance;
        private DevExpress.XtraBars.BarCheckItem bciShowCount;
        private DevExpress.XtraBars.PopupMenu pmDeviceTree;
        private DevExpress.XtraBars.BarSubItem bsiNavigation;
        private DevExpress.XtraBars.BarButtonItem bbiCloseSearch;
        private DevExpress.XtraBars.BarButtonItem bbiResetColumnsToDefault;
        private DevExpress.XtraBars.BarSubItem bsiColumns;
        private DevExpress.XtraBars.BarButtonItem bbiNameColumn;
        private DevExpress.XtraBars.BarButtonItem bbiSerialColumn;
        private DevExpress.XtraBars.BarButtonItem bbiUserColumn;
        private DevExpress.XtraBars.BarButtonItem bbiDate;
        private DevExpress.XtraBars.BarButtonItem bbiClearFilter;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer ControlForUsersNavBarGroup;
        private UsersFilter ucUsersFilter;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer ControlForSoftwareNavBarGroup;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbiSaveAs;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl bvccAbout;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiAbout;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbiExit;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiImport;
        private DevExpress.XtraBars.BarStaticItem bsiInfo;
        private DevExpress.XtraBars.BarEditItem beiZoom;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;
        private DevExpress.XtraBars.BarButtonItem bbiNormal;
        private DevExpress.XtraBars.BarButtonItem bbiReading;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl3;
        private PrintControl printControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiPrint;
        private AboutControl aboutControl;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl4;
        private ExportControl exportControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiExport;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarButtonItem bbiRenameFolder;
        private DevExpress.XtraBars.BarButtonItem bbiCreateFolder;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer ControlForMapsNavBarGroup;
        private DevExpress.XtraNavBar.NavBarGroup nbgMaps;
        private Controls.MapsControl ucMaps;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteFolder;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory rpcSearch;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSearch;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFilterActions;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFilterColumns;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgFilterClose;
        private DevExpress.XtraBars.BarButtonItem bbiIPColumn;
        private ImportControl importControl1;
        private DevExpress.XtraBars.PopupMenu pmMapTree;
        private DevExpress.XtraBars.BarButtonItem bbiMoveFolder;
        private DevExpress.XtraBars.BarButtonItem bbiCreateMap;
        private DevExpress.XtraBars.BarButtonItem bbiRenameMap;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteMap;
        private DevExpress.Utils.SharedImageCollection sharedImageCollection1;
        private DevExpress.XtraBars.Navigation.OfficeNavigationBar officeNavigationBar;
        private DevExpress.Utils.Animation.TransitionManager transitionManager;
        private DevExpress.XtraNavBar.NavBarGroup nbgRepairs;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpDevices;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgLayout;
        private DevExpress.XtraBars.BarSubItem bsiFolderPane;
        private DevExpress.XtraBars.BarCheckItem bciFolderNormal;
        private DevExpress.XtraBars.BarCheckItem bciFolderMinimized;
        private DevExpress.XtraBars.BarCheckItem bciFolderOff;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.BarSubItem bsiDataPane;
        private DevExpress.XtraBars.BarCheckItem bciDataRight;
        private DevExpress.XtraBars.BarCheckItem bciDataBottom;
        private DevExpress.XtraBars.BarCheckItem bciDataOff;
        private DevExpress.XtraBars.BarSubItem bsiPreview;
        private DevExpress.XtraBars.BarCheckItem bciPreviewOff;
        private DevExpress.XtraBars.BarCheckItem bciPreview1;
        private DevExpress.XtraBars.BarCheckItem bciPreview2;
        private DevExpress.XtraBars.BarCheckItem bciPreview3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDevicesNew;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDevicesDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDevicesActions;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDevicesQuickReports;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMaps;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpUsers;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpRepairs;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSoftware;
        private DevExpress.XtraBars.BarButtonItem bbiFindDevices;
        private DevExpress.XtraBars.RibbonGalleryBarItem galleryDeviceQuickReports;
        private DevExpress.XtraBars.BarButtonItem bbiBringToFront;
        private DevExpress.XtraBars.BarButtonItem bbiSendToBack;
        private DevExpress.XtraBars.BarButtonItem bbiMapBackground;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMapsDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMapsActions;
        private DevExpress.XtraBars.BarButtonItem bbiNewUser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUsersNew;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUsersDelete;
        private DevExpress.XtraBars.BarCheckItem bciShowList;
        private DevExpress.XtraBars.BarCheckItem bciShowCards;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUsersActions;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUsersCurrentView;
        private DevExpress.XtraBars.BarButtonItem bbiCloseAll;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgWindow;
        private DevExpress.XtraBars.BarButtonItem bbiNewRepair;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRepairsNew;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRepairsDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRepairsActions;
        private DevExpress.XtraBars.BarButtonItem bbiOpenRadmin;
        private DevExpress.XtraBars.BarButtonItem bbiOpenRomViewer;
        private DevExpress.XtraBars.BarButtonItem bbiOpenMstsc;
        private DevExpress.XtraBars.BarButtonItem bbiOpenWeb;
        private DevExpress.XtraBars.BarButtonItem bbiPing;
        private DevExpress.XtraBars.BarButtonItem bbiTracert;
        private DevExpress.XtraBars.BarButtonItem bbiSKUColumn;
        private DevExpress.XtraBars.BarButtonItem bbiMACColumn;
        private DevExpress.XtraBars.BarButtonItem bbiCustomFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUsersFilter;
        private RepairsFilter ucRepairsFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRepairsFilter;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer ControlForRepairsNavBarGroup;
        private DevExpress.XtraBars.BarButtonItem bbiNewSoftware;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSoftwareNew;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSoftwareDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSoftwareActions;
        private SoftwareFilter ucSoftwareFilter;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSoftwareFilter;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbiOptions;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager notificationsManager;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtiScheduler;
        private SchedulerControl schedulerControl1;
    }
}

