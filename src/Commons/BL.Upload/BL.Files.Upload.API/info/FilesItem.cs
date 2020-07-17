using System.Collections.Generic;

namespace BL.Files
{
    /// <summary>
    /// 
    /// </summary>
    public class FilesItem
    {
        public FilesItem()
        {
            Ts = new List<CompressItem>();
        }
        public OriginalItem O { get; set; }
        public List<CompressItem> Ts { get; set; }
        #region extentions for upload operate,not matter with database   
        /// <summary>
        /// 文件状态
        /// </summary>
        public FileStatus Status { get; set; }
        /// <summary>
        /// 设置状态
        /// </summary>
        public void SetStatus(FileStatus fileStatus)
        {
            Status = fileStatus;
        }
        #endregion
    }
}
