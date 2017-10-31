using System;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public class FileSizeFormatProvider : IFormatProvider, ICustomFormatter
    {
        // ReSharper disable InconsistentNaming
        const string FILE_SIZE_FORMAT = "fs";
        const decimal ONE_KILO_BYTE = 1024M;
        const decimal ONE_MEGA_BYTE = ONE_KILO_BYTE * 1024M;
        const decimal ONE_GIGA_BYTE = ONE_MEGA_BYTE * 1024M;
        // ReSharper restore InconsistentNaming

        public static FileSizeFormatProvider Default = new FileSizeFormatProvider();

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null || !format.StartsWith(FILE_SIZE_FORMAT))
            {
                return DefaultFormat(format, arg, formatProvider);
            }

            if (arg is string)
            {
                return DefaultFormat(format, arg, formatProvider);
            }

            decimal size;

            try
            {
                size = Convert.ToDecimal(arg);
            }
            catch (InvalidCastException)
            {
                return DefaultFormat(format, arg, formatProvider);
            }

            string suffix;
            if (size > ONE_GIGA_BYTE)
            {
                size /= ONE_GIGA_BYTE;
                suffix = "GB";
            }
            else if (size > ONE_MEGA_BYTE)
            {
                size /= ONE_MEGA_BYTE;
                suffix = "MB";
            }
            else if (size > ONE_KILO_BYTE)
            {
                size /= ONE_KILO_BYTE;
                suffix = "kB";
            }
            else
            {
                suffix = " B";
            }

            var precision = format.Substring(2);
            if (string.IsNullOrEmpty(precision)) precision = "2";
            var fmt = "{0:N" + precision + "}{1}";
            return string.Format(fmt, size, suffix);
        }

        static string DefaultFormat(string format, object arg, IFormatProvider formatProvider)
        {
            var formattableArg = arg as IFormattable;
            return formattableArg?.ToString(format, formatProvider) ?? arg.ToString();
        }

    }
}