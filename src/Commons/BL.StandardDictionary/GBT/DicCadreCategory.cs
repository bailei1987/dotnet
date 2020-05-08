namespace BL.StandardDictionary
{
    /// <summary>
    ///职位分类代码 本代码引自GB/T 14946.1-2009 附录A.6 JYT1001
    ///仅取了主要部分
    /// </summary>
    public class DicCadreCategory : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("0100","国务院总理级"),
                new DicItem("0200","国务院副总理，国务委员级"),
                new DicItem("0300","部级正职，省级正职级"),
                new DicItem("0400","部级副职，省级副职级"),
                new DicItem("0500","司级正职，厅级正职，巡视员级"),
                new DicItem("0600","司级副职，厅级副职，副巡视员级"),
                new DicItem("0700","处级正职，县级正职，调研员级"),
                new DicItem("0800","处级副职，县级副职，副调研员级"),
                new DicItem("0900","科级正职，乡级正职，主任科员级"),
                new DicItem("1000","科级副职，乡级副职，副主任科员级"),
                new DicItem("1100","科员级"),
                new DicItem("1200","办事员级"),
            };
            
        }
    }
}
