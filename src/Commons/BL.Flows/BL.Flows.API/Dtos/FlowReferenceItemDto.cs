using BL.Flows.Domain;
using System.ComponentModel.DataAnnotations;

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
            return new(Rid, Name);
        }
    }
}
