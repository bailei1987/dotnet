namespace BL.StandardDictionary
{
    /// <summary>
    /// JZWZK 建筑物状况代码 JT1001
    /// </summary>
    public class DicBuildingStatus : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","正常"),
                new DicItem("20","危房"),
                new DicItem("21","a 级危房"),
                new DicItem("22","b 级危房"),
                new DicItem("23","c 级危房"),
                new DicItem("24","d 级危房"),
                new DicItem("30","正在施工"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
