using BL.Common.Reflection;

namespace BL.Common
{
    public class ReferenceItem : IGetReferenceItem
    {
        public ReferenceItem() { }
        public ReferenceItem(string rid) { Rid = rid; }
        public ReferenceItem(string rid, string name) { Rid = rid; Name = name; }
        /// <summary>
        /// 标识
        /// </summary>
        [PropertyMark("引用Id")]
        public string Rid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [PropertyMark("名称")]
        public string Name { get; set; }

        public ReferenceItem GetReferenceItem()
        {
            return new(Rid, Name);
        }
        public bool Equal(ReferenceItem target)
        {
            return Rid == target.Rid;
        }
        public bool IsIntegrated()
        {
            return !string.IsNullOrWhiteSpace(Rid) && !string.IsNullOrWhiteSpace(Name);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
