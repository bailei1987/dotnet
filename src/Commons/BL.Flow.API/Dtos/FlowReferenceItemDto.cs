using System.ComponentModel.DataAnnotations;
using BL.Flows.API.Models;

namespace BL.Flows.API.Dtos
{
    public class FlowReferenceItemDto : IFlowMapClass<FlowReferenceItem>
    {
        [Required]
        public string Rid { get; set; }
        [Required]
        public string Name { get; set; }

        public FlowReferenceItem GetMapClass()
        {
            return new FlowReferenceItem(Rid, Name);
        }
    }
}
