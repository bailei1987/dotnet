namespace BL.StandardDictionary
{
    /// <summary>
    /// JSHJLB 教师获奖类别 JYT1001
    /// </summary>
    public class DicAwardType_Teacher : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","教学工作"),
                new DicItem("2","科研工作"),
                new DicItem("3","专业技术"),
                new DicItem("4","工作业绩"),
                new DicItem("5","科技竞赛"),
                new DicItem("6","体育比赛"),
                new DicItem("7","文艺比赛"),
                new DicItem("8","公益事业"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
