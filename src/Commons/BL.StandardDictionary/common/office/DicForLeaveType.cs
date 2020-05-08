namespace BL.StandardDictionary
{
    /// <summary>
    /// 请假类型
    /// </summary>
    public class DicForLeaveType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("00101","事假"),
                new DicItem("00102","病假"),
                new DicItem("00103","年假"),
                new DicItem("00104","调休"),
                new DicItem("00105","婚假"),
                new DicItem("00106","产假"),
                new DicItem("00107","陪产假"),
                new DicItem("00108","其他"),
                new DicItem("00109","产检假"),
                new DicItem("00101","丧假"),
            };
            
        }
    }
}
