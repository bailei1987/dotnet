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
                new DicItem("04","普通类"),
                new DicItem("05","职升专"),
                new DicItem("06","三校生"),
                new DicItem("07","单招"),
                new DicItem("08","单报"),
                new DicItem("09","统招"),
                new DicItem("10","扩招"),
                new DicItem("99","其他"),
            };

        }
    }
}
