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
                new DicItem("1","A 血型"),
                new DicItem("2","B 血型"),
                new DicItem("3","AB 血型"),
                new DicItem("4","O 血型"),
                new DicItem("5","RH 阳性血型"),
                new DicItem("6","RH 阴性血型"),
                new DicItem("7","HLA 血型"),
                new DicItem("8","未定血型"),
                new DicItem("9","其他血型"),
            };
            
        }
    }
}
