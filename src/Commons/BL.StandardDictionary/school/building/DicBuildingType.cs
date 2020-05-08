namespace BL.StandardDictionary
{
    /// <summary>
    /// JZWFL 建筑物分类代码 JT1001
    /// </summary>
    public class DicBuildingType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","房屋建筑"),
                new DicItem("2","围墙"),
                new DicItem("3","校门"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
