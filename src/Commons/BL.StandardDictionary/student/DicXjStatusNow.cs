namespace BL.StandardDictionary
{
    /// <summary>
    /// 学生当前状态(JYT1001-XSDQZT)
    /// </summary>
    public class DicXjStatusNow : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","在读"),
                new DicItem("02","休学"),
                new DicItem("03","退学"),
                new DicItem("04","停学"),
                new DicItem("05","复学"),
                new DicItem("06","流失"),
                new DicItem("07","毕业"),
                new DicItem("08","结业"),
                new DicItem("09","肄业"),
                new DicItem("10","转学（转出）"),
                new DicItem("11","死亡"),
                new DicItem("12","保留入学资格"),
                new DicItem("13","公派出国"),
                new DicItem("14","开除"),
                new DicItem("15","下落不明"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
