using BL.Common;

namespace BL.Dto
{
    public static class DtoExtensions
    {
        public static KVItemDto ToDto(this KVItem obj)
        {
            return new()
            {
                K = obj.K,
                V = obj.V
            };
        }
        public static ReferenceItemDto ToDto(this ReferenceItem obj)
        {
            return new () { Rid = obj.Rid, Name = obj.Name };
        }
        public static OperatorItemDto ToDto(this OperatorItem obj)
        {
            return new()
            {
                Name = obj.Name,
                Rid = obj.Rid
            };
        }
        public static UploadImageInfoDto ToDto(this UploadImageInfo obj)
        {
            return new()
            {
                UploadId = obj.UploadId,
                Url = obj.Url
            };
        }
        public static YMNumberDto ToDto(this YMNumber obj)
        {
            return new()
            {
                Y = (int)obj.Y,
                M = (int)obj.M
            };
        }
        public static YearNoDto ToDto(this YearNo obj)
        {
            return new()
            {
                Year = obj.Year,
                No = obj.No
            };
        }
    }
}
