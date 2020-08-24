using System;
using System.ComponentModel.DataAnnotations;
using BL.Common;

namespace BL.Dto
{
    public class UploadImageInfoDto : IMapClass<UploadImageInfo>
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string UploadId { get; set; }

        public UploadImageInfo GetMapClass(Action<UploadImageInfo> action = null)
        {
            return new UploadImageInfo
            {
                UploadId = UploadId,
                Url = Url
            };
        }
    }
}
