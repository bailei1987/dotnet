namespace BL.StandardDictionary
{
    /// <summary>
    /// 考试形式 JT1001-KSXS
    /// </summary>
    public class DicExamForm : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","考试"),
                new DicItem("2","考查"),
            };
            
        }
    }
}
