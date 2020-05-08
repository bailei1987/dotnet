namespace BL.StandardDictionary
{
    /// <summary>
    ///单位经济性质代码(经济类型分类与代码)  JT1001-GB/T 12402-2000
    /// </summary>
    public class DicUnitEconomyCharacter : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("100","内资"),
                new DicItem("110","国有全资"),
                new DicItem("120","集体全资"),
                new DicItem("130","股份合作"),
                new DicItem("140","联营"),
                new DicItem("141","国有联营"),
                new DicItem("142","集体联营"),
                new DicItem("143","国有与集体联营"),
                new DicItem("149","其他联营"),
                new DicItem("150","有限责任（公司）"),
                new DicItem("151","国有独资（公司）"),
                new DicItem("159","其他有限责任（公司）"),
                new DicItem("160","股份有限（公司）"),
                new DicItem("170","私有"),
                new DicItem("171","私有独资"),
                new DicItem("172","私有合伙"),
                new DicItem("173","私营有限责任（公司）"),
                new DicItem("174","私营股份有限（公司）"),
                new DicItem("175","个体经营"),
                new DicItem("179","其他私有"),
                new DicItem("190","其他内资"),
                new DicItem("200","港、澳、台投资"),
                new DicItem("210","内地和港、澳、台合资"),
                new DicItem("220","内地和港、澳、台合作"),
                new DicItem("230","港、澳、台独资"),
                new DicItem("240","港、澳、台投资股份有限（公司）"),
                new DicItem("290","其他港、澳、台投资"),
                new DicItem("300","国外投资"),
                new DicItem("310","中外合资"),
                new DicItem("320","中外合作"),
                new DicItem("330","外资"),
                new DicItem("340","国外投资股份有限（公司）"),
                new DicItem("390","其他国外投资"),
                new DicItem("900","其他"),
            };
            
        }
    }
}
