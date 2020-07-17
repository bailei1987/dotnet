namespace BL.Files
{
    /// <summary>
    /// 文件状态
    /// </summary>
    public enum FileStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 已删除
        /// </summary>
        Deleted = -1,
        /// <summary>
        /// 已上传
        /// </summary>
        Uploaded = 1
    }
}