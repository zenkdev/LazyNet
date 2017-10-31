using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using Dekart.LazyNet.Win.Modules;
using Dekart.LazyNet.Win.QuickReports;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSplashScreen;

namespace Dekart.LazyNet.Win
{
    public partial class MainForm : MainFormBase, ISupportTransitions
    {
        FormLayoutManager _layoutManager;
        readonly List<BarItem> _allowCustomizationMenuList = new List<BarItem>();
        readonly ModulesNavigator _modulesNavigator;
        FilterColumnsManager _filterColumnsManager;

        public MainForm()
        {
            InitializeComponent();

            ucDevicesTree.ParentFormMain = this;
            ElementLoader.LoadResourcesForMainForm(this);
            WinHelper.SetFormClientSize(Screen.GetWorkingArea(Location), this, 1080, 840);

            _modulesNavigator = new ModulesNavigator(this, pcMain);

            // ReSharper disable ObjectCreationAsStatement
            new ZoomManager(_modulesNavigator, beiZoom);
            new DataPaneManager(_modulesNavigator, bsiDataPane);
            new ReportsManager(_modulesNavigator, galleryDeviceQuickReports, typeof(Labels), typeof(InventoryCards), typeof(PrintingCosts));
            // ReSharper restore ObjectCreationAsStatement

            InitNavBar();
            InitRibbonButtons();
            InitNavigation();
            InitNotifications();
        }

        void InitNavBar()
        {
            rpDevices.Tag = TagResources.Devices;
            rpUsers.Tag = TagResources.Users;
            rpRepairs.Tag = TagResources.Repairs;
            rpMaps.Tag = TagResources.Maps;
            rpSoftware.Tag = TagResources.Software;

            nbgDevices.Tag = new NavBarGroupTagObject(TagResources.Devices, typeof(Devices));
            nbgUsers.Tag = new NavBarGroupTagObject(TagResources.Users, typeof(Users));
            nbgRepairs.Tag = new NavBarGroupTagObject(TagResources.Repairs, typeof(Repairs));
            nbgMaps.Tag = new NavBarGroupTagObject(TagResources.Maps, typeof(Maps));
            nbgSoftware.Tag = new NavBarGroupTagObject(TagResources.Software, typeof(Software));

            officeNavigationBar.NavigationClient = nbMain;
        }
        void InitRibbonButtons()
        {
            InitBarButtonItem(bbiNewDevice, TagResources.NewDevice);
            InitBarButtonItem(bbiFindDevices, TagResources.FindDevices);
            InitBarButtonItem(bbiOpenWeb, TagResources.OpenWeb);
            InitBarButtonItem(bbiOpenRadmin, TagResources.OpenRadmin);
            InitBarButtonItem(bbiOpenRomViewer, TagResources.OpenRomViewer);
            InitBarButtonItem(bbiOpenMstsc, TagResources.OpenMstsc);
            InitBarButtonItem(bbiPing, TagResources.Ping);
            InitBarButtonItem(bbiTracert, TagResources.Tracert);

            InitBarButtonItem(bbiNewUser, TagResources.NewUser);

            InitBarButtonItem(bbiBringToFront, TagResources.BringToFront);
            InitBarButtonItem(bbiSendToBack, TagResources.SendToBack);
            InitBarButtonItem(bbiMapBackground, TagResources.MapBackground);

            InitBarButtonItem(bbiNewRepair, TagResources.NewRepair);
            InitBarButtonItem(bbiNewSoftware, TagResources.NewSoftware);

            InitBarButtonItem(bbiDeleteItem, TagResources.DeleteItem);
            InitBarButtonItem(bbiEditItem, TagResources.EditItem);

            InitBarButtonItem(bbiNameColumn, TagResources.NameColumn);
            InitBarButtonItem(bbiSKUColumn, TagResources.SKUColumn);
            InitBarButtonItem(bbiSerialColumn, TagResources.SerialColumn);
            InitBarButtonItem(bbiUserColumn, TagResources.UserColumn);
            InitBarButtonItem(bbiIPColumn, TagResources.IPColumn);
            InitBarButtonItem(bbiMACColumn, TagResources.MACColumn);
            InitBarButtonItem(bbiResetColumnsToDefault, TagResources.ResetColumnsToDefault);
            InitBarButtonItem(bbiDate, TagResources.DateFilterMenu);
            InitBarButtonItem(bbiClearFilter, TagResources.ClearFilter);
            InitBarButtonItem(bbiCloseSearch, TagResources.CloseSearch, ConstStrings.CloseSearchDescription);

            bciShowList.Tag = TagResources.ShowList;
            bciShowCards.Tag = TagResources.ShowCards;

            var items = new List<BarButtonItem>
            {
                bbiNameColumn,
                bbiSKUColumn,
                bbiSerialColumn,
                bbiUserColumn,
                bbiIPColumn,
                bbiMACColumn,
                bbiDate
            };
            _filterColumnsManager = new FilterColumnsManager(items);

            rpcSearch.Tag = TagResources.SearchTools;
            bvbiSaveAs.Tag = TagResources.MenuSaveAs;

            _allowCustomizationMenuList.Add(bsiNavigation);
            _allowCustomizationMenuList.Add(bsiFolderPane);
            _allowCustomizationMenuList.Add(bsiDataPane);
            _allowCustomizationMenuList.Add(bsiPreview);
            _allowCustomizationMenuList.Add(rgbiSkins);
            rcMain.Toolbar.ItemLinks.Add(rgbiSkins);
        }
        void InitBarButtonItem(BarButtonItem buttonItem, object tag, string description = "")
        {
            buttonItem.ItemClick += OnButtonItemOnItemClick;
            buttonItem.Hint = description;
            buttonItem.Tag = tag;
        }

