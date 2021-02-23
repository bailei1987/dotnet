using System;
using System.Collections.Generic;

namespace BL.Common.Reflection
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class PropertyMarkAttribute : Attribute
    {
        public PropertyMarkAttribute() { }
        public PropertyMarkAttribute(string propertyNameCN, string category = null, int showOrder = 10000, bool showAsDetail = true, string filterTextTip = null, string sort = null)
        {
            PropertyNameCN = propertyNameCN;
            Category = category;
            ShowOrder = showOrder;
            ShowAsDetail = showAsDetail;
            FilterTextTip = filterTextTip;
            Sort = sort;
        }
        public string PropertyNameCN { get; set; }
        public string Category { get; set; }

        /// <summary>
        /// 详情中是否显示 默认显示
        /// </summary>
        public bool ShowAsDetail { get; set; }

        /// <summary>
        /// 显示顺序 默认不排序
        /// </summary>
        public int ShowOrder { get; set; } = 10000;

        /// <summary>
        /// 过滤文本框提示
        /// </summary>
        public string FilterTextTip { get; set; }

        /// <summary>
        /// 是否作为导出列
        /// </summary>
        public bool IsExport { get; set; } = true;
        /// <summary>
        /// 排序属性(用于类时)
        /// </summary>
        public string Sort { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class FilterMarkAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="placeholder">提示字符串</param>
        /// <param name="textFilter">文本框搜索 字段名,字段类型;</param>
        /// <param name="selectFilter">下拉框搜索 数据集名,提示,k,v,排序,条件</param>
        public FilterMarkAttribute(string placeholder, string textFilter, string selectFilter)
        {
            Placeholder = placeholder;
            TextFilter = textFilter;
            SelectFilter = selectFilter;
        }

        public string Placeholder { get; set; }

        public string TextFilter { get; set; }

        public string SelectFilter { get; set; }
    }

    public class FilterMark
    {
        public FilterMark(FilterMarkAttribute attr)
        {
            Placeholder = attr.Placeholder;
            TextFilter = new();
            foreach (string str in attr.TextFilter.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] strs = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                TextFilter.Add(new(strs[0], strs[1]));
            }
            SelectFilter = new();
            foreach (string str in attr.SelectFilter.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                SelectFilter.Add(new(str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)));
            }
        }
        public string Placeholder { get; set; }

        public List<KVItem> TextFilter { get; set; }

        public List<KVName> SelectFilter { get; set; }
    }

    public class KVName : KVItem
    {
        public KVName(params string[] args)
        {
            DataSetName = args[0];
            Placeholder = args[1];
            K = args[2];
            V = args[3];
            Field = args[4];
            Sort = args.Length < 6 ? "{\"_id:-1\"}" : args[5];
            Filter = args.Length < 7 ? "{}" : args[6];
        }
        public string DataSetName { get; set; }
        public string Sort { get; set; }
        public string Placeholder { get; set; }
        public string Filter { get; set; }
        public string Field { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class TableColumnsAttribute : Attribute
    {
        /// <summary>
        /// 设置Table的columns
        /// </summary>
        /// <param name="str">标题:C#字段名,</param>
        public TableColumnsAttribute(string str)
        {
            List = new();
            foreach (string s in str.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] array = s.Split(new char[] { ':', '：' }, StringSplitOptions.RemoveEmptyEntries);
                List.Add(new(array[0], array[1]));
            }
        }
        public List<KVItem> List { get; set; }
    }

    /// <summary>
    /// IView 表格列 特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class TableColumnAttribute : Attribute
    {
        /// <summary>
        /// IView 表格列 特性
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="name">属性名 首字母大写</param>
        /// <param name="width">宽度 0为平分剩余所有宽度 默认为0</param>
        /// <param name="align">对齐方式 默认为居中</param>
        public TableColumnAttribute(string title, string name, int width = 0, TableColumnAlign align = TableColumnAlign.center)
        {
            Title = title;
            NameArray = name.Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            CamelList = new();
            foreach (string str in NameArray)
            {
                CamelList.Add(str.ToCamel());
            }
            Key = string.Join("_", CamelList);
            Camel = string.Join(".", CamelList);
            Width = width;
            Align = align;
        }

        /// <summary> 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary> 字段名 Camel 以下划线间隔 用于前端Table的columns
        /// </summary>
        public string Key { get; set; }

        /// <summary> 以点号分隔的属性名数组 首字母大写 用于求Type
        /// </summary>
        public string[] NameArray { get; set; }

        /// <summary> 以点号分隔的字段名列表 Camel 用于求BsonValue
        /// </summary>
        public List<string> CamelList { get; set; }

        /// <summary> 字段名 Camel 用于拼接查询Find参数
        /// </summary>
        public string Camel { get; set; }

        /// <summary> 宽度 0为平分剩余所有宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 对齐方式 
        /// </summary>
        public TableColumnAlign Align { get; set; }
    }

    /// <summary>
    /// 过滤文本框搜索字段 特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class TextFilterAttribute : Attribute
    {
        /// <summary>
        /// 过滤文本框搜索字段 特性
        /// </summary>
        /// <param name="name">字段名 必须Camel 不能包含空格</param>
        /// <param name="option">过滤选项 默认为包含</param>
        public TextFilterAttribute(string name, TextFilterOption option)
        {
            FieldName = name;
            Option = option;
        }

        /// <summary> 字段名 Camel
        /// </summary>
        public string FieldName { get; set; }

        /// <summary> 字段名 Camel
        /// </summary>
        public TextFilterOption Option { get; set; }
    }

    /// <summary>
    /// 过滤下拉列表框 特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class SelectFilterAttribute : Attribute
    {
        /// <summary> 过滤文本框搜索字段 特性
        /// </summary>
        /// <param name="collectionName">集合名 首字母大写</param>
        /// <param name="placeholder">提示</param>
        /// <param name="valueField">Option元素Value字段名</param>
        /// <param name="labelField">Option元素Label字段名</param>
        /// <param name="fieldName">用于在当前集合中查询的字段名</param>
        /// <param name="width">下拉框宽度</param>
        /// <param name="sort">排序字符串 默认为{"identity":-1}</param>
        /// <param name="filter">过滤字符串 默认为{}</param>
        public SelectFilterAttribute(string collectionName, string placeholder, string valueField, string labelField, string fieldName, int width, string sort = "{\"identity\":-1}", string filter = "{}")
        {
            CollectionName = collectionName;
            Placeholder = placeholder;
            ValueField = valueField;
            LabelField = labelField;
            FieldName = fieldName;
            Width = width;
            Sort = sort;
            Filter = filter;
        }
        /// <summary> 集合名 首字母大写
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>  提示
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>  Option元素Value字段名
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>  Option元素Label字段名
        /// </summary>
        public string LabelField { get; set; }

        /// <summary> 用于在当前集合中查询的字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 下拉框宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 排序字符串
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        public string Filter { get; set; }
    }

    /// <summary>
    /// 对齐方式
    /// </summary>
    public enum TableColumnAlign { left, center, right }

    /// <summary> 文本框过滤选项
    /// </summary>
    public enum TextFilterOption { StartsWith, Equal, Contains }

}
