namespace BL.StandardDictionary
{
    /// <summary>
    /// JZWPMXS 建筑物平面形式 JT1001
    /// </summary>
    public class DicBuildingHorizontalType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("11","浅基础：条形基础"),
                new DicItem("12","浅基础：筏板基础"),
                new DicItem("13","浅基础：独立基础"),
                new DicItem("14","浅基础：其他"),
                new DicItem("21","深基础：桩基础"),
                new DicItem("22","深基础：箱型基础"),
                new DicItem("23","深基础：其他"),
                new DicItem("31","其他基础形式"),
                new DicItem("41","无基础"),
            };
            
        }
    }
}
