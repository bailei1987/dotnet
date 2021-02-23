using BL.Common.Reflection;

namespace BL.Common
{
    public class IdNameItem : IGetReferenceItem
    {
        public IdNameItem() { }
        public IdNameItem(string id, string name) { Id = id; Name = name; }
        [PropertyMark("主键Id")]
        public string Id { get; set; }
        [PropertyMark("名称")]
        public string Name { get; set; }
        public IdNameItem GetIdNameItem()
        {
            return new(Id, Name);
        }
        public ReferenceItem GetReferenceItem()
        {
            return new(Id, Name);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
