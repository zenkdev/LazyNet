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

namespace Dekart.LazyNet.Win.Controls
{
    public partial class MapsControl : ControlBase
    {
        bool _initialized;
        bool _allowDataSourceChanged;
        public event DataSourceChangedEventHandler DataSourceChanged;
        public event MouseEventHandler ShowMenu;

        public MapsControl()
        {
            InitializeComponent();

            treeList.SelectImageList = ImagesHelper.DeviceImages;
        }
        protected override void LookAndFeelStyleChanged()
        {
            base.LookAndFeelStyleChanged();
            Color controlColor = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("Control");
            treeList.Appearance.Empty.BackColor = controlColor;
            treeList.Appearance.Row.BackColor = controlColor;
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            ParentFormMain = FindForm() as MainForm;
        }

        internal bool EnableDelete
        {
            get
            {
                return treeList.FocusedNode != null && treeList.FocusedNode.Nodes.Count == 0 && (int)treeList.FocusedNode.GetValue(colData) == 0;
            }
        }

        internal void CreateMap()
        {
            if (treeList.FocusedNode == null) return;

            var map = DataHelper.CreateNewMap();
            var node = treeList.Nodes.Add();
            node.SetValue(colParent, map.Id);
            node.SetValue(colName, map.Name);

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
        internal void DeleteMap()
        {
            if (!EnableDelete) return;

            if (XtraMessageBox.Show(this,
                string.Format(ConstStrings.DeleteQuestion, treeList.FocusedNode.GetValue(colName)),
                ConstStrings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataHelper.DeleteMap(GetNodeData(treeList.FocusedNode));
                UpdateTreeView();
            }
        }

        internal void IncrementData()
        {
            if (treeList.FocusedNode != null)
            {
                var count = (int)treeList.FocusedNode.GetValue(colData);
                treeList.FocusedNode.SetValue(colData, ++count);
                RefreshTreeList();
            }
        }

        internal void DecrementData()
        {
            if (treeList.FocusedNode != null)
            {
                var count = (int)treeList.FocusedNode.GetValue(colData);
                treeList.FocusedNode.SetValue(colData, --count);
                RefreshTreeList();
            }
        }

        void TreeListFocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            RaiseDataSourceChanged(e.Node);
        }

        void RaiseDataSourceChanged(TreeListNode node)
        {
            if (DataSourceChanged != null && _allowDataSourceChanged && node != null)
                DataSourceChanged(treeList, new DataSourceChangedEventArgs(GetNodeCaption(node), GetNodeData(node), (int?)node.GetValue(colData)));
        }
        void InitData()
        {
            treeList.DataSource = DataHelper.GetMapDataItems();
            treeList.ExpandAll();

            treeList.ForceInitialize();
            treeList.BestFitColumns();

            treeList.FocusedNode = treeList.Nodes.FirstNode;

            _initialized = true;
        }
        string GetNodeCaption(TreeListNode node)
        {
            return string.Format("{0}", node.GetValue(colName));
        }
        int GetNodeData(TreeListNode node)
        {
            return (int)node.GetValue(colParent);
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

                var count = (int) e.Node.GetValue(colData);
                if (ShowObjectCount && count > 0)
                    e.CellText = string.Format("<Color={3}>{0}<Size=-1><Color={2}> [{1}]", textValue, count, ColorHelper.HtmlWarningColor, textColor);
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

            DataHelper.UpdateMap(GetNodeData(treeList.FocusedNode), GetNodeCaption(treeList.FocusedNode));
        }

        internal void RefreshTreeList()
        {
            treeList.LayoutChanged();
        }

        void TreeListMouseDown(object sender, MouseEventArgs e)
        {
            var tree = sender as MyTreeList;
            if (tree == null) return;

            var hitInfo = tree.CalcHitInfo(e.Location);

            if (e.Button == MouseButtons.Right && hitInfo.HitInfoType == HitInfoType.Cell)
                hitInfo.Node.Selected = !hitInfo.Node.Selected;

            if (e.Button == MouseButtons.Right && ShowMenu != null) ShowMenu(sender, e);
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

        internal void MapImage()
        {
            if (ofdMapImage.ShowDialog(this) == DialogResult.OK)
            {
                DataHelper.UpdateMap(GetNodeData(treeList.FocusedNode), GetNodeCaption(treeList.FocusedNode), ofdMapImage.FileName);
                UpdateTreeView();
            }
        }
    }
}
