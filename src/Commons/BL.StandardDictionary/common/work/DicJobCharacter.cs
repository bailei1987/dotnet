namespace BL.StandardDictionary
{
    /// <summary>
    /// 工作岗位性质代码  JT1001-GZGWXZ
    /// </summary>
    public class DicJobCharacter : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","科研"),
                new DicItem("2","教学"),
                new DicItem("3","设计"),
                new DicItem("4","管理"),
                new DicItem("5","生产"),
                new DicItem("6","行政"),
                new DicItem("7","后勤"),
                new DicItem("9","其他"),
            };
            
        }
    }
}
