namespace BL.StandardDictionary
{
    /// <summary>
    /// ZSDX 招生对象 JYT1001
    /// </summary>
    public class DicRecruitTarget : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("111","应届初中毕业生"),
                new DicItem("211","应届高中毕业生"),
                new DicItem("311","城镇下岗职工"),
                new DicItem("411","进城务工人员"),
                new DicItem("420","进城务工人员随迁子女"),
                new DicItem("421","外省迁入"),
                new DicItem("422","本省外县迁入"),
                new DicItem("511","农村留守儿童"),
                new DicItem("611","退役士兵"),
                new DicItem("711","农民"),
                new DicItem("811","五年制高职中职段学生"),
            };
            
        }
    }
}
