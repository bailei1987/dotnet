namespace BL.StandardDictionary
{
    /// <summary>
    ///JYT1001 教育培训结果代码 本代码引自GB/T 14946.1-2009 附录A.27
    /// </summary>
    public class DicTrainingResult : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","毕业"),
                new DicItem("2","结业"),
                new DicItem("3","未结业"),
                new DicItem("4","肄业"),
            };
            
        }
    }
}
