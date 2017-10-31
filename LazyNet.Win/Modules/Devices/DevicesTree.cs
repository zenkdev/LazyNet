using System;
using System.Drawing;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class DevicesTree : ControlBase
    {
        bool _initialized;
        bool _allowDataSourceChanged;
        public event DataSourceChangedEventHandler DataSourceChanged;
        public event MouseEventHandler ShowMenu;

        public DevicesTree()
        {
            InitializeComponent();
            treeList.RowHeight = Math.Max(Convert.ToInt32(treeList.Font.GetHeight()), imageCollection1.ImageSize.Height) + 5;
        }
        protected override void LookAndFeelStyleChanged()
        {
            base.LookAndFeelStyleChanged();
            Color controlColor = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("Control");
            treeList.Appearance.Empty.BackColor = controlColor;
            treeList.Appearance.Row.BackColor = controlColor;
        }
        internal bool EnableEdit
        {
            get { return treeList.FocusedNode != null && treeList.FocusedNode != treeList.Nodes.FirstNode; }
        }
        internal bool EnableDelete
        {
            get
            {
                return EnableEdit && treeList.FocusedNode.Nodes.Count == 0 && GetNodeData(treeList.FocusedNode) == 0;
            }
        }

        internal void CreateFolder()
        {
            if (treeList.FocusedNode == null) return;

            var room = DataHelper.CreateNewRoom(GetNodeParent(treeList.FocusedNode));
            var node = treeList.FocusedNode.Nodes.Add();
            node.SetValue(colParent, room.Id);
            node.SetValue(colName, room.Name);

            treeList.FocusedNode = node;
            StartEditing();
        }
        internal void StartEditing()
        {
            if (treeList.FocusedNode == null) return;

            treeList.OptionsBehavior.Editable = true;
            treeList.VisibleColumns[0].OptionsColumn.AllowFocus = true;
            treeList.FocusedColumn = treeList.VisibleColumns[0];
            treeList.ShowEditor();
        }
        internal void MoveFolder()
        {
            if (treeList.FocusedNode == null || treeList.FocusedNode.ParentNode == null)
                return;

            using (var frm = new MoveFolderForm())
            {
                frm.InitData(GetNodeParent(treeList.FocusedNode));
                if (frm.ShowDialog(FindForm()) == DialogResult.OK)
                    UpdateTreeView();
            }
        }
        internal void DeleteFolder()
        {
            if (!EnableDelete) return;

            if (XtraMessageBox.Show(this,
                string.Format(ConstStrings.DeleteQuestion, treeList.FocusedNode.GetValue(colName)),
                ConstStrings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataHelper.DeleteRoom(GetNodeParent(treeList.FocusedNode));
                UpdateTreeView();
            }
        }
        internal void RefreshTreeList()
        {
            treeList.LayoutChanged();
        }
        internal void UpdateTreeView()
        {
            _allowDataSourceChanged = false;

            var b = _initialized;
            if (b) treeList.ViewState.SaveState();
            InitData();
            RefreshTreeList();
            if (b) treeList.ViewState.LoadState();

            _allowDataSourceChanged = true;
            RaiseDataSourceChanged(treeList.FocusedNode);
        }
        void TreeListFocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            RaiseDataSourceChanged(e.Node);
        }
        void RaiseDataSourceChanged(TreeListNode node)
        {
            if (DataSourceChanged != null && _allowDataSourceChanged && node != null)
                DataSourceChanged(treeList, new DataSourceChangedEventArgs(GetNodeCaption(node), GetNodeParent(node), (int?)node.GetValue(colData)));
        }
        void InitData()
        {
            treeList.DataSource = DataHelper.GetRoomDataItems();

            treeList.ForceInitialize();
            treeList.FocusedNode = treeList.Nodes.FirstNode;
            treeList.ExpandAll();

            _initialized = true;
        }
        string GetNodeCaption(TreeListNode node, bool recursively = true)
        {
            var ret = string.Format("{0}", node.GetValue(colName));
            while (recursively && node.ParentNode != null)
            {
                node = node.ParentNode;
                ret = string.Format("{0} - {1}", node.GetValue(colName), ret);
            }
            return ret;
        }
        int GetNodeData(TreeListNode node)
        {
            return (int)node.GetValue(colData);
        }
        int GetNodeParent(TreeListNode node)
        {
            return (int) node.GetValue(colParent);
        }
        bool ShowObjectCount
        {
            get
            {
                if (LayoutManager == null)
                    return false;
                return LayoutManager.Properties.ShowObjectCount;
            }
        }

        void TreeListCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (DesignTimeTools.IsDesignMode) return;
            if (e.Column == colName)
            {
                var textColor = ColorHelper.GetHtmlTextColor(treeList.FocusedNode.Equals(e.Node));
                var textValue = e.Node.GetValue(colName);
                e.CellText = string.Format("<Color={1}>{0}", textValue, textColor);
                var count = GetNodeData(e.Node);
                if (ShowObjectCount && count > 0)
                    e.CellText = string.Format("<Color={1}>{0}<Size=-1><Color={3}> [{2}]", textValue, textColor, count, ColorHelper.HtmlWarningColor);
            }
        }
        void TreeListCustomNodeCellEditForEditing(object sender, GetCustomNodeCellEditEventArgs e)
        {
            e.RepositoryItem = repositoryItemTextEdit1;
        }
        void TreeListHiddenEditor(object sender, EventArgs e)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.VisibleColumns[0].OptionsColumn.AllowFocus = false;
            treeList.ClearFocusedColumn();

            DataHelper.UpdateRoom(GetNodeParent(treeList.FocusedNode), GetNodeCaption(treeList.FocusedNode, false));
        }

        #region Drag and drop

        public event UcTreeDragDropEventHandler UcTreeDragDrop;

        void TreeListMouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = treeList.CalcHitInfo(e.Location);

            if (e.Button == MouseButtons.Right && hitInfo.HitInfoType == HitInfoType.Cell)
                hitInfo.Node.Selected = !hitInfo.Node.Selected;

            if (e.Button == MouseButtons.Right && ShowMenu != null)
            {
                ShowMenu(sender, e);
            }
        }

        void TreeListDragEnter(object sender, DragEventArgs e)
        {
            var dragSelection = e.Data.GetData(typeof(DragSelection)) as DragSelection;
            if (dragSelection == null) return;
            e.Effect = DragDropEffects.Move;
        }

        void TreeListDragDrop(object sender, DragEventArgs e)
        {
            var dragSelection = e.Data.GetData(typeof(DragSelection)) as DragSelection;
            if (dragSelection == null) return;
            if (treeList.DropTaget != null) OnTreeDragDrop(treeList.DropTaget, dragSelection);
        }

        void OnTreeDragDrop(TreeListNode node, DragSelection selection)
        {
            if (UcTreeDragDrop != null)
            {
                UcTreeDragDrop(this, new UcTreeDragDropEventArgs(node, selection, GetNodeParent(node)));
            }
        }

        #endregion

    }
}
