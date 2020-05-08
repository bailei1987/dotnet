namespace BL.StandardDictionary
{
    public class DicMarryState : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","未婚"),
                new DicItem("20","已婚"),
                new DicItem("30","丧偶"),
                new DicItem("40","离婚"),
            };
            
        }
    }
}
