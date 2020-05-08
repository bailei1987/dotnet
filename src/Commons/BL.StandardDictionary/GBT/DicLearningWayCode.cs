namespace BL.StandardDictionary
{
    /// <summary>
    /// GBT 14946.1-2009 A.25 学习方式码
    /// </summary>
    public class DicLearningWay: DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","全脱产（离岗）"),
                new DicItem("2","半脱产（半离岗）"),
                new DicItem("3","不脱产（不离岗）")
            };
            
        }
    }
}
