using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MRTwitter.Helpers
{
    public static class TextHelper
    {
        public static string PrepareDate(string date)
        {
            if (DateTime.TryParseExact(
                                       date,
                                       "ddd MMM dd HH:mm:ss zzzz yyyy",
                                       new CultureInfo("en-US"),
                                       DateTimeStyles.None,
                                       out var dateValue
                                       ))
            {
                return string.Format(
                                     "{0}{1} {2} at {3}",
                                     dateValue.ToString("dd"),
                                     dateValue.Day.ToOrdinal(),
                                     dateValue.ToString("MMM yyyy", new CultureInfo("en-US")),
                                     dateValue.ToString("h:mm tt"));
            }
            else
            {
                return string.Empty;
            }
        }

        public static string PrepareShortText(string text)
        {
            var shortText = new string(text.Take(140).ToArray());
            return FormatHyperlink(shortText);
        }
        public static string FormatHyperlink(string text)
        {
            return Regex.Replace(text,
                 @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)",
                 "<a target='_blank' href='$1'>$1</a>");
        }

        public static string ToOrdinal(this int value)
        {
            string extension = "th";

            int lastDigits = value % 100;

            if (lastDigits < 11 || lastDigits > 13)
            {
                switch (lastDigits % 10)
                {
                    case 1:
                        extension = "st";
                        break;
                    case 2:
                        extension = "nd";
                        break;
                    case 3:
                        extension = "rd";
                        break;
                }
            }

            return extension;
        }

        public static string ComputeStrings(string a, string expression, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(expression) || string.IsNullOrEmpty(b))
            {
                return null;
            }

            var dataTable = new DataTable();
            var result = a + expression + b;

            return dataTable.Compute(result, null).ToString();
        }
    }
}