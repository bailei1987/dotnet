namespace BL.StandardDictionary
{
    /// <summary>
    /// 学生获奖类别(性质)(JYT1001-XSHJLB)
    /// </summary>
    public class DicAwardType_Student : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","学科获奖"),
                new DicItem("2","科技获奖"),
                new DicItem("3","文艺获奖"),
                new DicItem("4","体育获奖"),
                new DicItem("5","综合获奖"),
                new DicItem("6","社会工作获奖"),
                new DicItem("7","公益事业获奖"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
