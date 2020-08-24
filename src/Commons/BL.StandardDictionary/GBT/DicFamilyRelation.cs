namespace BL.StandardDictionary
{
    /// <summary>
    /// 家庭关系代码 GB/T 4761-2008 (仅取了部分)
    /// </summary>
    public class DicFamilyRelation : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","本人"),
                new DicItem("10","配偶"),
                //new DicItem("11","夫"),
                //new DicItem("12","妻"),
                new DicItem("20","子女"),
                //new DicItem("21","子"),
                //new DicItem("22","女"),
                new DicItem("50","父母"),
                //new DicItem("51","父亲"),
                //new DicItem("52","母亲"),
                new DicItem("70","兄弟"),
                //new DicItem("71","兄"),
                //new DicItem("72","弟"),
                new DicItem("80","姐妹"),
                //new DicItem("81","姐姐"),
                //new DicItem("82","妹妹"),
                new DicItem("97","其他亲属"),
                new DicItem("99","非亲属"),
            };
            
        }
    }
}
