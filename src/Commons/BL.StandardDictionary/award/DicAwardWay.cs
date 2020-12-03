namespace BL.StandardDictionary
{
    /// <summary>
    /// JLFS 奖励方式代码(JYT1001-JLFS)
    /// </summary>
    public class DicAwardWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","奖状"),
                new DicItem("2","荣誉称号"),
                new DicItem("3","奖金"),
                new DicItem("4","实物"),
                new DicItem("9","其他"),
            };            
        }
    }
}
