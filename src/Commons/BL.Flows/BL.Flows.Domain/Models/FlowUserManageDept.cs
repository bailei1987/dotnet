using System;
using System.Collections.Generic;

namespace BL.Flows.Domain
{
    public class FlowUserManageDept
    {
        public string Id { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public FlowReferenceItem User { get; set; }

        /// <summary>
        /// 分管部门列表
        /// </summary>
        public List<FlowReferenceItem> Departments { get; set; } = new List<FlowReferenceItem>();

        public FlowOperator Creator { get; set; }
        public string School { get; set; }
    }
}
