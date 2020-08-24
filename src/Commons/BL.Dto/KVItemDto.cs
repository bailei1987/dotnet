using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    public class KVItemDto : IMapClass<KVItem>
    {
        [Required]
        public string K { get; set; }
        [Required]
        public string V { get; set; }

        public KVItem GetMapClass(Action<KVItem> action = null)
        {
            return new KVItem(K, V);
        }
    }
}
