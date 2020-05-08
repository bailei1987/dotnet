namespace BL.StandardDictionary
{
    /// <summary>
    /// 编制类别代码 JT1001-BZLB
    /// </summary>
    public class DicScheduleType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","教学类"),
                new DicItem("20","行政类"),
                new DicItem("30","教辅类"),
                new DicItem("40","工勤类"),
                new DicItem("50","科研类"),
                new DicItem("60","校办企业类"),
                new DicItem("70","附设机构类"),
                new DicItem("99","其他类")
            };
            
        }
    }
}
