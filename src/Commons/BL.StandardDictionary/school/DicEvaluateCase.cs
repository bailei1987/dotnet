namespace BL.StandardDictionary
{
    /// <summary>
    /// 评估情况 JT1005-PGQK
    /// </summary>
    public class DicEvaluateCase : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","国家示范校"),
                new DicItem("2","国家级重点"),
                new DicItem("3","省部级重点"),
                new DicItem("4","国家优质特色学校"),
                new DicItem("5","国家实训基地"),
                new DicItem("6","其他"),
            };
            
        }
    }
}
