namespace BL.StandardDictionary
{
    /// <summary>
    /// 健康状况
    /// </summary>
    public class DicHealthState : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","健康或良好"),
                new DicItem("2","一般或较弱"),
                new DicItem("3","有慢性病"),
                new DicItem("6","残疾"),
            };
        }
    }
}
