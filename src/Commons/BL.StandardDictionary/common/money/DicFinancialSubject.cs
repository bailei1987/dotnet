namespace BL.StandardDictionary
{
    /// <summary>
    /// JFKM 经费科目代码 JYT1001
    /// </summary>
    public class DicFinancialSubject : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","教育事业费"),
                new DicItem("2","科研专款及基金"),
                new DicItem("3","基建设备费"),
                new DicItem("4","自筹经费"),
                new DicItem("5","世界银行贷款"),
                new DicItem("6","捐款"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
