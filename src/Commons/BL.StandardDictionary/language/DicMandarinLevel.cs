namespace BL.StandardDictionary
{
    /// <summary>
    ///PTHSPDJ 普通话水平等级 JYT1005
    /// </summary>
    public class DicMandarinLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","一级甲等"),
                new DicItem("2","一级乙等"),
                new DicItem("3","二级甲等"),
                new DicItem("4","二级乙等"),
                new DicItem("5","三级甲等"),
                new DicItem("6","三级乙等")
            };
            
        }
    }
}
