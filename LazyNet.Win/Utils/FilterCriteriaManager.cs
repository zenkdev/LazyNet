using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet.Win
{
    class FilterCriteriaManager
    {
        readonly GridView _view;
        readonly List<FilterCriteriaItem> _itemList;
        BarButtonItem _clearFilterItem;
        public FilterCriteriaManager(GridView view)
        {
            _view = view;
            _itemList = new List<FilterCriteriaItem>();
            view.ColumnFilterChanged += ViewColumnFilterChanged;
        }
        public GridView View { get { return _view; } }
        void ViewColumnFilterChanged(object sender, EventArgs e)
        {
            UpdateFilterInfo();
        }
        void UpdateFilterInfo()
        {
            foreach (FilterCriteriaItem item in _itemList)
                item.UpdateDown();
            if (_clearFilterItem != null)
                _clearFilterItem.Enabled = !_view.ActiveFilter.IsEmpty;
        }
        public void AddBarItem(BarButtonItem item, GridColumn column, string filterCriteria)
        {
            _itemList.Add(new FilterCriteriaItem(this, item, column, filterCriteria));
        }
        public void AddClearFilterButton(BarButtonItem item)
        {
            _clearFilterItem = item;
            UpdateFilterInfo();
        }
        internal string GetFilterCriteriaByColumn(GridColumn column)
        {
            return _itemList.Where(item => item.Checked && item.IsColumnEquals(column)).Aggregate(string.Empty, (current, item) => AddCriteria(current, item.FilterCriteria));
        }

        string AddCriteria(string ret, string filterCriteria)
        {
            ret = !string.IsNullOrEmpty(ret) ? string.Format("{0} Or {1}", ret, filterCriteria) : filterCriteria;
            return ret;
        }
    }

    class FilterCriteriaItem
    {
        readonly BarButtonItem _item;
        readonly string _filterCriteria;
        readonly GridColumn _column;
        readonly FilterCriteriaManager _owner;
        public FilterCriteriaItem(FilterCriteriaManager owner, BarButtonItem item, GridColumn column, string filterCriteria)
        {
            _item = item;
            _column = column;
            _filterCriteria = filterCriteria;
            _owner = owner;
            item.ButtonStyle = BarButtonStyle.Check;
            item.ItemClick += ItemItemClick;
        }
        GridView View { get { return _owner.View; } }
        public bool Checked { get { return _item.Down; } }
        internal string FilterCriteria { get { return _filterCriteria; } }
        internal bool IsColumnEquals(GridColumn column)
        {
            return _column.Equals(column);
        }
        void ItemItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateFilterCriteria(_column);
        }
        void UpdateFilterCriteria(GridColumn column)
        {
            var filterCriteria = _owner.GetFilterCriteriaByColumn(column);
            if (string.IsNullOrEmpty(filterCriteria)) View.ActiveFilter.Remove(column);
            else
                View.ActiveFilter.Add(column, new ColumnFilterInfo(filterCriteria));
        }
        internal void UpdateDown()
        {
            _item.Down = View.ActiveFilterString.IndexOf(_filterCriteria, StringComparison.Ordinal) >= 0;
        }
    }
}