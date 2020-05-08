namespace BL.StandardDictionary
{
    /// <summary>
    /// FJFLB 附加分类别代码 JYT1001
    /// </summary>
    public class DicAddtionalScoreType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","少数民族"),
                new DicItem("2","竞赛获奖"),
                new DicItem("3","文艺特长"),
                new DicItem("4","美术特长"),
                new DicItem("5","体育特长"),
                new DicItem("6","品学兼优"),
                new DicItem("9","其他自主认定"),
            };
            
        }
    }
}
