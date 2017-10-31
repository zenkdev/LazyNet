using System;
using System.Drawing;
using DevExpress.Utils.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet
{
    /// <summary> Grid edit bar control </summary>
    public partial class GridEditBarControl : XtraUserControl, IXtraResizableControl, IGridEditBar
    {
        /// <summary>Add record event</summary>
        public event EventHandler AddRecord;
        /// <summary>Delete record event</summary>
        public event EventHandler DeleteRecord;
        /// <summary>Allow editing changed event</summary>
        public event EventHandler AllowEditingChanged;

        GridView _view;

        /// <summary>Ctor</summary>
        public GridEditBarControl()
        {
            InitializeComponent();
        }
        /// <summary>Init</summary>
        public void Init(GridView view)
        {
            _view = view;
            bciAllowEditing.Checked = view.OptionsBehavior.Editable;
            InitButtons();
            SetGridOptions();
            view.FocusedRowChanged += ViewFocusedRowChanged;
            view.CellValueChanged += (s, e) =>
            {
                if (Changed != null)
                {
                    Changed(this, EventArgs.Empty);
                }
            };
        }
        /// <summary>Gets allow editing</summary>
        public bool AllowEditing { get { return bciAllowEditing.Checked; } }
        void ViewFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            InitButtons();
        }
        void InitButtons()
        {
            bbiAdd.Enabled = bciAllowEditing.Checked;
            bbiDelete.Enabled = bciAllowEditing.Checked && _view.GetRow(_view.FocusedRowHandle) != null;
        }

        void SetGridOptions()
        {
            _view.OptionsBehavior.Editable = bciAllowEditing.Checked;
            _view.OptionsView.ShowIndicator = bciAllowEditing.Checked;
            foreach (GridColumn column in _view.Columns)
            {
                if (!"ReadOnly".Equals(column.Tag))
                    column.OptionsColumn.AllowFocus = bciAllowEditing.Checked;
            }
        }

        void bbiAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (AddRecord != null)
            {
                AddRecord(this, e);
            }
        }

        void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DeleteRecord != null)
            {
                DeleteRecord(this, e);
            }
        }

        void bciAllowEditing_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            InitButtons();
            SetGridOptions();
            
            if (AllowEditingChanged != null)
            {
                AllowEditingChanged(this, e);
            }
        }


        #region IXtraResizableControl Members
        /// <summary>IXtraResizableControl Changed event</summary>
        public event EventHandler Changed;

        /// <summary>IXtraResizableControl IsCaptionVisible property</summary>
        public bool IsCaptionVisible
        {
            get { return false; }
        }
        /// <summary>IXtraResizableControl MaxSize property</summary>
        public Size MaxSize
        {
            get { return new Size(3000, ControlHeight); }
        }
        /// <summary>IXtraResizableControl MinSize property</summary>
        public Size MinSize
        {
            get { return new Size(170, ControlHeight); }
        }
        int ControlHeight
        {
            get
            {
                if (mainBar == null || mainBar.Size.IsEmpty || mainBar.Size.Height == 0)
                    return 25;
                return mainBar.Size.Height;
            }
        }
        #endregion

        #region IGridEditBar Members
        /// <summary>Set allow editing</summary>
        public void SetAllowEditing(bool allow)
        {
            bciAllowEditing.Checked = allow;
        }
        /// <summary>Disable buttons</summary>
        public void DisableButtons()
        {
            bbiAdd.Enabled = bbiDelete.Enabled = bciAllowEditing.Enabled = false;
        }
        #endregion
    }

}
