using System;
using System.ComponentModel;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using Dekart.LazyNet.Win.Modules;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Dekart.LazyNet.Win.UserControls
{
    public partial class RepairsControl : UserControl, IEditsContainer, IGridEditBar
    {
        bool _readOnly;
        bool _visible = true;
        bool _allow = true;
        Device _device;
        GetSessionCallback _session;

        public RepairsControl()
        {
            InitializeComponent();
            gebRepairs.Visible = true;
            gebRepairs.Init(gvMain);
            riRepairType.Items.AddLocalizedEnum<RepairTypeEnum>();
        }

        public event EventHandler EditValueChanged;

        public event EventHandler RowCountChanged;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public int DataRowCount { get { return gvMain.DataRowCount; } }

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
                gebRepairs.Visible = _visible;
            }
        }

        public void InitData(Device device, GetSessionCallback session, IDXMenuManager menuManager)
        {
            _device = device;
            _session = session;

            gcMain.MenuManager = menuManager;
            gcMain.DataSource = _device != null ? _device.Repairs : null;
        }

        Repair CurrentRepair { get { return gvMain.GetRow(gvMain.FocusedRowHandle) as Repair; } }

        void gebRepairs_AddRecord(object sender, EventArgs e)
        {
            using (var form = new AddRepair(ParentForm, _session(), null, gcMain.MenuManager))
            {
                if (form.ShowDialog() == DialogResult.Cancel) return;
                _device.Repairs.Add(form.Repair);
                GridHelper.GridViewFocusObject(gvMain, form.Repair);

                if (EditValueChanged != null)
                {
                    EditValueChanged(this, EventArgs.Empty);
                }
            }
        }

        void gebRepairs_DeleteRecord(object sender, EventArgs e)
        {
            if (CurrentRepair == null) return;

            gvMain.HideEditor();
            gvMain.UpdateCurrentRow();
            _device.Repairs.Remove(CurrentRepair);

            if (EditValueChanged != null)
            {
                EditValueChanged(this, EventArgs.Empty);
            }
        }

        void gvMain_RowCountChanged(object sender, EventArgs e)
        {
            if (RowCountChanged != null)
            {
                RowCountChanged(this, EventArgs.Empty);
            }
        }

        void gvMain_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (EditValueChanged != null)
            {
                EditValueChanged(this, EventArgs.Empty);
            }
        }

        void gvMain_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
            {
                if (CurrentRepair == null || !gvMain.Editable) return;
                using (var form = new AddRepair(ParentForm, _session(), CurrentRepair, gcMain.MenuManager))
                {
                    if (form.ShowDialog() == DialogResult.Cancel) return;

                    if (EditValueChanged != null)
                    {
                        EditValueChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void SetAllowEditing(bool allow)
        {
            _allow = allow; // store for future use
            gebRepairs.SetAllowEditing(!_readOnly && allow);
        }

        public void DisableButtons()
        {
            gebRepairs.DisableButtons();
        }

    }
}
