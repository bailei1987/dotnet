namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001 奖励代码 本代码引自GB/T 8563.1-2005
    /// 仅添加了主要的
    /// </summary>
    public class DicAwardCode : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","工作成绩奖励代码"),
                new DicItem("11","国家行政机关人员工作成绩奖励"),
                new DicItem("12","企业职工工作成绩奖励"),
                new DicItem("13","中国人民解放军工作成绩奖励"),
                new DicItem("2","科学技术奖励"),
                new DicItem("20","国家科学技术奖"),
                new DicItem("21","部委科学技术奖"),
                new DicItem("22","省(自治区、直辖市、特别行政区)科学技术奖"),
                new DicItem("23","省（部）级以下的科学技术奖励"),
                new DicItem("28","社会力量设立科学技术奖"),
                new DicItem("3","教学成果奖励"),
                new DicItem("30","国家教学成果奖"),
                new DicItem("8","国际和国外奖励"),
                new DicItem("80","国际和国外奖励"),
            };
            
        }
    }
}
