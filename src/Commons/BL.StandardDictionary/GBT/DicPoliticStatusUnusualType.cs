namespace BL.StandardDictionary
{
    /// <summary>
    ///政治面貌异常类别代码 本代码引自GB/T 14946.1-2009 附录A.17，见表A.11
    /// </summary>
    public class DicPoliticStatusUnusualType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("01","入团转党"),
                new DicItem("02","重新入党"),
                new DicItem("11","延期转正"),
                new DicItem("21","未予登记"),
                new DicItem("22","暂缓登记"),
                new DicItem("31","自动脱党"),
                new DicItem("32","除名"),
                new DicItem("33","取消预备党员资格"),
                new DicItem("34","开除党籍"),
                new DicItem("99","其他"),
            };
            
        }
    }
}
