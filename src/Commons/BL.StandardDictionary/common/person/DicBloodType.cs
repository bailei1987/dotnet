namespace BL.StandardDictionary
{
    /// <summary>
    /// 血型
    /// </summary>
    public class DicBloodType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("0","未知血型"),
                new DicItem("1","A血型"),
                new DicItem("2","B血型"),
                new DicItem("3","AB血型"),
                new DicItem("4","O血型"),
                new DicItem("5","RH阳性血型"),
                new DicItem("6","RH阴性血型"),
                new DicItem("7","HLA血型"),
                new DicItem("8","未定血型"),
                new DicItem("9","其他血型"),
            };
            
        }
    }
}
