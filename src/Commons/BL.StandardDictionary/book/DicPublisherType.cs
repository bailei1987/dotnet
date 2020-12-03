namespace BL.StandardDictionary.book
{
    /// <summary>
    ///CBSJB 出版社级别 JYT1005
    /// </summary>
    public class DicPublisherType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","中央出版社"),
                new DicItem("2","地方出版社"),
                new DicItem("3","国外（境外）出版社"),
            };            
        }
    }
}
