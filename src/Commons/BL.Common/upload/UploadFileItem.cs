namespace BL.Common
{
    /// <summary>
    /// 上传文件信息
    /// </summary>
    public class UploadFileItem
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public long Length { get; set; }
        public string ContentType { get; set; }
    }
}
