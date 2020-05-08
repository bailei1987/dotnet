namespace BL.StandardDictionary
{
    /// <summary>
    /// JYT1001 JS 角色代码
    /// 仅取了主要的
    /// </summary>
    public class DicAwardRole : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("100","独立完成人"),
                new DicItem("110","项目主持人"),
                new DicItem("120","项目主要负责人"),
                new DicItem("130","项目主要参加者"),
                new DicItem("200","独著人"),
                new DicItem("210","主编"),
                new DicItem("220","副主编"),
                new DicItem("230","作者"),
                new DicItem("240","编写者"),
                new DicItem("250","译者"),
                new DicItem("310","机构负责人"),
                new DicItem("320","机构参加者"),
                new DicItem("410","获奖成果负责人"),
                new DicItem("420","获奖成果参加人"),
                new DicItem("510","专利成果负责人"),
                new DicItem("520","专利成果参加人"),
                new DicItem("610","鉴定成果负责人"),
                new DicItem("620","鉴定成果参加人"),
                new DicItem("710","转让成果负责人"),
                new DicItem("720","转让成果参加人"),
            };
            
        }
    }
}
