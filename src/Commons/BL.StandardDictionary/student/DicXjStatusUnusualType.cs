namespace BL.StandardDictionary
{
    /// <summary>
    /// 学生学籍异动类型(JYT1001-XJYDLB)
    /// </summary>
    public class DicXjStatusUnusualType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","公派留学"),
                new DicItem("02","留级"),
                new DicItem("03","降级"),
                new DicItem("04","跳级"),
                new DicItem("05","试读"),
                new DicItem("06","延长年限"),
                new DicItem("07","试读通过"),
                new DicItem("08","回国复学"),
                new DicItem("11","休学"),
                new DicItem("12","复学"),
                new DicItem("13","停学"),
                new DicItem("14","保留入学资格"),
                new DicItem("15","恢复入学资格"),
                new DicItem("16","取消入学资格"),
                new DicItem("17","恢复学籍"),
                new DicItem("18","取消学籍"),
                new DicItem("19","保留学籍"),
                new DicItem("21","转学（转出）"),
                new DicItem("22","转学（转入）"),
                new DicItem("23","转专业"),
                new DicItem("24","专升本"),
                new DicItem("25","本转专"),
                new DicItem("26","转系"),
                new DicItem("27","硕转博"),
                new DicItem("28","博转硕"),
                new DicItem("29","转班级"),
                new DicItem("31","退学"),
                new DicItem("42","开除学籍"),
                new DicItem("51","死亡"),
                new DicItem("61","提前毕业"),
                new DicItem("62","结业"),
                new DicItem("63","肄业"),
                new DicItem("64","国内访学"),
                new DicItem("65","国内访学后返校"),
                new DicItem("99","其他")
            };
            
        }
    }
}
