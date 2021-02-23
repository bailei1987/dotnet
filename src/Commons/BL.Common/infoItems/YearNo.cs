namespace BL.Common
{
    public class YearNoStr : YearNo
    {
        /// <summary>
        /// 存储源值(常用于导入)
        /// </summary>
        public string Str { get; set; }
        public bool Fill()
        {
            if (string.IsNullOrWhiteSpace(Str)) return false;
            if (Str.Length == 6)
            {
                if (int.TryParse(Str, out int yn) == false) return false;
                Year = yn / 100;
                No = yn % 100;
                return true;
            }
            string[] strs = Str.Split('/', '-', '_', ' ', '|');
            if (strs.Length != 2) return false;
            if (int.TryParse(strs[0], out int y) == false) return false;
            if (int.TryParse(strs[1], out int n) == false) return false;
            Year = y;
            No = n;
            return true;
        }
        public YearNo GetYearNo()
        {
            return new YearNo { Year = Year, No = No };
        }

    }
    public class YearNo : IIntegrate
    {
        public YearNo() { }
        public YearNo(int year, int no) { Year = year; No = no; }
        public int Year { get; set; }
        public int No { get; set; }

        public override string ToString()
        {
            return $"{Year}{No.ToString().PadLeft(2, '0')}";
        }

        public bool IsIntegrated()
        {
            return Year != 0 && No != 0;
        }

        public static YearNo Parse(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (value.Length == 6)
            {
                return int.TryParse(value, out int yn) == false ? null : new() { Year = yn / 100, No = yn % 100 };
            }
            string[] strs = value.Split('/', '-', '_', ' ', '|');
            return strs.Length != 2
                ? null
                : int.TryParse(strs[0], out int y) == false
                ? null
                : int.TryParse(strs[1], out int n) == false ? null : new() { Year = y, No = n };
        }
    }
}
