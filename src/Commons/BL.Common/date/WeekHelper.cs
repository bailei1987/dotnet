namespace BL.Common.Date
{
    public static class WeekHelper
    {
        public static string GetDayName(int day, int type = 1)
        {
            string pre = type == 1 ? "周" : "星期";
            string name = day switch
            {
                1 => "一",
                2 => "二",
                3 => "三",
                4 => "四",
                5 => "五",
                6 => "六",
                0 => type == 1 ? "日" : "天",
                _ => "错误"
            };
            return pre + name;
        }
    }
}
