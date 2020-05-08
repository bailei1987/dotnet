namespace BL.StandardDictionary
{
    /// <summary>
    /// 宗教信仰
    /// </summary>
    public class DicFaith : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("0","无宗教信仰"),
                new DicItem("10","佛教"),
                new DicItem("20","喇嘛教"),
                new DicItem("30","道教"),
                new DicItem("40","天主教"),
                new DicItem("50","基督教"),
                new DicItem("60","东正教"),
                new DicItem("70","伊斯兰教"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
