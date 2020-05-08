namespace BL.StandardDictionary
{
    /// <summary>
    /// PRQK 聘任情况代码表 JYT1001
    /// </summary>
    public class DicEngageResult : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","聘任"),
                new DicItem("11","已聘"),
                new DicItem("12","高聘"),
                new DicItem("13","低聘"),
                new DicItem("2","不聘"),
                new DicItem("3","缓聘"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
