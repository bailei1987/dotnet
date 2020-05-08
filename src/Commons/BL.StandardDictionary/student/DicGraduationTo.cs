namespace BL.StandardDictionary
{
    /// <summary>
    /// 毕业去向 JT1001-BYQX(仅取了大类)
    /// </summary>
    public class DicGraduationTo : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","升学"),
                new DicItem("20","就业"),
                new DicItem("30","参军"),
                new DicItem("40","出国"),
                new DicItem("50","赴港澳台"),
                new DicItem("60","待就业"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
