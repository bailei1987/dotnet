namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001 纪律处分代码 本代码引自GB/T 8563.3-2005，
    /// 仅添加了主要的
    /// </summary>
    public class DicPunishmentCode : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","国家公务员纪律处分"),
                new DicItem("10","警告"),
                new DicItem("12","记过"),
                new DicItem("13","记大过"),
                new DicItem("14","降级"),
                new DicItem("17","撤职"),
                new DicItem("19","开除"),
                new DicItem("2","企业职工纪律处分"),
                new DicItem("20","警告"),
                new DicItem("22","记过"),
                new DicItem("23","记大过"),
                new DicItem("24","降级"),
                new DicItem("27","撤职"),
                new DicItem("28","留用察看"),
                new DicItem("29","开除"),
                new DicItem("3","中国人民解放军军人纪律处分"),
                new DicItem("30","警告"),
                new DicItem("31","严重警告"),
                new DicItem("32","记过"),
                new DicItem("33","记大过"),
                new DicItem("34","降一级"),
                new DicItem("35","降二级"),
                new DicItem("36","降职"),
                new DicItem("37","撤职"),
                new DicItem("39","开除军籍"),
                new DicItem("4","中国共产主义青年团团员纪律处分"),
                new DicItem("40","警告"),
                new DicItem("41","严重警告"),
                new DicItem("47","撤销团内职务"),
                new DicItem("48","留团察看"),
                new DicItem("49","开除团籍"),
                new DicItem("5","中国共产党党员纪律处分"),
                new DicItem("50","警告"),
                new DicItem("51","严重警告"),
                new DicItem("57","撤销党内职务"),
                new DicItem("58","留党察看"),
                new DicItem("59","开除党籍"),
            };
            
        }
    }
}
