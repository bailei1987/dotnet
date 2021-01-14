namespace BL.Upload.API.GridFS
{
    public class UploadItemResult
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        public string ContentType { get; set; }
    }
}
