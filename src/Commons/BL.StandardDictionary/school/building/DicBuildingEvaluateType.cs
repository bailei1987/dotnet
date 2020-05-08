namespace BL.StandardDictionary
{
    /// <summary>
    /// 建筑物鉴定内容码(JY/T 1001 JZWJDNR 建筑物鉴定内容代码)
    /// </summary>
    public class DicBuildingEvaluateType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","抗震鉴定"),
                new DicItem("2","安全鉴定"),
                new DicItem("3","抗淹没抗洪水冲击鉴定"),
                new DicItem("4","抗风能力验算"),
                new DicItem("5","其他鉴定"),
            };
            
        }
    }
}
