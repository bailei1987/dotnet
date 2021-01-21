using System.Collections.Generic;

namespace BL.Flows.Domain
{
    public class FlowProcess
    {
        public List<FlowStep> Steps { get; set; } = new List<FlowStep>();
        public int StepNow { get; set; }

        /// <summary>
        /// 当前待操作人
        /// </summary>
        public List<FlowReferenceItem> OperatorsNow { get; set; } = new List<FlowReferenceItem>();

        /// <summary>
        /// 历史已操作人列表
        /// </summary>
        public List<FlowReferenceItem> Operators { get; set; } = new List<FlowReferenceItem>();
    }
}
