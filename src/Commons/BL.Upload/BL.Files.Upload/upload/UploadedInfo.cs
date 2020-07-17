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
        public UploadedInfo()
        {
            Uploaded = new List<FilesItem>();
            Deleted = new List<DeletedItem>();
        }
        public Uploads Uploads
        {
            get;
            set;
        }
        public List<FilesItem> Uploaded { get; set; }
        public List<DeletedItem> Deleted { get; set; }
    }
}