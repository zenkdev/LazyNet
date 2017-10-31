using System;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Base;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class RepairDetail : DetailBase
    {
        bool _visible;
        bool _loading;

        /// <summary> new </summary>
        public RepairDetail(Form parent, GetSessionCallback session, CloseDetailForm closeForm)
            : base(parent, session, null, closeForm)
        {
            InitializeComponent();
            InitDetail();
        }

        /// <summary> edit </summary>
        public RepairDetail(Form parent, GetSessionCallback session, Repair editObject, CloseDetailForm closeForm)
            : base(parent, session, editObject, closeForm)
        {
            InitializeComponent();
            InitDetail();
        }
        void InitDetail()
        {
            icbRepairType.Properties.Items.AddLocalizedEnum<RepairTypeEnum>();
            DictionaryHelper.InitDictionary(spellChecker1);
            riDeviceState.Items.AddLocalizedEnum<DeviceStateEnum>();
            EditorsHelpers.InitDeviceTypeComboBox(riDeviceType);
            ((RepositoryItemSearchLookUpEditWithGlyph)leDevice.Properties).GetImageByValue += AddRepairGetImageByValue;
            searchLookUpEdit1View.CustomColumnSort += AddRepairCustomColumnSort;
        }

        public override string EditObjectName { get { return StringsHelper.EnumDisplayText(Repair.RepairType); } }

        internal Repair Repair { get { return EditObject as Repair; } }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _visible = true;
        }

        /// <summary>Creates new edit object</summary>
        protected override LazyNetBaseObject CreateNewObject()
        {
            base.CreateNewObject();
            return new Repair(Session);
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
                deRepairDate.EditValue = Repair.CreatedOn;
                icbRepairType.EditValue = Repair.RepairType;
                mruCustomer.Text = Repair.Customer;
                seAmount.Value = Repair.Amount;
                leDevice.EditValue = Repair.Device != null ? Repair.Device.Id : (int?)null;

                var query = new XPQuery<Repair>(Session);
                mruCustomer.Properties.Items.Clear();
                mruCustomer.Properties.Items.AddRange(query.Where(u => u.Customer != "").GroupBy(u => u.Customer).Select(g => g.Key).ToList());

                richEditControl.HtmlText = Repair.HtmlNote;
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
            Repair.CreatedOn = deRepairDate.DateTime;
            Repair.RepairType = (RepairTypeEnum)icbRepairType.EditValue;
            Repair.Customer = mruCustomer.Text;
            Repair.Amount = seAmount.Value;
            Repair.Device = Session.GetObjectByKey<Device>(leDevice.EditValue);

            Repair.HtmlNote = richEditControl.HtmlText;

            CommitSession();
        }

        protected override void InitValidation()
        {
            base.InitValidation();
            ValidationProvider.SetValidationRule(seAmount, EditorsHelpers.RuleIsNotBlank);
        }

        void richEditControl_HtmlTextChanged(object sender, EventArgs e)
        {
            if (!_loading && _visible)
                Dirty = true;
        }

        void richEditControl_SelectionChanged(object sender, EventArgs e)
        {
            tableToolsRibbonPageCategory1.Visible = richEditControl.IsSelectionInTable();
            floatingPictureToolsRibbonPageCategory1.Visible = richEditControl.IsFloatingObjectSelected;
        }

        void AddRepairGetImageByValue(object sender, ImageByValueEventArgs e)
        {
            Device row = null;
            try
            {
                row = Session.GetObjectByKey<Device>(e.Value);
            }
            catch
            {
                // ignored
            }
            if (row != null)
            {
                e.Image = ImagesHelper.DeviceImages.Images[(int)row.DeviceType];
            }
        }

        void AddRepairCustomColumnSort(object sender, CustomColumnSortEventArgs e)
        {
            if (e.Column == gcIcon || e.Column == gcDeviceState)
            {
                e.Handled = true;
                e.Result = Convert.ToInt32(e.Value1) < Convert.ToInt32(e.Value2) ? -1 : Convert.ToInt32(e.Value1) > Convert.ToInt32(e.Value2) ? 1 : 0;
            }
            else if (e.Column == gcIP)
            {
                e.Handled = true;
                var ip1 = IPAddress.Parse((string)e.Value1).AddressToInt();
                var ip2 = IPAddress.Parse((string)e.Value2).AddressToInt();

                if (ip1 < ip2)
                    e.Result = -1;
                else if (ip2 < ip1)
                    e.Result = 1;
                else
                    e.Result = 0;
            }
        }

        void OnResolveSession(object sender, ResolveSessionEventArgs e)
        {
            e.Session = new Session();
        }

        void OnDismissSession(object sender, ResolveSessionEventArgs e)
        {
            var session = e.Session as IDisposable;
            if (session != null)
            {
                session.Dispose();
            }
        }
    }
}
