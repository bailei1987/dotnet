using BL.Common;
using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    public class NameItemDto : IMapClassOnly<ReferenceItem>
    {
        [Required]
        public string Name { get; set; }

        public ReferenceItem GetMapClass()
        {
            return new()
            {
                Name = Name
            };
        }
    }
}
