namespace BL.Common
{
    public class IdRidNameItem : IGetReferenceItem
    {
        public IdRidNameItem() { }
        public string Id { get; set; }
        public string Rid { get; set; }
        public string Name { get; set; }
        public ReferenceItem GetReferenceItem()
        {
            return new(Rid, Name);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
