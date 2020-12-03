using System.Collections.Generic;

namespace BL.BusinessLog
{
    public class BusinessLogPageResult
    {
        public static BusinessLogPageResult<T> Wrap<T>(long? total, IEnumerable<T> list)
        {
            return new BusinessLogPageResult<T>(total, list);
        }
        public static BusinessLogPageResult<dynamic> WrapDynamic(long? total, IEnumerable<dynamic> list)
        {
            return new BusinessLogPageResult<dynamic>(total, list);
        }
    }
    public class BusinessLogPageResult<T>
    {
        public BusinessLogPageResult(long? total, IEnumerable<T> list)
        {
            Total = total != null ? (long)total : 0;
            List = list;
        }
        public long Total { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}
