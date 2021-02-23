using BL.Flows.Domain;

namespace BL.Flows.API.Dtos
{
    public class FlowRoleDtoPost : FlowRoleDtoBase
    {
        public FlowRole GetMapClass()
        {
            return new()
            {
                Desc = Desc,
                IsApplyerDept = IsApplyerDept,
                IsFlowRole = IsFlowRole,
                IsSystematic = false,
                Name = Name,
                Users = new()
            };
        }
    }
}