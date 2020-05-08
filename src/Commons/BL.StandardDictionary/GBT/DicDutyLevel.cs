namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001  职务级别代码 本代码引自GB/T 12407-2008，见表B.39
    /// </summary>
    public class DicDutyLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","公务员职务级别"),
                new DicItem("101","国家级正职"),
                new DicItem("102","国家级副职"),
                new DicItem("111","省部级正职"),
                new DicItem("112","省部级副职"),
                new DicItem("121","厅局级正职"),
                new DicItem("122","厅局级副职"),
                new DicItem("131","县处级正职"),
                new DicItem("132","县处级副职"),
                new DicItem("141","乡科级正职"),
                new DicItem("142","乡科级副职"),
                new DicItem("150","科员级"),
                new DicItem("160","办事员级"),
                new DicItem("199","未定职公务员"),
                new DicItem("2","职员级别"),
                new DicItem("211","一级职员"),
                new DicItem("212","二级职员"),
                new DicItem("221","三级职员"),
                new DicItem("222","四级职员"),
                new DicItem("231","五级职员"),
                new DicItem("232","六级职员"),
                new DicItem("241","七级职员"),
                new DicItem("242","八级职员"),
                new DicItem("250","九级职员"),
                new DicItem("260","十级职员"),
                new DicItem("299","未定级职员"),
                new DicItem("4","专业技术职务级别"),
                new DicItem("410","高级"),
                new DicItem("411","正高级"),
                new DicItem("412","副高级"),
                new DicItem("420","中级"),
                new DicItem("430","初级"),
                new DicItem("434","助理级"),
                new DicItem("435","员级"),
                new DicItem("499","未定职级专业技术人员"),
            };
            
        }
    }
}
