using System;

namespace BL.Common
{
    public class OperateInfo
    {
        public OperateInfo() { }
        public OperateInfo(bool done,DateTime? time) { Done = done;Time = time; }
        public DateTime? Time { get; set; }
        public bool Done { get; set; }
    }
}
