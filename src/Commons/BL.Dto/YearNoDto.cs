using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class YearNoDto : IMapClass<YearNo>
    {
        [Required]
        public int Year { get; set; }
        [Required]
        public int No { get; set; }

        public YearNo GetMapClass()
        {
            return new YearNo { Year=Year,No=No };
        }
    }
}
