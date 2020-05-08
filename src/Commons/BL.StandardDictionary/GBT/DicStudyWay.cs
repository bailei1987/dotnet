namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001  学习方式代码 本代码引自GB/T 14946.1-2009 附录A.25
    /// </summary>
    public class DicStudyWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","全脱产（离岗）"),
                new DicItem("2","半脱产（半离岗）"),
                new DicItem("3","不脱产（不离岗）"),
            };
            
        }
    }
}
