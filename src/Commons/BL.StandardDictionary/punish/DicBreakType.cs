namespace BL.StandardDictionary
{
    /// <summary>
    ///违纪类别(JYT1001-WJLB)
    /// </summary>
    public class DicBreakType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","触犯刑法"),
                new DicItem("02","违反治安管理条例"),
                new DicItem("03","学业违纪（考试作弊、旷课）"),
                new DicItem("04","涂改、伪造证件或证明"),
                new DicItem("05","侵犯他人人身权利"),
                new DicItem("06","侵犯公私财物"),
                new DicItem("07","侵犯学校权益"),
                new DicItem("08","危害公共安全"),
                new DicItem("09","扰乱公共场所秩序"),
                new DicItem("10","违反社团管理规定"),
                new DicItem("11","违反课外活动规定"),
                new DicItem("12","违反宿舍管理规定"),
                new DicItem("13","违反网络管理规定"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
