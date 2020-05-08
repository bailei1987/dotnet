namespace BL.StandardDictionary
{
    /// <summary>
    /// GNFS 供暖方式代码 JT1001
    /// </summary>
    public class DicBuildingWarmWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","集中供热"),
                new DicItem("2","采暖锅炉"),
                new DicItem("3","地热"),
                new DicItem("4","火炉"),
                new DicItem("5","热风"),
                new DicItem("6","其他形式"),
                new DicItem("7","无采暖"),
            };
            
        }
    }
}
