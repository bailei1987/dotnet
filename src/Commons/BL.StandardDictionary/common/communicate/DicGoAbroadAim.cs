namespace BL.StandardDictionary
{
    /// <summary>
    /// CGMD 出国目的代码 JYT1001
    /// </summary>
    public class DicGoAbroadAim : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","常驻国外使馆、领事馆"),
                new DicItem("02","常驻国际组织及其代表机构"),
                new DicItem("04","常驻国外其他组织"),
                new DicItem("05","短期派驻国外使馆、领事馆"),
                new DicItem("06","短期派驻国际组织及其他代表机构"),
                new DicItem("08","短期派驻国外其他组织"),
                new DicItem("10","党政代表团出访"),
                new DicItem("11","军事代表团出访"),
                new DicItem("12","经济贸易和财务方面代表团出访与洽谈"),
                new DicItem("13","学术、文艺、体育代表团和其他社会团体出访"),
                new DicItem("14","参加国际性的各类比赛"),
                new DicItem("15","参加交易会和展览会"),
                new DicItem("20","引进技术和设备"),
                new DicItem("21","商务出国"),
                new DicItem("22","实习"),
                new DicItem("23","监造"),
                new DicItem("30","援外技术工作"),
                new DicItem("31","援建工作"),
                new DicItem("32","援外培训工作"),
                new DicItem("33","劳务出口"),
                new DicItem("34","合营工程"),
                new DicItem("36","航空、邮电、海运、公路等国际联运业务"),
                new DicItem("37","随船工作"),
                new DicItem("39","科技合作项目"),
                new DicItem("40","考察"),
                new DicItem("41","领奖"),
                new DicItem("42","参加各种会议"),
                new DicItem("43","进修"),
                new DicItem("44","讲学"),
                new DicItem("45","公派留学"),
                new DicItem("451","国家公派博士后"),
                new DicItem("452","国家公派博士"),
                new DicItem("453","国家公派硕士"),
                new DicItem("454","国家公派本科"),
                new DicItem("455","国家公派进修学习"),
                new DicItem("456","单位公派博士后"),
                new DicItem("457","单位公派博士"),
                new DicItem("458","单位公派硕士"),
                new DicItem("459","单位公派本科"),
                new DicItem("45A","单位公派进修学习"),
                new DicItem("46","自费留学"),
                new DicItem("461","自费博士后"),
                new DicItem("462","自费博士"),
                new DicItem("463","自费硕士"),
                new DicItem("464","自费本科"),
                new DicItem("465","自费进修学习"),
                new DicItem("47","自费公派留学"),
                new DicItem("60","旅游"),
                new DicItem("61","探亲"),
                new DicItem("62","会友"),
                new DicItem("63","结婚"),
                new DicItem("64","继承财产"),
                new DicItem("65","就业"),
                new DicItem("66","定居"),
                new DicItem("70","特殊任务"),
                new DicItem("80","换发护照"),
                new DicItem("99","其他原因出国"),
            };            
        }
    }
}
