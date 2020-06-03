using System.Collections.Generic;

namespace BL.Regions
{
    /// <summary>
    /// 适配iview级联选择
    /// </summary>
    public class RegionCascaderItem
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public List<RegionCascaderItem> Children { get; set; } = new List<RegionCascaderItem>();
        public bool? Loading { get; set; }
    }
}
