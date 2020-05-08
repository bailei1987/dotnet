namespace BL.StandardDictionary
{
    /// <summary>
    /// 学生类别(JYT1001-XSLB仅取了部分)
    /// </summary>
    public class DicStudentType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","学前教育"),
                new DicItem("11","幼儿"),
                new DicItem("2","初等教育"),
                new DicItem("21","小学生"),
                new DicItem("3","中等教育"),
                new DicItem("31","初中生"),
                new DicItem("32","高中生"),
                new DicItem("33","中职学生"),
                new DicItem("34","工读学生"),
                new DicItem("4","高等教育"),
                new DicItem("41","专科生"),
                new DicItem("42","本科生"),
                new DicItem("43","研究生"),
                new DicItem("44","学位学生"),
                new DicItem("5","特殊教育"),
                new DicItem("51","特殊教育学生"),
                new DicItem("9","其他教育"),
                new DicItem("91","自考/预科/研究生课程类"),
                new DicItem("92","进修及培训类"),
                new DicItem("93","职业技术培训类"),
            };
            
        }
    }
}
