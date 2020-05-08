namespace BL.StandardDictionary
{
    /// <summary>
    /// SYZK 使用状况代码(园资产使用状况的分类)JYT1001
    /// </summary>
    public class DicPropertyUseStatus : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","使用"),
                new DicItem("2","闲置"),
                new DicItem("3","被借用"),
                new DicItem("4","借用"),
                new DicItem("5","租用"),
                new DicItem("6","出租"),
                new DicItem("7","对外投资"),
                new DicItem("8","担保"),
            };
            
        }
    }
}
