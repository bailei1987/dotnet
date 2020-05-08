namespace BL.StandardDictionary
{
    /// <summary>
    /// 教职工当前状态码 JT1001-JZGDQZT
    /// </summary>
    public class DicStatus : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","退休"),
                new DicItem("02","离休"),
                new DicItem("03","死亡"),
                new DicItem("04","返聘"),
                new DicItem("05","调出"),
                new DicItem("06","辞职"),
                new DicItem("07","离职"),
                new DicItem("08","开除"),
                new DicItem("09","下落不明"),
                new DicItem("11","在职"),
                new DicItem("12","延聘"),
                new DicItem("13","待退休"),
            };
            
        }
    }
}
