using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class YMNumberDto : IMapClass<YMNumber>
    {
        [Required]
        public int Y { get; set; }
        [Required]
        public int M { get; set; }

        public YMNumber GetMapClass(Action<YMNumber> action = null)
        {
            return new YMNumber { Y=Y,M=M };
        }
    }
    /// <summary>
    /// only have Str,use for import
    /// </summary>
    public class YMNumberDto_Import : IMapClass<YMNumber>
    {
        [Required]
        public string Str { get; set; }

        public YMNumber GetMapClass(Action<YMNumber> action = null)
        {
            var obj = new YMNumber { Str=Str};
            obj.FillByStr();
            return obj;
        }
    }
}
