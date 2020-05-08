namespace BL.StandardDictionary
{
    /// <summary>
    /// 户口类别
    /// </summary>
    public class DicResidenceType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("0","未落常住户口"),
                new DicItem("1","非农业家庭户口"),
                new DicItem("2","农业家庭户口"),
                new DicItem("3","非农业集体户口"),
                new DicItem("4","农业集体户口"),
                new DicItem("5","自理口粮户口"),
                new DicItem("6","寄住户口"),
                new DicItem("7","暂住户口"),
                new DicItem("8","其他户口"),
            };
            
        }
    }
}
