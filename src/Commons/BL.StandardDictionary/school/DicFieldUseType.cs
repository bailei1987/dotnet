namespace BL.StandardDictionary
{
    /// <summary>
    /// ZDYT 占地用途代码 JT1001
    /// </summary>
    public class DicFieldUseType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","房屋用地"),
                new DicItem("2","体育场地"),
                new DicItem("3","绿化用地"),
                new DicItem("4","农、林场用地"),
                new DicItem("9","其他用地"),
            };
            
        }
    }
}
