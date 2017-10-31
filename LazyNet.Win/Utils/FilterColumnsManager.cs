using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet.Win
{
    public class FilterColumnsManager
    {
        readonly List<BarButtonItem> _items;
        GridView _view;
        bool _lockUpdate;
        public FilterColumnsManager(List<BarButtonItem> items)
        {
            _items = items;
            foreach (BarButtonItem item in items)
                item.DownChanged += ItemDownChanged;
        }
        BarButtonItem GetItemByName(string name)
        {
            return _items.FirstOrDefault(item => item.Tag.Equals(name));
        }

        public void SetDefault()
        {
            _lockUpdate = true;
            foreach (BarButtonItem item in _items)
                if (item.CanDown)
                    item.Down = false;
            GetItemByName(TagResources.NameColumn).Down = true;
            _lockUpdate = false;
            Update();
        }
        void Update()
        {
            var filterColumns = string.Empty;
            if (GetItemByName(TagResources.NameColumn).Down) filterColumns += "Name;";
            if (GetItemByName(TagResources.SKUColumn).Down) filterColumns += "SKU;";
            if (GetItemByName(TagResources.SerialColumn).Down) filterColumns += "Serial;";
            if (GetItemByName(TagResources.UserColumn).Down) filterColumns += "User.FullName;";
            if (GetItemByName(TagResources.IPColumn).Down) filterColumns += "IP;";
            if (GetItemByName(TagResources.MACColumn).Down) filterColumns += "MAC;";
            _view.OptionsFind.FindFilterColumns = filterColumns;
        }
        void ItemDownChanged(object sender, ItemClickEventArgs e)
        {
            if (_lockUpdate) return;
            Update();
        }
        public void InitGridView(GridView gridView)
        {
            if (_view != null) return;
            _view = gridView;
            SetDefault();
        }
    }
}