using System;

namespace BL.Common
{
    public class KeywordPageInfo : PageInfo
    {

        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string SearchKey { get; set; }

    }
    public class KeywordIsEnablePageInfo : KeywordPageInfo
    {
        /// <summary>
        /// 数据状态
        /// null:所有(默认)
        /// true:正常
        /// false:禁用
        /// </summary>
        public bool? IsEnable { get; set; }
      
    }

    public class UserPageInfo : KeywordIsEnablePageInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string User { get; set; }
    }

    public class ParentPageInfo : KeywordPageInfo
    {
        /// <summary>
        /// 所属项(父级,分类等)
        /// </summary>
        public ReferenceItem Parent { get; set; }
    }
}
