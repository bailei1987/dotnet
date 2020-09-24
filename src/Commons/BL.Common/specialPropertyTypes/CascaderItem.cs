using System.Collections.Generic;

namespace BL.Common
{
    /// <summary>
    /// 适配iview级联选择
    /// </summary>
    public class CascaderItem
    {
        public string Value { get; set; }//一定得写value，
        public string Label { get; set; }//一定得写label
        public int? Layer { get; set; }
        public string Key { get; set; }
        public bool? Loading { get; set; }
        public List<CascaderItem> Children { get; set; }  //一定得写children
    }
}
