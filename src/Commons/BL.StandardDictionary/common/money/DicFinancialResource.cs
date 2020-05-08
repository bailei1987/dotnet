namespace BL.StandardDictionary
{
    /// <summary>
    /// JFLY 经费来源代码 JYT1001
    /// </summary>
    public class DicFinancialResource : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","财政拨款"),
                new DicItem("2","贷款"),
                new DicItem("3","自筹资金"),
                new DicItem("4","捐助"),
                new DicItem("5","集资"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
