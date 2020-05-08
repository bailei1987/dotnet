namespace BL.StandardDictionary
{
    /// <summary>
    /// JZWAQPCJL 建筑物安全排查结论 JT1001
    /// </summary>
    public class DicBuildingSafetyCheckResult : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","安全"),
                new DicItem("2","存在一般安全隐患"),
                new DicItem("3","存在重大安全隐患"),
            };
            
        }
    }
}
