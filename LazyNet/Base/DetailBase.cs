using System;
using System.ComponentModel;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Design;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

namespace Dekart.LazyNet
{
    public partial class DetailBase : RibbonForm, IFormWithLayoutManager
    {
        readonly Form _parent;
        readonly CloseDetailForm _closeForm;

        bool _dirty;
        bool _createNewObject;
        UnitOfWork _session;
        LazyNetBaseObject _editObject;
        Guid _id = Guid.Empty;

        DialogResult _returnResult = DialogResult.Cancel;
        bool _showCloseDialog = true;

        GetSessionCallback _externalSession;
        UnitOfWork _oldSession;

        protected UnitOfWork GetSession() { return _session; }

        public virtual FormLayoutManager LayoutManager
        {
            get
            {
                var frm = _parent as IFormWithLayoutManager;
                if (frm != null)
                    return frm.LayoutManager;
                return null;
            }
        }
        public MainFormBase ParentFormMain
        {
            get { return _parent as MainFormBase; }
        }
        /// <summary>Validation provider</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DXValidationProvider ValidationProvider { get { return dxValidationProvider; } }

        /// <summary> Ctor </summary>
        protected DetailBase()
        {
            InitializeComponent();

            Icon = ImagesHelper.AppIcon;
            InitButtons();
        }

        /// <summary>ctor</summary>
        protected DetailBase(Form parent, GetSessionCallback session, LazyNetBaseObject editObject, CloseDetailForm closeForm)
            : this()
        {
            _parent = parent;
            _editObject = editObject;
            _externalSession = session;
            _closeForm = closeForm;
            if (editObject != null) _id = editObject.Oid;
        }

        /// <summary>Id</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid Id { get { return _id; } }
        /// <summary>Get the current session</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected UnitOfWork Session { get { return _session; } }
        /// <summary>Gets the edit object</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected LazyNetBaseObject EditObject { get { return _editObject; } }
        /// <summary>Gets the edit object name</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string EditObjectName { get { return _editObject == null ? string.Empty : _editObject.ObjectName; } }

        /// <summary>ProcessCmdKey override</summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>OnLoad override</summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignTimeTools.IsDesignMode) return;
            LoadFormLayout();
            SetEditObject(_externalSession, EditObject);
            InitValidation();
            SetDefaultOptions();
            foreach (Control item in lcMain.Controls)
                AddControl(item);
        }

