 namespace BL.StandardDictionary
{
    /// <summary>
    /// JLDWZZ 监理单位资质代码 JT1001
    /// </summary>
    public class DicSuperviseUnitAbility : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("A","甲级"),
                new DicItem("B","乙级"),
                new DicItem("C","丙级"),
                new DicItem("D","无"),
            };
            
        }
    }
}
