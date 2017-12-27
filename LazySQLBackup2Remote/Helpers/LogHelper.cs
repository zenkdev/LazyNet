using System;
using System.IO;
using System.Text;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public static class LogHelper
    {
        private static readonly StringBuilder LogBuilder = new StringBuilder();

        public static int LogLength => LogBuilder.Length;

        public static event TextChangedEventHandler TextChanged;

        public static string GetContent()
        {
            return LogBuilder.ToString();
        }

        public static void WriteLine(string str)
        {
            LogBuilder.AppendLine(str);
            TextChanged?.Invoke(str);
        }

        public static void InsertText(int index, string str)
        {
            LogBuilder.Insert(index, str);
            TextChanged?.Invoke(str);
        }

        public static void WriteError(Exception exception)
        {
            var str = $"{DateTime.Now:G} {exception.Message}";
            LogBuilder.AppendLine(str);
            TextChanged?.Invoke(str);
        }

        public static void SaveToFile()
        {
            try
            {
                var path = WinHelper.GetDataDirectory() + "\\" + WinHelper.AppName + "_log.txt";
                string prev = null;
                if (File.Exists(path))
                {
                    prev = Environment.NewLine + Environment.NewLine + File.ReadAllText(path);
                }
                File.WriteAllText(path, LogBuilder + prev);
                LogBuilder.Length = 0;
            }
            catch (Exception ex)
            {
                WinHelper.LogException(ex);
            }
        }
    }

    public delegate void TextChangedEventHandler(string text);

}
