using System.Drawing;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace Dekart.LazyNet.Win
{
    class MyGridView : GridView
    {
        protected override bool IsAllowPixelScrollingPreview
        {
            get { return true; }
        }
    }
    class MyTreeList : TreeList
    {
        TreeListViewState _viewState;

        public TreeListViewState ViewState
        {
            get { return _viewState ?? (_viewState = new TreeListViewState(this)); }
        }
        DevExpress.XtraTreeList.Handler.StateData StateData
        {
            get
            {
                return Handler.StateData;
            }
        }

        public TreeListNode DropTaget
        {
            get
            {
                if (StateData != null && StateData.DragInfo != null && StateData.DragInfo.RowInfo != null) return StateData.DragInfo.RowInfo.Node;
                return null;
            }
        }

        public bool CopyCellValue()
        {
            var column = FocusedColumn;
            var node = FocusedNode;
            if (column == null || node == null) return false;

            var useDisplayText = column.ColumnEdit != null && column.ColumnEdit.ExportMode == DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            var value = useDisplayText ? node.GetDisplayText(column) : node.GetValue(column);
            if (value == null) return false;

            try { Clipboard.SetText(value.ToString(), TextDataFormat.UnicodeText); }
            catch { return false; }
            return true;
        }
    }
    class TaskPreviewGridView : GridView
    {
        float _rowFontSize = AppearanceObject.DefaultFont.Size;
        public TaskPreviewGridView()
        {
            Appearance.Row.Font = new Font("Segoe UI", _rowFontSize + 4);
            OptionsSelection.EnableAppearanceHideSelection = false;
            OptionsView.AutoCalcPreviewLineCount = true;
            OptionsView.EnableAppearanceEvenRow = true;
            OptionsView.ShowGroupPanel = false;
            OptionsView.ShowHorizontalLines = DefaultBoolean.False;
            OptionsView.ShowIndicator = false;
            OptionsView.ShowPreview = true;
            OptionsView.ShowVerticalLines = DefaultBoolean.False;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            PreviewIndent = 0;
            RowCellStyle += (s, e) =>
            {
                e.Appearance.Font = new Font(e.Appearance.Font.FontFamily, _rowFontSize, e.Appearance.Font.Style);
                if (e.RowHandle == FocusedRowHandle && GridControl.Focused)
                    e.Appearance.BackColor = PaintAppearance.FocusedRow.BackColor;
                else SetEvenRowAppearance(e.Appearance, e.RowHandle);
            };
            CustomDrawRowPreview += (s, e) =>
            {
                if (e.RowHandle == FocusedRowHandle && GridControl.Focused)
                {
                    e.Appearance.BackColor = PaintAppearance.FocusedRow.BackColor;
                    e.Appearance.ForeColor = PaintAppearance.FocusedRow.ForeColor;
                }
                else SetEvenRowAppearance(e.Appearance, e.RowHandle);
            };
        }
        void SetEvenRowAppearance(AppearanceObject appearance, int rowHandle)
        {
            appearance.BackColor = rowHandle % 2 == 0 ? PaintAppearance.EvenRow.BackColor : PaintAppearance.Row.BackColor;
        }

        public void SetViewFontSize(float rowFontSize, float previewFontSize)
        {
            if (previewFontSize > 0)
                Appearance.Preview.Font = new Font(AppearanceObject.DefaultFont.FontFamily, AppearanceObject.DefaultFont.Size + previewFontSize);
            if (rowFontSize > 0)
            {
                _rowFontSize += rowFontSize;
                Appearance.Row.Font = new Font("Segoe UI", _rowFontSize + 4);
            }
        }
        protected override bool IsAllowPixelScrollingPreview
        {
            get { return true; }
        }
    }
    class DateFilterMenu : PopupMenu
    {
        readonly GridView _view;
        readonly FilterCriteriaManager _filterManager;
        public DateFilterMenu(BarManager manager, GridView view, FilterCriteriaManager filterManager)
            : base(manager)
        {
            _view = view;
            _filterManager = filterManager;
            CreateBarItem(ConstStrings.IsToday, "IsOutlookIntervalToday([BuyedOn])");
            CreateBarItem(ConstStrings.IsYesterday, "IsOutlookIntervalYesterday([BuyedOn])");
            CreateBarItem(ConstStrings.IsEarlierThisWeek, "IsOutlookIntervalEarlierThisWeek([BuyedOn])");
            CreateBarItem(ConstStrings.IsLastWeek, "IsOutlookIntervalLastWeek([BuyedOn])");
            CreateBarItem(ConstStrings.IsEarlierThisMonth, "IsOutlookIntervalEarlierThisMonth([BuyedOn])");
            CreateBarItem(ConstStrings.IsEarlierThisYear, "IsOutlookIntervalEarlierThisYear([BuyedOn])");
        }
        void CreateBarItem(string caption, string filterString)
        {
            var item = new BarButtonItem(Manager, caption) { Tag = filterString, CloseSubMenuOnClick = false };
            ItemLinks.Add(item);
            _filterManager.AddBarItem(item, _view.Columns["CreatedOn"], filterString);
        }
    }

}
