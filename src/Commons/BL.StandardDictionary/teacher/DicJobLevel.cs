namespace BL.StandardDictionary
{
    /// <summary>
    /// 岗位等级(目前待定，先用文本)
    /// </summary>
    public class DicJobLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","一级"),
                new DicItem("2","二级"),
                new DicItem("3","三级"),
                new DicItem("4","四级"),
                new DicItem("5","五级"),               
                new DicItem("6","六级"),
                new DicItem("7","七级"),
                new DicItem("8","八级"),
                new DicItem("9","九级"),
                new DicItem("10","十级"),
                new DicItem("11","十一级"),
                new DicItem("12","十二级"),
                new DicItem("13","十三级"),
                new DicItem("14","未定级")
            };
        }
    }
}
