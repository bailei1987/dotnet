using System.ComponentModel.DataAnnotations;

namespace BL.Flows.Domain
{
    public abstract class FlowPostDto
    {
        [Required]
        public string FlowDef { get; set; }
    }
}
