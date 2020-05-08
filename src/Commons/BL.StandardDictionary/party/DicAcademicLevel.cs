namespace BL.StandardDictionary
{
    /// <summary>
    ///XSTTJB 学术团体级别 JYT1001
    /// </summary>
    public class DicAcademicLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","国际学术团体"),
                new DicItem("2","国家级学术团体"),
                new DicItem("3","省市、部委级学术团体"),
                new DicItem("4","地（市）级学术团体"),
                new DicItem("5","县（区、旗）级学术团体"),
            };
            
        }
    }
}
