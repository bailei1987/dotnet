using System;
using System.ComponentModel.DataAnnotations;

namespace BL.Flows.API.Models
{
    public class FlowBusinessContentsItem
    {
        [Required]
        public string Lable { get; set; }
        public string Value { get; set; }
    }
}
