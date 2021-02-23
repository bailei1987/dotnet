using BL.Flows.Domain;
using System.Linq;

namespace BL.Flows.API.Dtos
{
    public class FlowDefDtoPost : FlowDefDtoBase
    {
        public FlowDef GetMapClass()
        {
            return new()
            {
                Name = Name,
                StepsCount = StepsCount,
                ApproveType = ApproveType,
                BusinessType = BusinessType,
                Steps = Steps.Select(x => x.GetMapClass()).ToList()
            };
        }
    }
}