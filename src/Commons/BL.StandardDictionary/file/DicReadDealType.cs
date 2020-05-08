namespace BL.StandardDictionary
{
    /// <summary>
    ///YBLB 阅办类别代码 JYT1001
    /// </summary>
    public class DicReadDealType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","阅文"),
                new DicItem("2","拟办"),
                new DicItem("3","批办"),
                new DicItem("4","承办"),
                new DicItem("5","催办"),
                new DicItem("6","办复"),
                new DicItem("7","注办"),
                new DicItem("8","暂存"),
            };
            
        }
    }
}
