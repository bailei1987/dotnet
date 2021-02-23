using System.Collections.Generic;

namespace BL.Common
{
    public class PageResult
    {
        public static PageResult<T> Wrap<T>(long? total, IEnumerable<T> list)
        {
            return new(total, list);
        }
        public static PageResult<dynamic> WrapDynamic(long? total, IEnumerable<dynamic> list)
        {
            return new(total, list);
        }
    }
    public class PageResult<T>
    {
        public PageResult(long? total, IEnumerable<T> list)
        {
            Total = total != null ? (long)total : 0;
            List = list;
        }
        public long Total { get; set; }
        public IEnumerable<T> List { get; set; }

    }
}
