namespace BL.StandardDictionary
{
    /// <summary>
    /// JLZZZJLY 奖励资助资金来源代码 JYT1001
    /// </summary>
    public class DicAwardMoneyResource : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","中央财政"),
                new DicItem("2","省级财政"),
                new DicItem("3","市级财政"),
                new DicItem("4","县级财政"),
                new DicItem("5","学校事业收入提取"),
                new DicItem("6","企事业单位、社会或个人捐赠"),
                new DicItem("7","金融机构"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
