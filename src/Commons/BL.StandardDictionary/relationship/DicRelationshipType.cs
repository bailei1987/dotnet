namespace BL.StandardDictionary
{
    public class DicRelationshipType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","父"),
                new DicItem("2","母"),
                new DicItem("3","父母"),
                new DicItem("4","其他")
            };
        }
    }
}
