using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BL.Flows.API.Models;

namespace BL.Flows.API.Dtos
{
    public class FlowUserManageDeptDtoBase
    {
        [Required]
        public FlowReferenceItem User { get; set; }

        [Required]
        public List<FlowReferenceItem> Departments { get; set; }
    }
}