using System;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class Repairs : ModuleBase
    {
        int _focusedRowHandle;
        bool _lockUpdate = true;
        CriteriaOperator _filterCriteria;
        int _previewLineCount;

        Repair _currentRepair;

        Repair CurrentRepair
        {
            get { return _currentRepair; }
            set
            {
                if (ReferenceEquals(_currentRepair, value)) return;
                _currentRepair = value;
                UpdateCurrentRepair();
            }
        }

        public override string ModuleName => ConstStrings.Repairs;

        public Repairs()
        {
            InitializeComponent();
            riRepairType.Items.AddLocalizedEnum<RepairTypeEnum>();
            gvList.ShowFindPanel();
        }
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
        protected override ColumnView MainView => gvList;
        protected override bool PreviewEnable => true;

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
            gcMain.DataSource = new XPServerCollectionSource(Session, typeof (Repair), _filterCriteria);
        }

        protected override void DoFocusedRowChanged()
        {
            if (_lockUpdate) return;
            if (CurrentView.FocusedRowHandle >= 0)
                CurrentRepair = CurrentView.GetFocusedRow() as Repair;
            else
                CurrentRepair = null;
        }

        void UpdateActionButtons() { }
        void UpdateCurrentRepair()
        {
            //ucUserView.Init(CurrentRepair, null);
            gvList.MakeRowVisible(gvList.FocusedRowHandle);
            ParentFormMain.EnableEdit(CurrentRepair != null);
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
                    ShowDetail(new RepairDetail(ParentFormMain, GetSession, CloseEditRepair));
                    break;
                case TagResources.NewSoftware:
                    ShowDetail(new SoftwareDetail(ParentFormMain, GetSession, result => CloseActiveDetailForm()));
                    break;
                case TagResources.EditItem:
                    EditRepair(CurrentView.FocusedRowHandle);
                    break;
                case TagResources.DeleteItem:
                    int index = gvList.FocusedRowHandle;
                    if (CurrentRepair != null)
                    {
                        ObjectHelper.SafeDelete(this, CurrentRepair, true);
                    }
                    RefreshData();
                    if (index > gvList.DataRowCount - 1) index--;
                    gvList.FocusedRowHandle = index;
                    ShowInfo(gvList);
                    break;
            }
        }

        void EditRepair(int rowHandle)
        {
            if (rowHandle < 0) return;
            var repair = CurrentView.GetRow(rowHandle) as Repair;
            if (repair == null) return;

            _focusedRowHandle = rowHandle;
            ShowDetail(new RepairDetail(ParentFormMain, GetSession, repair, CloseEditRepair));
        }

        
        void CloseEditRepair(DialogResult result)
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
            UpdateCurrentRepair();
        }

        void gvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && gvList.FocusedRowHandle >= 0)
                EditRepair(gvList.FocusedRowHandle);
        }

        void gvList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
                EditRepair(e.RowHandle);
        }
    }
}
