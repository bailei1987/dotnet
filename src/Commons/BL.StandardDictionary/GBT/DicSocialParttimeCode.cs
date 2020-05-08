namespace BL.StandardDictionary
{
    /// <summary>
    ///社会兼职代码 本代码引自GB/T 12408-1990，见表B.40。
    ///仅取了主要部分
    /// </summary>
    public class DicSocialParttimeCode : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","人大"),
                new DicItem("02","政协"),
                new DicItem("04","民革"),
                new DicItem("05","民盟"),
                new DicItem("06","民建"),
                new DicItem("07","民进"),
                new DicItem("08","农工党"),
            };
            
        }
    }
}
