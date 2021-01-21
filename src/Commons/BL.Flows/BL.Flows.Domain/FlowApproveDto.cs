namespace BL.Flows.Domain
{
    public class FlowApproveDto
    {
        public bool Agree { get; set; }
        public string Comment { get; set; }
        //public string OperateTitle { get { return Agree ? "审批同意" : "审批拒绝"; } }
    }
}
