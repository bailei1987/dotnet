namespace BL.StandardDictionary
{
    /// <summary>
    /// GBT 4658 文化程度代码（学历码）
    /// </summary>
    public class DicEducationDeep:DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","研究生教育"),
                new DicItem("11","博士研究生毕业"),
                new DicItem("12","博士研究生结业"),
                new DicItem("13","博士研究生肄业"),
                new DicItem("14","硕士研究生毕业"),
                new DicItem("15","硕士研究生结业"),
                new DicItem("16","硕士研究生肄业"),
                new DicItem("17","研究生班毕业"),
                new DicItem("18","研究生班结业"),
                new DicItem("19","研究生班肄业"),
                new DicItem("20","大学本科"),
                new DicItem("21","大学本科毕业"),
                new DicItem("22","大学本科结业"),
                new DicItem("23","大学本科肄业"),
                new DicItem("28","大学普通班毕业"),
                new DicItem("30","专科教育"),
                new DicItem("31","大学专科毕业"),
                new DicItem("32","大学专科结业"),
                new DicItem("33","大学专科肄业"),

                new DicItem("40","中等职业教育"),
                new DicItem("41","中等专科毕业"),
                new DicItem("42","中等专科结业"),
                new DicItem("43","中等专科肄业"),
                new DicItem("44","职业高中毕业"),
                new DicItem("45","职业高中结业"),
                new DicItem("46","职业高中肄业"),
                new DicItem("47","技工学校毕业"),
                new DicItem("48","技工学校结业"),
                new DicItem("49","技工学校肄业"),

                new DicItem("60","普通高级中学教育"),
                new DicItem("61","普通高中毕业"),
                new DicItem("62","普通高中结业"),
                new DicItem("63","普通高中肄业"),

                new DicItem("70","初级中等教育"),
                new DicItem("71","初中毕业"),
                new DicItem("73","初中肄业"),

                new DicItem("80","小学教育"),
                new DicItem("81","小学毕业"),
                new DicItem("83","小学肄业"),

                new DicItem("90","其他"),
            };
            
        }
    }
}
