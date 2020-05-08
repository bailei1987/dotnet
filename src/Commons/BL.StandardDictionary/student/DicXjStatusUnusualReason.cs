namespace BL.StandardDictionary
{
    /// <summary>
    /// 学生学籍异动原因(JYT1001-XJYDYY)
    /// </summary>
    public class DicXjStatusUnusualReason : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","成绩优秀"),
                new DicItem("10","疾病"),
                new DicItem("11","精神疾病"),
                new DicItem("12","传染疾病"),
                new DicItem("19","其他疾病"),
                new DicItem("21","自动退学"),
                new DicItem("22","成绩太差"),
                new DicItem("23","触犯刑法"),
                new DicItem("24","休学创业"),
                new DicItem("25","停学实践（求职）"),
                new DicItem("26","家长病重"),
                new DicItem("27","贫困"),
                new DicItem("28","非留学出国（境）"),
                new DicItem("29","自费出国退学"),
                new DicItem("30","自费留学"),
                new DicItem("31","休学期满未办理复学"),
                new DicItem("32","恶意欠缴学费"),
                new DicItem("33","超过最长学习期限未完成学业"),
                new DicItem("34","应征入伍"),
                new DicItem("39","其他原因退学"),
                new DicItem("4","死亡"),
                new DicItem("40","事故灾难致死"),
                new DicItem("41","溺水死亡"),
                new DicItem("42","交通事故致死"),
                new DicItem("43","拥挤踩踏致死"),
                new DicItem("44","房屋倒塌致死"),
                new DicItem("45","坠楼坠崖致死"),
                new DicItem("46","中毒致死"),
                new DicItem("47","爆炸致死"),
                new DicItem("50","社会安全事件致死"),
                new DicItem("51","打架斗殴致死"),
                new DicItem("52","校园伤害致死"),
                new DicItem("53","刑事案件致死"),
                new DicItem("54","火灾致死"),
                new DicItem("60","自然灾害致死"),
                new DicItem("61","山体滑坡致死"),
                new DicItem("62","泥石流致死"),
                new DicItem("63","洪水致死"),
                new DicItem("64","地震致死"),
                new DicItem("65","暴雨致死"),
                new DicItem("66","冰雹致死"),
                new DicItem("67","雪灾致死"),
                new DicItem("68","龙卷风致死"),
                new DicItem("70","因病死亡"),
                new DicItem("71","传染病致死"),
                new DicItem("72","猝死"),
                new DicItem("79","其他疾病致死"),
                new DicItem("81","自杀死亡"),
                new DicItem("89","其他原因死亡"),
                new DicItem("99","其他")
            };
            
        }
    }
}
