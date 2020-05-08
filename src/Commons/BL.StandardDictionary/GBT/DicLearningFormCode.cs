namespace BL.StandardDictionary
{
    /// <summary>
    /// GBT 14946.1-2009 A.3 学习形式码
    /// </summary>
    public class DicLearningForm : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","正规高等院校"),
                new DicItem("02","高等教育自学考试"),
                new DicItem("03","夜大学"),
                new DicItem("04","职工大学"),
                new DicItem("05","电视大学"),
                new DicItem("06","业余大学"),
                new DicItem("07","函授"),
                new DicItem("08","研修班"),
                new DicItem("09","高等学校进修"),
                new DicItem("10","党校"),
                new DicItem("11","社会主义学院"),
                new DicItem("15","培训"),
                new DicItem("99","其他")
            };
            
        }
    }
}
