using System;

namespace BL.Common.Date
{
    public static class WeekHelper
    {
        /// <summary>
        /// 获取一周星期对应中文名
        /// </summary>
        /// <param name="day"></param>
        /// <param name="type"> 1 ? "周" : "星期"</param>
        /// <returns>周(一至日(天))||星期(一至日(天))</returns>
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
            return $"{pre}{name}";
        }

        /// <summary>
        /// 获取一周星期对应中文名
        /// </summary>
        /// <param name="day"></param>
        /// <param name="type"> 1 ? "周" : "星期"</param>
        /// <returns>周(一至日(天))||星期(一至日(天))</returns>
        public static string GetDayName(this DayOfWeek day, int type = 1)
        {
            string pre = type == 1 ? "周" : "星期";
            string name = day switch
            {
                DayOfWeek.Monday => "一",
                DayOfWeek.Tuesday => "二",
                DayOfWeek.Wednesday => "三",
                DayOfWeek.Thursday => "四",
                DayOfWeek.Friday => "五",
                DayOfWeek.Saturday => "六",
                DayOfWeek.Sunday => type == 1 ? "日" : "天",
                _ => "错误"
            };
            return $"{pre}{name}";
        }

        /// <summary>
        /// 获取整周的星期数字形式
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static int GetDayNumber(this DayOfWeek day) => day switch
        {
            DayOfWeek.Friday => 5,
            DayOfWeek.Monday => 1,
            DayOfWeek.Saturday => 6,
            DayOfWeek.Thursday => 4,
            DayOfWeek.Tuesday => 2,
            DayOfWeek.Wednesday => 3,
            _ => 7,
        };

        public static int GetWeekNoFromPoint(DateTime point, DateTime? date)
        {
            if (date is null) date = DateTime.Now;
            if (date < point) throw new Exception("要计算的日期不能小于起始日期");
            int dayDiff = point.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)point.DayOfWeek - 1;
            var first_monday = point.AddDays(-dayDiff);
            var daysCount = (date.Value - first_monday).Days;
            var weekno = daysCount / 7 + (daysCount % 7 == 0 ? 0 : 1);
            return weekno;
        }
        public static (DateTime, DateTime) GetWeekRange(DateTime date)
        {
            date = date.Date;
            int dayDiff = date.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)date.DayOfWeek - 1;
            var monday = date.AddDays(-dayDiff);
            var sunday = monday.AddDays(6);
            return (monday, sunday);
        }
    }
}
