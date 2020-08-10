namespace BL.StandardDictionary
{
    /// <summary>
    /// 招收计划类型
    /// </summary>
    public class DicTargetPlanLX : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","单列类"),
                new DicItem("02","民语言类"),
                new DicItem("03","双语类"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
