namespace BL.StandardDictionary
{
    /// <summary>
    /// 注册状态(JYT1005)
    /// </summary>
    public class DicRegistStatus : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","注册"),
                new DicItem("2","报到"),
                new DicItem("3","未报到")
            };
            
        }
    }
}
