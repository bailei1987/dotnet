using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    public class OperatorItemDto : IMapClass<OperatorItem>
    {
        [Required]
        public string Rid { get; set; }
        [Required]
        public string Name { get; set; }

        public OperatorItem GetMapClass(Action<OperatorItem> action = null)
        {
            return new OperatorItem(Rid, Name) { Time = DateTime.Now };
        }
    }
}
