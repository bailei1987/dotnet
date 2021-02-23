using System.Collections.Generic;

namespace BL.Flows.Domain
{
    public class FlowRole
    {
        public string Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 是否为申请人同部门
        /// </summary>
        public bool IsApplyerDept { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 是否系统角色(无法删除,预先定义)
        /// </summary>
        public bool IsSystematic { get; set; }

        /// <summary>
        ///是否流程角色(为否时不参与流程)
        /// </summary>
        public bool IsFlowRole { get; set; } = true;

        /// <summary>
        /// </summary>
        //public List<ReferenceItem> ManageDepts { get; set; }
        public List<FlowReferenceItem> Users { get; set; }

        /// <summary>
        /// </summary>
        public FlowOperator Creator { get; set; }

        public string School { get; set; }
    }
}
