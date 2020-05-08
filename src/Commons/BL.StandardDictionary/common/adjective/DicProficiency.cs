namespace BL.StandardDictionary
{
    /// <summary>
    /// 熟练程度 (如 GB/T 6865-2009 语种熟练程度)
    /// </summary>
    public class DicProficiency : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","精通"),
                new DicItem("2","熟练"),
                new DicItem("3","良好"),
                new DicItem("4","一般"),
            };
            
        }
    }
}
