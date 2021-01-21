using System;
namespace BL.Flows.Domain
{
    /// <summary>
    /// 流程操作步骤
    /// </summary>
    public class FlowStep : FlowDefStep
    {
        /// <summary>
        /// 操作人
        /// </summary>
        public FlowReferenceItem Operator { get; set; }

        /// <summary>
        /// 本步骤开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperateTime { get; set; }

        /// <summary>
        /// true:同意 false:不同意 null:未操作
        /// </summary>
        public bool? Agree { get; set; }

        /// <summary>
        /// 意见
        /// </summary>
        public string Comment { get; set; }
    }
}
