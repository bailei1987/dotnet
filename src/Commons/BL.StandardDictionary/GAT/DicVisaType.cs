namespace BL.StandardDictionary
{
    /// <summary>
    /// 中国签证种类代码 本代码引自GA/T 704.8-2007，见表C.4
    /// </summary>
    public class DicVisaType : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("C","乘务签证"),
                new DicItem("D","定居签证"),
                new DicItem("E","特区旅游签证"),
                new DicItem("F","访问签证"),
                new DicItem("G","过境签证"),
                new DicItem("I","外国人永久居留证"),
                new DicItem("J","常住记者签证"),
                new DicItem("L","旅游签证"),
                new DicItem("M","免办签证"),
                new DicItem("P","临时来华记者证"),
                new DicItem("R","居留许可"),
                new DicItem("S","APEC 商务旅行卡"),
                new DicItem("T","团体签证"),
                new DicItem("U","公务签证"),
                new DicItem("W","外交签证"),
                new DicItem("X","学习签证"),
                new DicItem("Y","礼遇签证"),
                new DicItem("Z","职业签证"),
                new DicItem("Q","其他"),
            };
            
        }
    }
}
