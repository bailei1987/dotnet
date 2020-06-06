using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    public class NameItemDto : IMapClass<ReferenceItem>
    {
        [Required]
        public string Name { get; set; }

        public ReferenceItem GetMapClass()
        {
            return new ReferenceItem { Name = Name };
        }
    }
}
