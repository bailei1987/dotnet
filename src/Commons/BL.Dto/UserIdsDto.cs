using System.ComponentModel.DataAnnotations;

namespace BL.Dto
{
    public class UserIdsDto
    {
        [Required]
        public string[] Ids { get; set; }
        [Required]
        public string User { get; set; }
    }
}
