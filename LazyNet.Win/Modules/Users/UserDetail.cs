using System;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class UserDetail : DetailBase
    {
        bool _visible;
        bool _loading;

        /// <summary> new </summary>
        public UserDetail(Form parent, GetSessionCallback session, CloseDetailForm closeForm)
            : base(parent, session, null, closeForm)
        {
            InitializeComponent();
            InitDetail();
        }

        /// <summary> edit </summary>
        public UserDetail(Form parent, GetSessionCallback session, User editObject, CloseDetailForm closeForm)
            : base(parent, session, editObject, closeForm)
        {
            InitializeComponent();
            InitDetail();
        }
        void InitDetail()
        {
            EditorsHelpers.InitGenderComboBox(icbGender.Properties);
            icbUserState.Properties.Items.AddLocalizedEnum<UserStateEnum>();
            DictionaryHelper.InitDictionary(spellChecker1);
            teFirstName.EditValueChanged += OnAnyNameUpdated;
            teLastName.EditValueChanged += OnAnyNameUpdated;
            teMiddleName.EditValueChanged += OnAnyNameUpdated;
        }

        public override string EditObjectName { get { return User.FullName; } }

        internal User User { get { return EditObject as User; } }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _visible = true;
        }

        /// <summary>Creates new edit object</summary>
        protected override LazyNetBaseObject CreateNewObject()
        {
            base.CreateNewObject();
            return new User(Session) { FullName = ConstStrings.NewUser };
        }

        /// <summary>Loads form layout</summary>
        protected override void LoadFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.RestoreFormLayout(new FormLayoutInfo(this, lcMain, rcMain.Toolbar));
        }

        /// <summary>Saves form layout</summary>
        protected override void SaveFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.SaveFormLayout(new FormLayoutInfo(this, lcMain, rcMain.Toolbar));
        }

        /// <summary> Initialize edit object data </summary>
        protected override void InitData()
        {
            _loading = true;

            try
            {
                teFirstName.Text = User.FirstName;
                teLastName.Text = User.LastName;
                teMiddleName.Text = User.MiddleName;
                teFullName.Text = User.FullName;

                deBirthDate.EditValue = User.BirthDate;
                icbGender.EditValue = User.Gender;
                pictureEdit.Image = User.Photo;

                teUserName.Text = User.UserName;

                beWorkPhone.Text = User.WorkPhone;
                beMobilePhone.Text = User.MobilePhone;
                beEmail.Text = User.Email;

                mruDepartment.Text = User.Department;
                mruTitle.Text = User.Title;

                var query = new XPQuery<User>(Session);
                mruDepartment.Properties.Items.Clear();
                mruDepartment.Properties.Items.AddRange(query.Where(u => u.Department != "").GroupBy(u => u.Department).Select(g => g.Key).ToList());
                mruTitle.Properties.Items.Clear();
                mruTitle.Properties.Items.AddRange(query.Where(u => u.Title != "").GroupBy(u => u.Title).Select(g => g.Key).ToList());

                icbUserState.EditValue = User.UserState;
                tsIsAdmin.IsOn = User.IsAdmin;
                deHireDate.EditValue = User.HireDate;

                richEditControl.HtmlText = User.Note;
                richEditControl.Document.Sections[0].Page.PaperKind = PaperKind.A4;
            }
            finally
            {
                _loading = false;
            }
        }

        /// <summary>Saves data</summary>
        protected override void SaveData()
        {
            User.FirstName = teFirstName.Text;
            User.LastName = teLastName.Text;
            User.MiddleName = teMiddleName.Text;
            User.FullName = teFullName.Text;
            User.BirthDate = deBirthDate.DateTime != DateTime.MinValue ? deBirthDate.DateTime : (DateTime?)null;
            User.Gender = (UserGender)icbGender.EditValue;
            User.Photo = pictureEdit.Image;

            User.UserName = teUserName.Text;

            User.WorkPhone = beWorkPhone.Text;
            User.MobilePhone = beMobilePhone.Text;
            User.Email = beEmail.Text;

            User.Department = mruDepartment.Text;
            User.Title = mruTitle.Text;
            User.UserState = (UserStateEnum)icbUserState.EditValue;
            User.IsAdmin = tsIsAdmin.IsOn;
            User.HireDate = deHireDate.DateTime != DateTime.MinValue ? deHireDate.DateTime : (DateTime?)null;

            User.Note = richEditControl.HtmlText;

            CommitSession();
        }

        protected override void InitValidation()
        {
            base.InitValidation();
            ValidationProvider.SetValidationRule(teFirstName, EditorsHelpers.RuleIsNotBlank);
        }

        void OnAnyNameUpdated(object sender, EventArgs e)
        {
            if (_loading) return;
            var str = teFirstName.Text.Trim();
            if (teMiddleName.Text.Trim() != "")
            {
                str = string.Format("{0} {1}", str, teMiddleName.Text.Trim());
            }
            if (teLastName.Text.Trim() != "")
            {
                str = string.Format("{0} {1}", teLastName.Text.Trim(), str);
            }
            teFullName.Text = str;
        }

        void OnUserNameOrEmailUpdated(object sender, EventArgs e)
        {
            bbiImportFromAD.Enabled = (teUserName.Text.Trim() != string.Empty || beEmail.Text.Trim() != string.Empty);
        }

        void bbiImportFromAD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ReSharper disable once JoinDeclarationAndInitializer
            string username, email, firstName, lastName, phone, mobile, title, office;

            username = teUserName.Text.Trim();
            if (username != string.Empty)
            {
                if (AdHelper.GetUserPropertiesFromAD(username, out email, out firstName, out lastName, out phone, out mobile, out title, out office))
                {
                    beEmail.Text = StringsHelper.DefaultIfNullOrWhiteSpace(email, beEmail.Text);
                    teFirstName.Text = StringsHelper.DefaultIfNullOrWhiteSpace(firstName, teFirstName.Text);
                    teLastName.Text = StringsHelper.DefaultIfNullOrWhiteSpace(lastName, teLastName.Text);
                    beWorkPhone.Text = StringsHelper.DefaultIfNullOrWhiteSpace(phone, beWorkPhone.Text);
                    beMobilePhone.Text = StringsHelper.DefaultIfNullOrWhiteSpace(mobile, beMobilePhone.Text);

                    mruDepartment.Text = StringsHelper.DefaultIfNullOrWhiteSpace(office, mruDepartment.Text);
                    mruTitle.Text = StringsHelper.DefaultIfNullOrWhiteSpace(title, mruTitle.Text);
                }
            }
            else
            {
                email = beEmail.Text.Trim();
                if (AdHelper.GetUserPropertiesFromADByEmail(email, out username, out firstName, out lastName, out phone, out mobile, out title, out office))
                {
                    var index = username.IndexOf(@"\", StringComparison.Ordinal);
                    if (index < 0)
                    {
                        if (!string.IsNullOrEmpty(Environment.UserDomainName))
                            username = string.Concat(Environment.UserDomainName, @"\", username);
                    }
                    teUserName.Text = StringsHelper.DefaultIfNullOrWhiteSpace(username, teUserName.Text);

                    teFirstName.Text = StringsHelper.DefaultIfNullOrWhiteSpace(firstName, teFirstName.Text);
                    teLastName.Text = StringsHelper.DefaultIfNullOrWhiteSpace(lastName, teLastName.Text);
                    beWorkPhone.Text = StringsHelper.DefaultIfNullOrWhiteSpace(phone, beWorkPhone.Text);
                    beMobilePhone.Text = StringsHelper.DefaultIfNullOrWhiteSpace(mobile, beMobilePhone.Text);

                    mruDepartment.Text = StringsHelper.DefaultIfNullOrWhiteSpace(office, mruDepartment.Text);
                    mruTitle.Text = StringsHelper.DefaultIfNullOrWhiteSpace(title, mruTitle.Text);
                }
            }
        }

        void richEditControl_HtmlTextChanged(object sender, EventArgs e)
        {
            if (!_loading && _visible)
                Dirty = true;
            //if (_isLoading) return;
            //if (richEditControl.HtmlText.Trim() != TextHelper.EnsureNotNull(User.Note).Trim())
            //    Dirty = true;
        }

        void richEditControl_SelectionChanged(object sender, EventArgs e)
        {
            tableToolsRibbonPageCategory1.Visible = richEditControl.IsSelectionInTable();
            floatingPictureToolsRibbonPageCategory1.Visible = richEditControl.IsFloatingObjectSelected;
        }

    }
}
