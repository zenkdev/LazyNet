using System;
using System.Drawing;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet.Converters
{
    /// <summary>
    /// Rectangle value converter
    /// </summary>
    public class RectangleValueConverter : ValueConverter
    {
        public override Type StorageType { get { return typeof(string); } }
        public override object ConvertToStorageType(object val)
        {
            if (!(val is Rectangle)) return null;
            var rect = (Rectangle)val;
            return string.Format("{0}@{1}@{2}@{3}", rect.X, rect.Y, rect.Width, rect.Height);
        }
        public override object ConvertFromStorageType(object val)
        {
            var data = string.Format("{0}", val).Split('@');
            if (data.Length < 4) return null;
            return new Rectangle(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]), Convert.ToInt32(data[3]));
        }
    }
    
    /// <summary>
    /// Size value converter
    /// </summary>
    public class SizeValueConverter : ValueConverter
    {
        public override Type StorageType { get { return typeof(string); } }
        public override object ConvertToStorageType(object val)
        {
            if (!(val is Size)) return null;
            var size = (Size)val;
            return string.Format("{0}@{1}", size.Width, size.Height);
        }
        public override object ConvertFromStorageType(object val)
        {
            var data = string.Format("{0}", val).Split('@');
            if (data.Length < 2) return null;
            return new Size(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]));
        }
    }
}
