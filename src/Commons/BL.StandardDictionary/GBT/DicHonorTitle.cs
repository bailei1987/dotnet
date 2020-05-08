namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001 荣誉称号代码（GB/T 8563.2-2005 表2）
    /// 仅添加了主要的
    /// </summary>
    public class DicHonorTitle : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","特级劳动模范"),
                new DicItem("02","劳动模范"),
                new DicItem("03","劳动英雄"),
                new DicItem("04","先进工作者"),
                new DicItem("05","优秀共产党员"),
                new DicItem("06","优秀工会工作者"),
                new DicItem("07","优秀工会积极分子"),
                new DicItem("08","技术协作能手"),
                new DicItem("09","新长征突击手"),
                new DicItem("10","优秀共青团员干部"),
                new DicItem("11","三八红旗手"),
                new DicItem("13","三好学生"),
                new DicItem("14","优秀毕业生"),
                new DicItem("15","优秀共青团员"),
                new DicItem("16","优秀学生干部"),
                new DicItem("17","十佳少先队辅导员"),
                new DicItem("18","青年岗位能手"),
                new DicItem("19","杰出（优秀）青年卫士"),
                new DicItem("20","十大杰出青年"),
                new DicItem("21","各族青年团结进步杰出（优秀）奖"),
                new DicItem("22","农村优秀人才"),
                new DicItem("23","杰出青年农民"),
                new DicItem("24","农村青年创业致富带头人"),
                new DicItem("25","杰出（优秀）进城务工青年"),
                new DicItem("26","杰出（优秀）青年外事工作者"),
                new DicItem("27","青年科学家奖"),
                new DicItem("28","青年科技创新奖"),
                new DicItem("29","五四新闻奖"),
                new DicItem("30","未成年人保护杰出（优秀）公民"),
                new DicItem("31","留学回国人民成就奖"),
                new DicItem("32","全国留学回国人员先进个人"),
                new DicItem("33","民族团结进步模范"),
                new DicItem("34","十大农民女状元"),
                new DicItem("35","中国十大女杰"),
                new DicItem("36","“双学双比”先进女能手"),
                new DicItem("37","“双学双比”活动先进工作者"),
                new DicItem("38","十大绿化女壮元"),
                new DicItem("39","巾帼创业带头人"),
                new DicItem("40","“巾帼建功”标兵"),
                new DicItem("41","巾帼文明示范岗"),
                new DicItem("42","“不让毒品进我家”先进个人"),
                new DicItem("43","“不让毒品进我家”活动先进工作者"),
                new DicItem("44","维护妇女儿童权益先进个人"),
                new DicItem("45","先进工作者"),
                new DicItem("46","优秀党务工作者"),
                new DicItem("47","模范公务员"),
                new DicItem("48","人民满意的公务员"),
                new DicItem("49","有突击贡献的中青年专家"),
                new DicItem("50","政府特殊津贴获得者"),
                new DicItem("51","杰出专业技术人才"),
                new DicItem("52","模范教师"),
                new DicItem("53","优秀教师"),
                new DicItem("54","优秀教育工作者"),
                new DicItem("55","中华技能大奖"),
                new DicItem("56","技术能手"),
            };
            
        }
    }
}
