using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    [Persistent("lzAccount")]
    public class Account : LazyNetBaseObject
    {
        /// <summary>ctor</summary>
        public Account() : base(Session.DefaultSession) { }
        /// <summary>ctor</summary>
        public Account(Session session) : base(session) { }

        /// <summary> Device </summary>
        [Association("Device-Account")]
        public Device Device
        {
            get { return GetPropertyValue<Device>("Device"); }
            set { SetPropertyValue("Device", value); }
        }

        [Size(100)]
        public string Login
        {
            get { return GetPropertyValue<string>("Login"); }
            set { SetPropertyValue("Login", value); }
        }

        [Size(100)]
        public string Password
        {
            get { return GetPropertyValue<string>("Password"); }
            set { SetPropertyValue("Password", value); }
        }

        /// <summary> Comment </summary>
        [Size(SizeAttribute.Unlimited)]
        public string Comment
        {
            get { return GetPropertyValue<string>("Comment"); }
            set { SetPropertyValue("Comment", value); }
        }
    }
}
