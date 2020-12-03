using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace BL.Files.Upload.API
{
    public abstract class FileOperateBase
    {
        public const string Original = "O";
        public const string Thumb = "T";
        protected string SavePath;

        protected UploadSettings UploadSettings { get; set; }
        protected Uploads Uploads { get; set; }

        protected void ValidateSize()
        {
            foreach (var file in UploadSettings.UploadParam.UploadFiles)
            {
                if (UploadSettings.MaxSize > 0 && file.Length > UploadSettings.MaxSize) throw new Exception($"exceed the MaxSize(kb) {UploadSettings.MaxSize / 1024} of setting,now is {file.Length / 1024}");
            }
        }
        protected abstract void ValidateFileType();

        protected void CreatePaths()
        {
            if (UploadSettings.UploadParam.HasDateDirecotry)
            {
                SavePath = Path.Combine(Path.DirectorySeparatorChar.ToString(), UploadSettings.RootFloder, UploadSettings.UploadParam.Directory, DateTime.Now.ToString("yyyyMMdd"));
            }
            else
            {
                SavePath = Path.Combine(Path.DirectorySeparatorChar.ToString(), UploadSettings.RootFloder, UploadSettings.UploadParam.Directory);
            }
            var absolutePath = UploadSettings.WebRootPath + SavePath;
            if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
        }
        private void Validate()
        {
            ValidateSize();
        }
        protected virtual void SaveOriginal(FilesItem filesItem, UploadFileInfo uploadFile)
        {
            string path = Path.Combine(SavePath, $"{Guid.NewGuid()}_{Original}{uploadFile.Extension}");
            using (var newStream = new FileStream(UploadSettings.WebRootPath + path, FileMode.OpenOrCreate))
            {
                uploadFile.FileStream.CopyTo(newStream);
            }
            filesItem.O = new OriginalItem
            {
                Length = uploadFile.Length,
                Name = uploadFile.FileName,
                FullPath = $"{UploadSettings.UriPath.TrimEnd('/')}/{path.Replace("\\", "/").TrimStart('/')}",
                UriPath = UploadSettings.UriPath,
                Path = path,
                Suff = uploadFile.Extension,
                No = Uploads.Files.Count
            };
        }
        protected abstract void SaveAddtional(FilesItem filesItem, UploadFileInfo uploadFile);
        /// <summary>
        /// 上传文件
        /// </summary>
        public UploadedInfo Save()
        {
            Validate();
            CreatePaths();
            UploadedInfo uploadedInfo = new UploadedInfo();
            foreach (var file in UploadSettings.UploadParam.UploadFiles)
            {
                var item = new FilesItem();
                SaveOriginal(item, file);
                SaveAddtional(item, file);
                item.SetStatus(FileStatus.Uploaded);
                Uploads.Files.Add(item);
                uploadedInfo.Uploaded.Add(item);
            }
            uploadedInfo.Deleted.AddRange(DeleteOldFiles());
            uploadedInfo.Uploads = Uploads;
            return uploadedInfo;
        }
        private List<DeletedItem> DeleteOldFiles()
        {
            List<DeletedItem> list = new List<DeletedItem>();
            if (UploadSettings.UploadParam.DeleteFiles != null)
            {
                foreach (var item in UploadSettings.UploadParam.DeleteFiles)
                {
                    DeletedItem deleted = new DeletedItem()
                    {
                        Path = item.Path,
                        PhysicalPath = $"{UploadSettings.WebRootPath.TrimEnd('/')}/{item.Path.TrimStart('/')}"
                    };
                    if (File.Exists(deleted.PhysicalPath))
                    {
                        File.Delete(deleted.PhysicalPath);
                        deleted.Msg = "success";
                    }
                    else deleted.Msg = "failed,the file not find";
                    list.Add(deleted);
                }
            }
            return list;
        }
        /// <summary>
        /// 创建图片处理对象
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="newName">新文件名,当未指定该名时,文件名随机</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="path">保存路径</param>
        public static FileOperateBase CreateOperate(Uploads uploads, UploadSettings uploadSettings)
        {
            FileOperateBase fileOperate = null;
            if (uploadSettings.UploadParam.UploadType == UploadType.SingleImage || uploadSettings.UploadParam.UploadType == UploadType.MutipleImage)
            {
                fileOperate = new ImageFileOperate();
            }
            else if (uploadSettings.UploadParam.UploadType == UploadType.Files)
            {
                fileOperate = new FilesOperate();
            }
            fileOperate.Uploads = uploads;
            fileOperate.UploadSettings = uploadSettings;
            return fileOperate;
        }

    }
    /// <summary>
    /// 图片上传操作类
    /// </summary>
    public class ImageFileOperate : FileOperateBase
    {
        protected override void ValidateFileType() { }

        protected override void SaveAddtional(FilesItem filesItem, UploadFileInfo uploadFile)
        {
            var param = (ImageUploadParam)UploadSettings.UploadParam;

            if (param.ImageCompressSettings != null && param.ImageCompressSettings.Any())
            {

                string nameT = Path.GetFileNameWithoutExtension(filesItem.O.Path).Replace(Original, Thumb), name;
                Image img = Image.FromStream(uploadFile.FileStream);
                int imgWidth = img.Width, imgHeight = img.Height;
                int i = 0;

                foreach (var item in param.ImageCompressSettings)
                {
                    CompressItem compress = new CompressItem()
                    {
                        Quality = item.Quality,
                        Width = item.Width ?? imgWidth,
                        Height = item.Height ?? imgHeight
                    };
                    name = nameT + i.ToString() + uploadFile.Extension;
                    compress.Length = SaveThumImg(uploadFile.Extension, img, name, compress.Width, compress.Height, compress.Quality);
                    compress.UriPath = UploadSettings.UriPath;
                    compress.Path = Path.Combine(SavePath, name).Replace('\\', '/');
                    compress.FullPath = $"{compress.UriPath.TrimEnd('/')}/{compress.Path.TrimStart('/')}";
                    compress.No = i;
                    filesItem.Ts.Add(compress);
                    i++;
                }
            }
        }
        protected long SaveThumImg(string suffix, Image imgSource, string filename, int width, int height, int quality)
        {
            suffix = (suffix.Substring(1) == "jpg" ? "jpeg" : suffix.Substring(1));
            ImageCodecInfo imageCodecInfo = GetEncoderInfo($"image/{suffix}");
            EncoderParameter ep = new EncoderParameter(Encoder.Quality, quality);
            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = ep;
            Bitmap imgNew = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(imgNew);
            g.DrawImage(imgSource, 0, 0, width, height);
            imgNew.Save(UploadSettings.WebRootPath + Path.Combine(SavePath, filename), imageCodecInfo, eps);//保存物理文件
            using (MemoryStream stream = new MemoryStream())//获取大小
            {
                imgNew.Save(stream, imageCodecInfo, eps);
                long length = stream.Length;
                return length;
            }
        }
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
    /// <summary>
    /// 通用文件上传操作类
    /// </summary>
    public class FilesOperate : FileOperateBase
    {
        protected override void SaveAddtional(FilesItem filesItem, UploadFileInfo uploadFile) { }

        protected override void ValidateFileType() { }
    }
}
