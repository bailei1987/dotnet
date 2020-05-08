namespace BL.StandardDictionary
{
    /// <summary>
    ///当前任职状态代码 本代码引自GB/T 14946.1-2009 附录A.8，见表A.5。
    /// </summary>
    public class DicTakeDutyStatus : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","不在任"),
                new DicItem("2","在任"),
            };
            
        }
    }
}
