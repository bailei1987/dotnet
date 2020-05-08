namespace BL.StandardDictionary
{
    ///中职专用
    /// <summary>
    ///JZJSGW 兼职教师岗位 JYT1005
    /// </summary>
    public class DicTeacherParttimeHireDuty : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","日常教学"),
                new DicItem("2","科研工作"),
                new DicItem("3","实习指导"),
                new DicItem("4","管理工作"),
            };
            
        }
    }
}
