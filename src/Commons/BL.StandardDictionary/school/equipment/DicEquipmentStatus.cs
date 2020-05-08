namespace BL.StandardDictionary
{
    /// <summary>
    /// YQXZ 仪器现状代码 JT1001
    /// </summary>
    public class DicEquipmentStatus : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","在用"),
                new DicItem("2","闲置"),
                new DicItem("3","待修"),
                new DicItem("4","待报废"),
                new DicItem("5","丢失"),
                new DicItem("6","报废"),
                new DicItem("7","调出"),
                new DicItem("8","降档"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
