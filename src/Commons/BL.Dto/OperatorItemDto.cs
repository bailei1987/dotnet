using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    public class OperatorItemDto : IMapClassOnly<OperatorItem>
    {
        [Required]
        public string Rid { get; set; }
        [Required]
        public string Name { get; set; }

        public OperatorItem GetMapClass()
        {
            return new OperatorItem(Rid, Name) { Time = DateTime.Now };
        }
    }
}
