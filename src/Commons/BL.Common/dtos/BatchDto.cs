using System.Collections.Generic;

namespace BL.Common
{
    public class ListDto<T>
    {
        public List<T> Items { get; set; } = new List<T>();
    }
    public class BatchDto<T>: ListDto<T>
    {
        public OperatorItem User { get; set; }
    }
}