        void OnButtonItemOnItemClick(object sender, ItemClickEventArgs e)
        {
            _modulesNavigator.CurrentModule.ButtonClick($"{e.Item.Tag}");
        }

        void InitNavigation()
        {
            foreach (NavBarGroup group in nbMain.Groups)
            {
                var barItem = new BarButtonItem(rcMain.Manager, group.Caption) { Tag = @group, Glyph = @group.SmallImage };
                barItem.ItemClick += delegate(object sender, ItemClickEventArgs e) { nbMain.ActiveGroup = (NavBarGroup)e.Item.Tag; };
                bsiNavigation.ItemLinks.Add(barItem);
            }
        }
        void OnDataSourceChanged(object sender, DataSourceChangedEventArgs e)
        {
            _modulesNavigator.CurrentModule.DataSourceChanged(e);
            ShowInfo(e.Count);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SkinHelper.InitSkinGallery(rgbiSkins, true);

            _layoutManager = new FormLayoutManager();
            LoadLayout();

            OnActiveGroupChanged(nbMain.ActiveGroup);
            CalcCloseAllDetails();

            SplashScreenManager.CloseForm(false);
        }

        public override FormLayoutManager LayoutManager => _layoutManager;
        public override IDXMenuManager MenuManager => rcMain.Manager;
        public override BackstageViewButtonItem SaveAsMenuItem => bvbiSaveAs;
        public override BarSubItem PreviewMenuItem => bsiPreview;
        public override BarButtonItem ClearFilterItem => bbiClearFilter;
        public override BarButtonItem CloseAllButton => bbiCloseAll;

        void LoadLayout()
        {
            LayoutManager.Properties.LoadDefaultSkin();

            bciShowCount.Checked = LayoutManager.Properties.ShowObjectCount;

            FolderPaneVisibility = LayoutManager.Properties.CurrentProperty.FolderPaneVisibility;
            int i1 = LayoutManager.Properties.CurrentProperty.SplitterPosition;
            if (i1 > 0)
                splitContainerControl.SplitterPosition = i1;

            int i2 = LayoutManager.Properties.PreviewLineCount;
            if (i2 == 1)
            {
                bciPreview1.Checked = true;
            }
            else if (i2 == 2)
            {
                bciPreview2.Checked = true;
            }
            else if (i2 == 3)
            {
                bciPreview3.Checked = true;
            }
            else
            {
                bciPreviewOff.Checked = true;
            }

            LayoutManager.RestoreFormLayout(new FormLayoutInfo(this, null, rcMain.Toolbar));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            var canCancel = (e.CloseReason != CloseReason.ApplicationExitCall &&
                             e.CloseReason != CloseReason.TaskManagerClosing &&
                             e.CloseReason != CloseReason.WindowsShutDown);
            if (canCancel)
            {
                CloseAllDetails();
                if (Details.Count > 0)
                {
                    ActiveDetail = Details[0];
                    e.Cancel = true;
                    return;
                }
            }
            _modulesNavigator.CurrentModule?.HideModule();
            LayoutManager.SaveFormLayout(new FormLayoutInfo(this, null, rcMain.Toolbar));
            LayoutManager.Properties.SaveDefaultProperties(FolderPaneVisibility, splitContainerControl.SplitterPosition);
        }

