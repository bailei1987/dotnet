using BL.Common;
using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    /// <summary>
    /// only have v,use for import of KVItem
    /// </summary>
    public class KItemDto : IMapClassOnly<KVItem>
    {
        [Required]
        public string K { get; set; }

        public KVItem GetMapClass()
        {
            return new()
            {
                K = K
            };
        }
    }
}
