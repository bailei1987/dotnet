namespace BL.StandardDictionary
{
    /// <summary>
    /// 教师培训对象(补充):新任教师,专任教师
    /// </summary>
    public class DicTeacherTrainingTarget : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","新任教师"),
                new DicItem("02","专任教师")
            };
            
        }
    }
}
