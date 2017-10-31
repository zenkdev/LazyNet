using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Dekart.LazyNet
{
    public partial class AddFormBase : XtraForm, IFormWithLayoutManager
    {
        readonly Session _session;
        readonly Form _parent;
        protected LazyNetBaseObject EditObject;

        public AddFormBase()
        {
            InitializeComponent();

            Icon = ImagesHelper.AppIcon;
        }

        /// <summary>ctor</summary>
        public AddFormBase(Form parent, Session session, LazyNetBaseObject editObject, IDXMenuManager manager)
            : this()
        {
            _parent = parent;
            _session = session;
            EditObject = editObject;
            lcMain.MenuManager = manager;
            if (EditObject == null) CreateNewObject();
        }
        public FormLayoutManager LayoutManager
        {
            get
            {
                var frm = _parent as IFormWithLayoutManager;
                if (frm != null)
                    return frm.LayoutManager;
                return null;
            }
        }

        bool AllowEditing
        {
            get
            {
                if (LayoutManager == null)
                    return false;
                return LayoutManager.Properties.CurrentProperty.DefaultEditGridViewInDetailForms;
            }
        }

        public Session Session { get { return _session; } }

        public DXValidationProvider ValidationProvider { get { return dxValidationProvider; } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_parent == null) return;
            InitData();
            InitValidation();
            LoadFormLayout();
            SetDefaultOptions();
            var pt = new Point(_parent.Left + (_parent.Width - Width) / 2, _parent.Top + (_parent.Height - Height) / 2);
            Location = _parent.MdiParent != null ? _parent.PointToScreen(pt) : pt;

            foreach (Control item in lcMain.Controls)
            {
                var edit = item as BaseEdit;
                if (edit != null)
                    edit.MenuManager = lcMain.MenuManager;
            }
        }

        void SetDefaultOptions()
        {
            foreach (Control item in lcMain.Controls)
            {
                var editBar = item as IGridEditBar;
                if (editBar != null)
                {
                    editBar.SetAllowEditing(AllowEditing);
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult != DialogResult.OK)
                CloseCancelForm();
            SaveFormLayout();
        }

        protected virtual void CloseCancelForm()
        {
            if (EditObject != null) Session.RemoveFromLists(EditObject);
        }
        /// <summary>Creates new edit object</summary>
        protected virtual void CreateNewObject() { }
        /// <summary>Initialize data</summary>
        protected virtual void InitData() { }
        /// <summary>Initialize validation</summary>
        protected virtual void InitValidation() { }
        /// <summary>Validates data</summary>
        protected virtual bool ValidateData()
        {
            return ValidationProvider.Validate();
        }
        /// <summary> OnSave </summary>
        protected virtual void OnSave()
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                SaveData();
                Close();
            }
        }
        /// <summary>Saves data</summary>
        protected virtual void SaveData() { }
        protected virtual void LoadFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.RestoreFormLayout(new FormLayoutInfo(this, lcMain));
        }
        protected virtual void SaveFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.SaveFormLayout(new FormLayoutInfo(this, lcMain));
        }

        public void Error(string text)
        {
            XtraMessageBox.Show(this, text, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void SbSaveClick(object sender, EventArgs e)
        {
            OnSave();
        }

        void SbCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
