namespace BL.StandardDictionary
{
    /// <summary>
    /// XFNHDJ 消防耐火等级代码 JYT1001
    /// </summary>
    public class DicFireControlLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","一级"),
                new DicItem("2","二级"),
                new DicItem("3","三级"),
                new DicItem("4","四级"),
            };
            
        }
    }
}
