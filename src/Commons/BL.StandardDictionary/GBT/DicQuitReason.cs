namespace BL.StandardDictionary
{
    /// <summary>
    ///JYT1001 免职、辞职原因代码 本代码引自GB/T 14946.1-2009 附录A.10
    /// </summary>
    public class DicQuitReason : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","自然免职类"),
                new DicItem("11","任新职免原职"),
                new DicItem("12","离休免职"),
                new DicItem("13","退休免职"),
                new DicItem("14","到龄免职"),
                new DicItem("15","届满免职"),
                new DicItem("16","单位撤销免职"),
                new DicItem("17","单位变更免职"),
                new DicItem("18","挂职终止"),
                new DicItem("1A","去世"),
                new DicItem("1B","牺牲"),
                new DicItem("1Z","其他自然免职"),
                new DicItem("2","因故免职类"),
                new DicItem("21","因病免职"),
                new DicItem("22","因离职学习免职"),
                new DicItem("23","因调出免职"),
                new DicItem("2Z","其他因故免职"),
                new DicItem("3","撤职类"),
                new DicItem("31","因出国不归撤职"),
                new DicItem("32","因受处分撤职"),
                new DicItem("33","因故罢免"),
                new DicItem("34","因判刑撤销职务"),
                new DicItem("3Z","其他原因撤职"),
                new DicItem("4","降职"),
                new DicItem("41","因故停职"),
                new DicItem("42","因工作需要降职"),
                new DicItem("43","因受处分降职"),
                new DicItem("44","考核不称职降职"),
                new DicItem("4Z","其他原因降职"),
                new DicItem("5","辞职"),
                new DicItem("51","因公辞职"),
                new DicItem("52","自愿辞职"),
                new DicItem("53","引咎辞职"),
                new DicItem("54","责令辞职"),
                new DicItem("5Z","其他原因辞职"),
            };
            
        }
    }
}
