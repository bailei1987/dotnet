namespace BL.StandardDictionary
{
    /// <summary>
    /// 招收计划科类
    /// </summary>
    public class DicTargetPlanKL : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","兼收"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
