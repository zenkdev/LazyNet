using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    /// <summary>Base add form</summary>
    public partial class AddFormBase : XtraForm//, IFormWithLayoutManager
    {
        /// <summary>Edit object</summary>
        protected object EditObject;
        readonly Form _parent;
        /// <summary>ctor</summary>
        public AddFormBase()
        {
            InitializeComponent();
            //ElementLoader.LoadResourcesForAddFormBase(this);
        }
        /// <summary>ctor</summary>
        protected AddFormBase(Form parent, object editObject, IDXMenuManager manager)
            : this()
        {
            _parent = parent;
            EditObject = editObject;
            lcMain.MenuManager = manager;
            if (EditObject == null) CreateNewObject();
        }

        protected virtual bool TestButtonVisible { get { return true; }}
        
        ///// <summary>Layout manager</summary>
        //public FormLayoutManager LayoutManager
        //{
        //    get
        //    {
        //        var layoutManager = _parent as IFormWithLayoutManager;
        //        return layoutManager != null ? layoutManager.LayoutManager : null;
        //    }
        //}
        
        /// <summary>OnLoad override</summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_parent == null) return;
            InitData();
            InitValidation();
            LoadFormLayout();
            Location = new Point(_parent.Left + (_parent.Width - Width) / 2, _parent.Top + (_parent.Height - Height) / 2);
            foreach (Control item in lcMain.Controls)
            {
                var edit = item as BaseEdit;
                if (edit != null)
                    edit.MenuManager = lcMain.MenuManager;
            }
            sbTest.Visible = TestButtonVisible;
        }
        
        /// <summary>OnClosing override</summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult != DialogResult.OK)
                CloseCancelForm();
            SaveFormLayout();
        }
        
        void SbSaveClick(object sender, EventArgs e)
        {
            OnSave();
        }

        void SbTestClick(object sender, EventArgs e)
        {
            ValidateData(false);
        }

        /// <summary>CloseCancelForm</summary>
        protected virtual void CloseCancelForm(){}
        /// <summary>Validation provider</summary>
        public DXValidationProvider ValidationProvider { get { return dxValidationProvider; } }
        /// <summary>Creates new edit object</summary>
        protected virtual void CreateNewObject() { }
        /// <summary>Initialize data</summary>
        protected virtual void InitData() { }
        /// <summary>Initialize validation</summary>
        protected virtual void InitValidation() { }
        /// <summary>Validates data</summary>
        protected virtual bool ValidateData(bool hideOnSuccessMessage)
        {
            return ValidationProvider.Validate();
        }
        /// <summary> OnSave </summary>
        protected virtual void OnSave()
        {
            if (ValidateData(true))
            {
                DialogResult = DialogResult.OK;
                SaveData();
                Close();
            }
        }
        /// <summary>Saves data</summary>
        protected virtual void SaveData() { }
        /// <summary>Load form layout</summary>
        protected virtual void LoadFormLayout()
        {
            //if (LayoutManager == null) return;
            //LayoutManager.RestoreFormLayout(new FormLayoutInfo(this, lcMain));
        }
        /// <summary>Saves form layout</summary>
        protected virtual void SaveFormLayout()
        {
            //if (LayoutManager == null) return;
            //LayoutManager.SaveFormLayout(new FormLayoutInfo(this, lcMain));
        }

    }
}
