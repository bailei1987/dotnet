namespace BL.StandardDictionary
{
    /// <summary>
    /// 政治面貌
    /// </summary>
    public class DicPoliticStatus : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[] {
                new DicItem("1","群众"),
                new DicItem("2","中国共产党预备党员"),
                new DicItem("3","中国共产主义青年团团员"),
                new DicItem("4","中国国民党革命委员会会员"),
                new DicItem("5","中国民主同盟盟员"),
                new DicItem("6","中国民主建国会会员"),
                new DicItem("7","中国民主促进会会员"),
                new DicItem("8","中国农工民主党党员"),
                new DicItem("9","中国致公党党员"),
                new DicItem("10","九三学社社员"),
                new DicItem("11","台湾民主自治同盟盟员"),
                new DicItem("12","无党派民主人士"),
                new DicItem("13","中国共产党党员"),
            };
            
        }
    }
}
