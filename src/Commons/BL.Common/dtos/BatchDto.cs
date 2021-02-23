using System.Collections.Generic;

namespace BL.Common
{
    public class ListDto<T>
    {
        public List<T> Items { get; set; } = new();
    }
    public class BatchDto<T> : ListDto<T>
    {
        public OperatorItem User { get; set; }
    }
}
