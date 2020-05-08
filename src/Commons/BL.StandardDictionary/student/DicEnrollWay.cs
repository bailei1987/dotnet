namespace BL.StandardDictionary
{
    /// <summary>
    /// 入学方式
    /// </summary>
    public class DicEnrollWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","统一招生考试/普通入学"),
                new DicItem("02","保送"),
                new DicItem("03","民族班"),
                new DicItem("04","定向培养"),
                new DicItem("05","体育特招"),
                new DicItem("06","文艺特招"),
                new DicItem("07","学生干部保送"),
                new DicItem("08","考试推荐"),
                new DicItem("09","外校转入"),
                new DicItem("10","恢复入学资格"),
                new DicItem("11","预科班"),
                new DicItem("12","来华留学"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
