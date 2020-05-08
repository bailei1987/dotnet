namespace BL.StandardDictionary
{
    ///中职专用
    /// <summary>
    ///KCFL 课程分类代码 JYT1005
    /// </summary>
    public class DicCourseCategory : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","文化基础课"),
                new DicItem("2","专业基础课"),
                new DicItem("3","专业课"),
                new DicItem("4","推荐选修课"),
                new DicItem("5","任意选修课"),
                new DicItem("6","课程设计与实习"),
                new DicItem("7","顶岗实习或实训"),
                new DicItem("8","社会实践"),
                new DicItem("9","军训"),
            };
            
        }
    }
}
