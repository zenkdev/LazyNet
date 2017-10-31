using System;
using System.Collections;
using System.Windows.Forms;
using DevExpress.Utils.Design;
using DevExpress.Xpo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;

namespace Dekart.LazyNet
{
    public class ModuleBase : ControlBase
    {
        // ReSharper disable once InconsistentNaming
        protected string partNameCore = string.Empty;
        protected UnitOfWork Session { get { return _session; } }
        UnitOfWork _session;
        UnitOfWork _oldSession;

        protected ModuleBase() { }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
                LoadFormLayout();
        }
        public virtual void InitModule(object data, UnitOfWork session)
        {
            if (MainView != null)
            {
                MainView.FocusedRowChanged += OnFocusedRowChanged;
                MainView.ColumnFilterChanged += OnColumnFilterChanged;
                //MainView.GridControl.MouseDoubleClick += new MouseEventHandler(GridControl_MouseDoubleClick);
                //MainView.GridControl.KeyDown += new KeyEventHandler(GridControl_KeyDown);
            }
            if (AlternateView != null)
            {
                AlternateView.FocusedRowChanged += OnFocusedRowChanged;
                AlternateView.ColumnFilterChanged += OnColumnFilterChanged;
            }
            _session = session;
        }
        public void SetParent(Form parent)
        {
            if (ParentFormMain == parent) return;
            ParentFormMain = parent as MainFormBase;
            if (parent != null)
            {
                SetMenuManager(Controls, MenuManager);
            }
            DoParentChanged();
        }
        protected virtual void DoParentChanged()
        {
            RefreshGridDataSource();
        }
        protected virtual void RefreshGridDataSource() { }
        public virtual void ShowModule(bool firstShow)
        {
            if (ParentFormMain != null)
            {
                ParentFormMain.SaveAsMenuItem.Enabled = SaveAsEnable;
                ParentFormMain.PreviewMenuItem.Enabled = PreviewEnable;
                PreviewLineCount = ParentFormMain.LayoutManager.Properties.PreviewLineCount;
            }
            ShowInfo();
        }
        public virtual void HideModule()
        {
            SaveFormLayout();
        }
        protected virtual void LoadFormLayout() { }
        protected virtual void SaveFormLayout() { }
        protected void ShowInfo()
        {
            if (ParentFormMain == null) return;
            if (Grid == null)
            {
                ParentFormMain.ShowInfo(null);
                return;
            }
            var list = Grid.DataSource as ICollection;
            if (list == null)
                ParentFormMain.ShowInfo(null);
            else ParentFormMain.ShowInfo(list.Count);
        }
        protected void ShowInfo(ColumnView view)
        {
            if (ParentFormMain != null && view != null)
                ParentFormMain.ShowInfo(view.DataRowCount);
        }
        void OnColumnFilterChanged(object sender, EventArgs e)
        {
            DoFocusedRowChanged();
            ShowInfo(CurrentView);
        }
        void OnFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            DoFocusedRowChanged();
        }
        public virtual IPrintable PrintableComponent { get { return Grid; } }
        public virtual IPrintable ExportComponent { get { return Grid; } }
        public virtual RichEditControl CurrentRichEdit { get { return null; } }
        public virtual void ButtonClick(string tag) { }
        public virtual void DataSourceChanged(DataSourceChangedEventArgs args) { }
        public virtual void SendKeyDown(KeyEventArgs e) { }
        public virtual string ModuleName { get { return GetType().Name; } }
        public string PartName { get { return partNameCore; } }
        public virtual int PreviewLineCount { get; set; }
        public virtual GridControl Grid { get { return null; } }
        protected virtual ColumnView MainView { get { return null; } }
        protected virtual ColumnView AlternateView { get { return null; } }
        protected virtual ColumnView CurrentView { get { return MainView; } }
        protected virtual bool SaveAsEnable { get { return false; } }
        protected virtual bool PreviewEnable { get { return false; } }

        /// <summary>Refresh data</summary>
        public void RefreshData()
        {
            BeginRefreshData();
            EndRefreshData();
        }

        /// <summary>Begin data refresh</summary>
        protected virtual void BeginRefreshData()
        {
            Cursor.Current = Cursors.WaitCursor;
            //_lockUpdate = true;
            _oldSession = _session;
            if (_session != null) _session = new UnitOfWork();
            //_current = CurrentObject;
            //RefreshGridDataSource();
        }

        /// <summary>EndRefreshData</summary>
        protected virtual void EndRefreshData()
        {
            //_lockUpdate = false;

            if (_oldSession != null)
            {
                _oldSession.Dispose();
                _oldSession = null;
            }

            //if (CurrentView != null)
            //{
            //    CurrentView.GridControl.Select();
            //    CurrentView.Focus();
            //    if (_current != null) ObjectHelper.GridViewFocusObject(CurrentView, _current);
            //}

            //UpdateReadOnlyData();
        }
        public void FocusRow(int rowHandle)
        {
            if (CurrentView != null)
            {
                CurrentView.FocusedRowHandle = rowHandle;
                CurrentView.ClearSelection();
                CurrentView.SelectRow(rowHandle);
                CurrentView.Focus();
            }
            DoFocusedRowChanged();
        }
        protected virtual void DoFocusedRowChanged() { }
        /// <summary>Gets the session</summary>
        protected UnitOfWork GetSession() { return Session; }

        public void ShowDetail(DetailBase detail)
        {
            if (ParentFormMain == null) return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!ParentFormMain.IsDetailExist(detail.Id))
                    ParentFormMain.ShowDetail(detail);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void CloseActiveDetailForm()
        {
            if (ParentFormMain == null) return;

            ParentFormMain.CloseActiveDetailForm();
        }
    }
}