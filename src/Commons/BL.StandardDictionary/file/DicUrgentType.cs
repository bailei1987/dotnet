namespace BL.StandardDictionary
{
    /// <summary>
    ///JJCD 紧急程度代码 JYT1001
    /// </summary>
    public class DicUrgentType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","特提"),
                new DicItem("2","特急"),
                new DicItem("3","加急"),
                new DicItem("4","平急"),
                new DicItem("5","急件"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
