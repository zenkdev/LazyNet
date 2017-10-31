using System.Drawing;
using Dekart.LazyNet.Converters;
using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    public class WinFormProperty : ExtendedXPBaseObject
    {
        User _createdBy;

        /// <summary>ctor</summary>
        public WinFormProperty(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _createdBy = Session.GetObjectByKey<User>(DataHelper.CurrentUserId);
            AllowRestoreFormLayout = true;
            AllowRestoreLayoutControlLayout = true;
            AllowRestoreGridViewLayout = true;
            DefaultEditGridViewInDetailForms = false;
            FolderPaneVisibility = FolderPaneVisibilityEnum.Normal;
            SplitterPosition = 0;
            GridSize = new Size(10, 10);
        }

        protected override void OnSavingOverride()
        {
            base.OnSavingOverride();
            if (Session.IsNewObject(this))
            {
                _createdBy = Session.GetObjectByKey<User>(DataHelper.CurrentUserId);
            }
        }

        /// <summary>
        /// WinForm property identifier
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
        /// Default skin name
        /// </summary>
        public string DefaultSkinName
        {
            get { return GetPropertyValue<string>("DefaultSkinName"); }
            set { SetPropertyValue("DefaultSkinName", value); }
        }

        /// <summary>
        /// Allow restore Form layout
        /// </summary>
        public bool AllowRestoreFormLayout
        {
            get { return GetPropertyValue<bool>("AllowRestoreFormLayout"); }
            set { SetPropertyValue("AllowRestoreFormLayout", value); }
        }

        /// <summary>
        /// Allow restore LayoutControl layout
        /// </summary>
        public bool AllowRestoreLayoutControlLayout
        {
            get { return GetPropertyValue<bool>("AllowRestoreLayoutControlLayout"); }
            set { SetPropertyValue("AllowRestoreLayoutControlLayout", value); }
        }

        /// <summary>
        /// Allow restore GridView layout
        /// </summary>
        public bool AllowRestoreGridViewLayout
        {
            get { return GetPropertyValue<bool>("AllowRestoreGridViewLayout"); }
            set { SetPropertyValue("AllowRestoreGridViewLayout", value); }
        }

        /// <summary>
        /// Default edit GridView in detail forms
        /// </summary>
        public bool DefaultEditGridViewInDetailForms
        {
            get { return GetPropertyValue<bool>("DefaultEditGridViewInDetailForms"); }
            set { SetPropertyValue("DefaultEditGridViewInDetailForms", value); }
        }

        /// <summary>
        /// Map grid size
        /// </summary>
        [ValueConverter(typeof(SizeValueConverter))]
        public Size GridSize
        {
            get { return GetPropertyValue<Size>("GridSize"); }
            set { SetPropertyValue("GridSize", value); }
        }

        public bool ShowObjectCount
        {
            get { return GetPropertyValue<bool>("ShowObjectCount"); }
            set { SetPropertyValue("ShowObjectCount", value); }
        }
        public int PreviewLineCount
        {
            get { return GetPropertyValue<int>("PreviewLineCount"); }
            set { SetPropertyValue("PreviewLineCount", value); }
        }

        public FolderPaneVisibilityEnum FolderPaneVisibility
        {
            get { return GetPropertyValue<FolderPaneVisibilityEnum>("FolderPaneVisibility"); }
            set { SetPropertyValue("FolderPaneVisibility", value); }
        }
        public int SplitterPosition
        {
            get { return GetPropertyValue<int>("SplitterPosition"); }
            set { SetPropertyValue("SplitterPosition", value); }
        }
    }
}
