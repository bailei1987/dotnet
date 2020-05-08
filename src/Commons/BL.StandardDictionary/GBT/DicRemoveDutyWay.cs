namespace BL.StandardDictionary
{
    /// <summary>
    ///免职方式代码 本代码引自GB/T 14946.1-2009 附录A.9，见表A.6。
    /// </summary>
    public class DicRemoveDutyWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","落选"),
                new DicItem("2","解聘"),
                new DicItem("3","罢免"),
                new DicItem("4","届满"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
