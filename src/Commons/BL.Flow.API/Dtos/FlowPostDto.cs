using System.ComponentModel.DataAnnotations;

namespace BL.Flows.API.Dtos
{
    public abstract class FlowPostDto
    {
        [Required]
        public string FlowDef { get; set; }
        public FlowReferenceItemDto Creator { get; set; }

    }
}
