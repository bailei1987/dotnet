using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    /// <summary>
    /// only have v,use for import of KVItem
    /// </summary>
    public class VItemDto : IMapClass<KVItem>
    {
        [Required]
        public string V { get; set; }

        public KVItem GetMapClass(Action<KVItem> action = null)
        {
            return new KVItem { V = V };
        }
    }
}
