using System;
using System.Linq;
using BL.Flows.API.Models;
using BL.Flows.Domain;

namespace BL.Flows.API.Dtos
{
    public class FlowDefDtoPost : FlowDefDtoBase
    {
        public FlowDef GetMapClass()
        {
            var obj = new FlowDef
            {
                Name = Name,
                StepsCount = StepsCount,
                ApproveType = ApproveType,
                BusinessType = BusinessType,
                Steps = Steps.Select(x => x.GetMapClass()).ToList()
            };
            return obj;
        }
    }
}