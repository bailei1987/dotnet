namespace BL.StandardDictionary
{
    /// <summary>
    /// SJDWZZ 设计单位资质代码 JT1001
    /// </summary>
    public class DicDesignUnitAbility : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("A","一类"),
                new DicItem("B","二类"),
                new DicItem("C","三类"),
                new DicItem("D","无"),
            };
            
        }
    }
}
