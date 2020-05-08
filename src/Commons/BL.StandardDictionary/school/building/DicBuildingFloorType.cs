namespace BL.StandardDictionary
{
    /// <summary>
    /// JZWLBXS 建筑物楼板形式代码 JT1001
    /// </summary>
    public class DicBuildingFloorType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","预制"),
                new DicItem("2","现浇"),
                new DicItem("3","木板"),
                new DicItem("4","其他"),
            };
            
        }
    }
}
