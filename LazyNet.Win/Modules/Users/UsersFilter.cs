using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Design;
using DevExpress.Xpo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;

namespace Dekart.LazyNet.Win.Modules
{
    partial class UsersFilter : FilterControlBase
    {
        bool _allowDataSourceChanged = true;
        public UsersFilter()
            : base(new FilterTreeSettings<AppSettings>(AppSettings.Default, x => x.UsersStaticFilters, x => x.UsersCustomFilters))
        {
            InitializeComponent();
        }
        public event DataSourceChangedEventHandler DataSourceChanged;

        protected override void LookAndFeelStyleChanged()
        {
            base.LookAndFeelStyleChanged();
            Color controlColor = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("Control");
            treeList.Appearance.Empty.BackColor = controlColor;
            treeList.Appearance.Row.BackColor = controlColor;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
                BindTreeList();
        }

        internal void UpdateTreeView()
        {
            _allowDataSourceChanged = false;

            //var b = _initialized;
            //if (b) treeList.ViewState.SaveState();
            //InitData();
            //RefreshTreeList();
            treeList.RefreshDataSource();
            treeList.ExpandAll();
            //if (b) treeList.ViewState.LoadState();

            _allowDataSourceChanged = true;
            RaiseDataSourceChanged(SelectedItem);
        }

        #region TreeList Binding
        void BindTreeList()
        {
            var colName = treeList.Columns.AddField("Name");
            colName.Visible = true;
            colName.ColumnEdit = repositoryItemButtonEdit1;

            treeList.DataSource = this;
            treeList.ExpandAll();

            var manager = new FilterTreeListManager(treeList);
            treeList.FocusedNode = manager.FindNode(SelectedItem);
        }
        void treeList_VirtualTreeGetChildNodes(object sender, VirtualTreeGetChildNodesInfo e)
        {
            e.Children = GetСhildren(e.Node);
        }
        void treeList_VirtualTreeGetCellValue(object sender, VirtualTreeGetCellValueInfo e)
        {
            e.CellData = GetFilterName(e.Node, e.Node as FilterItemBase, e.Node.Equals(treeList.FocusedNode));
        }
        #endregion
        #region TreeList Node Menu
        void treeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hi = treeList.CalcHitInfo(e.Location);
            var helper = new FilterTreeListManager(treeList);
            helper.ModifyFilter(hi.Node, this);
        }
        void treeList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.MenuType == TreeListMenuType.Node)
            {
                var hi = treeList.CalcHitInfo(e.Point);
                var helper = new FilterTreeListManager(treeList);
                if (!helper.PopulateFiltersMenu(e.Menu, hi.Node, this))
                    e.Allow = false;
            }
        }
        #endregion
        #region Nodes Drag&Drop
        void treeList_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            if (e.Node.ParentNode == null)
                e.CanDrag = false;
        }
        void treeList_DragOver(object sender, DragEventArgs e)
        {
            var ea = treeList.GetDXDragEventArgs(e);
            e.Effect = !Equals(ea.RootNode, ea.TargetRootNode) ? DragDropEffects.None : DragDropEffects.Move;
        }

        void treeList_DragDrop(object sender, DragEventArgs e)
        {
            var ea = treeList.GetDXDragEventArgs(e);
            if (ea.TargetNode != null)
            {
                treeList.SetNodeIndex(ea.Node, treeList.GetNodeIndex(ea.TargetNode));
                e.Effect = DragDropEffects.None;
            }
        }
        void treeList_CalcNodeDragImageIndex(object sender, CalcNodeDragImageIndexEventArgs e)
        {
            var ea = treeList.GetDXDragEventArgs(e.DragArgs);
            if (!Equals(ea.RootNode, ea.TargetRootNode))
                e.ImageIndex = -1;
            else
                e.ImageIndex = 1;
        }
        #endregion
        #region Focused Node Synchronization
        void treeList_BeforeFocusNode(object sender, BeforeFocusNodeEventArgs e)
        {
            e.CanFocus = (treeList.GetDataRecordByNode(e.Node) is FilterItemBase);
        }

        void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            var filterItem = treeList.GetDataRecordByNode(e.Node) as FilterItemBase;
            SelectedItem = filterItem;
            treeList.RefreshNode(e.Node);
            treeList.RefreshNode(e.OldNode);
        }

        #endregion

        public override void New()
        {
            var newFilterItem = CreateFilterItem(null, null, null);
            var frm = new UserFilterForm(newFilterItem);
            if (frm.ShowDialog(ParentFormMain) == DialogResult.OK)
            {
                if (frm.Save)
                {
                    AddNewCustomFilter(newFilterItem);
                    UpdateTreeView();
                }
                SelectedItem = newFilterItem;
                var helper = new FilterTreeListManager(treeList);
                treeList.FocusedNode = helper.FindNode(SelectedItem);
            }
        }

        public override void Modify(FilterItem item)
        {
            var frm = new UserFilterForm(item);
            if (frm.ShowDialog(ParentFormMain) == DialogResult.OK)
            {
                if (frm.Save)
                {
                    SaveCustomFilters();
                    UpdateTreeView();
                }
                RaiseDataSourceChanged(item);
            }
        }

        public override void Delete(FilterItem item)
        {
            DeleteCustomFilter(item);
            UpdateTreeView();
            if (SelectedItem == item)
                SelectedItem = StaticFilters.FirstOrDefault();
        }

        protected override void OnSelectedItemChanged()
        {
            RaiseDataSourceChanged(SelectedItem);
        }

        void RaiseDataSourceChanged(FilterItemBase filterItem)
        {
            if (!_allowDataSourceChanged || filterItem == null) return;

            var handler = DataSourceChanged;
            if (handler != null)
                handler(treeList, new DataSourceChangedEventArgs(filterItem.Name, filterItem.FilterCriteria));
        }

        public string GetFilterName(object filtersCollection, FilterItemBase filter, bool focused)
        {
            if (filter != null)
            {
                int count;
                using (var session = new Session())
                {
                    count = session.GetObjects(session.GetClassInfo<User>(), filter.FilterCriteria, null, 0, false, false).Count;
                }
                if (count > 0)
                    return string.Format("<Color={1}>{0}<Size=-1><Color={3}> [{2}]", filter.Name, ColorHelper.GetHtmlTextColor(focused), count, ColorHelper.HtmlWarningColor);
                return string.Format("<Color={1}>{0}", filter.Name, ColorHelper.GetHtmlTextColor(focused));
            }
            if (Equals(filtersCollection, StaticFilters))
                return ConstStrings.StaticFiltersName;
            if (Equals(filtersCollection, CustomFilters))
                return ConstStrings.CustomFiltersName;
            return null;
        }

    }
}
