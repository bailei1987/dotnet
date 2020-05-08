namespace BL.StandardDictionary
{
    /// <summary>
    /// 中考科目代码 暂未补充
    /// </summary>
    public class DicMiddleExamSubject : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("9","其他"),
            };
            
        }
    }
}
