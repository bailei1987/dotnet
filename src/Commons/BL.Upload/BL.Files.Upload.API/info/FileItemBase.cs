using System.Collections.Generic;

namespace BL.Files
{
    /// <summary>
    /// 上传文件信息基类
    /// </summary>
    public class FileItemBase
    {
        public int No { get; set; }
        /// <summary>
        /// 全路径(如:htt;//192.168.53.132/FileService.Api/upload/studentImg/2332sdfs32asfgd_T.jpg)
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// 资源路径(如:htt;//192.168.53.132/FileService.Api)
        /// </summary>
        public string UriPath { get; set; }
        /// <summary>
        /// 相对路径(如:/upload/studentImg/2332sdfs32asfgd_T.jpg)
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Length { get; set; }

    }
    /// <summary>
    /// 上传文件比较器
    /// </summary>
    public class FileItemComparer : EqualityComparer<FileItemBase>
    {
        public override bool Equals(FileItemBase x, FileItemBase y)
        {
            return x.Path == y.Path;
        }

        public override int GetHashCode(FileItemBase obj)
        {
            throw new System.NotImplementedException();
        }
    }
}