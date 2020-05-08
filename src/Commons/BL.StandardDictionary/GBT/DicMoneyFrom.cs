namespace BL.StandardDictionary
{
    /// <summary>
    ///JYT1001 经费来源代码 本代码引自GB/T 14946.1-2009 附录A.28
    /// </summary>
    public class DicMoneyFrom : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","国家出资"),
                new DicItem("2","单位出资"),
                new DicItem("3","外方资助"),
                new DicItem("4","自费"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
