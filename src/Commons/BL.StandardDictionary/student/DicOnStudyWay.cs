namespace BL.StandardDictionary
{
    /// <summary>
    /// 就读方式(JYT1001)
    /// </summary>
    public class DicOnStudyWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","走读"),
                new DicItem("2","住校"),
                new DicItem("3","借宿"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
