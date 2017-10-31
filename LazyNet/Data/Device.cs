using System;
using System.Drawing;
using System.Linq;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet
{
    public class Device : LazyNetBaseObject
    {
        public Device(Session session) : base(session) { }

        /// <summary> Gets or sets the room </summary>
        [Indexed]
        public Room Room
        {
            get { return GetPropertyValue<Room>("Room"); }
            set { SetPropertyValue("Room", value); }
        }

        /// <summary> Gets or set the device type </summary>
        [Indexed]
        public DeviceTypeEnum DeviceType
        {
            get { return GetPropertyValue<DeviceTypeEnum>("DeviceType"); }
            set { SetPropertyValue("DeviceType", value); }
        }

        /// <summary> Gets or set the device state </summary>
        public DeviceStateEnum DeviceState
        {
            get { return GetPropertyValue<DeviceStateEnum>("DeviceState"); }
            set { SetPropertyValue("DeviceState", value); }
        }

        /// <summary> Gets or sets the deletion mark </summary>
        [Indexed]
        public bool DeletionMark
        {
            get { return GetPropertyValue<bool>("DeletionMark"); }
            set { SetPropertyValue("DeletionMark", value); }
        }
        
        /// <summary> Gets or sets the deleted date </summary>
        [DbType("datetime2")]
        public DateTime? DeletedOn
        {
            get { return GetPropertyValue<DateTime?>("DeletedOn"); }
            set { SetPropertyValue("DeletedOn", value); }
        }

        /// <summary> Gets or set the name </summary>
        [Size(200)]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", StringsHelper.EnsureMaximumLength(value, 200)); }
        }

        /// <summary> Gets or set the SKU </summary>
        [Size(50)]
        public string SKU
        {
            get { return GetPropertyValue<string>("SKU"); }
            set { SetPropertyValue("SKU", StringsHelper.EnsureMaximumLength(value, 50)); }
        }

        /// <summary> Gets or set the serial </summary>
        [Size(50)]
        public string Serial
        {
            get { return GetPropertyValue<string>("Serial"); }
            set { SetPropertyValue("Serial", StringsHelper.EnsureMaximumLength(value, 50)); }
        }

        /// <summary> Gets or set the specification </summary>
        [Size(500)]
        public string Specification
        {
            get { return GetPropertyValue<string>("Specification"); }
            set { SetPropertyValue("Specification", StringsHelper.EnsureMaximumLength(value, 500)); }
        }

        /// <summary> Gets or sets the buyed date </summary>
        [DbType("datetime2")]
        public DateTime BuyedOn
        {
            get { return GetPropertyValue<DateTime>("BuyedOn"); }
            set { SetPropertyValue("BuyedOn", value); }
        }

        /// <summary> Gets or sets the host name </summary>
        public string HostName
        {
            get { return GetPropertyValue<string>("HostName"); }
            set { SetPropertyValue("HostName", value); }
        }

        /// <summary> Gets or sets the IP address </summary>
        public string IP
        {
            get { return GetPropertyValue<string>("IP"); }
            set { SetPropertyValue("IP", value); }
        }

        /// <summary> Gets or sets the IP address </summary>
        public long IPInt
        {
            get { return GetPropertyValue<long>("IPInt"); }
            set { SetPropertyValue("IPInt", value); }
        }

        /// <summary> Gets or sets the MAC address </summary>
        public string MAC
        {
            get { return GetPropertyValue<string>("MAC"); }
            set { SetPropertyValue("MAC", value); }
        }

        /// <summary> Gets or sets the user </summary>
        [Association("User-Device")]
        public User User
        {
            get { return GetPropertyValue<User>("User"); }
            set { SetPropertyValue("User", value); }
        }

        /// <summary> Gets or sets the picture </summary>
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Picture
        {
            get { return GetPropertyValue<Image>("Picture"); }
            set { SetPropertyValue("Picture", value); }
        }

        /// <summary> Gets or sets the html note </summary>
        [Size(SizeAttribute.Unlimited)]
        public string HtmlNote
        {
            get { return GetPropertyValue<string>("HtmlNote"); }
            set
            {
                if (SetPropertyValue("HtmlNote", value))
                {
                    _plainText = string.Empty;
                }
            }
        }

        [Aggregated, Association("Device-Account", typeof(Account))]
        public XPCollection<Account> Accounts => GetCollection<Account>("Accounts");

        [Aggregated, Association("Device-Repair", typeof(Repair))]
        public XPCollection<Repair> Repairs
        {
            get
            {
                var collection = GetCollection<Repair>("Repairs");
                collection.DeleteObjectOnRemove = false;
                return collection;
            }
        }

        [Aggregated, Association("Device-Software", typeof(SoftwareObject))]
        public XPCollection<SoftwareObject> Software
        {
            get
            {
                var collection = GetCollection<SoftwareObject>("Software");
                collection.DeleteObjectOnRemove = false;
                return collection;
            }
        }

        [Aggregated, Association("Device-Movement", typeof(Movement))]
        public XPCollection<Movement> Movements => GetCollection<Movement>("Movements");

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

        public Image PictureExists => Picture ?? ImagesHelper.UnknownDevice;

        public string DeviceTypeText => StringsHelper.EnumDisplayText(DeviceType);

        public string AboutHtml
        {
            get
            {
                var str = $"<i>{Specification}</i>";
                if (!string.IsNullOrWhiteSpace(SKU))
                {
                    str = $"<b>{SKU}</b><br>{str}";
                }
                return str;
            }
        }

        /// <summary>
        /// Gets allow delete flag
        /// </summary>
        public override bool AllowDelete => false;

        /// <summary> Safe deletes object </summary>
        public override bool SafeDelete()
        {
            DeletionMark = true;
            DeletedOn = DateTime.Now;
            Save();
            return true;
        }

        /// <summary> Gets the object name </summary>
        public override string ObjectName => Name + (string.IsNullOrWhiteSpace(SKU) ? "" : string.Concat(" (", SKU, ")"));

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            DeviceType = Enum.GetValues(typeof(DeviceTypeEnum)).Cast<DeviceTypeEnum>().First();
            DeviceState = DeviceStateEnum.Operated;
        }
    }
}
