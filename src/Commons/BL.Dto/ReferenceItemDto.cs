using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    public class ReferenceItemDto : IMapClassOnly<ReferenceItem>
    {
        [Required]
        public string Rid { get; set; }
        [Required]
        public string Name { get; set; }

        public ReferenceItem GetMapClass()
        {
            return new ReferenceItem(Rid, Name);
        }
    }
}
