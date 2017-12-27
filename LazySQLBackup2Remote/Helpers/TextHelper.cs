using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public static class TextHelper
    {
        public static string StripHTML(string html)
        {
            var original = html;
            original = original.ReplaceEx("<br>", "\r\n").ReplaceEx("<br/>", "\r\n").ReplaceEx("<br />", "\r\n").ReplaceEx("</p>", "\r\n").ReplaceEx("</div>", "\r\n");
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
            int num3;
            var length = 0;
            var startIndex = 0;
            var str = original.ToUpper();
            var str2 = pattern.ToUpper();
            var num4 = (original.Length / pattern.Length) * (replacement.Length - pattern.Length);
            var chArray = new char[original.Length + Math.Max(0, num4)];
            while ((num3 = str.IndexOf(str2, startIndex, StringComparison.Ordinal)) != -1)
            {
                for (var j = startIndex; j < num3; j++)
                {
                    chArray[length++] = original[j];
                }
                foreach (var t in replacement)
                {
                    chArray[length++] = t;
                }
                startIndex = num3 + pattern.Length;
            }
            if (startIndex == 0)
            {
                return original;
            }
            for (var i = startIndex; i < original.Length; i++)
            {
                chArray[length++] = original[i];
            }
            return new string(chArray, 0, length);
        }

        /// <summary>
        /// Вставляет заданный разделитель между элементами массива
        /// создавая одну сцепленную строку. Пустые элементы игнорируются.
        /// </summary>
        /// <returns>Строка состоящая из элементов value, перемежаемых строками separator.</returns>
        public static string Join(string separator, params string[] value)
        {
            var arr = new List<string>(value);
            arr.RemoveAll(String.IsNullOrWhiteSpace);
            return String.Join(separator, arr.ToArray());
        }

        /// <summary>
        /// Вставляет заданный разделитель между элементами массива
        /// создавая одну сцепленную строку. Пустые элементы игнорируются.
        /// </summary>
        /// <returns>Строка состоящая из элементов value, перемежаемых строками separator.</returns>
        public static string Join(string separator, IEnumerable<string> value)
        {
            var arr = new List<string>(value);
            arr.RemoveAll(string.IsNullOrEmpty);
            return string.Join(separator, arr.ToArray());
        }

        /// <summary>
        /// Convert enum for front-end
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Converted string</returns>
        public static string ConvertEnum(string str)
        {
            var result = string.Empty;
            var letters = str.ToCharArray();
            foreach (var c in letters)
                if (c.ToString() != c.ToString().ToLower())
                    result += (result.Length > 0 ? " " : "") + c;
                else
                    result += c.ToString();
            return result;
        }
    }
}
