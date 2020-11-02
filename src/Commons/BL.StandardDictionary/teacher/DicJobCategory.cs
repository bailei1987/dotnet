namespace BL.StandardDictionary
{
    /// <summary>
    /// 现岗位类别
    /// </summary>
    public class DicJobCategory : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","管理岗"),
                new DicItem("2","专技岗"),
                new DicItem("3","工勤岗"),
                new DicItem("99","其他"),
                //new DicItem("4","初级工"),
                //new DicItem("5","专业技术岗"),
                //new DicItem("6","工勤技能岗位四级"),
                //new DicItem("7","中教正高级"),
                //new DicItem("8","中教一级"),
                //new DicItem("9","享受七级待遇"),
                //new DicItem("10","无"),

            };

        }
    }
}
