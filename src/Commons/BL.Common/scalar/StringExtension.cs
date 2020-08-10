using System;

namespace BL.Common
{
    public static class StringExtension
    {
        public static string ToCamel(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        /// <summary>
        /// get DateTime? from string,support string value as '2020/10/01,2020-10-01,20201001,2020.10.01'
        /// </summary>
        /// <param name="s">string value</param>
        /// <param name="force">if is true,will throw Exception when can not be converted.is is false,will return null when can not be converted</param>
        /// <exception cref="FormatException"></exception>
        public static DateTime? ToDateTime(this string value, bool force = true)
        {
            value = value.Replace("/", "-").Replace(".", "-").Replace("。", "-").Replace(",", "-").Replace(" ", "-").Replace("|", "-");
            if (value.Split("-").Length == 1)
            {
                if (value.Length == 8) value = string.Join("-", value.Substring(0, 4), value.Substring(4, 2), value.Substring(6, 2));
            }
            if (DateTime.TryParse(value, out DateTime date) == false)
            {
                if (force) throw new Exception("string format is not correct,must like:2020/10/01,2020-10-01,20201001,2020.10.01");
                else return null;
            }
            else return date;
        }

        /// <summary>
        /// deal value to DateTime format,example:change 20180506 to 2018-05-06
        /// </summary>
        /// <exception cref="FormatException"></exception>
        public static string ToDateTimeFormat(this string value, bool force = true)
        {
            value = value.Replace("/", "-").Replace(".", "-").Replace("。", "-").Replace(",", "-").Replace(" ", "-").Replace("|", "-");
            if (value.Split("-").Length == 1)
            {
                if (value.Length == 8) value = string.Join("-", value.Substring(0, 4), value.Substring(4, 2), value.Substring(6, 2));
            }
            if (DateTime.TryParse(value, out _)) return value;
            else
            {
                if (force) throw new FormatException("string format is not correct,must like:2020/10/01,2020-10-01,20201001,2020.10.01");
                else return null;
            }
        }
    }
}
