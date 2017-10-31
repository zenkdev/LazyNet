using System;
using System.ComponentModel;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet
{
    public class MainFormBase : RibbonForm, IFormWithLayoutManager
    {
        DetailBase _activeDetail;
        readonly DetailsCollection _detailsCollection;

        public MainFormBase()
        {
            _detailsCollection = new DetailsCollection(this);
        }

        public virtual FormLayoutManager LayoutManager { get { return null; } }
        public virtual IDXMenuManager MenuManager { get { return null; } }
        public virtual BackstageViewButtonItem SaveAsMenuItem { get { return null; } }
        public virtual BarSubItem PreviewMenuItem { get { return null; } }
        public virtual BarButtonItem ClearFilterItem { get { return null; } }
        public virtual BarButtonItem CloseAllButton { get { return null; } }
        public DetailsCollection Details { get { return _detailsCollection; } }

        public virtual void UpdateTreeView() { }
        public virtual void SetDateFilterMenu(PopupMenu menu) { }
        public virtual void ShowInfo(int? count) { }
        public virtual void EnableEdit(bool enabled, bool enableActions = true) { }
        public virtual void UpdateCurrentView(bool isGrid) { }
        public virtual void InitFilterColumns(GridView gridView) { }
        public virtual void ResetFilterColumns() { }

        public bool IsDetailExist(Guid id)
        {
            return Details.IsDetailExist(id);
        }
        
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DetailBase ActiveDetail
        {
            get { return _activeDetail; }
            set
            {
                if (_activeDetail == value)
                {
                    if (_activeDetail != null) _activeDetail.Select();
                    return;
                }
                _activeDetail = value;
                if (ActiveDetail == null || _activeDetail.IsDisposed)
                {
                    Select();
                }
                else
                {
                    _activeDetail.Select();
                }
            }
        }
        public void ShowDetail(DetailBase detail)
        {
            detail.Show();
            Details.Add(detail);
        }
        public void CloseActiveDetailForm()
        {
            Details.Remove(ActiveDetail);
        }
        public void CalcCloseAllDetails()
        {
            CloseAllButton.Enabled = Details.Count > 0;
        }
        public void CloseAllDetails()
        {
            var isDirtyDetailExist = Details.IsDirtyDetailExist();
            Details.RemoveAll(isDirtyDetailExist && XtraMessageBox.Show(this, ConstStrings.CloseCancelFormsWarning, ConstStrings.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

    }
}
