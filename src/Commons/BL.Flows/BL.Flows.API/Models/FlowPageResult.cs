using System.Collections.Generic;

namespace BL.Flows.API.Models
{
    public class FlowPageResult
    {
        public static FlowPageResult<T> Wrap<T>(long? total, IEnumerable<T> list)
        {
            return new FlowPageResult<T>(total, list);
        }
        public static FlowPageResult<dynamic> WrapDynamic(long? total, IEnumerable<dynamic> list)
        {
            return new FlowPageResult<dynamic>(total, list);
        }
    }
    public class FlowPageResult<T>
    {
        public FlowPageResult(long? total, IEnumerable<T> list)
        {
            Total = total != null ? (long)total : 0;
            List = list;
        }
        public long Total { get; set; }
        public IEnumerable<T> List { get; set; }

    }
}
