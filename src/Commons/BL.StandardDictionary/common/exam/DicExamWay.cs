namespace BL.StandardDictionary
{
    /// <summary>
    /// 考试方式 JT1001-KSFS
    /// </summary>
    public class DicExamWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","笔试"),
                new DicItem("2","口试"),
                new DicItem("3","面试"),
                new DicItem("4","操作"),
                new DicItem("5","机考"),
                new DicItem("6","大作业"),
                new DicItem("7","实验报告"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
