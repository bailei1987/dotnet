namespace BL.Files.Upload
{
    /// <summary>
    /// 上传配置类
    /// 上传文件路径层级:RootFloder/Directory/[DateDirecotry]/
    /// </summary>
    public class UploadSettings
    {
        #region 全局基础配置
        public static string App { get; set; }
        /// <summary>
        /// 当前运行目录(绝对路径) [上传前必需配置此项]
        /// </summary>
        public static string WebRootPath;

        /// <summary>
        /// 文件上传根目录
        /// </summary>
        public static string RootFloder;
        /// <summary>
        /// 允许的最大文件大小
        /// </summary>
        public static long MaxSize = long.MaxValue;

        /// <summary>
        /// 资源地址(http://域名.com )[上传前必需配置此项.由Controller Request获取]
        /// </summary>
        public string UriPath { get; set; }

        /// <summary>
        /// 获取设置的路径信息
        /// </summary>
        public string GetPathSettings()
        {
            return "UriPath:" + UriPath + "|" + "WebRootPath:" + WebRootPath + "|" + "RootFloder:" + RootFloder + "|" + "MaxSize:" + MaxSize / 1024 / 1024 + "M";
        }
        #endregion

        #region 上传参数

        public UploadParam UploadParam { get; set; }


        #endregion
    }
}
