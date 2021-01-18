
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BL.Flows.API.Models;

namespace BL.Flows.API.Dtos
{
    public abstract class FlowDefDtoBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int StepsCount { get; set; }

        [Required]
        public ApproveType ApproveType { get; set; }

        [Required]
        public FlowBusiness BusinessType { get; set; }

        [Required]
        public List<FlowDefStepDto> Steps { get; set; }
    }

    public class FlowDefStepDto
    {
        [Required]
        public int No { get; set; }

        [Required]
        public FlowReferenceItem Role { get; set; }

        public FlowDefStep GetMapClass()
        {
            return new FlowDefStep
            {
                No = No,
                Role = Role
            };
        }
    }
}