using System;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class Software : ModuleBase
    {
        int _focusedRowHandle;
        bool _lockUpdate = true;
        CriteriaOperator _filterCriteria;

        SoftwareObject _currentSoftware;

        SoftwareObject CurrentSoftware
        {
            get { return _currentSoftware; }
            set
            {
                if (ReferenceEquals(_currentSoftware, value)) return;
                _currentSoftware = value;
                UpdateCurrentSoftware();
            }
        }
        public Software()
        {
            InitializeComponent();
            gvList.ShowFindPanel();
        }

        public override string ModuleName { get { return ConstStrings.Software; } }
        public override GridControl Grid { get { return gcMain; } }
        protected override ColumnView MainView { get { return gvList; } }

        public override void ShowModule(bool firstShow)
        {
            base.ShowModule(firstShow);
            if (firstShow)
            {
                gcMain.ForceInitialize();
                GridHelper.SetFindControlImages(gcMain);
                ShowAboutRow();
                //DoFocusedRowChanged();
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

        public override void DataSourceChanged(DataSourceChangedEventArgs args)
        {
            partNameCore = args.Caption;
            _filterCriteria = (CriteriaOperator)args.Data;
            RefreshData();
            FocusRow(0);
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
            gcMain.DataSource = new XPServerCollectionSource(Session, typeof(SoftwareObject), _filterCriteria);
        }
        protected override void DoFocusedRowChanged()
        {
            if (_lockUpdate) return;
            if (CurrentView.FocusedRowHandle >= 0)
                CurrentSoftware = CurrentView.GetFocusedRow() as SoftwareObject;
            else
                CurrentSoftware = null;
        }

        void UpdateActionButtons() { }
        void UpdateCurrentSoftware()
        {
            //ucUserView.Init(CurrentRepair, null);
            gvList.MakeRowVisible(gvList.FocusedRowHandle);
            ParentFormMain.EnableEdit(CurrentSoftware != null);
        }
        public override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResources.NewDevice:
                    ShowDetail(new DeviceDetail(ParentFormMain, GetSession, (int?)null, result => CloseActiveDetailForm()));
                    break;
                case TagResources.NewUser:
                    ShowDetail(new UserDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.NewRepair:
                    ShowDetail(new RepairDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.NewSoftware:
                    ShowDetail(new SoftwareDetail(ParentFormMain, GetSession, CloseEditSoftware));
                    break;
                case TagResources.EditItem:
                    EditSoftware(CurrentView.FocusedRowHandle);
                    break;
                case TagResources.DeleteItem:
                    int index = gvList.FocusedRowHandle;
                    if (CurrentSoftware != null)
                    {
                        ObjectHelper.SafeDelete(this, CurrentSoftware, true);
                    }
                    RefreshData();
                    if (index > gvList.DataRowCount - 1) index--;
                    gvList.FocusedRowHandle = index;
                    ShowInfo(gvList);
                    break;
            }
        }
        void EditSoftware(int rowHandle)
        {
            if (rowHandle < 0) return;
            var software = gvList.GetRow(rowHandle) as SoftwareObject;
            if (software == null) return;
            
            _focusedRowHandle = rowHandle;
            ShowDetail(new SoftwareDetail(ParentFormMain, GetSession, software, CloseEditSoftware));
        }

        void CloseEditSoftware(DialogResult result)
        {
            CloseActiveDetailForm();
            if (result == DialogResult.Cancel) return;

            RefreshData();
            FocusRow(_focusedRowHandle);
            ShowInfo(CurrentView);
        }

        void gvList_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            //if (e.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            //    gvMain.FocusedColumn = colFullName;
            //else if (e.FocusedRowHandle >= 0)
            //    gvMain.FocusedColumn = null;
            UpdateCurrentSoftware();
        }

        void gvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                EditSoftware(gvList.FocusedRowHandle);
        }

        void gvList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
                EditSoftware(e.RowHandle);
        }

        void MinPowerSpinEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (Convert.ToInt32(e.Value) == 0)
            {
                e.DisplayText = "";
            }
        }
    }
}
