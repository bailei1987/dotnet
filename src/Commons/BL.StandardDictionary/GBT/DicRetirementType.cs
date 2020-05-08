namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001  离休、退休类别代码 本代码引自GB/T 14946.1-2009 附录A.62
    /// </summary>
    public class DicRetirementType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","离休"),
                new DicItem("2","退休"),
                new DicItem("3","退职"),
                new DicItem("4","因病退休"),
                new DicItem("5","特殊工种退休"),
                new DicItem("6","工伤退休"),
                new DicItem("7","工作年限满三十年退休"),
                new DicItem("8","距国家规定的退休年龄不足五年，且工作年限满二十年退休"),
                new DicItem("9","符合国家规定的可以提前退休的其他情形的"),
            };
            
        }
    }
}
