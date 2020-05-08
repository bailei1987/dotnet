namespace BL.StandardDictionary
{
    /// <summary>
    ///CQSHJZHXSTTZWYY 辞去社会兼职或学术团体职务原因 JYT1001
    /// </summary>
    public class DicResignReason : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","任职期满"),
                new DicItem("2","工作调动"),
                new DicItem("3","换届改选"),
                new DicItem("4","离退休"),
                new DicItem("5","健康原因"),
                new DicItem("6","辞职"),
                new DicItem("7","免职"),
                new DicItem("8","处分"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
