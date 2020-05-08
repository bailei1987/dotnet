namespace BL.StandardDictionary
{
    /// <summary>
    ///任职方式代码本代码引自GB/T 14946.1-2009 附录A.4，见表A.2
    /// </summary>
    public class DicTakeDutyWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","党委（党组）决定任职"),
                new DicItem("2","行政命令任职"),
                new DicItem("3","会议选举任职"),
                new DicItem("4","聘用任职"),
                new DicItem("5","考试录用任职"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
