namespace BL.StandardDictionary
{
    /// <summary>
    ///GWFZFS 公文封装方式代码 JYT1001
    /// </summary>
    public class DicSealWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","粘封"),
                new DicItem("2","缝封"),
                new DicItem("3","轧封"),
                new DicItem("4","捆轧"),
                new DicItem("5","印存"),
                new DicItem("6","纸封"),
                new DicItem("7","铅封"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
