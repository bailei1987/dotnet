namespace BL.StandardDictionary
{
    /// <summary>
    ///HYGZLB 行业工种类别代码 JYT1001
    /// </summary>
    public class DicIndustryWorkType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","机械加工类"),
                new DicItem("02","电工电器工程类"),
                new DicItem("03","建筑工程类"),
                new DicItem("04","仪器仪表工程类"),
                new DicItem("05","水暖通风工程类"),
                new DicItem("06","机动车驾驶类"),
                new DicItem("07","家具维修类"),
                new DicItem("08","宣传广告标本制作类"),
                new DicItem("09","餐饮服务类"),
                new DicItem("10","商贸服务类"),
                new DicItem("11","护理保健类"),
                new DicItem("12","花木养殖类"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
