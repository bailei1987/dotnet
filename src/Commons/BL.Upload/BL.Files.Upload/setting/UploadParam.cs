using System.Collections.Generic;
using System.IO;

namespace BL.Files.Upload
{
    /// <summary>
    /// 上传类型
    /// </summary>
    public enum UploadType
    {
        /// <summary>
        /// 单图片
        /// </summary>
        SingleImage,
        /// <summary>
        /// [多]文件
        /// </summary>
        Files,
        /// <summary>
        /// 多图片
        /// </summary>
        MutipleImage
    }
    /// <summary>
    /// 上传文件信息
    /// </summary>
    public class UploadFileInfo
    {
        /// <summary>
        /// 上传文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 上传文件流
        /// </summary>
        public Stream FileStream { get; set; }


    }
    /// <summary>
    /// 上传参数
    /// </summary>
    public class UploadParam
    {
        /// <summary>
        /// 当前上传目录
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// 是否生成日期文件夹.格式:yyyyMMdd 位于上传目录之下
        /// </summary>
        public bool HasDateDirecotry { get; set; }
        /// <summary>
        /// 上传类型
        /// </summary>
        public UploadType UploadType { get; set; }
        /// <summary>
        /// 上传文件
        /// </summary>
        public IEnumerable<UploadFileInfo> UploadFiles { get; set; }
        /// <summary>
        /// 要删除的文件
        /// </summary>
        public IEnumerable<FileItemBase> DeleteFiles { get; set; }
    }

    public class ImageCompressSetting
    {
        /// <summary>
        /// 压缩质量0-100
        /// </summary>
        public int Quality { get; set; }
        /// <summary>
        /// 压缩图宽,未指定则于原图相同
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// 压缩图高,未指定则于原图相同
        /// </summary>
        public int? Height { get; set; }
    }
    /// <summary>
    /// 图片上传参数
    /// </summary>
    public class ImageUploadParam : UploadParam
    {
        /// <summary>
        /// 压缩设置
        /// </summary>
        public IEnumerable<ImageCompressSetting> ImageCompressSettings { get; set; }

    }

}
