namespace BL.StandardDictionary
{
    /// <summary>
    /// KZSFLD 抗震设防烈度代码 JYT1001
    /// </summary>
    public class DicEarthQuakeDefendIntensity : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","抗震设防烈度为6度以下"),
                new DicItem("2","抗震设防烈度为6度"),
                new DicItem("3","抗震设防烈度为7度"),
                new DicItem("4","抗震设防烈度为7.5度"),
                new DicItem("5","抗震设防烈度为8度"),
                new DicItem("6","抗震设防烈度为8.5度"),
                new DicItem("9","抗震设防烈度为9度"),
            };
            
        }
    }
}
