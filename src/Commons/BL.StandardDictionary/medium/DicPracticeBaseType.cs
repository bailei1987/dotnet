namespace BL.StandardDictionary
{
    ///中职专用
    /// <summary>
    ///SXJDLB 实习基地类别代码 JYT1005
    /// </summary>
    public class DicPracticeBaseType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","本地区校内"),
                new DicItem("2","本地区校外"),
                new DicItem("3","本省其他地区校内"),
                new DicItem("4","本省其他地区校外"),
                new DicItem("5","外省市校内"),
                new DicItem("6","外省市校外"),
            };
            
        }
    }
}
