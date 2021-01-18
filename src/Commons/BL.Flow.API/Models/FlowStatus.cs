using System;
namespace BL.Flows.API.Models
{
    /// <summary>
    /// </summary>
    public class FlowStatus
    {
        /// <summary>
        /// true:通过 false:不通过 null:流程中
        /// </summary>
        public FlowStatusPass Pass { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? OverTime { get; set; }
    }

    public enum FlowStatusPass
    {
        审批中 = 0,
        已通过 = 1,
        未通过 = 2,
        已撤销 = 3
    }
}
