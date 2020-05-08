namespace BL.StandardDictionary
{
    /// <summary>
    ///社会单位性质代码  JT1001-SHDWXZ
    /// </summary>
    public class DicUnitCharacter : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","机关"),
                new DicItem("11","省级以上党政机关"),
                new DicItem("12","省级以下党政机关"),
                new DicItem("20","事业单位"),
                new DicItem("21","科研设计单位"),
                new DicItem("22","高等学校"),
                new DicItem("23","其他教育单位"),
                new DicItem("24","医疗卫生单位"),
                new DicItem("25","体育文化单位"),
                new DicItem("29","其他事业单位"),
                new DicItem("30","企业"),
                new DicItem("31","国有企业"),
                new DicItem("32","中外合资企业"),
                new DicItem("33","民营（私营）企业"),
                new DicItem("34","外资企业"),
                new DicItem("35","集体企业"),
                new DicItem("39","其他企业"),
                new DicItem("40","部队"),
                new DicItem("50","社会组织机构"),
                new DicItem("60","国际组织机构"),
                new DicItem("70","国防科工机构"),
                new DicItem("80","财政金融机构"),
                new DicItem("99","其他")
            };
            
        }
    }
}
