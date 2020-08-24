namespace BL.StandardDictionary
{
    /// <summary>
    /// JZWYT 建筑物用途代码 JT1001
    /// </summary>
    public class DicBuildingUseType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("10","教学及辅助用房"),
                new DicItem("11","教学"),
                new DicItem("12","综合"),
                new DicItem("13","实验"),
                new DicItem("14","图书馆(室)"),
                new DicItem("15","体育活动"),
                new DicItem("16","礼堂"),
                new DicItem("20","生活"),
                new DicItem("21","学生宿舍"),
                new DicItem("22","食堂"),
                new DicItem("23","厕所"),
                new DicItem("24","锅炉房(开水房)"),
                new DicItem("25","浴室"),
                new DicItem("26","教工宿舍"),
                new DicItem("30","行政办公"),
                new DicItem("31","办公"),
                new DicItem("32","卫生保健"),
                new DicItem("40","其他"),
                new DicItem("41","通道"),
                new DicItem("51","其他配套设施"),
            };
            
        }
    }
}
