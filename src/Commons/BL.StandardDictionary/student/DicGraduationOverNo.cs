namespace BL.StandardDictionary
{
    /// <summary>
    /// 结束学业码
    /// </summary>
    public class DicGraduationOverNo : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","毕业"),
                new DicItem("2","结业"),
                new DicItem("3","未结业"),
                new DicItem("4","肄业")
            };            
        }
    }
}
