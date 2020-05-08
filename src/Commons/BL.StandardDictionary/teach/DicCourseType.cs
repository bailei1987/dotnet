namespace BL.StandardDictionary
{
    /// <summary>
    /// KCSX 课程属性代码 JYT1005
    /// </summary>
    public class DicCourseType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","必修"),
                new DicItem("2","限选"),
                new DicItem("3","任选"),
                new DicItem("4","辅修"),
                new DicItem("5","实践"),
                new DicItem("6","双必"),
                new DicItem("7","双选"),
                new DicItem("8","通选"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
