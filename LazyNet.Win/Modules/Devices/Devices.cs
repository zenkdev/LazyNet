using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class Devices : ModuleBase, ISupportZoom, IDataPaneModule
    {
        int _parent;
        RibbonControl _ribbon;
        FindControlManager _findControlManager;
        FilterCriteriaManager _filterCriteriaManager;

        int _focusedRowHandle;
        bool _lockUpdate = true;
        int _previewLineCount;
        Device _currentDevice;
        Device CurrentDevice
        {
            get { return _currentDevice; }
            set
            {
                if (ReferenceEquals(_currentDevice, value)) return;
                _currentDevice = value;
                UpdateCurrentDevice();
            }
        }

        public Devices()
        {
            InitializeComponent();

            EditorsHelpers.InitDeviceTypeComboBox(riDeviceType);
            EditorsHelpers.InitDeviceTypeComboBox(riDeviceType1);
            riDeviceState.Items.AddLocalizedEnum<DeviceStateEnum>();

            gvList.FormatRules.Add(
                new GridFormatRule
                {
                    Column = gcDeviceState,
                    ColumnApplyTo = gcName,
                    Name = "Format0",
                    Rule =
                        new FormatConditionRuleValue
                        {
                            Condition = FormatCondition.NotEqual,
                            PredefinedName = "Strikeout Text",
                            Value1 = DeviceStateEnum.Operated
                        },
                    StopIfTrue = true
                }
                );

            bbiOpenWeb.ItemClick += (s, e) => ButtonClick(TagResources.OpenWeb);
            bbiOpenRadmin.ItemClick += (s, e) => ButtonClick(TagResources.OpenRadmin);
            bbiOpenRomViewer.ItemClick += (s, e) => ButtonClick(TagResources.OpenRomViewer);
            bbiOpenMstsc.ItemClick += (s, e) => ButtonClick(TagResources.OpenMstsc);
            bbiPing.ItemClick += (s, e) => ButtonClick(TagResources.Ping);
            bbiTracert.ItemClick += (s, e) => ButtonClick(TagResources.Tracert);
            bbiSystemInfo.ItemClick += (s, e) => ButtonClick(TagResources.SystemInfo);
        }

        public override string ModuleName => ConstStrings.Devices;
        public override RichEditControl CurrentRichEdit => ucDeviceView.RichEdit;

        public override int PreviewLineCount
        {
            get { return _previewLineCount; }
            set
            {
                if (_previewLineCount == value) return;
                _previewLineCount = value;

                gvList.PreviewLineCount = _previewLineCount;
                gvList.OptionsView.ShowPreview = _previewLineCount > 0;
                gvList.OptionsView.ShowHorizontalLines = _previewLineCount > 0 ? DefaultBoolean.True : DefaultBoolean.False;
            }
        }

        public override GridControl Grid => gcMain;
        protected override ColumnView CurrentView => gcMain.MainView as ColumnView;
        protected override ColumnView MainView => gvList;
        protected override bool SaveAsEnable => true;
        protected override bool PreviewEnable => true;

        protected override void DoParentChanged()
        {
            base.DoParentChanged();
            if (ParentFormMain != null)
                _ribbon = ParentFormMain.Ribbon;
            ucDeviceView.SetMenuManager(MenuManager);
        }

        public override void ShowModule(bool firstShow)
        {
            base.ShowModule(firstShow);
            if (firstShow)
            {
                gcMain.ForceInitialize();
                _filterCriteriaManager = new FilterCriteriaManager(gvList);
                _filterCriteriaManager.AddClearFilterButton(ParentFormMain.ClearFilterItem);
                SetDateFilterMenu();
                ParentFormMain.InitFilterColumns(gvList);
                GridHelper.SetFindControlImages(gcMain);
                ShowAboutRow();
                CalcPreviewIndent();
            }
            else
            {
                _lockUpdate = false;
                FocusRow(_focusedRowHandle);
            }
            gcMain.Focus();
            UpdateDataPaneState();
        }
        public override void HideModule()
        {
            _lockUpdate = true;
            _focusedRowHandle = CurrentView.FocusedRowHandle;
            base.HideModule();
        }
        public override void ButtonClick(string tag)
        {
            radialMenu1.HidePopup();

            switch (tag)
            {
                case TagResources.NewDevice:
                    ShowDetail(new DeviceDetail(ParentFormMain, GetSession, _parent, CloseEditDevice));
                    break;
                case TagResources.NewUser:
                    ShowDetail(new UserDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.NewRepair:
                    ShowDetail(new RepairDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.NewSoftware:
                    ShowDetail(new SoftwareDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.EditItem:
                    EditDevice(CurrentView.FocusedRowHandle);
                    break;
                case TagResources.DeleteItem:
                    var index = CurrentView.FocusedRowHandle;
                    if (CurrentDevice != null)
                    {
                        if (XtraMessageBox.Show(this,
                            string.Format(ConstStrings.DeleteQuestion, CurrentDevice.Name), ConstStrings.Question,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (ObjectHelper.SafeDelete(this, CurrentDevice, true))
                            {
                                ParentFormMain.UpdateTreeView();
                                if (index > CurrentView.DataRowCount - 1) index--;
                                CurrentView.FocusedRowHandle = index;
                                ShowInfo(CurrentView);
                            }
                        }
                    }
                    break;
                case TagResources.FindDevices:
                    using (var form = new FindDevices(ParentFormMain))
                        if (form.ShowDialog(FindForm()) == DialogResult.OK)
                        {
                            //RefreshData();
                            ParentFormMain.UpdateTreeView();
                        }
                    break;
                case TagResources.OpenWeb:
                    CurrentDevice.OpenWeb();
                    break;
                case TagResources.OpenRadmin:
                    CurrentDevice.OpenRadmin();
                    break;
                case TagResources.OpenRomViewer:
                    CurrentDevice.OpenRomViewer();
                    break;
                case TagResources.OpenMstsc:
                    CurrentDevice.OpenMstsc();
                    break;
                case TagResources.Ping:
                    CurrentDevice.Ping();
                    break;
                case TagResources.Tracert:
                    CurrentDevice.Tracert();
                    break;
                case TagResources.SystemInfo:
                    using (var frm = new SystemInfoForm(CurrentDevice.HostName))
                    {
                        frm.ShowDialog(this);
                    }
                    break;
                case TagResources.CloseSearch:
                    CurrentView.Focus();
                    break;
                case TagResources.ResetColumnsToDefault:
                    ParentFormMain.ResetFilterColumns();
                    break;
                case TagResources.ClearFilter:
                    CurrentView.ActiveFilter.Clear();
                    break;
                case TagResources.MenuSaveAs:
                    SaveAs();
                    break;
            }
        }
        public override void SendKeyDown(KeyEventArgs e)
        {
            base.SendKeyDown(e);
            if (e.KeyData == (Keys.E | Keys.Control))
            {
                FindControl?.FindEdit.Focus();
            }
        }
        public override void DataSourceChanged(DataSourceChangedEventArgs args)
        {
            partNameCore = args.Caption;
            _parent = (int)args.Data;
            RefreshData();
            if (FindControl != null)
            {
                FindControl.FindEdit.Properties.NullValuePrompt = string.Format(ConstStrings.SearchString, partNameCore);
                FindControl.FindEdit.Properties.NullValuePromptShowForEmptyValue = true;
                if (_findControlManager == null)
                    _findControlManager = new FindControlManager(_ribbon, FindControl);
            }
            FocusRow(0);
        }
        protected override void LoadFormLayout()
        {
            LayoutManager?.RestoreFormLayout(new FormLayoutInfo(Name, null, gvList, null, this));
        }

        protected override void SaveFormLayout()
        {
            LayoutManager?.SaveFormLayout(new FormLayoutInfo(Name, null, gvList, null, this));
        }

        void ShowAboutRow()
        {
            var tmr = new Timer { Interval = 100 };
            tmr.Tick += TmrTick;
            tmr.Start();
        }
        void TmrTick(object sender, EventArgs e)
        {
            _lockUpdate = false;
            FocusRow(0);
            ((Timer)sender).Stop();
        }

        #region Filter Implementation
        FindControl FindControl => gcMain.Controls.OfType<FindControl>().FirstOrDefault();
        PopupMenu _dateFilterMenu;
        PopupMenu DateFilterMenu => _dateFilterMenu ?? (_dateFilterMenu = new DateFilterMenu(_ribbon.Manager, gvList, _filterCriteriaManager));

        void SetDateFilterMenu()
        {
            ParentFormMain.SetDateFilterMenu(DateFilterMenu);
        }
        #endregion

        protected override void BeginRefreshData()
        {
            base.BeginRefreshData();
            CurrentDevice = null;
            CriteriaOperator theCriteria = new BinaryOperator("DeletionMark", false);
            if (_parent > 0) theCriteria = CriteriaOperator.And(theCriteria, new BinaryOperator("Room", _parent));
            gcMain.DataSource = new XPServerCollectionSource(Session, typeof(Device), theCriteria);
        }
        protected override void DoFocusedRowChanged()
        {
            if (_lockUpdate) return;
            if (CurrentView.FocusedRowHandle >= 0)
                CurrentDevice = CurrentView.GetFocusedRow() as Device;
            else
                CurrentDevice = null;
        }

        void UpdateCurrentDevice()
        {
            ucDeviceView.Init(CurrentDevice, "");
            gvList.MakeRowVisible(gvList.FocusedRowHandle);
            ParentFormMain.EnableEdit(CurrentDevice != null, CurrentDevice.CanConnect());
        }
        void SaveAs()
        {
            if (saveFileDialog1.ShowDialog(FindForm()) != DialogResult.OK) return;
            switch (saveFileDialog1.FilterIndex)
            {
                case 1:
                    DeviceActions.SaveAsRemoteOfficeAddressBook(saveFileDialog1.OpenFile());
                    break;
                case 2:
                    DeviceActions.SaveAsRadminPhoneBook(saveFileDialog1.OpenFile());
                    break;
            }
        }
        void EditDevice(int rowHandle)
        {
            var device = CurrentView.GetRow(rowHandle) as Device;
            if (device == null) return;
            _focusedRowHandle = rowHandle;

            ShowDetail(new DeviceDetail(ParentFormMain, GetSession, device, CloseEditDevice));
        }

        void CloseEditDevice(DialogResult result)
        {
            CloseActiveDetailForm();
            if (result == DialogResult.Cancel) return;

            //RefreshData();
            ParentFormMain.UpdateTreeView();
            FocusRow(_focusedRowHandle);
            ShowInfo(CurrentView);
        }

        #region Drag and drop

        Point _dragStart = new Point(int.MinValue, 0);

        int[] _dragSelection;

        void ResetDrag()
        {
            _dragSelection = null;
            _dragStart = new Point(int.MinValue, int.MinValue);
        }

        void GridView1MouseDown(object sender, MouseEventArgs e)
        {
            if (gvList.CalcHitInfo(e.X, e.Y).InRow)
            {
                _dragStart = new Point(e.X, e.Y);
                if (_dragSelection == null || _dragSelection.Length == 0) _dragSelection = new[] { gvList.FocusedRowHandle };
            }
            else
                ResetDrag();
        }

        void GridView1MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragStart.X != int.MinValue && e.Button == MouseButtons.Left)
            {
                Point delta = Point.Subtract(_dragStart, new Size(e.X, e.Y));
                if (Math.Abs(delta.X) > SystemInformation.DragSize.Width ||
                    Math.Abs(delta.Y) > SystemInformation.DragSize.Height)
                {
                    _dragSelection = gvList.GetSelectedRows();
                    StartRowsDrag();
                }
            }
        }

        void StartRowsDrag()
        {
            gcMain.DoDragDrop(new DragSelection { Rows = _dragSelection }, DragDropEffects.Move);
        }

        internal void OnUcTreeDragDrop(UcTreeDragDropEventArgs e)
        {
            var devices = new List<Device>();
            foreach (var row in e.Selection.Rows)
            {
                if (row >= 0 && gvList.GetRow(row) is Device)
                    devices.Add(gvList.GetRow(row) as Device);
                if (row >= 0) continue;
                var count = gvList.GetChildRowCount(row);
                for (var n = 0; n < count; n++)
                {
                    var rowHandle = gvList.GetChildRowHandle(row, n);
                    if (rowHandle >= 0 && gvList.GetRow(rowHandle) is Device)
                        devices.Add(gvList.GetRow(rowHandle) as Device);
                }
            }
            foreach (var device in devices)
            {
                Console.WriteLine(device.ObjectName);
                var srcRoom = device.Room;
                var dstRoom = Session.GetObjectByKey<Room>(e.Data);
                device.Room = dstRoom;
                var movement = new Movement(Session)
                {
                    Device = device,
                    OldRoom = srcRoom,
                    NewRoom = dstRoom,
                    OldUser = device.User,
                    NewUser = device.User
                };
                movement.Save();
            }
            SessionHelper.CommitSession(Session, new ExceptionProcesser(this));
            ParentFormMain.UpdateTreeView();
            ResetDrag();
        }

        #endregion

        #region ISupportZoom Implementation
        public int ZoomLevel
        {
            get { return (int)(ucDeviceView.ZoomFactor * 100); }
            set
            {
                if (ZoomLevel == value) return;
                ucDeviceView.ZoomFactor = value / 100f;
                var handler = ZoomChanged;
                handler?.Invoke(this, EventArgs.Empty);
            }
        }
        public bool ZoomEnabled => true;

        public event EventHandler ZoomChanged;

        #endregion

        #region IDataPaneModule Implementation

        DataPaneStateEnum _dataPaneState;

        /// <summary> Data pane state </summary>
        public DataPaneStateEnum DataPaneState
        {
            get { return _dataPaneState; }
            set
            {
                if (_dataPaneState == value) return;
                _dataPaneState = value;
                UpdateDataPaneState();
            }
        }

        /// <summary> Splitter position </summary>
        public int SplitterPosition
        {
            get { return splitContainerControl.SplitterPosition; }
            set
            {
                if (value <= 0) return;
                splitContainerControl.SplitterPosition = value;
            }
        }

        /// <summary> Data pane enabled </summary>
        public bool DataPaneEnabled => true;

        /// <summary> Data pane changed event </summary>
        public event EventHandler DataPaneChanged;

        void UpdateDataPaneState()
        {
            switch (_dataPaneState)
            {
                case DataPaneStateEnum.Right:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
                    splitContainerControl.Horizontal = true;
                    break;
                case DataPaneStateEnum.Bottom:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
                    splitContainerControl.Horizontal = false;
                    break;
                case DataPaneStateEnum.Off:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Panel1;
                    break;
            }

            var handler = DataPaneChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        void gvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && gvList.FocusedRowHandle >= 0)
                EditDevice(gvList.FocusedRowHandle);
        }
        void gvList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
                EditDevice(e.RowHandle);
        }
        void gvList_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
                radialMenu1.ShowPopup(gcMain.PointToScreen(e.Point));
        }

        void gvList_ColumnPositionChanged(object sender, EventArgs e)
        {
            CalcPreviewIndent();
        }
        void CalcPreviewIndent()
        {
            int indent = 0;
            foreach (GridColumn column in gvList.VisibleColumns)
            {
                if ("DeviceType".IndexOf(column.FieldName, StringComparison.Ordinal) > -1)
                    indent += column.Width;
                else break;
            }
            gvList.PreviewIndent = indent;
        }
    }
}
