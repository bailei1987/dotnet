namespace BL.StandardDictionary
{
    /// <summary>
    ///JYT1001 在学单位类别代码本代码引自GB/T 14946.1-2009 附录A.26
    ///仅取了主要的
    /// </summary>
    public class DicStudyInUnitType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","全日制学校"),
                new DicItem("2","成人教育培训机构"),
                new DicItem("3","事业单位"),
                new DicItem("4","行政学院"),
                new DicItem("5","企业"),
                new DicItem("6","机关"),
                new DicItem("7","党校"),
                new DicItem("8","军队（武警）院校"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
