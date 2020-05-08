namespace BL.StandardDictionary
{
    /// <summary>
    /// WWJZDJ 文物建筑等级 JT1001
    /// </summary>
    public class DicBuildingCulturalLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("A","全国重点文物保护单位"),
                new DicItem("B","省级文物保护单位"),
                new DicItem("C","市县级文物保护单位"),
                new DicItem("D","尚未核定公布单位的文物"),
                new DicItem("X","非文物建筑"),
            };
            
        }
    }
}
