namespace BL.Common
{
    /// <summary>
    /// 上传文件信息
    /// </summary>
    public class UploadImageInfo
    {
        public string Url { get; set; }
        public string UploadId { get; set; }
        public FileItem File { get; set; }

    }
    public class UploadFilesInfo
    {
        public int FilesCount { get; set; }
        public string UploadId { get; set; }
        public FileItem[] Files { get; set; }
    }
    public class FileItem
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
    }
}
