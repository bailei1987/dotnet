namespace BL.Excel
{
    public class ExcelHeaderColumn
    {
        public ExcelHeaderColumn() { }
        public ExcelHeaderColumn(string name, string fieldName)
        {
            Name = name;
            FieldName = fieldName;
            ValueFrom = ValueFrom.Property;
        }
        public string Name { get; set; }
        public string FieldName { get; set; }
        public ValueFrom ValueFrom { get; set; }
        public bool IsDropDownList { get; set; }
        public string[] DropDownListOptions { get; set; }
        public int? Width { get; set; }
        /// <summary>
        /// 在列中的索引
        /// </summary>
        //public int Index { get; set; }
    }
    /// <summary>
    /// 列值的获取方式
    /// </summary>
    public enum ValueFrom
    {
        /// <summary>
        /// 从属性中获取
        /// </summary>
        Property,
        /// <summary>
        /// 从传入字典中获取
        /// </summary>
        Dictionary
    }
}
