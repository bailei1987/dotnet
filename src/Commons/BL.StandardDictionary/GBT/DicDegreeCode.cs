namespace BL.StandardDictionary
{
    /// <summary>
    /// GB/T 6864 学位码 （第二层未添加）
    /// </summary>
    public class DicDegree : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","名誉博士"),
                new DicItem("2","博士"),
                new DicItem("3","硕士"),
                new DicItem("4","学士")
            };
            
        }
    }
}
