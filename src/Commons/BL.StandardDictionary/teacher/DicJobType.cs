namespace BL.StandardDictionary
{
    /// <summary>
    ///  岗位类别代码 JT1001-GWLB
    /// </summary>
    public class DicJobType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","文化基础课"),
                new DicItem("2","专业课"),
                new DicItem("3","实践技术指导课"),
                new DicItem("9","其他")
            };
            
        }
    }
}
