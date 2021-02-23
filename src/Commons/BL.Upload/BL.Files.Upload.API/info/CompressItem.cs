namespace BL.Files
{
    /// <summary>
    /// 压缩文件信息
    /// </summary>
    public class CompressItem : FileItemBase
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Quality { get; set; }

        public static CompressItem From(FileItemBase fileInfo)
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