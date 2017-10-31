using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dekart.LazyNet.Converters;
using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    /// <summary>WinForm layout</summary>
    public class WinFormLayout : ExtendedXPBaseObject
    {
        User _createdBy;

        /// <summary>ctor</summary>
        public WinFormLayout(Session session) : base(session) { }
        /// <summary>ctor</summary>
        public WinFormLayout(Session session, string name)
            : this(session)
        {
            Name = name;
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _createdBy = Session.GetObjectByKey<User>(DataHelper.CurrentUserId);
            MainView = true;
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
        /// WinForm layout identifier
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
        /// Name
        /// </summary>
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }
        /// <summary>
        /// Form bounds
        /// </summary>
        [ValueConverter(typeof(RectangleValueConverter))]
        public Rectangle FormBounds
        {
            get { return GetPropertyValue<Rectangle>("FormBounds"); }
            set { SetPropertyValue("FormBounds", value); }
        }
        /// <summary>
        /// Window state
        /// </summary>
        public FormWindowState WindowState
        {
            get { return GetPropertyValue<FormWindowState>("WindowState"); }
            set { SetPropertyValue("WindowState", value); }
        }

        /// <summary>
        /// Main LayoutControl layout
        /// </summary>
        [ValueConverter(typeof(MemoryStreamValueConverter))]
        public MemoryStream MainLayoutControlLayout
        {
            get { return GetPropertyValue<MemoryStream>("MainLayoutControlLayout"); }
            set { SetPropertyValue("MainLayoutControlLayout", value); }
        }
        /// <summary>
        /// Main ColumnView layout
        /// </summary>
        [ValueConverter(typeof(MemoryStreamValueConverter))]
        public MemoryStream MainColumnViewLayout
        {
            get { return GetPropertyValue<MemoryStream>("MainColumnViewLayout"); }
            set { SetPropertyValue("MainColumnViewLayout", value); }
        }
        /// <summary>
        /// Alternate ColumnView layout
        /// </summary>
        [ValueConverter(typeof(MemoryStreamValueConverter))]
        public MemoryStream AlternateColumnViewLayout
        {
            get { return GetPropertyValue<MemoryStream>("AlternateColumnViewLayout"); }
            set { SetPropertyValue("AlternateColumnViewLayout", value); }
        }
        /// <summary>
        /// Quick access toolbar
        /// </summary>
        [ValueConverter(typeof(MemoryStreamValueConverter))]
        public MemoryStream QuickAccessToolbar
        {
            get { return GetPropertyValue<MemoryStream>("QuickAccessToolbar"); }
            set { SetPropertyValue("QuickAccessToolbar", value); }
        }
        /// <summary>
        /// Main view
        /// </summary>
        public bool MainView
        {
            get { return GetPropertyValue<bool>("MainView"); }
            set { SetPropertyValue("MainView", value); }
        }
        /// <summary>
        /// Data pane state
        /// </summary>
        public DataPaneStateEnum DataPaneState
        {
            get { return GetPropertyValue<DataPaneStateEnum>("DataPaneState"); }
            set { SetPropertyValue("DataPaneState", value); }
        }
        /// <summary>
        /// Splitter position
        /// </summary>
        public int SplitterPosition
        {
            get { return GetPropertyValue<int>("SplitterPosition"); }
            set { SetPropertyValue("SplitterPosition", value); }
        }
    }
}
