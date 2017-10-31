using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Win
{
    public partial class AddAccountForm : AddFormBase
    {
        public AddAccountForm(Form parent, UnitOfWork session, LazyNetBaseObject editObject, IDXMenuManager manager)
            : base(parent, session, editObject, manager)
        {
            InitializeComponent();

            Text = editObject != null ? "Edit Account" : "Add Account";
        }

        /// <summary>Account</summary>
        public Account Account { get { return EditObject as Account; } }

        /// <summary>CreateNewObject</summary>
        protected override void CreateNewObject()
        {
            base.CreateNewObject();
            EditObject = new Account(Session);
        }

        protected override void InitValidation()
        {
            base.InitValidation();

            ValidationProvider.SetValidationRule(teLogin, EditorsHelpers.RuleIsNotBlank);
        }

        /// <summary>InitData</summary>
        protected override void InitData()
        {
            var query = new XPQuery<Account>(Session);
            mruComment.Properties.Items.Clear();
            mruComment.Properties.Items.AddRange(query.Where(a => a.Comment != "").Select(a => a.Comment).Distinct().ToList());

            teLogin.Text = Account.Login;
            tePassword.EditValue = Account.Password;
            mruComment.Text = Account.Comment;
        }

        /// <summary>SaveData</summary>
        protected override void SaveData()
        {
            Account.Login = teLogin.Text;
            Account.Password = tePassword.Text;
            Account.Comment = mruComment.Text;
        }

    }
}
