using System.ComponentModel.DataAnnotations;

namespace BL.Flows.API.Dtos
{
    public class FlowRoleDtoBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsApplyerDept { get; set; }

        public string Desc { get; set; }

        [Required]
        public bool IsFlowRole { get; set; }
    }
}