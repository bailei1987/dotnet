namespace BL.StandardDictionary.book
{
    /// <summary>
    ///LZLB 论著类别代码 JYT1001
    /// </summary>
    public class DicBookType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","著作"),
                new DicItem("11","专著"),
                new DicItem("12","编著"),
                new DicItem("13","译著"),
                new DicItem("14","教材"),
                new DicItem("15","科普读物"),
                new DicItem("20","辞典、字典"),
                new DicItem("21","手册"),
                new DicItem("30","图集"),
                new DicItem("40","文艺作品"),
                new DicItem("41","作曲"),
                new DicItem("42","书法"),
                new DicItem("43","绘画"),
                new DicItem("44","摄影"),
                new DicItem("45","工艺美术"),
                new DicItem("49","其他文艺作品"),
                new DicItem("50","报告"),
                new DicItem("60","论文"),
                new DicItem("61","发表论文"),
                new DicItem("62","会议论文"),
                new DicItem("70","教学软件"),
                new DicItem("71","软件"),
                new DicItem("80","技术标准"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
