namespace BL.StandardDictionary
{
    /// <summary>
    /// ZYZWLB 主要职务类别 JT1005
    /// </summary>
    public class DicMainDuty : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","学校校长"),
                new DicItem("2","党组织负责人"),
                new DicItem("3","学校联系人"),
            };
            
        }
    }
}
