 namespace BL.StandardDictionary
{
    /// <summary>
    /// SGDWZZDJ 施工单位资质等级代码 JT1001
    /// </summary>
    public class DicExecuteUnitAbility : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","特级"),
                new DicItem("2","一级"),
                new DicItem("3","二级"),
                new DicItem("4","三级"),
                new DicItem("5","无"),
            };
            
        }
    }
}
