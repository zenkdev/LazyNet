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

namespace Dekart.LazyNet.Win
{
    public partial class MoveFolderForm : XtraForm
    {
        int _data;
        public MoveFolderForm()
        {
            InitializeComponent();

            Icon = ImagesHelper.AppIcon;
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged += ActiveLookAndFeelStyleChanged;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeelStyleChanged();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && !DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged -= ActiveLookAndFeelStyleChanged;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        void ActiveLookAndFeelStyleChanged(object sender, EventArgs e)
        {
            LookAndFeelStyleChanged();
        }
        void LookAndFeelStyleChanged()
        {
            Color controlColor = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("Control");
            treeList.Appearance.Empty.BackColor = controlColor;
            treeList.Appearance.Row.BackColor = controlColor;
        }
        internal void InitData(int data)
        {
            _data = data;

            treeList.DataSource = DataHelper.GetRoomDataItems();

            treeList.ForceInitialize();
            treeList.FocusedNode = treeList.Nodes.FirstNode;
            treeList.ExpandAll();

            UpdateButtons();
        }
        int GetNodeData(TreeListNode node)
        {
            return (int)node.GetValue(colParent);
        }

        void UpdateButtons()
        {
            sbOk.Enabled = treeList.FocusedNode != null && GetNodeData(treeList.FocusedNode) != _data;
        }

        void SbOkClick(object sender, EventArgs e)
        {
            DataHelper.UpdateRoom(_data, GetNodeData(treeList.FocusedNode));
            DialogResult = DialogResult.OK;
            Close();
        }
        void TreeListFocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            UpdateButtons();
        }

        void TreeListCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (DesignTimeTools.IsDesignMode) return;
            if (e.Column != colName) return;

            var textColor = ColorHelper.GetHtmlTextColor(treeList.FocusedNode.Equals(e.Node));
            var textValue = e.Node.GetValue(colName);
            e.CellText = string.Format("<Color={1}>{0}", textValue, textColor);
        }
    }
}
