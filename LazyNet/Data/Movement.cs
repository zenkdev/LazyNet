using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    public class Movement : LazyNetBaseObject
    {
        public Movement() : base(Session.DefaultSession) { }

        /// <summary>ctor</summary>
        public Movement(Session session) : base(session) { }

        /// <summary> Gets or sets the device </summary>
        [Indexed, Association("Device-Movement")]
        public Device Device
        {
            get { return GetPropertyValue<Device>("Device"); }
            set { SetPropertyValue("Device", value); }
        }

        /// <summary> Gets or sets the old room </summary>
        public Room OldRoom
        {
            get { return GetPropertyValue<Room>("OldRoom"); }
            set { SetPropertyValue("OldRoom", value); }
        }

        /// <summary> Gets or sets the new room </summary>
        public Room NewRoom
        {
            get { return GetPropertyValue<Room>("NewRoom"); }
            set { SetPropertyValue("NewRoom", value); }
        }

        /// <summary> Gets or sets the old user </summary>
        public User OldUser
        {
            get { return GetPropertyValue<User>("OldUser"); }
            set { SetPropertyValue("OldUser", value); }
        }

        /// <summary> Gets or sets the new user </summary>
        public User NewUser
        {
            get { return GetPropertyValue<User>("NewUser"); }
            set { SetPropertyValue("NewUser", value); }
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
