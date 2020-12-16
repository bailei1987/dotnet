namespace BL.StandardDictionary
{
    /// <summary>
    /// 港奥台侨
    /// </summary>
    public class DicGATQ : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("0","非港澳台侨"),
                new DicItem("1","香港同胞"),
                new DicItem("2","澳门同胞"),
                new DicItem("3","台湾同胞"),
                new DicItem("4","海外侨胞"),
            };
            
        }
    }
}
