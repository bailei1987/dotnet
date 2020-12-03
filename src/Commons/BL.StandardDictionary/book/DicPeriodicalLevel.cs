namespace BL.StandardDictionary.book
{
    /// <summary>
    ///KWJB 刊物级别代码 JYT1001
    /// </summary>
    public class DicPeriodicalLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","国际学术刊物"),
                new DicItem("11","国际权威学术刊物"),
                new DicItem("12","国际一般学术刊物"),
                new DicItem("19","国际其他刊物"),
                new DicItem("20","全国性学术刊物"),
                new DicItem("21","国内一级、权威、重点学术刊物"),
                new DicItem("22","国内一般学术刊物"),
                new DicItem("29","国内其他刊物"),
                new DicItem("30","省级学术刊物"),
                new DicItem("31","省级公开发行学术刊物"),
                new DicItem("39","省级公开发行其他刊物"),
                new DicItem("40","院校级学术刊物"),
                new DicItem("41","重点院校学报"),
                new DicItem("42","一般院校学报"),
                new DicItem("49","院校其他公开发行学术刊物"),
            };            
        }
    }
}
