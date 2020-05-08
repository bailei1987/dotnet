namespace BL.StandardDictionary
{
    /// <summary>
    /// ZTBXS 招投标形式代码 JT1001
    /// </summary>
    public class DicBidType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","公开招标"),
                new DicItem("2","邀请招标"),
                new DicItem("3","无招标"),
            };
            
        }
    }
}
