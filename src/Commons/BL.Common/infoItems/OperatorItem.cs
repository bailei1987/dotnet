using System;

namespace BL.Common
{

    public class OperatorItem : ReferenceItem
    {
        public OperatorItem() { }
        public OperatorItem(string rid, string name) : base(rid, name) { }
        public DateTime? Time { get; set; }
    }
}