        public IPrintable CurrentPrintableComponent => _modulesNavigator.CurrentModule.PrintableComponent;
        public IPrintable CurrentExportComponent => _modulesNavigator.CurrentModule.ExportComponent;
        public RichEditControl CurrentRichEdit => _modulesNavigator.CurrentModule.CurrentRichEdit;
        public string CurrentModuleName => _modulesNavigator.CurrentModule.ModuleName;

        public override void UpdateTreeView()
        {
            var moduleType = _modulesNavigator.CurrentModule.GetType();
            if (moduleType == typeof(Devices))
            {
                ucDevicesTree.UpdateTreeView();
            }
            else if (moduleType == typeof(Users))
            {
                ucUsersFilter.UpdateTreeView();
            }
            else if (moduleType == typeof(Repairs))
            {
                ucRepairsFilter.UpdateTreeView();
            }
            else if (moduleType == typeof(Maps))
            {
                ucMaps.UpdateTreeView();
            }
            else if (moduleType == typeof(Software))
            {
                ucSoftwareFilter.UpdateTreeView();
            }
        }
        public override void SetDateFilterMenu(PopupMenu menu)
        {
            bbiDate.DropDownControl = menu;
        }
        public override void ShowInfo(int? count)
        {
            bsiInfo.Caption = count == null ? string.Empty : string.Format(ConstStrings.InfoText, count.Value);
            HtmlText = $"{_modulesNavigator.GetModuleName()}{_modulesNavigator.GetModulePartName()}";
        }
        public override void EnableEdit(bool enabled, bool enableActions = true)
        {
            bbiEditItem.Enabled = enabled;
            bbiDeleteItem.Enabled = enabled;
            bbiBringToFront.Enabled = enabled;
            bbiSendToBack.Enabled = enabled;

            bbiOpenWeb.Enabled = enabled && enableActions;
            bbiOpenRadmin.Enabled = enabled && enableActions;
            bbiOpenRomViewer.Enabled = enabled && enableActions;
            bbiOpenMstsc.Enabled = enabled && enableActions;
            bbiPing.Enabled = enabled && enableActions;
            bbiTracert.Enabled = enabled && enableActions;
        }
        public override void UpdateCurrentView(bool isGrid)
        {
            bciShowList.Checked = isGrid;
            bciShowCards.Checked = !isGrid;
        }
        public override void InitFilterColumns(GridView gridView)
        {
            _filterColumnsManager.InitGridView(gridView);
        }
        public override void ResetFilterColumns()
        {
            _filterColumnsManager.SetDefault();
        }

        int _oldIndex;
        void OnActiveGroupChanged(NavBarGroup @group)
        {
            var groupObject = @group.Tag as NavBarGroupTagObject;
            if (groupObject == null) return;

            var index = nbMain.Groups.IndexOf(@group);
            bool effective = _modulesNavigator.CurrentModule != null;
            object waitParameter = groupObject.Module == null ? @group.Caption : null;
            using (new TransitionService(this).EnterTransition(effective, index > _oldIndex, waitParameter))
            {
                //var workspaceService = this.Resolve<Services.IWorkspaceService>();
                //var resolver = this.Resolve<IModuleTypesResolver>();
                //if (oldType != ModuleType.Unknown)
                //    workspaceService.SaveWorkspace(resolver.GetName(oldType));
                //else
                //    workspaceService.SetupDefaultWorkspace();
                //SelectedModule = GetModule(SelectedModuleType);
                WinHelper.CloseCustomizationForm(_modulesNavigator.CurrentModule);
                var data = GetModuleData(groupObject);
                _modulesNavigator.ChangeModule(@group, data);
                _oldIndex = index;

                UpdateTreeView();

                //RaiseSelectedModuleTypeChanged();
                //if (SelectedModuleType != ModuleType.Unknown)
                //    workspaceService.RestoreWorkspace(resolver.GetName(SelectedModuleType));
            }
        }

        void OnPreviewBarItemItemClick(object sender, ItemClickEventArgs e)
        {
            int i = 0;
            if (e.Item == bciPreviewOff) i = 0;
            else if (e.Item == bciPreview1) i = 1;
            else if (e.Item == bciPreview2) i = 2;
            else if (e.Item == bciPreview3) i = 3;
            _modulesNavigator.CurrentModule.PreviewLineCount = i;
            LayoutManager.Properties.PreviewLineCount = i;
        }

