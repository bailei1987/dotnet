namespace BL.StandardDictionary
{
    /// <summary>
    ///免职、辞职原因代码 本代码引自GB/T 14946.1-2009 附录A.10，见表A.7。
    ///仅选取了主要的
    /// </summary>
    public class DicRemoveDutyReason : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","自然免职类"),
                new DicItem("2","因故免职类"),
                new DicItem("3","撤职类"),
                new DicItem("4","降职"),
                new DicItem("9","辞职"),
            };
            
        }
    }
}
