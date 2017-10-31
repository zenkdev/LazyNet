using System;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class Users : ModuleBase, ISupportZoom, IDataPaneModule
    {
        int _focusedRowHandle;
        bool _lockUpdate = true;
        CriteriaOperator _filterCriteria;
        
        User _currentUser;

        User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (ReferenceEquals(_currentUser, value)) return;
                _currentUser = value;
                UpdateCurrentUser();
            }
        }

        public override string ModuleName { get { return ConstStrings.Users; } }
        public override RichEditControl CurrentRichEdit { get { return ucUserView.RichEdit; } }
        public override GridControl Grid { get { return gcMain; } }
        protected override ColumnView CurrentView { get { return gcMain.MainView as ColumnView; } }
        protected override ColumnView MainView { get { return gvList; } }
        protected override ColumnView AlternateView { get { return lvCards; } }

        public Users()
        {
            InitializeComponent();
            EditorsHelpers.InitGenderComboBox(riGender);
            lvCards.Appearance.FieldCaption.ForeColor = ColorHelper.DisabledTextColor;
            lvCards.Appearance.FieldCaption.Options.UseForeColor = true;
            colEmail.AppearanceCell.ForeColor = colEmail1.AppearanceCell.ForeColor = ColorHelper.HyperLinkTextColor;
        }

        protected override void DoParentChanged()
        {
            base.DoParentChanged();
            ucUserView.SetMenuManager(MenuManager);
        }

        public override void ShowModule(bool firstShow)
        {
            base.ShowModule(firstShow);
            if (firstShow)
            {
                gcMain.ForceInitialize();
                GridHelper.SetFindControlImages(gcMain);
                ShowAboutRow();
            }
            else
            {
                _lockUpdate = false;
                FocusRow(_focusedRowHandle);
            }
            gcMain.Focus();
            UpdateActionButtons();
        }
        public override void HideModule()
        {
            _lockUpdate = true;
            _focusedRowHandle = CurrentView.FocusedRowHandle;
            base.HideModule();
        }
        public override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResources.NewDevice:
                    ShowDetail(new DeviceDetail(ParentFormMain, GetSession, (int?)null, result => CloseActiveDetailForm()));
                    break;
                case TagResources.NewUser:
                    ShowDetail(new UserDetail(ParentFormMain, GetSession, CloseEditUser));
                    break;
                case TagResources.NewRepair:
                    ShowDetail(new RepairDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.NewSoftware:
                    ShowDetail(new SoftwareDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.EditItem:
                    EditUser(CurrentView.FocusedRowHandle);
                    break;
                case TagResources.DeleteItem:
                    var index = CurrentView.FocusedRowHandle;
                    if (CurrentUser != null)
                    {
                        if (XtraMessageBox.Show(this,
                                string.Format(ConstStrings.DeleteQuestion, CurrentUser.FullName), ConstStrings.Question,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (ObjectHelper.SafeDelete(this, CurrentUser, true))
                            {
                                RefreshData();
                                if (index > CurrentView.DataRowCount - 1) index--;
                                CurrentView.FocusedRowHandle = index;
                                ShowInfo(CurrentView);
                            }
                        }
                    }
                    break;
                case TagResources.ShowList:
                    UpdateMainView(gvList);
                    break;
                case TagResources.ShowCards:
                    UpdateMainView(lvCards);
                    break;
            }
        }
        public override void DataSourceChanged(DataSourceChangedEventArgs args)
        {
            partNameCore = args.Caption;
            _filterCriteria = (CriteriaOperator)args.Data;
            RefreshData();
            FocusRow(0);
        }
        protected override void LoadFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.RestoreFormLayout(new FormLayoutInfo(Name, null, gvList, lvCards, this));
            UpdateMainView(gcMain.MainView as ColumnView);
        }

        protected override void SaveFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.SaveFormLayout(new FormLayoutInfo(Name, null, gvList, lvCards, this));
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

        protected override void BeginRefreshData()
        {
            base.BeginRefreshData();
            CurrentUser = null;
            gcMain.DataSource = new XPServerCollectionSource(Session, typeof(User), _filterCriteria);
        }
        protected override void DoFocusedRowChanged()
        {
            if (_lockUpdate) return;
            if (CurrentView.FocusedRowHandle >= 0)
                CurrentUser = CurrentView.GetFocusedRow() as User;
            else
                CurrentUser = null;
        }

        void UpdateMainView(ColumnView view)
        {
            var currentObject = CurrentUser;
            var filter = CurrentView.ActiveFilterString;
            gcMain.MainView = view;
            GridHelper.GridViewFocusObject(CurrentView, currentObject);
            CurrentView.ActiveFilterString = filter;
            GridHelper.SetFindControlImages(gcMain);
            UpdateActionButtons();
        }
        void UpdateActionButtons()
        {
            ParentFormMain.UpdateCurrentView(gcMain.MainView is GridView);
            UpdateDataPaneState();
            var handler = ZoomChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
            handler = DataPaneChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        void UpdateCurrentUser()
        {
            ucUserView.Init(CurrentUser, null);
            gvList.MakeRowVisible(gvList.FocusedRowHandle);
            ParentFormMain.EnableEdit(CurrentUser != null);
        }

        void EditUser(int rowHandle)
        {
            var user = CurrentView.GetRow(rowHandle) as User;
            if (user == null) return;
 
            _focusedRowHandle = rowHandle;
            ShowDetail(new UserDetail(ParentFormMain, GetSession, user, CloseEditUser));
        }

        void CloseEditUser(DialogResult result)
        {
            CloseActiveDetailForm();
            if (result == DialogResult.Cancel) return;

            RefreshData();
            FocusRow(_focusedRowHandle);
            ShowInfo(CurrentView);
        }

        #region ISupportZoom Implementation
        public int ZoomLevel
        {
            get { return (int)(ucUserView.ZoomFactor * 100); }
            set
            {
                if (ZoomLevel == value) return;
                ucUserView.ZoomFactor = value / 100f;
                var handler = ZoomChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
        public bool ZoomEnabled { get { return gcMain.MainView is GridView; } }

        public event EventHandler ZoomChanged;

        #endregion

        #region IDataPaneModule Implementation

        DataPaneStateEnum _dataPaneState;
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

        public int SplitterPosition
        {
            get { return splitContainerControl.SplitterPosition; }
            set
            {
                if (value <= 0) return;
                splitContainerControl.SplitterPosition = value;
            }
        }
        public bool DataPaneEnabled { get { return gcMain.MainView is GridView; } }
        public event EventHandler DataPaneChanged;

        void UpdateDataPaneState()
        {
            if (!(CurrentView is GridView))
            {
                splitContainerControl.PanelVisibility = SplitPanelVisibility.Panel1;
                return;
            }

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
        }

        #endregion

        void gvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && gvList.FocusedRowHandle >= 0)
                EditUser(gvList.FocusedRowHandle);
        }
        void gvList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
                EditUser(e.RowHandle);
        }
        void gvList_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            if (e.FocusedRowHandle == GridControl.AutoFilterRowHandle)
                gvList.FocusedColumn = colFullName;
            else if (e.FocusedRowHandle >= 0)
                gvList.FocusedColumn = null;
            UpdateCurrentUser();
        }
        void lvCards_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks != 2 || e.Button != MouseButtons.Left) return;

            var info = lvCards.CalcHitInfo(e.Location);
            if (info.InCard)
                EditUser(info.RowHandle);
        }
    }
}