        void ISupportTransitions.StartTransition(bool forward, object waitParameter)
        {
            var transition = transitionManager.Transitions[pcMain];
            var animator = (SlideFadeTransition)transition.TransitionType;
            animator.Parameters.EffectOptions = forward ? PushEffectOptions.FromRight : PushEffectOptions.FromLeft;
            if (waitParameter == null)
                transition.ShowWaitingIndicator = DefaultBoolean.False;
            else
            {
                transition.ShowWaitingIndicator = DefaultBoolean.True;
                transition.WaitingIndicatorProperties.Caption = EnumDisplayTextHelper.GetDisplayText(waitParameter);
                transition.WaitingIndicatorProperties.Description = "Loading...";
                transition.WaitingIndicatorProperties.ContentMinSize = new Size(160, 0);
            }
            transitionManager.StartTransition(pcMain);
        }
        void ISupportTransitions.EndTransition()
        {
            transitionManager.EndTransition();
        }

        object GetModuleData(NavBarGroupTagObject tag)
        {
            if (tag == null) return null;
            if (tag.ModuleType == typeof(Maps)) return ucMaps;
            return null;
        }

        #region Folders Pane

        FolderPaneVisibilityEnum _folderPaneVisibility = FolderPaneVisibilityEnum.Normal;

        FolderPaneVisibilityEnum FolderPaneVisibility
        {
            get { return _folderPaneVisibility; }
            set
            {
                splitContainerControl.SuspendLayout();
                try
                {
                    if (_folderPaneVisibility == value) return;
                    _folderPaneVisibility = value;
                    OnFolderPaneVisibilityChanged();
                }
                finally
                {
                    splitContainerControl.ResumeLayout(true);
                }
            }
        }

        void OnFolderPaneVisibilityChanged()
        {
            switch (FolderPaneVisibility)
            {
                case FolderPaneVisibilityEnum.Normal:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
                    nbMain.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                    bciFolderNormal.Checked = true;
                    break;
                case FolderPaneVisibilityEnum.Minimized:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
                    nbMain.OptionsNavPane.NavPaneState = NavPaneState.Collapsed;
                    bciFolderMinimized.Checked = true;
                    break;
                case FolderPaneVisibilityEnum.Off:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Panel2;
                    bciFolderOff.Checked = true;
                    break;
            }

            bbiNormal.Down = FolderPaneVisibility != FolderPaneVisibilityEnum.Minimized;
            bbiReading.Down = FolderPaneVisibility == FolderPaneVisibilityEnum.Minimized;
        }

        bool _isProcessingLayout;

        void CheckNavPaneState(int splitterPosition)
        {
            if (nbMain.OptionsNavPane.IsAnimationInProgress) return;
            if (!_isProcessingLayout)
            {
                try
                {
                    if (nbMain.OptionsNavPane.NavPaneState == NavPaneState.Expanded)
                    {
                        if (splitterPosition < 100)
                        {
                            _isProcessingLayout = true;
                            nbMain.OptionsNavPane.NavPaneState = NavPaneState.Collapsed;
                        }
                    }
                    else if (nbMain.OptionsNavPane.NavPaneState == NavPaneState.Collapsed)
                    {
                        if (splitterPosition > 100)
                        {
                            _isProcessingLayout = true;
                            nbMain.OptionsNavPane.ExpandedWidth = splitterPosition;
                            nbMain.OptionsNavPane.NavPaneState = NavPaneState.Expanded;
                        }
                    }
                }
                finally
                {
                    _isProcessingLayout = false;
                }
            }
        }

        void NbMainNavPaneStateChanged(object sender, EventArgs e)
        {
            FolderPaneVisibility = nbMain.OptionsNavPane.NavPaneState == NavPaneState.Collapsed ? FolderPaneVisibilityEnum.Minimized : FolderPaneVisibilityEnum.Normal;
        }

        void bciFolderNormal_ItemClick(object sender, ItemClickEventArgs e)
        {
            FolderPaneVisibility = FolderPaneVisibilityEnum.Normal;
        }

        void bciFolderMinimized_ItemClick(object sender, ItemClickEventArgs e)
        {
            FolderPaneVisibility = FolderPaneVisibilityEnum.Minimized;
        }