        /// <summary>OnFormClosing override</summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_showCloseDialog)
            {
                _showCloseDialog = e.CloseReason != CloseReason.ApplicationExitCall &&
                                   e.CloseReason != CloseReason.TaskManagerClosing &&
                                   e.CloseReason != CloseReason.WindowsShutDown;
            }
            CloseForm();
            e.Cancel = _returnResult != DialogResult.OK;
        }

        /// <summary>HasObjectToSave</summary>
        protected virtual bool HasObjectToSave
        {
            get { return Session.GetObjectsToSave().Count > (_createNewObject ? 1 : 0); }
        }

        /// <summary>Dirty</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Dirty
        {
            get
            {
                return _dirty || (Session != null && (HasObjectToSave || Session.GetObjectsToDelete().Count > 0));
            }
            set
            {
                _dirty = value;
                UpdateDetailCaption();
            }
        }

        /// <summary>Sets edit object</summary>
        void SetEditObject(GetSessionCallback session, LazyNetBaseObject editObject)
        {
            _externalSession = session;
            _session = session == null ? null : new UnitOfWork {ConnectionString = session().ConnectionString};
            if (session == null && editObject == null) return;
            try
            {
                _editObject = editObject != null ? SessionHelper.GetObject(editObject, Session) : CreateNewObject();
            }
            catch (ObjectDisposedException)
            {
                _editObject = null;
            }
            if (_editObject == null)
            {
                _showCloseDialog = false;
                CloseForm();
                return;
            }
            InitData();
            if (_editObject != null) _id = _editObject.Oid;
            UpdateDetailCaption();
        }

        /// <summary>Saves detail and closes form</summary>
        public bool SaveAndClose()
        {
            if (Save())
            {
                _showCloseDialog = false;
                Close();
                //CloseForm();
                return true;
            }
            return false;
        }

        /// <summary>Saves detail if dirty</summary>
        public bool SaveIfDirty()
        {
            if (Dirty)
            {
                var result = XtraMessageBox.Show(this, ConstStrings.SaveCancelFormWarning, ConstStrings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes || !Save())
                    return false;
            }
            return true;
        }

        /// <summary>Saves detail</summary>
        public virtual bool Save()
        {
            BeforeFormClose();
            if (!ValidateData()) return false;

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SaveData();
            }
            catch (Exception exc)
            {
                ProcessException(exc);
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            Dirty = false;

            return true;
        }

        /// <summary>Closes form</summary>
        public virtual void CloseForm()
        {
            if (_showCloseDialog && Dirty)
            {
                var result = XtraMessageBox.Show(this, ConstStrings.CloseCancelFormWarning, ConstStrings.Question, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.No)
                    CloseCancelForm();
                if (result == DialogResult.Yes)
                    if (!Save()) return;
            }
            _returnResult = DialogResult.OK;
            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }
            SaveFormLayout();
            Cursor.Current = Cursors.Default;
            if (_closeForm != null) _closeForm(_returnResult);
            Dispose();
        }

        /// <summary>Commits current session</summary>
        protected void CommitSession()
        {
            _oldSession = Session;
            SessionHelper.CommitSession(_oldSession, new ExceptionProcesser(this));
            SetEditObject(_externalSession, EditObject);
            _oldSession.Dispose();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>Loads form layout</summary>
        protected virtual void LoadFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.RestoreFormLayout(new FormLayoutInfo(this, lcMain));
        }

        /// <summary>Saves form layout</summary>
        protected virtual void SaveFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.SaveFormLayout(new FormLayoutInfo(this, lcMain));
        }

        /// <summary>Creates new edit object</summary>
        protected virtual LazyNetBaseObject CreateNewObject()
        {
            _createNewObject = true;
            return null;
        }

        /// <summary> Initialize edit object data </summary>
        protected virtual void InitData() { }

        /// <summary> Initialize validators </summary>
        protected virtual void InitValidation() { }

        /// <summary> Save edit object data </summary>
        protected virtual void SaveData() { }

        /// <summary> Validate edit object data </summary>
        protected virtual bool ValidateData()
        {
            // Проверка по валидаторам
            if (!ValidationProvider.Validate())
            {
                var text = "";
                foreach (var control in ValidationProvider.GetInvalidControls())
                {
                    var validationRule = ValidationProvider.GetValidationRule(control);
                    if (validationRule.ErrorType == ErrorType.Default || validationRule.ErrorType == ErrorType.Critical)
                    {
                        if (!string.IsNullOrEmpty(text)) text += Environment.NewLine;
                        var item = lcMain.GetItemByControl(control);
                        if (item != null) text = string.Format("{0}{1} ", text, item.Text);
                        text += validationRule.ErrorText;
                    }
                }
                if (!string.IsNullOrEmpty(text))
                {
                    XtraMessageBox.Show(this, text, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Проверка дочерних коллекций
            foreach (XPMemberInfo memberInfo in EditObject.ClassInfo.CollectionProperties)
            {
                var xpCollection = (XPBaseCollection)EditObject.GetMemberValue(memberInfo.Name);
                foreach (var item in xpCollection)
                {
                    if (!(item is IDXDataErrorInfo)) continue;

                    var dxDataErrorInfo = (IDXDataErrorInfo)item;
                    var errorInfo = new ErrorInfo { ErrorType = ErrorType.None };
                    dxDataErrorInfo.GetError(errorInfo);
                    if (errorInfo.ErrorType == ErrorType.Default || errorInfo.ErrorType == ErrorType.Critical)
                    {
                        XtraMessageBox.Show(this, errorInfo.ErrorText, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>BeforeFormClose</summary>
        protected virtual void BeforeFormClose()
        {
            foreach (Control ctrl in lcMain.Controls)
            {
                var edit = ctrl as BaseEdit;
                if (edit != null) edit.DoValidate(PopupCloseMode.Normal);

                var grid = ctrl as GridControl;
                if (grid == null) continue;

                var view = grid.DefaultView as ColumnView;
                if (view == null) continue;
                view.CloseEditor();
                view.UpdateCurrentRow();
            }
        }

        /// <summary>CloseCancelForm</summary>
        void CloseCancelForm()
        {
            if (EditObject != null) Session.RemoveFromLists(EditObject);
        }

        /// <summary> Question </summary>
        protected bool Question(string text)
        {
            return XtraMessageBox.Show(this, text, ConstStrings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        
        /// <summary> Process exception </summary>
        protected void ProcessException(Exception exc)
        {
            Logger.Error(exc.Message, exc);
            XtraMessageBox.Show(this, exc.Message, ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary> UpdateDetailCaption </summary>
        void UpdateDetailCaption()
        {
            Text = string.Format("{0}{1}", StringsHelper.EnsureMaximumLength(EditObjectName, 70), Dirty ? "*" : string.Empty);
        }

        void AddControl(Control item)
        {
            var edit = item as BaseEdit;
            if (edit != null && !"ReadOnly".Equals(edit.Tag))
            {
                edit.MenuManager = lcMain.MenuManager;
                edit.EditValueChanged += EditEditValueChanged;
            }
            var container = item as IEditsContainer;
            if (container != null)
            {
                container.EditValueChanged += EditEditValueChanged;
            }
            var grid = item as GridControl;
            if (grid != null)
            {
                grid.MenuManager = lcMain.MenuManager;
            }
        }

        void EditEditValueChanged(object sender, EventArgs e)
        {
            Dirty = true;
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

        /// <summary> Error </summary>
        public void Error(string text, string caption = null)
        {
            XtraMessageBox.Show(this, text, caption ?? ConstStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Buttons

        void InitButtons()
        {
            SaveButton.ItemClick += ((s, e) => Save());
            SaveAndCloseButton.ItemClick += ((s, e) => SaveAndClose());
            CloseButton.ItemClick += ((s, e) => CloseForm());
        }

        /// <summary> Save button </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BarButtonItem SaveButton { get { return bbiSave; } }
        /// <summary> Save and close button </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BarButtonItem SaveAndCloseButton { get { return bbiSaveAndClose; } }
        /// <summary> Close button </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual BarButtonItem CloseButton { get { return bbiClose; } }

        #endregion
    }
}
