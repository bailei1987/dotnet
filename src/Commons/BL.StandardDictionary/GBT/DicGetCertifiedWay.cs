using System.Collections.Generic;

namespace BL.StandardDictionary
{
    /// <summary>
    ///取得资格途径代码 本代码引自GB/T 14946.1-2009 附录A.11，见表A.8。 JYT1001
    ///仅取了主要部分
    /// </summary>
    public class DicGetCertifiedWay : DicItem
    {
        protected override DicItem[] AllOption()
        {
            return new[]{
                new DicItem("1","评审"),
                new DicItem("2","考试"),
                new DicItem("3","特批"),
                new DicItem("9","其他"),
            }; 
        }
    }
}
