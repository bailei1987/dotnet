namespace BL.StandardDictionary
{
    /// <summary>
    ///职务变动类别代码 本代码引自GB/T 14946.1-2009 附录A.7，见表A.4
    /// </summary>
    public class DicDutyChangeType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("11","新定职"),
                new DicItem("21","按期逐级晋升"),
                new DicItem("22","提前逐级晋升"),
                new DicItem("23","越一级晋升"),
                new DicItem("24","越二级及二级以上晋升"),
                new DicItem("25","未免原职务、晋升新职务"),
                new DicItem("31","同职连任"),
                new DicItem("32","延长任职"),
                new DicItem("33","平级增职"),
                new DicItem("34","向下兼职"),
                new DicItem("35","平级调任"),
                new DicItem("36","保留原级别任职"),
                new DicItem("37","挂职"),
                new DicItem("38","平级转任"),
                new DicItem("41","免减兼职"),
                new DicItem("42","全免现职"),
                new DicItem("43","免去挂职"),
                new DicItem("51","降一级任职"),
                new DicItem("52","降二级任职"),
                new DicItem("53","降三级任职"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
