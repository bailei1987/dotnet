namespace BL.StandardDictionary
{
    /// <summary>
    /// 获奖类型(性质)(JYT1001-HJLX)
    /// </summary>
    public class DicAwardCharacter : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","集体"),
                new DicItem("2","个人综合"),
                new DicItem("3","个人单项"),
            };

        }
    }
}
