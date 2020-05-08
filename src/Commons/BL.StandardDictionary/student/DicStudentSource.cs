namespace BL.StandardDictionary
{
    /// <summary>
    /// 学生来源(JYT1001)
    /// </summary>
    public class DicStudentSource : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                //XSLY学生来源
                new DicItem("000","研究生"),
                new DicItem("001","科技人员"),
                new DicItem("002","高校教师"),
                new DicItem("003","中学教师"),
                new DicItem("004","其他在职"),
                new DicItem("005","应届本科"),
                new DicItem("006","成人应届本科"),
                new DicItem("007","网络教育应届本科"),
                new DicItem("009","其他人员"),
                new DicItem("100","普通高校本专科/中等职业学校"),
                new DicItem("101","城镇应届"),
                new DicItem("102","农村应届"),
                new DicItem("103","城镇往届"),
                new DicItem("104","农村往届"),
                new DicItem("105","工人"),
                new DicItem("106","干部"),
                new DicItem("107","复退军人"),
                new DicItem("108","现役军人"),
                new DicItem("109","香港生"),
                new DicItem("110","澳门生"),
                new DicItem("111","台湾生"),
                new DicItem("112","归国华侨/港澳台侨"),
                new DicItem("113","留学生/外籍"),
                new DicItem("199","其他"),
                new DicItem("200","成人高校"),
                new DicItem("201","国家机关、党群组织、企业、事业单位负责人"),
                new DicItem("209","军人"),
                new DicItem("211","专业技术人员"),
                new DicItem("231","办事人员和有关人员"),
                new DicItem("241","商业、服务业人员"),
                new DicItem("251","农、林、牧、渔、水利业生产人员"),
                new DicItem("261","生产、运输设备操作人员及有关人员"),
                new DicItem("299","不便分类的其他从业人员"),
                //ZXXXSLY中小学学生来源
                new DicItem("1","正常入学"),
                new DicItem("2","借读"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
