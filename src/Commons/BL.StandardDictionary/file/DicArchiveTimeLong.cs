namespace BL.StandardDictionary
{
    /// <summary>
    ///DABGQX 档案保管期限代码 JYT1001
    /// </summary>
    public class DicArchiveTimeLong : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","永久"),
                new DicItem("2","长期"),
                new DicItem("21","30 年"),
                new DicItem("22","25 年"),
                new DicItem("3","短期"),
                new DicItem("31","15 年"),
                new DicItem("32","10 年"),
                new DicItem("33","5 年"),
                new DicItem("34","3 年"),
            };
            
        }
    }
}
