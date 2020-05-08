namespace BL.StandardDictionary
{
    /// <summary>
    /// 授课方式 JT1001-SKFS
    /// </summary>
    public class DicTeachWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","面授讲课"),
                new DicItem("2","辅导"),
                new DicItem("3","录像讲课"),
                new DicItem("4","网络教学"),
                new DicItem("5","实验"),
                new DicItem("6","实习"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
