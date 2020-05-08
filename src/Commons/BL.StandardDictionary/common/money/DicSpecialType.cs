namespace BL.StandardDictionary
{
    /// <summary>
    /// ZYZXTZBZMC 中央专项投资补助名称代码 JYT1001
    /// </summary>
    public class DicSpecialType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("A","义教工程"),
                new DicItem("B","校舍维修改造工程"),
                new DicItem("C","危房改造工程"),
                new DicItem("D","寄宿制工程"),
                new DicItem("E","世行贷款工程"),
                new DicItem("F","西扶项目工程"),
                new DicItem("G","抗震救灾工程"),
                new DicItem("H","初中校舍改造工程"),
                new DicItem("I","特殊教育学校建设工程"),
                new DicItem("J","布局调整项目"),
                new DicItem("K","新农村卫生新校园建设工程"),
                new DicItem("L","边境工程"),
                new DicItem("M","安全工程"),
                new DicItem("N","薄弱项目改造工程"),
                new DicItem("Z","中央其他工程"),
            };
            
        }
    }
}
