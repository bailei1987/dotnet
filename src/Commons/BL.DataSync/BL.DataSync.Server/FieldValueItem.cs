using System;
namespace BL.DataSync.Server
{
    /// <summary>
    /// 字段值变更条目
    /// </summary>
    public class FieldValueItem
    {
        public string Ds { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public object MyProperty { get; set; }
    }
}
