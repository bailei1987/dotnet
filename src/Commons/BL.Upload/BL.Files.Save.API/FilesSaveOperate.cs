using System;
using System.IO;

namespace BL.Files.Save.API
{
    public class FilesSaveOperate
    {
        private static readonly string tipTitle = "BL.Files.Save.API FilesSaveOperate:";
        private static void ValidateSize(long length)
        {
            if (length > FilesSaveSettings.MaxSize) throw new Exception($"{tipTitle} file size [{length}]({length / 1024}KB) excess the max size [{FilesSaveSettings.MaxSize}]({FilesSaveSettings.MaxSize / 1024}KB)");
        }

        private static string CreateDirectory(FilesSaveOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Directory)) throw new Exception($"{tipTitle} Directory cant be empty");
            string savePath;
            if (options.CreateDateDirectory) savePath = Path.Combine(Path.DirectorySeparatorChar.ToString(), options.Directory, DateTime.Now.ToString("yyyyMMdd"));
            else savePath = Path.Combine(Path.DirectorySeparatorChar.ToString(), options.Directory);
            var absolutePath = FilesSaveSettings.WebRootPath + savePath;
            if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
            return absolutePath;
        }
        public static string SaveFrom(string base64String, FilesSaveOptions options)
        {
            var imgBytes = Convert.FromBase64String(base64String);
            ValidateSize(imgBytes.Length);
            string directory = CreateDirectory(options);
            string filePath;
            if (!string.IsNullOrWhiteSpace(options.FileName)) filePath = directory + Path.DirectorySeparatorChar.ToString() + options.FileName;
            else filePath = directory + Path.DirectorySeparatorChar.ToString() + Guid.NewGuid().ToString() + "." + options.FileExtension.Replace(".", "");
            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            stream.Write(imgBytes, 0, imgBytes.Length);
            return filePath;
        }

    }
    public class FilesSaveOptions
    {
        public string Directory { get; set; }
        public bool CreateDateDirectory { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
    }
}
