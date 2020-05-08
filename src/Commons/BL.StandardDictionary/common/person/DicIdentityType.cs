namespace BL.StandardDictionary
{
    /// <summary>
    /// 证件类型
    /// </summary>
    public class DicIdentityType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[] {
                new DicItem("1","居民身份证"),
                new DicItem("6","香港特区护照"),
                new DicItem("7","澳门特区护照"),
                new DicItem("8","台湾居民来往大陆通行证"),
                new DicItem("9","境外永久居住证"),
                new DicItem("A","护照"),
                new DicItem("B","户口薄"),
                new DicItem("Z","其他")
            };
            
        }
    }
}
