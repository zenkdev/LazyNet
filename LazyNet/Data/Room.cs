using System;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    public class Room : LazyNetBaseObject
    {
        public Room(Session session) : base(session) {}

        /// <summary> Gets or sets the parent </summary>
        [Indexed]
        public int? Parent
        {
            get { return GetPropertyValue<int?>("Parent"); }
            set { SetPropertyValue("Parent", value); }
        }
        
        /// <summary> Gets or set the name </summary>
        [Size(200)]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", StringsHelper.EnsureMaximumLength(value, 200)); }
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

        /// <summary> Gets or sets the sort order </summary>
        public int SortOrder
        {
            get { return GetPropertyValue<int>("SortOrder"); }
            set { SetPropertyValue("SortOrder", value); }
        }

        public override bool AllowDelete => false;

        /// <summary> Safe deletes object </summary>
        public override bool SafeDelete()
        {
            DeletionMark = true;
            DeletedOn = DateTime.Now;
            Save();
            return true;
        }

        public Room GetParent()
        {
            return Session.GetObjectByKey<Room>(Parent);
        }
    }
}
