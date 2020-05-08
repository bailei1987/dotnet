namespace BL.StandardDictionary
{
    /// <summary>
    ///JYT1001 考核类别代码 本代码引自GB/T 14946.1-2009 附录A.18
    /// </summary>
    public class DicExamCheckType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","平时考核"),
                new DicItem("2","年度考核"),
                new DicItem("3","特定考核"),
            };
            
        }
    }
}
