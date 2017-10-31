using System;
using System.IO;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet.Converters
{
    /// <summary>
    /// MemoryStream value converter
    /// </summary>
    public class MemoryStreamValueConverter : ValueConverter
    {
        public override Type StorageType { get { return typeof(byte[]); } }
        public override object ConvertFromStorageType(object val)
        {
            try
            {
                var buffer = val as byte[];
                if (buffer != null)
                {
                    var stream = new MemoryStream(buffer);
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return formatter.Deserialize(stream);
                }
            }
            catch
            {
                // ignored
            }
            return null;
        }
        public override object ConvertToStorageType(object val)
        {
            try
            {
                if (val == null) return null;
                var stream = new MemoryStream();
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, val);
                return stream.GetBuffer();
            }
            catch
            {
                // ignored
            }
            return null;
        }
    }
}
