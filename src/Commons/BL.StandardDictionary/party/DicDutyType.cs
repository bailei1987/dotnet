namespace BL.StandardDictionary
{
    /// <summary>
    ///ZWLB 职务类别 JYT1001
    /// </summary>
    public class DicDutyType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("11","党委正职"),
                new DicItem("12","行政正职"),
                new DicItem("13","党的职能部门正职"),
                new DicItem("14","行政职能部门正职"),
                new DicItem("15","民主党派正职"),
                new DicItem("16","社会团体正职"),
                new DicItem("21","党委副职"),
                new DicItem("22","行政副职"),
                new DicItem("23","党的职能部门副职"),
                new DicItem("24","行政职能部门副职"),
                new DicItem("25","民主党派副职"),
                new DicItem("26","社会团体副职"),
                new DicItem("31","党委常委"),
                new DicItem("32","党委委员"),
                new DicItem("33","纪委委员"),
                new DicItem("34","校长助理"),
                new DicItem("35","总会计师"),
                new DicItem("36","总经济师"),
                new DicItem("38","党委其他职"),
                new DicItem("39","行政其他职"),
                new DicItem("41","党的职能部门其他职"),
                new DicItem("42","行政职能部门其他职"),
                new DicItem("43","民主党派其他职"),
                new DicItem("44","社会团体其他职")
            };
            
        }
    }
}
