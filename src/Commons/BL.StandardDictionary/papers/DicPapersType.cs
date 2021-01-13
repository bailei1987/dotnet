namespace BL.StandardDictionary
{
    /// <summary>
    /// 证件类型
    /// </summary>
    public class DicPapersType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","居民身份证、临时身份证"),
                new DicItem("2","军官证"),
                new DicItem("3","武警警官证"),
                new DicItem("4","士兵证"),
                new DicItem("5","军队学员证"),
                new DicItem("6","军队文职干部证"),
                new DicItem("7","军队离退休干部证"),
                new DicItem("8","军队职工证"),
                new DicItem("9","护照"),
                new DicItem("10","港澳同乡回乡证"),
                new DicItem("11","港澳居民来往内地通行证"),
                new DicItem("12","中华人民共和国往来港澳通行证"),
                new DicItem("13","台湾居民来往大陆通行证"),
                new DicItem("14","大陆居民往来台湾通行证"),
                new DicItem("15","外国人居留证"),
                new DicItem("16","外国人出入境证"),
                new DicItem("17","外交官证"),
                new DicItem("18","领事馆证"),
                new DicItem("19","海员证"),
                new DicItem("20","铁路乘车证"),
                new DicItem("21","居民户口簿"),
                new DicItem("22","居民居住证(带照片)"),
                new DicItem("23","居民暂住证(带照片)"),
                new DicItem("24","过期居民身份证"),
                new DicItem("25","驾驶证"),
                new DicItem("26","学生证"),
                new DicItem("27","退伍证"),
                new DicItem("28","刑满释放证明"),
                new DicItem("29","救助证明")
            };
        }
    }
}
