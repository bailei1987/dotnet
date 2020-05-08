namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001 JB 级别代码
    /// </summary>
    public class DicAwardLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","国家级"),
                new DicItem("20","省、部委级"),
                new DicItem("21","教育部"),
                new DicItem("22","中央其他部委"),
                new DicItem("23","省（自治区、直辖市）级"),
                new DicItem("30","省部门级、地（市、州）级"),
                new DicItem("31","省级教育行政部门"),
                new DicItem("32","省级其他部门"),
                new DicItem("33","地（市、州）级"),
                new DicItem("40","地（市、州）部门级、县（区、旗）级"),
                new DicItem("41","地级教育行政部门"),
                new DicItem("42","地级其他部门"),
                new DicItem("43","县级"),
                new DicItem("50","县部门级、乡（镇）级"),
                new DicItem("51","县级教育行政部门"),
                new DicItem("52","县级其他部门"),
                new DicItem("53","乡（镇）级"),
                new DicItem("60","学校级"),
                new DicItem("70","国际"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