        void bciFolderOff_ItemClick(object sender, ItemClickEventArgs e)
        {
            FolderPaneVisibility = FolderPaneVisibilityEnum.Off;
        }

        void bbiNormal_ItemClick(object sender, ItemClickEventArgs e)
        {
            FolderPaneVisibility = FolderPaneVisibilityEnum.Normal;
        }

        void bbiReading_ItemClick(object sender, ItemClickEventArgs e)
        {
            FolderPaneVisibility = FolderPaneVisibilityEnum.Minimized;
        }

        void splitContainerControl1_SplitterMoving(object sender, SplitMovingEventArgs e)
        {
            e.Cancel = e.CurrentPosition < nbMain.CalcCollapsedPaneWidth();
            CheckNavPaneState(e.CurrentPosition);
        }

        void splitContainerControl1_SplitterMoved(object sender, EventArgs e)
        {
            if (nbMain.OptionsNavPane.NavPaneState == NavPaneState.Collapsed)
                splitContainerControl.SplitterPosition = nbMain.CalcCollapsedPaneWidth();
        }


        #endregion

        #region Devices

        void ucDevicesTree_UcTreeDragDrop(object sender, UcTreeDragDropEventArgs e)
        {
            var devices = _modulesNavigator.CurrentModule as Devices;
            devices?.OnUcTreeDragDrop(e);
        }

        void ucDevicesTree_ShowMenu(object sender, MouseEventArgs e)
        {
            bbiRenameFolder.Enabled = bbiMoveFolder.Enabled = ucDevicesTree.EnableEdit;
            bbiDeleteFolder.Enabled = ucDevicesTree.EnableDelete;
            pmDeviceTree.ShowPopup(ucDevicesTree.PointToScreen(e.Location));
        }

        void BbiCreateFolderItemClick(object sender, ItemClickEventArgs e)
        {
            pmDeviceTree.HidePopup();
            ucDevicesTree.CreateFolder();
        }

        void BbiRenameFolderItemClick(object sender, ItemClickEventArgs e)
        {
            pmDeviceTree.HidePopup();
            ucDevicesTree.StartEditing();
        }
        void BbiMoveFolderItemClick(object sender, ItemClickEventArgs e)
        {
            pmDeviceTree.HidePopup();
            ucDevicesTree.MoveFolder();
        }


        void BbiDeleteFolderItemClick(object sender, ItemClickEventArgs e)
        {
            pmDeviceTree.HidePopup();
            ucDevicesTree.DeleteFolder();
        }

        #endregion

        #region Maps

        void UcMapTreeShowMenu(object sender, MouseEventArgs e)
        {
            bbiDeleteMap.Enabled = ucMaps.EnableDelete;
            pmMapTree.ShowPopup(ucMaps.PointToScreen(e.Location));
        }

        void BbiCreateMapItemClick(object sender, ItemClickEventArgs e)
        {
            pmMapTree.HidePopup();
            ucMaps.CreateMap();
        }

        void BbiRenameMapItemClick(object sender, ItemClickEventArgs e)
        {
            pmMapTree.HidePopup();
            ucMaps.StartEditing();
        }

        void BbiDeleteMapItemClick(object sender, ItemClickEventArgs e)
        {
            pmMapTree.HidePopup();
            ucMaps.DeleteMap();
        }

        #endregion

