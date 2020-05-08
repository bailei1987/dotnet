namespace BL.StandardDictionary
{
    /// <summary>
    //A.9 国家职业资格(工人技术等级)代码 本代码引自GB/T 14946.1-2009 附录A.13，见表A.9。 JYT1001
    ///仅取了主要部分
    /// </summary>
    public class DicWorkerTechnicLevel : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","职业资格一级(高级技师)"),
                new DicItem("2","职业资格二级(技师)"),
                new DicItem("3","职业资格三级(高级)"),
                new DicItem("4","职业资格四级(中级)"),
                new DicItem("5","职业资格五级(初级)"),
            };
            
        }
    }
}
