namespace BL.StandardDictionary
{
    /// <summary>
    ///WJFL 文件分类代码 JYT1001
    /// </summary>
    public class DicCategoryType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","决议"),
                new DicItem("02","决定"),
                new DicItem("03","指示"),
                new DicItem("04","意见"),
                new DicItem("05","通知"),
                new DicItem("06","通报"),
                new DicItem("07","公告"),
                new DicItem("08","报告"),
                new DicItem("09","请示"),
                new DicItem("10","批复"),
                new DicItem("11","条例"),
                new DicItem("12","规定"),
                new DicItem("13","会议纪要"),
                new DicItem("14","简报"),
                new DicItem("15","函"),
                new DicItem("16","通告"),
                new DicItem("17","对外报文"),
                new DicItem("18","命令（令）"),
                new DicItem("19","公报"),
                new DicItem("20","议案"),
            };
            
        }
    }
}
