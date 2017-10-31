using System;
using DevExpress.Mvvm;

namespace Dekart.LazyNet.SQLBackup2Remote.Models
{
    public class BackupHistoryViewModel : BindableBase
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Type { get; set; }
        public decimal BackupSize { get; set; }
        public decimal CompressedBackupSize { get; set; }
        public string LogicalDeviceName { get; set; }
        public string PhysicalDeviceName { get; set; }
        public string BackupsetName { get; set; }
        public string Description { get; set; }
        public string FirstLsn { get; set; }
        public string LastLsn { get; set; }
        public string CheckpointLsn { get; set; }
        public string DatabaseBackupLsn { get; set; }

        public string BackupType
        {
            get
            {
                switch (Type)
                {
                    case "D":
                        return "Database";
                    case "I":
                        return "Incremental";
                    case "L":
                        return "Log";
                }
                return null;
            }
        }
    }
}