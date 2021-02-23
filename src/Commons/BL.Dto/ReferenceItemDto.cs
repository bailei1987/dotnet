using BL.Common;
using System.ComponentModel.DataAnnotations;

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
            return new(Rid, Name);
        }
    }
}
