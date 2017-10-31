using DevExpress.Utils.Menu;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Dekart.LazyNet.Win
{
    public class FilterTreeListManager
    {
        readonly TreeList _treeList;
        public FilterTreeListManager(TreeList treeList)
        {
            _treeList = treeList;
        }
        public void ModifyFilter(TreeListNode node, FilterControlBase control)
        {
            if (node == null || node.ParentNode == null) return;

            if (MatchHierarchy(node, control.CustomFilters))
                control.Modify(GetRow<FilterItem>(node));
        }
        public bool PopulateFiltersMenu(DXPopupMenu nodeMenu, TreeListNode node, FilterControlBase control)
        {
            if (MatchHierarchy(node, control.CustomFilters))
            {
                var newItem = new DXMenuItem { Caption = ConstStrings.NewFilter };
                newItem.Click += (sender, e) => control.New();
                nodeMenu.Items.Add(newItem);
                if (node.ParentNode != null)
                {
                    var filterItem = GetRow<FilterItem>(node);
                    var editItem = new DXMenuItem { Caption = ConstStrings.EditFilter };
                    editItem.Click += (sender, e) => control.Modify(filterItem);
                    nodeMenu.Items.Add(editItem);
                    var deleteItem = new DXMenuItem { Caption = ConstStrings.DeleteFilter };
                    deleteItem.Click += (sender, e) => control.Delete(filterItem);
                    nodeMenu.Items.Add(deleteItem);
                }
                return true;
            }
            return false;
        }

        public TreeListNode FindNode(object dataItem)
        {
            return _treeList.FindNode(node => Match(node, dataItem));
        }
        public bool Match(TreeListNode node, object dataItem)
        {
            return _treeList.GetDataRecordByNode(node) == dataItem;
        }
        public bool MatchHierarchy(TreeListNode node, object dataItem)
        {
            while (node != null)
            {
                if (Match(node, dataItem))
                    return true;
                node = node.ParentNode;
            }
            return false;
        }
        public T GetRow<T>(TreeListNode node) where T : class
        {
            return _treeList.GetDataRecordByNode(node) as T;
        }
    }
}