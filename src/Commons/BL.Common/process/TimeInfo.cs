using System;

namespace BL.Common
{
    public class TimeInfo
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public TimeSpan? Long { get; set; }
        public double? Ms { get; set; }

        public void Begin()
        {
            Start = DateTime.Now;
        }
        public void Over()
        {
            if (Start == null) throw new Exception("Start not set");
            End = DateTime.Now;
            Long = End - Start;
            Ms = Long.Value.TotalMilliseconds;
        }
    }
}
