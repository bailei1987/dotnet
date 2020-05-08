namespace BL.StandardDictionary
{
    /// <summary>
    ///FSFS 发送方式代码 JYT1001
    /// </summary>
    public class DicSendWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","印送"),
                new DicItem("2","传抄"),
                new DicItem("3","网络"),
                new DicItem("4","传真"),
                new DicItem("5","电话"),
                new DicItem("6","电报"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
