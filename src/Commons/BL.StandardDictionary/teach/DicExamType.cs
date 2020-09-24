namespace BL.StandardDictionary
{
    /// <summary>
    /// KCSX 考试属性代码 JYT1005
    /// </summary>
    public class DicExamType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("Normal","平时考试"),
                new DicItem("Middle","期中考试"),
                new DicItem("End","期末考试"),
                new DicItem("Other","其他考试")             
            };
            
        }
    }
}
