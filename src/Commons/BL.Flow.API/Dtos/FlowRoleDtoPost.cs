using System.Collections.Generic;
using BL.Flows.API.Models;

namespace BL.Flows.API.Dtos
{
    public class FlowRoleDtoPost : FlowRoleDtoBase
    {
        public FlowRole GetMapClass()
        {
            var obj = new FlowRole
            {
                Desc = Desc,
                IsApplyerDept = IsApplyerDept,
                IsFlowRole = IsFlowRole,
                IsSystematic = false,
                Name = Name,
                Users = new List<FlowReferenceItem>()
            };
            return obj;
        }
    }
}