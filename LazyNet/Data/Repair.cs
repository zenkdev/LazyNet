using System;
using System.ComponentModel.DataAnnotations;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    public class Repair : LazyNetBaseObject
    {
        public Repair(Session session) : base(session) { }

        /// <summary> Gets or sets the device </summary>
        [Indexed, DevExpress.Xpo.Association("Device-Repair")]
        public Device Device
        {
            get { return GetPropertyValue<Device>("Device"); }
            set { SetPropertyValue("Device", value); }
        }

        /// <summary> Gets or set the repair type </summary>
        [Display(Name = @"Вид ремонта")]
        public RepairTypeEnum RepairType
        {
            get { return GetPropertyValue<RepairTypeEnum>("RepairType"); }
            set { SetPropertyValue("RepairType", value); }
        }
        /// <summary> Gets or set the customer </summary>
        [Size(200), Display(Name = @"Организация")]
        public string Customer
        {
            get { return GetPropertyValue<string>("Customer"); }
            set { SetPropertyValue("Customer", value); }
        }
        /// <summary> Gets or set the amount </summary>
        [Display(Name = @"Сумма")]
        public decimal Amount
        {
            get { return GetPropertyValue<decimal>("Amount"); }
            set { SetPropertyValue("Amount", value); }
        }
        /// <summary> Gets or set the html note </summary>
        [Size(SizeAttribute.Unlimited)]
        public string HtmlNote
        {
            get { return GetPropertyValue<string>("HtmlNote"); }
            set { SetPropertyValue("HtmlNote", value); }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            RepairType = RepairTypeEnum.PaidRepair;
        }

        /// <summary>
        /// Gets the plain text (preview field in grid)
        /// </summary>
        public string PlainText => GetPlainText();

        string _plainText = string.Empty;

        string GetPlainText()
        {
            if (string.IsNullOrEmpty(_plainText))
                _plainText = StringsHelper.EnsureMaximumLength(StringsHelper.StripHTML(HtmlNote), 500);
            return _plainText;
        }

        public string RepairTypeString => StringsHelper.EnumDisplayText(RepairType).ToUpper();
    }

    public enum RepairTypeEnum
    {
        [Display(Name = @"Гарантийный ремонт")]
        WarrantyRepair = 1,
        [Display(Name = @"Платный ремонт")]
        PaidRepair = 2,
        [Display(Name = @"Плановое обслуживание")]
        ScheduledMaintenance = 3,
        [Display(Name = @"Замена картриджа")]
        CartridgeReplacement = 4,
        [Display(Name = @"Другое")]
        Other = 5
    }
}
