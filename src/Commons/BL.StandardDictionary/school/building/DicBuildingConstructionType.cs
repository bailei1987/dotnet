namespace BL.StandardDictionary
{
    /// <summary>
    /// JZWJG 建筑物结构代码 JT1001
    /// </summary>
    public class DicBuildingConstructionType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","土木结构"),
                new DicItem("2","砖木结构"),
                new DicItem("3","砖混结构"),
                new DicItem("4","框架结构"),
                new DicItem("5","钢架结构"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
