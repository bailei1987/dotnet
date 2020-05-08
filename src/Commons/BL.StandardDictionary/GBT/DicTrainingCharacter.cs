namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001 (教育)培训、进修性质代码 本代码引自GB/T 14946.1-2009 附录A.24
    /// </summary>
    public class DicTrainingCharacter : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","培训"),
                new DicItem("2","进修"),
            };
            
        }
    }
}
