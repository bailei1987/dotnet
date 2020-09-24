using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

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
            return new KVItem { K = K };
        }
    }
}
