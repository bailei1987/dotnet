using System;
using System.Reflection;

namespace BL.Common
{
    public class YMNumber: IFill
    {
        public YMNumber() { }
        public YMNumber(int y, int m) { Y = y; M = m; }
        public int? Y { get; set; }
        public int? M { get; set; }
        public string Str { get; set; }
        public string Format { get; set; }
        public string FormatStr
        {
            get
            {
                if (Y != null) return Y.ToString() + (Format ?? "/") + (M == null ? null : M < 10 ? "0" + M.ToString() : M.ToString());
                else return null;
            }
        }
        public override string ToString()
        {
            if (M is null) return Convert.ToString(Y);
            if (Y is null) return Convert.ToString(M);
            return (Y * 100 + M).ToString();
        }
        public string Fill(object sourceValue)
        {
            Str = sourceValue?.ToString();
            return FillByStr();
        }

        public static YMNumber Parse(string value, string format = null)
        {
            YMNumber ym;
            if (string.IsNullOrWhiteSpace(value)) return null;
            else if (value.Length == 6 && int.TryParse(value, out int date))
            {
                ym = new YMNumber
                {
                    Y = date / 100,
                    M = date % 100,
                    Format = format
                };
                ym.Str = (ym.Y * 100 + ym.M).ToString();
                return ym;
            }
            else if (value.Length == 4 && int.TryParse(value, out int year))
            {
                ym = new YMNumber
                {
                    Y = year,
                    Format = format
                };
                ym.Str = value;
                return ym;
            }
            else return null;
        }

        /*
        public static string Fill(object obj, PropertyInfo prop, object sourceValue)
        {
            string valueStr = sourceValue?.ToString();
            YMNumber ym = new YMNumber() { Str = valueStr };
            if (string.IsNullOrWhiteSpace(valueStr)) { }
            else if (valueStr.Length == 6)
            {
                if (int.TryParse(valueStr, out int date))
                {
                    ym.Y = date / 100;
                    ym.M = date % 100;
                    ym.Str = (ym.Y * 100 + ym.M).ToString();
                }
            }
            else if (valueStr.Length == 4)
            {
                if (int.TryParse(valueStr, out int year))
                {
                    ym.Y = year;
                }
            }
            else
            {
                valueStr = valueStr.Replace("&", "-").Replace(" ", "-").Replace(".", "-").Replace(",", "-").Replace("/", "-").Replace("\\", "-").Replace("|", "-");
                if (DateTime.TryParse(valueStr, out DateTime date))
                {
                    ym.Y = date.Year;
                    ym.M = date.Month;
                    ym.Str = (ym.Y * 100 + ym.M).ToString();
                }
            }
            prop.SetValue(obj, ym);
            if (ym.Y == null || ym.M == null) return "值[" + sourceValue + "]转换年月失败";
            else return null;
        }
        */
        public string FillByStr()
        {
            if (string.IsNullOrWhiteSpace(Str)) return "值不能为空";
            if (DateTime.TryParse(Str, out DateTime dtValue))
            {
                Y = dtValue.Year;
                M = dtValue.Month;
                return null;
            }
            if (Str.Length == 8 && int.TryParse(Str, out int intValue))
            {
                Y = intValue / 10000;
                M = intValue % 10000 / 100;
                return null;
            }
            if (Str.Length == 6)
            {
                if (int.TryParse(Str, out int date))
                {
                    Y = date / 100;
                    M = date % 100;
                    Str = (Y * 100 + M).ToString();
                }
                return null;
            }
            else if (Str.Length == 4)
            {
                if (int.TryParse(Str, out int year))
                {
                    Y = year;
                }
                return null;
            }
            else
            {
                Str = Str.Replace("&", "-").Replace(" ", "-").Replace(".", "-").Replace(",", "-").Replace("/", "-").Replace("\\", "-").Replace("|", "-");
                if (DateTime.TryParse(Str, out DateTime date))
                {
                    Y = date.Year;
                    M = date.Month;
                    Str = (Y * 100 + M).ToString();
                }
                return null;
            }
        }
    }
}
