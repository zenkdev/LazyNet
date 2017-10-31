using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Serializing;

namespace Dekart.LazyNet.SQLBackup2Remote.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    [SuppressMessage("ReSharper", "UnusedParameter.Local")]
    public class WinFormData : IXtraSerializable
    {
        private List<WinFormLayout> _layouts;

        /// <summary>
        /// Default skin name
        /// </summary>
        [XtraSerializableProperty]
        public string DefaultSkinName { get; set; }

        /// <summary>
        /// Most recent files
        /// </summary>
        [XtraSerializableProperty]
        public string MRUFiles { get; set; }

        /// <summary>
        /// Most recent folders
        /// </summary>
        [XtraSerializableProperty]
        public string MRUFolders { get; set; }

        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 1, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]
        public List<WinFormLayout> Layouts => _layouts ?? (_layouts = new List<WinFormLayout>());

        void Load(string fileName)
        {
            if (!File.Exists(fileName)) return;

            File.SetAttributes(fileName, FileAttributes.Normal);

            LoadCore(new XmlXtraSerializer(), fileName);
        }

        bool Save(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.SetAttributes(fileName, FileAttributes.Normal);
            }

            return SaveCore(new XmlXtraSerializer(), fileName);
        }

        #region IXtraSerializable Members

        void IXtraSerializable.OnEndDeserializing(string restoredVersion) { }
        void IXtraSerializable.OnEndSerializing() { }
        void IXtraSerializable.OnStartDeserializing(DevExpress.Utils.LayoutAllowEventArgs e) { }
        void IXtraSerializable.OnStartSerializing() { }

        object XtraCreateLayoutsItem(XtraItemEventArgs e)
        {
            return new WinFormLayout();
        }
        void XtraSetIndexLayoutsItem(XtraSetItemIndexEventArgs e)
        {
            Layouts.Insert(e.NewIndex, (WinFormLayout)e.Item.Value);
        }

        #endregion

        bool SaveCore(XtraSerializer serializer, object path)
        {
            var stream = path as Stream;
            if (stream != null)
                return serializer.SerializeObjects(new[] { new XtraObjectInfo("WinFormData", this) }, stream, GetType().Name);
            return serializer.SerializeObjects(new[] { new XtraObjectInfo("WinFormData", this) }, path.ToString(), GetType().Name);
        }

        void LoadCore(XtraSerializer serializer, object path)
        {
            var stream = path as Stream;
            if (stream != null)
                serializer.DeserializeObjects(new[] { new XtraObjectInfo("WinFormData", this) }, stream, GetType().Name);
            else
                serializer.DeserializeObjects(new[] { new XtraObjectInfo("WinFormData", this) }, path.ToString(), GetType().Name);
        }

        #region Static
        static WinFormData _current;

        /// <summary>
        /// Gets the current property
        /// </summary>
        public static WinFormData Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new WinFormData();
                    _current.Load(WinHelper.GetDataDirectory() + "\\" + WinHelper.AppName + "_settings.xml");
                }
                return _current;
            }
        }

        public static void LoadFormLayout(Form form)
        {
            var layout = Current.Layouts.FirstOrDefault(x => x.Name == form.Name);
            if (layout != null && !layout.FormBounds.IsEmpty)
            {
                form.Size = layout.FormBounds.Size;
                form.Location = ControlUtils.CalcFormLocation(layout.FormBounds.Location, layout.FormBounds.Size);
                form.WindowState = layout.WindowState;
            }
        }

        public static void SaveFormLayout(Form form)
        {
            var layout = Current.Layouts.FirstOrDefault(x => x.Name == form.Name);
            if (layout == null)
            {
                layout = new WinFormLayout {Name = form.Name};
                Current.Layouts.Add(layout);
            }
            layout.WindowState = form.WindowState;
            layout.FormBounds = form.WindowState == FormWindowState.Maximized ? form.RestoreBounds : form.Bounds;
        }

        /// <summary>
        /// Loads default skin
        /// </summary>
        public static void LoadDefaultSkin()
        {
            if (Current.DefaultSkinName == null) return;
            var lfName = Current.DefaultSkinName.Split('@');
            if (lfName.Length < 2) return;
            switch (lfName[0])
            {
                case "WindowsXP":
                    UserLookAndFeel.Default.SetWindowsXPStyle();
                    break;
                case "Office2003":
                    UserLookAndFeel.Default.SetOffice2003Style();
                    break;
                case "Flat":
                    UserLookAndFeel.Default.SetFlatStyle();
                    break;
                case "Style3D":
                    UserLookAndFeel.Default.SetStyle3D();
                    break;
                case "UltraFlat":
                    UserLookAndFeel.Default.SetUltraFlatStyle();
                    break;
                default:
                    UserLookAndFeel.Default.SetSkinStyle(lfName[1]);
                    break;
            }
        }

        /// <summary>
        /// Saves default properties
        /// </summary>
        public static void SaveDefaultProperties(MRUArrayList mruFiles, MRUArrayList mruFolders)
        {
            SaveDefaultSkin();
            Current.MRUFiles = SaveMostRecentFiles(mruFiles);
            Current.MRUFolders = SaveMostRecentFiles(mruFolders);
            Current.Save(WinHelper.GetDataDirectory() + "\\" + WinHelper.AppName + "_settings.xml");
        }

        static void SaveDefaultSkin()
        {
            Current.DefaultSkinName = $"{UserLookAndFeel.Default.ActiveStyle}@{UserLookAndFeel.Default.ActiveSkinName}";
        }

        static string SaveMostRecentFiles(MRUArrayList arList)
        {
            var sw = new StringWriter();
            for (var i = 0; i < arList.Count; i++) sw.WriteLine("{0},{1}", arList[i], arList.GetLabelChecked(arList[i].ToString()));
            sw.Close();
            return sw.ToString();
        }

        #endregion
    }

    public class WinFormLayout
    {
        [XtraSerializableProperty]
        public string Name { get; set; }

        [XtraSerializableProperty]
        public FormWindowState WindowState { get; set; }

        [XtraSerializableProperty]
        public Rectangle FormBounds { get; set; }
    }
}