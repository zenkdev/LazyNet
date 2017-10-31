using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class AddSoftware : AddFormBase
    {
        public AddSoftware(Form parent, UnitOfWork session, SoftwareObject editObject, IDXMenuManager manager)
            : base(parent, session, editObject, manager)
        {
            InitializeComponent();
            deBuyedOn.Properties.NullDate = DateTime.MinValue;
            deExpiredOn.Properties.NullDate = DateTime.MinValue;
        }

        internal SoftwareObject Software { get { return EditObject as SoftwareObject; } }

        protected override void CreateNewObject()
        {
            base.CreateNewObject();
            EditObject = new SoftwareObject(Session) { Name = ConstStrings.NewSoftware };
        }

        /// <summary> Initialize edit object data </summary>
        protected override void InitData()
        {
            teSKU.Text = Software.SKU;
            teName.Text = Software.Name;
            mruCompany.Text = Software.Company;
            deBuyedOn.DateTime = Software.BuyedOn;
            deExpiredOn.DateTime = Software.ExpiredOn;
            teSerial.Text = Software.Serial;
            seUsed.Value = Software.Used;
            seAvailable.Value = Software.Available;
            meNote.Text = Software.Note;

            var query = new XPQuery<SoftwareObject>(Session);
            mruCompany.Properties.Items.Clear();
            mruCompany.Properties.Items.AddRange(query.Where(u => u.Company != "").GroupBy(u => u.Company).Select(g => g.Key).ToList());
        }

        /// <summary>Saves data</summary>
        protected override void SaveData()
        {
            Software.SKU = teSKU.Text;
            Software.Name = teName.Text;
            Software.Company = mruCompany.Text;
            Software.BuyedOn = deBuyedOn.DateTime.Date;
            Software.ExpiredOn = deExpiredOn.DateTime.Date;
            Software.Serial = teSerial.Text;
            Software.Used = Convert.ToInt32(seUsed.Value);
            Software.Available = Convert.ToInt32(seAvailable.Value);
            Software.Note = meNote.Text;
        }

        void MinPowerSpinEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (Convert.ToInt32(e.Value) == 0)
            {
                e.DisplayText = "";
            }
        }
    }
}
