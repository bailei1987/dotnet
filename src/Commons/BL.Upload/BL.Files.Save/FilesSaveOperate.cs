using System;
using System.IO;

namespace BL.Files.Save
{
    public class FilesSaveOperate
    {
        private static readonly string tipTitle = "BL.Files.Save.API FilesSaveOperate:";
        public static void SettingsCheck()
        {
            if (FilesSaveSettings.Ok == false) throw new Exception($"{tipTitle} CheckSetting error,please check if use BL.Files.Save.API.UseBLFilesSave method in startup.cs");
        }
        private static void ValidateSize(long length)
        {
            if (length > FilesSaveSettings.MaxSize) throw new Exception($"{tipTitle} file size [{length}]({length / 1024}KB) excess the max size [{FilesSaveSettings.MaxSize}]({FilesSaveSettings.MaxSize / 1024}KB)");
        }

        private static string CreateDirectory(FilesSaveOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Directory)) throw new Exception($"{tipTitle} Directory cant be empty");
            string savePath;
            if (options.CreateDateDirectory) savePath = Path.Combine(Path.DirectorySeparatorChar.ToString(),FilesSaveSettings.RootFloder, options.Directory, DateTime.Now.ToString("yyyyMMdd"));
            else savePath = Path.Combine(Path.DirectorySeparatorChar.ToString(), FilesSaveSettings.RootFloder, options.Directory);
            var absolutePath = FilesSaveSettings.WebRootPath + savePath;
            if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
            return absolutePath;
        }
        public static string SaveFrom(string base64String, FilesSaveOptions options)
        {
            SettingsCheck();
            byte[] imgBytes;
            try
            {
                imgBytes = Convert.FromBase64String(base64String);
            }
            catch
            {
                throw new Exception("cant convert to byte[] from this string,need Base64String");
            }
            ValidateSize(imgBytes.Length);
            string directory = CreateDirectory(options);
            string filePath;
            if (!string.IsNullOrWhiteSpace(options.FileName)) filePath = directory + Path.DirectorySeparatorChar.ToString() + options.FileName;
            else filePath = directory + Path.DirectorySeparatorChar.ToString() + Guid.NewGuid().ToString() + "." + options.FileExtension.Replace(".", "");
            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            stream.Write(imgBytes, 0, imgBytes.Length);
            return filePath;
        }
        public static bool Delete(string relativePath)
        {
            SettingsCheck();
            var physicalPath = FilesSaveSettings.WebRootPath.TrimEnd('/') + "/" + relativePath.TrimStart('/');
            return DeleteByPhysicalh(physicalPath);
        }
        public static bool DeleteByPhysicalh(string physicalPath)
        {
            SettingsCheck();
            if (File.Exists(physicalPath))
            {
                File.Delete(physicalPath);
                return true;
            }
            return false;
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
