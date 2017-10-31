using System;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class AddRepair : AddFormBase
    {
        public AddRepair(Form parent, UnitOfWork session, LazyNetBaseObject editObject, IDXMenuManager manager)
            : base(parent, session, editObject, manager)
        {
            InitializeComponent();

            icbRepairType.Properties.Items.AddLocalizedEnum<RepairTypeEnum>();
        }

        /// <summary>Repair</summary>
        public Repair Repair { get { return EditObject as Repair; } }

        /// <summary>CreateNewObject</summary>
        protected override void CreateNewObject()
        {
            base.CreateNewObject();
            EditObject = new Repair(Session);
        }

        protected override void InitValidation()
        {
            base.InitValidation();

            ValidationProvider.SetValidationRule(deCreatedOn, EditorsHelpers.RuleIsNotBlank);
            ValidationProvider.SetValidationRule(icbRepairType, EditorsHelpers.RuleIsNotBlank);
            ValidationProvider.SetValidationRule(mruCustomer, EditorsHelpers.RuleIsNotBlank);
            ValidationProvider.SetValidationRule(richEditControl, EditorsHelpers.RuleIsNotBlank);
        }

        /// <summary>InitData</summary>
        protected override void InitData()
        {
            deCreatedOn.EditValue = Repair.CreatedOn;
            icbRepairType.EditValue = Repair.RepairType;
            mruCustomer.EditValue = Repair.Customer;
            seAmount.EditValue = Repair.Amount;
            richEditControl.HtmlText = Repair.HtmlNote;

            xcDevices.Session = Session;

            var query = new XPQuery<Repair>(Session);
            mruCustomer.Properties.Items.Clear();
            mruCustomer.Properties.Items.AddRange(query.Where(r => r.Customer != "").GroupBy(r => r.Customer).Select(g => g.Key).ToList());
        }

        /// <summary>SaveData</summary>
        protected override void SaveData()
        {
            Repair.CreatedOn = deCreatedOn.DateTime;
            Repair.RepairType = (RepairTypeEnum)icbRepairType.EditValue;
            Repair.Customer = mruCustomer.Text;
            Repair.Amount = seAmount.Value;
            Repair.HtmlNote = richEditControl.HtmlText;
        }

        void richEditControl_HtmlTextChanged(object sender, EventArgs e)
        {
            //if (!_loading && _visible)
            //    Dirty = true;
        }

        void richEditControl_SelectionChanged(object sender, EventArgs e)
        {
            //tableToolsRibbonPageCategory1.Visible = richEditControl.IsSelectionInTable();
            //floatingPictureArrangeBar1.Visible = richEditControl.IsFloatingObjectSelected;
            //floatingPictureShapeStylesBar1.Visible = richEditControl.IsFloatingObjectSelected;
        }

    }
}
