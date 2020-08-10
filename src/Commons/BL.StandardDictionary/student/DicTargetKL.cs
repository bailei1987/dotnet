namespace BL.StandardDictionary
{
    /// <summary>
    /// 招收科类
    /// </summary>
    public class DicTargetKL : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","理科"),
                new DicItem("02","体育"),
                new DicItem("03","文科"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
