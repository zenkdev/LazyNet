using System;
using System.ComponentModel;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet.Win.UserControls
{
    public partial class MovementsControl : UserControl, IEditsContainer, IGridEditBar
    {
        bool _readOnly;
        bool _visible = true;
        bool _allow = true;
        Device _device;
        GetSessionCallback _session;

        public MovementsControl()
        {
            InitializeComponent();
            gridEditBar.Visible = true;
            gridEditBar.Init(gvList);
        }

        public event EventHandler EditValueChanged;

        public event EventHandler RowCountChanged;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int DataRowCount { get { return gvList.DataRowCount; } }

        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                if (_readOnly == value) return;
                _readOnly = value;
                SetAllowEditing(_allow);
                if (_readOnly) DisableButtons();
            }
        }
        [DefaultValue(true)]
        public bool GridEditBarVisible
        {
            get { return _visible; }
            set
            {
                if (_visible == value) return;
                _visible = value;
                gridEditBar.Visible = _visible;
            }
        }

        public void InitData(Device device, GetSessionCallback session, IDXMenuManager menuManager)
        {
            _device = device;
            _session = session;

            gcMain.MenuManager = menuManager;
            gcMain.DataSource = _device != null ? _device.Movements : null;
        }

        Movement CurrentMovement { get { return gvList.GetRow(gvList.FocusedRowHandle) as Movement; } }

        void gridEditBar_AddRecord(object sender, EventArgs e)
        {
            using (var form = new AddMovement(ParentForm, _session(), null, gcMain.MenuManager))
            {
                if (form.ShowDialog() == DialogResult.Cancel) return;
                _device.Movements.Add(form.Movement);
                GridHelper.GridViewFocusObject(gvList, form.Movement);

                if (EditValueChanged != null)
                {
                    EditValueChanged(this, EventArgs.Empty);
                }
            }
        }

        void gridEditBar_DeleteRecord(object sender, EventArgs e)
        {
            if (CurrentMovement == null) return;

            gvList.HideEditor();
            gvList.UpdateCurrentRow();
            _device.Movements.Remove(CurrentMovement);

            if (EditValueChanged != null)
            {
                EditValueChanged(this, EventArgs.Empty);
            }
        }

        void gvList_RowCountChanged(object sender, EventArgs e)
        {
            if (RowCountChanged != null)
            {
                RowCountChanged(this, EventArgs.Empty);
            }
        }

        void gvList_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (EditValueChanged != null)
            {
                EditValueChanged(this, EventArgs.Empty);
            }
        }

        void gvList_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
            {
                if (CurrentMovement != null && gvList.Editable)
                {
                    using (var form = new AddMovement(ParentForm, _session(), CurrentMovement, gcMain.MenuManager))
                    {
                        if (form.ShowDialog() == DialogResult.Cancel) return;

                        if (EditValueChanged != null)
                        {
                            EditValueChanged(this, EventArgs.Empty);
                        }
                    }
                }
            }
        }

        public void SetAllowEditing(bool allow)
        {
            _allow = allow; // store for future use
            gridEditBar.SetAllowEditing(!_readOnly && allow);
        }

        public void DisableButtons()
        {
            gridEditBar.DisableButtons();
        }

    }
}
