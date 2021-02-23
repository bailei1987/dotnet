namespace BL.Files
{
    /// <summary>
    /// 原文件信息
    /// </summary>
    public class OriginalItem : FileItemBase
    {
        public string Name { get; set; }
        public string Suff { get; set; }


        public static OriginalItem From(FileItemBase fileInfo)
        {
            return new()
            {
                Length = fileInfo.Length,
                No = fileInfo.No,
                FullPath = fileInfo.FullPath,
                UriPath = fileInfo.UriPath,
                Path = fileInfo.Path
            };
        }
    }
}