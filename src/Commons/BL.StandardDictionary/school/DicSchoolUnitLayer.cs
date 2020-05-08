namespace BL.StandardDictionary
{
    /// <summary>
    /// XXDWCC 学校单位层次代码 JT1001
    /// </summary>
    public class DicSchoolUnitLayer : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","校本部"),
                new DicItem("2","分校"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
