using BL.Common;
using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class YearNoDto : IMapClassOnly<YearNo>
    {
        [Required]
        public int Year { get; set; }
        [Required]
        public int No { get; set; }

        public YearNo GetMapClass()
        {
            return new() { Year = Year, No = No };
        }
    }
}
