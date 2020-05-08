namespace BL.StandardDictionary
{
    /// <summary>
    ///专业技术职务代码 本代码引自GB/T 8561-2001，见表B.29  JYT1001
    ///仅取了主要部分
    /// </summary>
    public class DicTechnicalDutyName : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("010","高等学校教师"),
                new DicItem("020","中等专业学校教师"),
                new DicItem("030","技工学校教师"),
                new DicItem("040","技工学校教师（实习指导）"),
                new DicItem("050","中学教师"),
                new DicItem("070","实验技术人员"),
                new DicItem("080","工程技术人员"),
                new DicItem("090","农业技术人员（农艺）"),
                new DicItem("100","农业技术人员（兽医）"),
                new DicItem("110","农业技术人员（畜牧）"),
                new DicItem("120","经济专业人员"),
                new DicItem("130","会计专业人员"),
                new DicItem("140","统计专业人员"),
                new DicItem("150","出版专业人员（编审）"),
                new DicItem("160","出版专业人员（技术编辑）"),
                new DicItem("170","出版专业人员（校对）"),
                new DicItem("180","翻译人员"),
                new DicItem("190","新闻专业人员（记者）"),
                new DicItem("200","新闻专业人员（编辑）"),
                new DicItem("220","播音员"),
                new DicItem("230","卫生技术人员（医师）"),
                new DicItem("240","卫生技术人员（药剂）"),
                new DicItem("250","卫生技术人员（护理）"),
                new DicItem("260","卫生技术人员（技师）"),
                new DicItem("270","工艺美术人员"),
                new DicItem("280","艺术人员（演员）"),
                new DicItem("290","艺术人员（演奏员）"),
                new DicItem("300","艺术人员（编剧）"),
                new DicItem("310","艺术人员（导演）"),
                new DicItem("320","艺术人员（指挥）"),
                new DicItem("330","艺术人员（作曲）"),
                new DicItem("340","艺术人员（美术）"),
                new DicItem("350","艺术人员（舞美设计）"),
                new DicItem("360","艺术人员（舞台技术）"),
                new DicItem("370","体育锻炼"),
                new DicItem("390","律师"),
                new DicItem("400","公证员"),
                new DicItem("410","小学教师"),
                new DicItem("420","船舶技术人员（驾驶）"),
                new DicItem("430","船舶技术人员（轮机）"),
                new DicItem("440","船舶技术人员（电机）"),
                new DicItem("450","船舶技术人员（报务）"),
                new DicItem("460","飞行技术人员（驾驶）"),
                new DicItem("470","飞行技术人员（领航）"),
                new DicItem("480","飞行技术人员（通信）"),
                new DicItem("490","飞行技术人员（机械）"),
                new DicItem("500","船舶技术人员（引航）"),
                new DicItem("610","自然科学研究人员"),
                new DicItem("620","社会科学研究人员"),
                new DicItem("640","图书、资料专业人员"),
                new DicItem("650","文博专业人员"),
                new DicItem("660","档案专业人员"),
                new DicItem("670","群众文化专业人员"),
                new DicItem("680","审计专业人员"),
                new DicItem("690","法医专业人员"),
                new DicItem("980","思想政治工作人员"),
            };
            
        }
    }
}
