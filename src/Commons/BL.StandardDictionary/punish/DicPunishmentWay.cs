namespace BL.StandardDictionary
{
    /// <summary>
    /// 处分方式(名称)(JYT1001-CFMC)
    /// </summary>
    public class DicPunishmentWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","警告"),
                new DicItem("2","严重警告"),
                new DicItem("3","记过"),
                new DicItem("4","留校察看"),
                new DicItem("6","开除学籍"),
                new DicItem("9","其他")
            };
            
        }
    }
}
