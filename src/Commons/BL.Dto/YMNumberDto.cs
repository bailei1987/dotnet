using BL.Common;
using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class YMNumberDto : IMapClassOnly<YMNumber>
    {
        [Required]
        public int Y { get; set; }
        [Required]
        public int M { get; set; }

        public YMNumber GetMapClass()
        {
            return new() { Y = Y, M = M };
        }
    }
    /// <summary>
    /// only have Str,use for import
    /// </summary>
    public class YMNumberDto_Import : IMapClassOnly<YMNumber>
    {
        [Required]
        public string Str { get; set; }

        public YMNumber GetMapClass()
        {
            var obj = new YMNumber { Str = Str };
            _ = obj.FillByStr();
            return obj;
        }
    }
}
