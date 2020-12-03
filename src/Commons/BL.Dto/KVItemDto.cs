using BL.Common;
using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    public class KVItemDto : IMapClassOnly<KVItem>
    {
        [Required]
        public string K { get; set; }
        [Required]
        public string V { get; set; }

        public KVItem GetMapClass()
        {
            return new KVItem(K, V);
        }
    }
}
