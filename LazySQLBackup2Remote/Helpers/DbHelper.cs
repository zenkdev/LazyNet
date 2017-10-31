using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Dapper;
using Dekart.LazyNet.SQLBackup2Remote.Models;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public static class DbHelper
    {
        public static List<string> GetDataSources()
        {
            var dataSources = new List<string>();
            var dataTable = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in dataTable.Rows)
            {
                var dataSource = row["ServerName"].ToString();
                if (row["InstanceName"] != DBNull.Value && !string.IsNullOrEmpty((string)row["InstanceName"]))
                    dataSource += "\\" + row["InstanceName"];
                dataSources.Add(dataSource);
            }

            return dataSources;
        }

        public static SqlConnection GetNewOpenConnection(JobData job)
        {
            return GetNewOpenConnection(job.ServerName, job.IntegratedSecurity, job.UserName, job.Password);
        }

        public static SqlConnection GetNewOpenConnection(string serverName, bool integratedSecurity, string userName, string password)
        {
            var builder = new SqlConnectionStringBuilder();
            if (serverName != null) builder.DataSource = serverName;
            builder.IntegratedSecurity = integratedSecurity;
            if (userName != null) builder.UserID = userName;
            if (password != null) builder.Password = password;
            builder.ApplicationName = ConstStrings.ApplicationCaption;

            var conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            return conn;
        }

        public static List<string> GetDatabaseNames(bool showSystemDatabases, SqlConnection cn)
        {
            var flag = cn.State == ConnectionState.Open;
            if (!flag)
            {
                cn.Open();
            }

            var databases = new List<string>();
            var cmd = new SqlCommand("SELECT name FROM sys.databases", cn);
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var db = rdr.GetString(0);
                if (showSystemDatabases || !db.IsSystemDatabase())
                {
                    databases.Add(db);
                }
            }
            rdr.Close();

            if (!flag)
            {
                cn.Close();
            }

            return databases;
        }

        public static string GetBackupDirectory(SqlConnection cn)
        {
            var flag = cn.State == ConnectionState.Open;
            if (!flag)
            {
                cn.Open();
            }

            var cmd = new SqlCommand("master.dbo.xp_instance_regread", cn) { CommandType = CommandType.StoredProcedure };
            var p1 = new SqlParameter("@rootkey", SqlDbType.NVarChar, 128) { Value = "HKEY_LOCAL_MACHINE" };
            var p2 = new SqlParameter("@key", SqlDbType.NVarChar, 128) { Value = @"Software\Microsoft\MSSQLServer\MSSQLServer" };
            var p3 = new SqlParameter("@value_name", SqlDbType.NVarChar, 128) { Value = "BackupDirectory" };
            var p4 = new SqlParameter("@value", SqlDbType.NVarChar, 128) { Direction = ParameterDirection.Output };
            cmd.Parameters.AddRange(new[] { p1, p2, p3, p4 });
            cmd.ExecuteNonQuery();

            var backupDirectory = (string)p4.Value;

            if (!flag)
            {
                cn.Close();
            }

            return backupDirectory;
        }

        public static ObservableCollection<BackupHistoryViewModel> GetBackupHistory(SqlConnection cn, string database)
        {
            var flag = cn.State == ConnectionState.Open;
            if (!flag)
            {
                cn.Open();
            }

            var backupHistory = cn.Query<BackupHistoryViewModel>(@"
--------------------------------------------------------------------------------- 
--Database Backups for all databases For Previous Week 
--------------------------------------------------------------------------------- 
SELECT 
msdb.dbo.backupset.name AS [Name],
CONVERT(NVARCHAR(100), SERVERPROPERTY('Servername')) AS [Server],
msdb.dbo.backupset.database_name AS [DatabaseName], 
msdb.dbo.backupset.backup_start_date AS [StartDate], 
msdb.dbo.backupset.backup_finish_date AS [FinishDate], 
msdb.dbo.backupset.expiration_date AS [ExpirationDate],
msdb.dbo.backupset.type AS [Type],
msdb.dbo.backupset.backup_size AS [BackupSize], 
msdb.dbo.backupset.compressed_backup_size AS [CompressedBackupSize], 
msdb.dbo.backupmediafamily.logical_device_name AS [LogicalDeviceName], 
msdb.dbo.backupmediafamily.physical_device_name AS [PhysicalDeviceName], 
msdb.dbo.backupset.name AS [BackupsetName], 
msdb.dbo.backupset.description AS [Description],
msdb.dbo.backupset.first_lsn AS [FirstLsn],
msdb.dbo.backupset.last_lsn AS [LastLsn],
msdb.dbo.backupset.checkpoint_lsn AS [CheckpointLsn],
msdb.dbo.backupset.database_backup_lsn AS [DatabaseBackupLsn]
FROM msdb.dbo.backupmediafamily 
INNER JOIN msdb.dbo.backupset ON msdb.dbo.backupmediafamily.media_set_id = msdb.dbo.backupset.media_set_id 
WHERE msdb.dbo.backupset.database_name = @database --(CONVERT(datetime, msdb.dbo.backupset.backup_start_date, 102) >= GETDATE() - 7) 
ORDER BY 
msdb.dbo.backupset.database_name, 
msdb.dbo.backupset.backup_finish_date
", new { database }).ToObservableCollection();

            if (!flag)
            {
                cn.Close();
            }

            return backupHistory;
        }

        public static ObservableCollection<DatabaseFileViewModel> GetDatabaseFiles(SqlConnection cn, string database)
        {
            var flag = cn.State == ConnectionState.Open;
            if (!flag)
            {
                cn.Open();
            }

            var databaseFiles = cn.Query<DatabaseFileViewModel>($"select * from sys.master_files where database_id = DB_ID('{database}')", new { }).ToObservableCollection();

            if (!flag)
            {
                cn.Close();
            }

            return databaseFiles;
        }

        public static bool IsSystemDatabase(this string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            return name.Equals("master", StringComparison.InvariantCultureIgnoreCase) ||
                   name.Equals("model", StringComparison.InvariantCultureIgnoreCase) ||
                   name.Equals("msdb", StringComparison.InvariantCultureIgnoreCase) ||
                   name.Equals("tempdb", StringComparison.InvariantCultureIgnoreCase);
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}