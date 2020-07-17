using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Files.Upload
{
    /// <summary>
    /// 上传信息基类
    /// </summary>
    public class Uploads
    {
        public Uploads()
        {
            Files = new List<FilesItem>();
        }
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string App { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string BusinessType { get; set; }
        /// <summary>
        /// 上传类型
        /// </summary>
        public UploadType UploadType { get; set; }

        /// <summary>
        /// 上传文件信息
        /// </summary>
        public List<FilesItem> Files { get; set; }

        public virtual void RemoveFiles(IEnumerable<FileItemBase> files)
        {
            Files.RemoveAll(x => files.Select(f => f.Path).Contains(x.O.Path));
        }
        public virtual void ClearFiles()
        {
            Files.Clear();
        }
        public virtual bool HasFile()
        {
            return Files.Count > 0;
        }
        public virtual IEnumerable<FileItemBase> GetFiles()
        {
            List<FileItemBase> list = new List<FileItemBase>();
            foreach (var item in Files)
            {
                if (item.O != null) list.Add(item.O);
                list.AddRange(item.Ts);
            }
            return list;
        }
        //public virtual UploadedInfo GetUploadedFiles()
        //{
        //    return new UploadedInfo()
        //    {
        //        UploadId = Id,
        //        Files = Files.FindAll(x => x.Status == FileStatus.Uploaded)
        //    };
        //}    
    }
}
