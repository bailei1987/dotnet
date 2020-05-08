namespace BL.StandardDictionary
{
    /// <summary>
    ///JYT1001  考核结论代码 本代码引自GB/T 14946.1-2009 附录A.19
    /// </summary>
    public class DicExamCheckResult : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","优秀"),
                new DicItem("2","称职"),
                new DicItem("3","基本称职"),
                new DicItem("4","不称职"),
                new DicItem("5","不确定考核等级"),
            };
            
        }
    }
}
