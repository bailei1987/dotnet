using BL.Common;
using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    /// <summary>
    /// only have v,use for import of KVItem
    /// </summary>
    public class VItemDto : IMapClassOnly<KVItem>
    {
        [Required]
        public string V { get; set; }

        public KVItem GetMapClass()
        {
            return new() { V = V };
        }
    }
}
