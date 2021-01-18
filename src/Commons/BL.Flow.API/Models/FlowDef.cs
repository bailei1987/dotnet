using System.Collections.Generic;

namespace BL.Flows.API.Models
{
    public class FlowDef
    {
        public string Name { get; set; }
        public int StepsCount { get; set; }
        public ApproveType ApproveType { get; set; }
        public FlowBusiness BusinessType { get; set; }
        public List<FlowDefStep> Steps { get; set; } = new List<FlowDefStep>();

        public string Id { get; set; }
        public FlowOperator Creator { get; set; }
        public string School { get; set; }
    }

    public enum ApproveType
    {
        Continuous = 10, //众签(依次审批)
        All = 20, //会签(不分顺序,全部审批)
        Or = 30, //或签(不分顺序,单人审批),
        Danymic = 40 //动态(无设定步骤,下一步操作当前操作人选人或结束流程决定)
    }

    public class FlowDefReference : FlowReferenceItem
    {
        public ApproveType ApproveType { get; set; }
    }
}
