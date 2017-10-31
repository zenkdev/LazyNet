using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    public class WinFormSetting : ExtendedXPBaseObject
    {
        User _createdBy;

        public WinFormSetting() : base(Session.DefaultSession) { }
        public WinFormSetting(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _createdBy = Session.GetObjectByKey<User>(DataHelper.CurrentUserId);
        }

        /// <summary>
        /// WinForm setting identifier
        /// </summary>
        [Key(true)]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        /// <summary>
        /// Gets or sets created by
        /// </summary>
        public User CreatedBy
        {
            get { return _createdBy; }
            set { SetPropertyValue("CreatedBy", ref _createdBy, value); }
        }

        /// <summary>
        ///  WinForm setting name
        /// </summary>
        [Indexed]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        /// <summary>
        ///  WinForm setting value
        /// </summary>
        [Size(SizeAttribute.Unlimited)]
        public string Value
        {
            get { return (string)GetPropertyValue("Value"); }
            set { SetPropertyValue("Value", value); }
        }
    }
}