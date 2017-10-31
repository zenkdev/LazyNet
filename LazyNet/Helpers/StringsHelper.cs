using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Dekart.LazyNet.Helpers
{
    public static class StringsHelper
    {
        public static string AppendToString(string buffer, string append)
        {
            if (string.IsNullOrEmpty(buffer))
            {
                return append;
            }
            return buffer + Environment.NewLine + append;
        }

        /// <summary>
        /// Ensure that a string doesn't exceed maximum allowed length
        /// </summary>
        /// <param name="str">Input string</param>
        /// <param name="maxLength">Maximum length</param>
        /// <returns>Input string if its lengh is OK; otherwise, truncated input string</returns>
        public static string EnsureMaximumLength(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            if (str.Length > maxLength)
                return str.Substring(0, maxLength);
            return str;
        }
        public static string RemoveFromEndIfNeeded(string str, string remove)
        {
            if (str == null)
            {
                return null;
            }

            if (str.EndsWith(remove))
            {
                str = str.Substring(0, str.Length - remove.Length);
            }
            return str;
        }
        public static string DefaultIfNullOrWhiteSpace(string str, string @default)
        {
            if (string.IsNullOrWhiteSpace(str))
                return @default;
            return str;
        }
        public static string EnsureNotNull(string str)
        {
            if (str == null)
                return "";
            return str;
        }
        public static string EnumDisplayText(object value)
        {
            if (value == null)
                return string.Empty;
            var name = value.ToString();
            Type type1 = value.GetType();
            MemberInfo[] member = type1.GetMember(name);
            if (member.Length == 0)
                return name;
            var customAttributes = member[0].GetCustomAttributes(false);
            foreach (object customAttribute in customAttributes)
            {
                Type type2 = customAttribute.GetType();
                if (typeof(DisplayNameAttribute).IsAssignableFrom(type2))
                    return ((DisplayNameAttribute)customAttribute).DisplayName;
                if (type2 == typeof(DisplayAttribute))
                    return ((DisplayAttribute)customAttribute).GetName();
                if (typeof(DescriptionAttribute).IsAssignableFrom(type2))
                    return ((DescriptionAttribute)customAttribute).Description;
            }
            TypeConverter converter = TypeDescriptor.GetConverter(type1);
            return converter.ConvertToString(value);
        }
        public static string StripHTML(string html)
        {
            if (html == null) return null;

            string original = html;
            original = original.ReplaceEx("\r\n", "").ReplaceEx("\t", "");
            original = original.ReplaceEx("<br>", "\r\n").ReplaceEx("<br/>", "\r\n").ReplaceEx("<br />", "\r\n").ReplaceEx("</p>", "\r\n").ReplaceEx("</div>", "\r\n").ReplaceEx("</li>", "\r\n");
            if (original.ToLower().Contains("<body"))
            {
                original = original.Substring(original.ToLower().IndexOf("<body", StringComparison.Ordinal) + 5);
                original = original.Substring(original.IndexOf(">", StringComparison.Ordinal) + 1);
            }
            if (original.ToLower().Contains("</body>"))
            {
                original = original.Substring(0, original.ToLower().IndexOf("</body>", StringComparison.Ordinal));
            }
            return Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(original, @"<head.*?>.*?<\/head>", string.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase), @"<style.*?>.*?<\/style>", string.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase), @"<script.*?>.*?<\/script>", string.Empty, RegexOptions.Singleline | RegexOptions.IgnoreCase), "<.*?>", string.Empty, RegexOptions.Singleline).Replace("&nbsp;", " ");
        }

        static string ReplaceEx(this string original, string pattern, string replacement)
        {
            int length = 0;
            int startIndex = 0;
            int num3;
            string str = original.ToUpper();
            string str2 = pattern.ToUpper();
            int num4 = (original.Length / pattern.Length) * (replacement.Length - pattern.Length);
            var chArray = new char[original.Length + Math.Max(0, num4)];
            while ((num3 = str.IndexOf(str2, startIndex, StringComparison.Ordinal)) != -1)
            {
                for (int j = startIndex; j < num3; j++)
                {
                    chArray[length++] = original[j];
                }
                // ReSharper disable once ForCanBeConvertedToForeach
                for (int k = 0; k < replacement.Length; k++)
                {
                    chArray[length++] = replacement[k];
                }
                startIndex = num3 + pattern.Length;
            }
            if (startIndex == 0)
            {
                return original;
            }
            for (int i = startIndex; i < original.Length; i++)
            {
                chArray[length++] = original[i];
            }
            return new string(chArray, 0, length);
        }

    }
}