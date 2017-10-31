using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace Dekart.LazyNet.Helpers
{
    public static class GridHelper
    {
        public static void SetFindControlImages(GridControl grid) { SetFindControlImages(grid, true); }
        public static void SetFindControlImages(GridControl grid, bool forceAlignment)
        {
            FindControl fControl = null;
            foreach (Control ctrl in grid.Controls)
            {
                fControl = ctrl as FindControl;
                if (fControl != null) break;
            }
            if (fControl != null)
            {
                var btn = fControl.FindEdit.Properties.Buttons[0];
                btn.Kind = ButtonPredefines.Search;
                btn = new EditorButton(ButtonPredefines.Close) { Visible = false };
                fControl.FindEdit.Properties.Buttons.Add(btn);
                fControl.FindEdit.ButtonClick += (s, e) =>
                {
                    if (!e.Button.IsDefaultButton)
                    {
                        ButtonEdit edit = (ButtonEdit)s;
                        edit.Text = string.Empty;
                    }
                };
                fControl.FindEdit.EditValueChanged += (s, e) =>
                {
                    MRUEdit edit = (MRUEdit)s;
                    edit.Properties.BeginUpdate();
                    try
                    {
                        edit.Properties.Buttons[0].Visible = string.IsNullOrEmpty(edit.Text);
                        edit.Properties.Buttons[1].Visible = !string.IsNullOrEmpty(edit.Text);
                    }
                    finally
                    {
                        edit.Properties.EndUpdate();
                    }
                };
                if (forceAlignment)
                {
                    LayoutControl lc = (LayoutControl)fControl.FindEdit.Parent;
                    lc.BeginUpdate();
                    try
                    {
                        for (int i = lc.Root.Items.Count - 1; i >= 0; i--)
                        {
                            var item = lc.Root.Items[i] as LayoutControlItem;
                            if (item == null) continue;
                            if (item.Visibility == LayoutVisibility.Never)
                                lc.Root.Remove(item);
                            else item.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
                        }
                    }
                    finally
                    {
                        lc.EndUpdate();
                    }
                }
            }
        }
        public static void GridViewFocusObject(ColumnView cView, LazyNetBaseObject obj)
        {
            if (cView == null || obj == null) return;

            // try server mode
            cView.GridControl.ForceInitialize();
            var iListServer = cView.DataController.ListSource as IListServer;
            if (iListServer != null)
            {
                var rowHandle = cView.GetRowHandle(iListServer.GetRowIndexByKey(obj.Id));
                if (rowHandle == GridControl.InvalidRowHandle)
                {
                    if (cView.RowCount <= 0) return;
                    rowHandle = 0;
                }
                cView.FocusedRowHandle = rowHandle;
                var gridView = cView as GridView;
                if (gridView != null) gridView.MakeRowVisible(rowHandle, true);
            }
            else
            {
                var dataController = cView.DataController as AsyncServerModeDataController;
                if (dataController != null)
                {
                    cView.LocateByValue(
                        obj.ClassInfo.KeyProperty.Name,
                        obj.Id,
                        delegate(object arguments)
                        {
                            var rowHandle = DataHelper.ToInt32(arguments);
                            if (rowHandle == GridControl.InvalidRowHandle)
                            {
                                if (cView.RowCount <= 0) return;
                                rowHandle = 0;
                            }
                            cView.FocusedRowHandle = rowHandle;
                            var gridView = cView as GridView;
                            if (gridView != null) gridView.MakeRowVisible(rowHandle, true);
                        }
                        );
                }
                else
                {
                    var oldFocusedRowHandle = cView.FocusedRowHandle;
                    for (var i = 0; i < cView.DataRowCount; ++i)
                    {
                        var rowObj = cView.GetRow(i) as LazyNetBaseObject;
                        if (rowObj == null) continue;
                        if (obj.Oid != rowObj.Oid) continue;
                        if (i == oldFocusedRowHandle)
                            cView.FocusedRowHandle = GridControl.InvalidRowHandle;
                        cView.FocusedRowHandle = i;
                        break;
                    }
                }
            }

        }
        public static bool GridViewCopyCell(ColumnView view)
        {
            var column = view.FocusedColumn;
            if (column == null) return false;
            var b = column.ColumnEdit != null && column.ColumnEdit.ExportMode == ExportMode.DisplayText;

            var value = b ? view.GetFocusedDisplayText() : view.GetFocusedValue();
            if (value == null)
                return false;

            try { Clipboard.SetText(value.ToString(), TextDataFormat.UnicodeText); }
            catch { return false; }
            return true;
        }
    }
}
