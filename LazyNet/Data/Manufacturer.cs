using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    public class Manufacturer : LazyNetBaseObject
    {
        /// <summary>ctor</summary>
        public Manufacturer() : base(Session.DefaultSession) { }
        /// <summary>ctor</summary>
        public Manufacturer(Session session) : base(session) { }

        [Indexed(Unique = true)]
        public string MAC
        {
            get { return GetPropertyValue<string>("MAC"); }
            set { SetPropertyValue("MAC", value); }
        }

        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

    }
}
