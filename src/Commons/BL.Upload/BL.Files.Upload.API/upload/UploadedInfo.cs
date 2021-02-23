using System.Collections.Generic;

namespace BL.Files.Upload
{
    public class DeletedItem
    {
        public string Path
        {
            get;
            set;
        }
        public string WebRootPath
        {
            get;
            set;
        }
        public string PhysicalPath
        {
            get;
            set;
        }
        public string Msg
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 本次上传的文件
    /// </summary>
    public class UploadedInfo
    {
        public Uploads Uploads
        {
            get;
            set;
        }
        public List<FilesItem> Uploaded { get; set; } = new();
        public List<DeletedItem> Deleted { get; set; } = new();
    }
}