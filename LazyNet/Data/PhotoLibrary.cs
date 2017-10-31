using System.Drawing;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet
{
    public class PhotoLibrary : LazyNetBaseObject
    {
        public PhotoLibrary() : base(Session.DefaultSession) { }

        /// <summary>ctor</summary>
        public PhotoLibrary(Session session) : base(session) { }

        /// <summary>
        /// Gets or set name
        /// </summary>
        [Size(200)]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", StringsHelper.EnsureMaximumLength(value, 200)); }
        }

        /// <summary>
        /// Gets or set group
        /// </summary>
        [Size(200)]
        public string Group
        {
            get { return GetPropertyValue<string>("Group"); }
            set { SetPropertyValue("Group", StringsHelper.EnsureMaximumLength(value, 200)); }
        }

        [ValueConverter(typeof(ImageValueConverter))]
        public Image Photo
        {
            get { return GetPropertyValue<Image>("Photo"); }
            set { SetPropertyValue("Photo", value); }
        }
    }
}
