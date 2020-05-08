namespace BL.StandardDictionary
{
    /// <summary>
    /// SGTZSCZZ 施工图纸审查资质代码 JT1001
    /// </summary>
    public class DicExecuteGraphCheckUnitAbility : DicItem
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
