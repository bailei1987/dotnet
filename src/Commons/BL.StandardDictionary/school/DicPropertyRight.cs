namespace BL.StandardDictionary
{
    /// <summary>
    /// CQ 产权代码表 JT1001
    /// </summary>
    public class DicPropertyRight : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","学校独立产权"),
                new DicItem("2","产权非学校但独立使用"),
                new DicItem("3","产权非属学校共同使用"),
            };            
        }
    }
}
