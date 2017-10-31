using System;
using System.IO;
using System.Text;

namespace Dekart.LazyNet.Helpers
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

        public static void WriteLine(string str, bool saveToFile = false)
        {
            LogBuilder.AppendLine(str);
            TextChanged?.Invoke(str);
            if (saveToFile)
            {
                SaveToFile();
            }
        }

        public static void WriteToFile(string filename, string contents)
        {
            try
            {
                var path = WinHelper.GetDataDirectory() + "\\" + filename;
                File.WriteAllText(path, contents);
            }
            catch (Exception ex)
            {
                WinHelper.LogException(ex);
            }
        }

        public static void InsertText(int index, string str)
        {
            LogBuilder.Insert(index, str);
            TextChanged?.Invoke(str);
        }

        public static void WriteError(Exception exception, bool saveToFile = false)
        {
            var str = $"{DateTime.Now:G} {exception.Message}";
            LogBuilder.AppendLine(str);
            TextChanged?.Invoke(str);
            if (saveToFile)
            {
                SaveToFile();
            }
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
