namespace BL.StandardDictionary
{
    /// <summary>
    /// JXJLX 奖学金类型代码 JYT1001
    /// </summary>
    public class DicScholarshipType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","国家奖助类"),
                new DicItem("02","综合优秀类"),
                new DicItem("03","学业优秀类"),
                new DicItem("04","科技创新类"),
                new DicItem("05","学术竞赛优胜类"),
                new DicItem("06","艺术杰出类"),
                new DicItem("07","体育优胜类"),
                new DicItem("08","社会实践优秀类"),
                new DicItem("09","社会工作优秀类"),
                new DicItem("10","自立自强逆境成才类"),
                new DicItem("11","杰出志愿者类"),
                new DicItem("12","学习进步突出类"),
                new DicItem("13","少数民族优秀学生类"),
                new DicItem("14","港澳台侨优秀学生类"),
                new DicItem("15","优秀新生类"),
                new DicItem("30","来华留学生奖学金"),
                new DicItem("31","中国政府奖学金"),
                new DicItem("32","外国汉语教师短期研修奖学金"),
                new DicItem("33","HSK 优胜者奖学金"),
                new DicItem("34","中华文化研究奖学金"),
                new DicItem("35","长城奖学金"),
                new DicItem("36","优秀生奖学金"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
