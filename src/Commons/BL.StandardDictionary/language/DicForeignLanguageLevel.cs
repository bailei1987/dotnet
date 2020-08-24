namespace BL.StandardDictionary
{
    /// <summary>
    ///外语水平等级 
    /// </summary>
    public class DicForeignLanguageLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","英语四级"),
                new DicItem("2","英语六级"),
                new DicItem("3","英语六级以上"),
                new DicItem("99","其他")
            };
            
        }
    }
}