namespace BL.StandardDictionary
{
    /// <summary>
    /// 资助政策
    /// </summary>
    public class DicFundingPolicyType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]
            {
                new DicItem("01","国家资助"),
                new DicItem("02","学前教育国家资助"),
                new DicItem("03","学前教育保障机制"),
                new DicItem("04","义务教育国家资助"),
                new DicItem("05","中职国家资助"),
                new DicItem("06","普通高中国家资助"),
                new DicItem("07","高等教育国家资助"),
                new DicItem("08","寄宿生生活补助"),
                new DicItem("09","免学费"),
                new DicItem("10","国家助学金"),
                new DicItem("11","免住宿教材费"),
                new DicItem("12","建档立卡免学费"),
                new DicItem("13","国家奖学金"),
                new DicItem("14","国家励志奖学金"),
                new DicItem("15","自治区人民政府励志奖学金"),
                new DicItem("16","自治区人民政府助学金"),
                new DicItem("17","少数民族预科生学费和住宿费补助"),
                new DicItem("18","应征入伍、直招士官服义务兵役"),
                new DicItem("19","退役士兵国家资助"),
                new DicItem("20","免费师范生"),
                new DicItem("21","研究生国家奖学金"),
                new DicItem("22","研究生自治区奖学金"),
                new DicItem("23","研究生自治区学业奖学金")
            };
        }
    }
}
