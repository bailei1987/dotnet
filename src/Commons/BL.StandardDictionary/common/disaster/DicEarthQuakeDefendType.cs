namespace BL.StandardDictionary
{
    /// <summary>
    /// KZSFBZ 抗震设防标准代码 JYT1001
    /// </summary>
    public class DicEarthQuakeDefendType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","特殊设防类"),
                new DicItem("2","重点设防类"),
                new DicItem("3","标准设防类"),
                new DicItem("4","适度设防类"),
            };
            
        }
    }
}
