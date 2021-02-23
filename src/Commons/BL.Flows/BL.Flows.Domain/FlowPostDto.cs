using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BL.Flows.Domain
{
    public abstract class FlowPostDto
    {
        [Required]
        public string FlowDef { get; set; }
    }
    public abstract class FlowDynamicPostDto : FlowPostDto
    {
        [Required]
        public List<FlowReferenceItem> Operators { get; set; }
    }
}
