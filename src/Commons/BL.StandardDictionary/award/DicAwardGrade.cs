namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001 JLDJ 奖励等级代码
    /// </summary>
    public class DicAwardGrade : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","特等"),
                new DicItem("2","一等"),
                new DicItem("3","二等"),
                new DicItem("4","三等"),
                new DicItem("5","四等"),
                new DicItem("6","未评等级"),
                new DicItem("9","其他"),
            };

        }
    }
}
