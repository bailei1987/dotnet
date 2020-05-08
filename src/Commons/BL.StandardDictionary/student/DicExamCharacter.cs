namespace BL.StandardDictionary
{
    /// <summary>
    /// 考试性质  JT1001-KSXZ
    /// </summary>
    public class DicExamCharacter : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","正常考试"),
                new DicItem("02","缓考"),
                new DicItem("03","旷考"),
                new DicItem("11","补考一"),
                new DicItem("12","补考二"),
                new DicItem("13","重修"),
                new DicItem("14","免修"),
                new DicItem("21","结业后回校补考"),
                new DicItem("41","国家级考试"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
