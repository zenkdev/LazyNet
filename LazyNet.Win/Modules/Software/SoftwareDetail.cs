using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class SoftwareDetail : DetailBase
    {
        /// <summary> new </summary>
        public SoftwareDetail(Form parent, GetSessionCallback session, CloseDetailForm closeForm)
            : base(parent, session, null, closeForm)
        {
            InitializeComponent();
            InitDetail();
        }

        /// <summary> edit </summary>
        public SoftwareDetail(Form parent, GetSessionCallback session, SoftwareObject editObject, CloseDetailForm closeForm)
            : base(parent, session, editObject, closeForm)
        {
            InitializeComponent();
            InitDetail();
        }
        void InitDetail()
        {
            deBuyedOn.Properties.NullDate = DateTime.MinValue;
            deExpiredOn.Properties.NullDate = DateTime.MinValue;
            riDeviceState.Items.AddLocalizedEnum<DeviceStateEnum>();
            EditorsHelpers.InitDeviceTypeComboBox(riDeviceType);
            ((RepositoryItemSearchLookUpEditWithGlyph)leDevice.Properties).GetImageByValue += AddRepairGetImageByValue;
            searchLookUpEdit1View.CustomColumnSort += AddRepairCustomColumnSort;
        }
        public override string EditObjectName { get { return Software.Name; } }

        internal SoftwareObject Software { get { return EditObject as SoftwareObject; } }

        protected override LazyNetBaseObject CreateNewObject()
        {
            base.CreateNewObject();
            return new SoftwareObject(Session){Name = ConstStrings.NewSoftware};
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
            teSKU.Text = Software.SKU;
            teName.Text = Software.Name;
            mruCompany.Text = Software.Company;
            deBuyedOn.DateTime = Software.BuyedOn;
            deExpiredOn.DateTime = Software.ExpiredOn;
            teSerial.Text = Software.Serial;
            seUsed.Value = Software.Used;
            seAvailable.Value = Software.Available;
            leDevice.EditValue = Software.Device != null ? Software.Device.Id : (int?)null;
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
            Software.Device = Session.GetObjectByKey<Device>(leDevice.EditValue);
            Software.Note = meNote.Text;

            CommitSession();
        }

        void MinPowerSpinEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (Convert.ToInt32(e.Value) == 0)
            {
                e.DisplayText = "";
            }
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
