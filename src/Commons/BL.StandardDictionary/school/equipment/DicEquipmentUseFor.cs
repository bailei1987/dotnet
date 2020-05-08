namespace BL.StandardDictionary
{
    /// <summary>
    /// YQSYFX 仪器使用方向代码 JT1001
    /// </summary>
    public class DicEquipmentUseFor : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","教学"),
                new DicItem("2","科研"),
                new DicItem("3","行政"),
                new DicItem("4","生活与后勤"),
                new DicItem("5","生产"),
                new DicItem("6","技术开发"),
                new DicItem("7","社会服务"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
