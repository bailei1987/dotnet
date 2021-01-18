using System.ComponentModel.DataAnnotations;

namespace BL.Flows.API.Models
{
    public class FlowBusiness
    {
        [Required]
        public string K { get; set; }
        [Required]
        public string V { get; set; }
    }
}
