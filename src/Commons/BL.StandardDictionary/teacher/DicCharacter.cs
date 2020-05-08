namespace BL.StandardDictionary
{
    /// <summary>
    ///  教职工类别代码表 JT1001-JZGLB
    /// </summary>
    public class DicCharacter : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","校本部教职工"),
                new DicItem("11","专任教师"),
                new DicItem("12","教辅人员"),
                new DicItem("13","行政人员"),
                new DicItem("14","工勤人员"),
                new DicItem("19","其他校本部教职工"),
                new DicItem("20","科研机构人员"),
                new DicItem("30","校办企业职工/校办工厂、农（林）场职工"),
                new DicItem("40","其他附设机构人员"),
                new DicItem("50","聘请校外教师"),
                new DicItem("51","来自高校以外科研、事业单位"),
                new DicItem("52","来自校外企业"),
                new DicItem("53","国外聘请"),
                new DicItem("54","来自其他高校"),
                new DicItem("55","代课教师"),
                new DicItem("56","兼任教师"),
                new DicItem("59","其他兼任（职）教师"),
                new DicItem("60","其他人员"),
                new DicItem("61","附属中小学幼儿园教职工"),
                new DicItem("62","集体所有制人员"),
                new DicItem("99","其他教职工"),
            };
            
        }
    }
}
