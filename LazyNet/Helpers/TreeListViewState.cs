using System;
using System.Collections;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace Dekart.LazyNet.Helpers
{
    /// <summary>
    /// Вспомогательный класс для сохранения / восстановления состояния дерева.
    /// </summary>
    public sealed class TreeListViewState
    {
        private TreeList _treeList;
        private ArrayList _expanded;
        private ArrayList _checked;
        private ArrayList _selected;
        private object _focused;
        private int _topIndex;

        /// <summary>
        /// Создает новый нелпер с параметрами по умолчанию.
        /// </summary>
        public TreeListViewState() : this(null) { }
        /// <summary>
        /// Создает новый нелпер с заданными параметрами.
        /// </summary>
        /// <param name="treeList">Дерево прикрепленное к хелперу.</param>
        public TreeListViewState(TreeList treeList)
        {
            _treeList = treeList;
            _expanded = new ArrayList();
            _checked = new ArrayList();
            _selected = new ArrayList();
        }
        /// <summary>
        /// Сбрасывает состояние хелпера.
        /// </summary>
        public void Clear()
        {
            _expanded.Clear();
            _checked.Clear();
            _selected.Clear();
            _focused = null;
            _topIndex = 0;
        }

        private ArrayList GetExpanded()
        {
            var op = new OperationSaveExpanded();
            TreeList.NodesIterator.DoOperation(op);
            return op.Nodes;
        }

        private ArrayList GetSelected()
        {
            var al = new ArrayList();
            foreach (TreeListNode node in TreeList.Selection)
                al.Add(node.GetValue(TreeList.KeyFieldName));
            return al;
        }

        /// <summary>
        /// Текущее дерево прикрепленное к хелперу.
        /// </summary>
        public TreeList TreeList
        {
            get
            {
                return _treeList;
            }
            set
            {
                _treeList = value;
                Clear();
            }
        }

        /// <summary>
        /// Восстанавливает состояние дерева.
        /// </summary>
        public void LoadState()
        {
            TreeList.BeginUpdate();
            try
            {
                TreeList.CollapseAll();
                TreeList.NodesIterator.DoOperation(new OperationClearChecked());
                TreeListNode node;
                foreach (var key in _expanded)
                {
                    node = TreeList.FindNodeByKeyID(key);
                    if (node != null)
                        node.Expanded = true;
                }
                foreach (var key in _checked)
                {
                    node = TreeList.FindNodeByKeyID(key);
                    if (node != null)
                        node.Checked = true;
                }
                foreach (var key in _selected)
                {
                    node = TreeList.FindNodeByKeyID(key);
                    if (node != null)
                        TreeList.Selection.Add(node);
                }
                TreeList.FocusedNode = TreeList.FindNodeByKeyID(_focused);
            }
            finally
            {
                TreeList.EndUpdate();
                TreeList.TopVisibleNodeIndex = TreeList.GetVisibleIndexByNode(TreeList.FocusedNode) - _topIndex;
            }
        }

        /// <summary>
        /// Сохраняет состояние дерева.
        /// </summary>
        public void SaveState()
        {
            if (TreeList.FocusedNode == null)
            {
                Clear();
                return;
            }

            try
            {
                _expanded = GetExpanded();
                _checked = GetChecked();
                _selected = GetSelected();
                _focused = TreeList.FocusedNode[TreeList.KeyFieldName];
                _topIndex = TreeList.GetVisibleIndexByNode(TreeList.FocusedNode) - TreeList.TopVisibleNodeIndex;
            }
            catch (NullReferenceException)
            {
                Clear();
            }
        }

        /// <summary>
        /// Вызвращает список значений ключевого поля для отмеченных узлов.
        /// </summary>
        public ArrayList GetChecked()
        {
            var op = new OperationSaveChecked();
            TreeList.NodesIterator.DoOperation(op);
            return op.Nodes;
        }

        class OperationSaveExpanded : TreeListOperation
        {
            private readonly ArrayList _al = new ArrayList();

            public override void Execute(TreeListNode node)
            {
                if (node.HasChildren && node.Expanded)
                    _al.Add(node.GetValue(node.TreeList.KeyFieldName));
            }

            public ArrayList Nodes { get { return _al; } }
        }

        class OperationSaveChecked : TreeListOperation
        {
            private readonly ArrayList _al = new ArrayList();

            public override void Execute(TreeListNode node)
            {
                if (node.Checked)
                    _al.Add(node.GetValue(node.TreeList.KeyFieldName));
            }

            public ArrayList Nodes { get { return _al; } }
        }

        class OperationClearChecked : TreeListOperation
        {
            public override void Execute(TreeListNode node)
            {
                if (node.Checked)
                    node.Checked = false;
            }
        }
    }
}
