using System.Diagnostics.CodeAnalysis;
using DevExpress.Mvvm;

namespace Dekart.LazyNet.SQLBackup2Remote.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DatabaseFileViewModel : BindableBase
    {
        public int file_id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string physical_name { get; set; }

    }
}
