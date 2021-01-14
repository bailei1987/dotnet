namespace BL.StandardDictionary
{
    /// <summary>
    /// 教育阶段
    /// </summary>
    public class DicEducationStageType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","学前教育"),
                new DicItem("02","义务教育"),
                new DicItem("03","中等职业教育"),
                new DicItem("04","普通高中"),
                new DicItem("05","高等教育")
            };

        }
    }
}
