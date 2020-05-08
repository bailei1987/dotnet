namespace BL.StandardDictionary
{
    /// <summary>
    ///性别
    /// </summary>
    public class DicGender : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                 new DicItem("1","男"),
                 new DicItem("2","女")
            };
            
        }
    }
}
