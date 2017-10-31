using System;
using System.ComponentModel.DataAnnotations;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    [Persistent("Software")]
    public class SoftwareObject : LazyNetBaseObject
    {
        public SoftwareObject(Session session) : base(session) { }

        /// <summary> Gets or sets the device </summary>
        [Indexed, DevExpress.Xpo.Association("Device-Software")]
        public Device Device
        {
            get { return GetPropertyValue<Device>("Device"); }
            set { SetPropertyValue("Device", value); }
        }
        
        /// <summary> Gets or set the SKU </summary>
        [Size(50), Display(Name = "Номер лицензии")]
        public string SKU
        {
            get { return GetPropertyValue<string>("SKU"); }
            set { SetPropertyValue("SKU", StringsHelper.EnsureMaximumLength(value, 50)); }
        }
        
        /// <summary> Gets or set the name </summary>
        [Size(200), Display(Name = "Продукт")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", StringsHelper.EnsureMaximumLength(value, 200)); }
        }

        /// <summary> Gets or set the company </summary>
        [Size(200), Display(Name = "Организация")]
        public string Company
        {
            get { return GetPropertyValue<string>("Company"); }
            set { SetPropertyValue("Company", StringsHelper.EnsureMaximumLength(value, 200)); }
        }

        /// <summary> Gets or sets the buyed date </summary>
        [Display(Name = "Дата покупки")]
        public DateTime BuyedOn
        {
            get { return GetPropertyValue<DateTime>("BuyedOn"); }
            set { SetPropertyValue("BuyedOn", value); }
        }

        /// <summary> Gets or sets the expired date </summary>
        [Display(Name = "Заканчивается")]
        public DateTime ExpiredOn
        {
            get { return GetPropertyValue<DateTime>("ExpiredOn"); }
            set { SetPropertyValue("ExpiredOn", value); }
        }

        /// <summary> Gets or set the serial </summary>
        [Size(50)]
        public string Serial
        {
            get { return GetPropertyValue<string>("Serial"); }
            set { SetPropertyValue("Serial", StringsHelper.EnsureMaximumLength(value, 50)); }
        }

        /// <summary> Gets or sets the used </summary>
        [Display(Name = "Использовано")]
        public int Used
        {
            get { return GetPropertyValue<int>("Used"); }
            set { SetPropertyValue("Used", value); }
        }

        /// <summary> Gets or sets the available </summary>
        [Display(Name = "Доступно")]
        public int Available
        {
            get { return GetPropertyValue<int>("Available"); }
            set { SetPropertyValue("Available", value); }
        }

        /// <summary> Gets or set the note </summary>
        [Size(SizeAttribute.Unlimited)]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }
    }
}