        void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            _modulesNavigator.CurrentModule.SendKeyDown(e);
        }
        void nbMain_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
        {
            OnActiveGroupChanged(e.Group);
        }
        void bbiCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllDetails();
        }

        void BvbiExitItemClick(object sender, BackstageViewItemEventArgs e)
        {
            Close();
        }
        void BackstageViewControl1ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            _modulesNavigator.CurrentModule?.ButtonClick($"{e.Item.Tag}");
        }

        void BvtiImportSelectedChanged(object sender, BackstageViewItemEventArgs e)
        {
            if (backstageViewControl1.SelectedTab == bvtiImport)
                importControl1.InitData();
        }
        void BvtiPrintSelectedChanged(object sender, BackstageViewItemEventArgs e)
        {
            if (backstageViewControl1.SelectedTab == bvtiPrint)
                printControl1.InitPrintingSystem();
        }
        private void bvtiScheduler_SelectedChanged(object sender, BackstageViewItemEventArgs e)
        {
            if (backstageViewControl1.SelectedTab == bvtiScheduler)
                schedulerControl1.RefreshState();
        }
        void RcMainBeforeApplicationButtonContentControlShow(object sender, EventArgs e)
        {
            if (backstageViewControl1.SelectedTab == bvtiPrint) backstageViewControl1.SelectedTab = bvtiAbout;
            bvtiPrint.Enabled = CurrentRichEdit != null || CurrentPrintableComponent != null;
            bvtiExport.Enabled = CurrentExportComponent != null;
        }
        void RcMainShowCustomizationMenu(object sender, RibbonCustomizationMenuEventArgs e)
        {
            e.CustomizationMenu.InitializeMenu();
            if (e.Link == null || !_allowCustomizationMenuList.Contains(e.Link.Item))
                e.CustomizationMenu.RemoveLink(e.CustomizationMenu.ItemLinks[0]);
        }
        void bbiCustomFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            var module = _modulesNavigator.CurrentModule;
            if (module is Users)
            {
                ucUsersFilter.New();
            }
            else if (module is Repairs)
            {
                ucRepairsFilter.New();
            }
            else if (module is Software)
            {
                ucSoftwareFilter.New();
            }
        }
        void BciShowCountCheckedChanged(object sender, ItemClickEventArgs e)
        {
            LayoutManager.Properties.ShowObjectCount = ((BarCheckItem)sender).Checked;
            var module = _modulesNavigator.CurrentModule;
            if (module is Devices)
            {
                pmDeviceTree.HidePopup();
                ucDevicesTree.RefreshTreeList();
            }
            else if (module is Repairs)
            {
                pmMapTree.HidePopup();
                ucMaps.RefreshTreeList();
            }
            else if (module is Maps)
            {
                pmMapTree.HidePopup();
                ucMaps.RefreshTreeList();
            }
            else if (module is Software)
            {
                pmMapTree.HidePopup();
                ucMaps.RefreshTreeList();
            }
        }

        void bvbiOptions_ItemClick(object sender, BackstageViewItemEventArgs e)
        {
            using (var frm = new LayoutOptions(LayoutManager))
                frm.ShowDialog(this);
        }

        #region Notifications

        readonly Guid _notificationId = new Guid("F2E72ED1-F645-4DC3-8D8B-CF95BB3EA3E2");

        void InitNotifications()
        {
            notificationsManager.ApplicationIconPath = Path.Combine(Environment.CurrentDirectory, "AppIcon.ico");
            notificationsManager.ApplicationName = AssemblyVersion.AssemblyProduct;
            new SilentUpdater().UpdateAvailable += SilentUpdaterUpdateAvailable;
        }

        void SilentUpdaterUpdateAvailable(object sender, UpdateAvailableEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { ShowNotification(e.CurrentVersion, e.AvailableVersion); });
            }
            else
            {
                ShowNotification(e.CurrentVersion, e.AvailableVersion);
            }
        }

        void ShowNotification(string currentVersion, string availableVersion)
        {
            var body = string.Format(ConstStrings.NotificationBody, availableVersion, currentVersion);

            if (ToastNotificationsManager.AreToastNotificationsSupported)
            {
                var notification = new ToastNotification(_notificationId, null, AssemblyVersion.AssemblyProduct, body, ConstStrings.NotificationBody2, ToastNotificationTemplate.Text04) { Duration = ToastNotificationDuration.Long };
                notificationsManager.ShowNotification(notification);
            }
            else
            {
                var alertCaption = "<b>" + AssemblyVersion.AssemblyProduct + "</b>";
                var alertText = body + Environment.NewLine + ConstStrings.NotificationBody2;
                var info = new AlertInfo(alertCaption, alertText, ImagesHelper.AppIcon.ToBitmap()) { Tag = _notificationId };
                alertControl.Show(this, info);
            }
        }


        void alertControl_AlertClick(object sender, AlertClickEventArgs e)
        {
            e.AlertForm.Close();
            if (_notificationId.Equals(e.Info.Tag))
            {
                if (Program.ExecuteClickOnce(AssemblyVersion.AssemblyProduct))
                {
                    Close();
                }
            }
        }

        void notificationsManager_Activated(object sender, ToastNotificationEventArgs e)
        {
            if (_notificationId.Equals(e.NotificationID))
            {
                if (Program.ExecuteClickOnce(AssemblyVersion.AssemblyProduct))
                {
                    Close();
                }
            }
        }

        #endregion

    }
}
