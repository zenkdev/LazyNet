using System.Drawing;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet
{
    [Persistent("lzMap")]
    public class Map : LazyNetBaseObject
    {
        public Map(Session session) : base(session) { }

        /// <summary> Name </summary>
        [Size(200)]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", StringsHelper.EnsureMaximumLength(value, 200)); }
        }

        [ValueConverter(typeof(ImageValueConverter))]
        public Image Picture
        {
            get { return GetPropertyValue<Image>("Picture"); }
            set { SetPropertyValue("Picture", value); }
        }

        [Aggregated, Association("Map-MapToDevice", typeof(MapToDevice))]
        public XPCollection<MapToDevice>Devices
        {
            get { return GetCollection<MapToDevice>("Devices"); }
        }
    }

    [Persistent("lzMapToDevice")]
    public class MapToDevice : XPBaseObject
    {
        public MapToDevice(Session session) : base(session) { }

        [Key(true)]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Association("Map-MapToDevice")]
        public Map Map
        {
            get { return GetPropertyValue<Map>("Map"); }
            set { SetPropertyValue("Map", value); }
        }

        public int SortOrder
        {
            get { return GetPropertyValue<int>("SortOrder"); }
            set { SetPropertyValue("SortOrder", value); }
        }

        public Device Device
        {
            get { return GetPropertyValue<Device>("Device"); }
            set { SetPropertyValue("Device", value); }
        }

        public int X1
        {
            get { return GetPropertyValue<int>("X1"); }
            set { SetPropertyValue("X1", value); }
        }

        public int Y1
        {
            get { return GetPropertyValue<int>("Y1"); }
            set { SetPropertyValue("Y1", value); }
        }

        public int X2
        {
            get { return GetPropertyValue<int>("X2"); }
            set { SetPropertyValue("X2", value); }
        }

        public int Y2
        {
            get { return GetPropertyValue<int>("Y2"); }
            set { SetPropertyValue("Y2", value); }
        }
    }
}
