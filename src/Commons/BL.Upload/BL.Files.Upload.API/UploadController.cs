using BL.Files;
using BL.Files.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BL.Files.Upload.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IMongoCollection<Uploads> _uploads;
        public UploadController(IMongoCollection<Uploads> uploads) { _uploads = uploads; }

        #region 常规上传
        /// <summary>
        /// 上传
        /// </summary>
        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public UploadedInfo Post([FromForm] UploadDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.BusinessType)) throw new Exception("BusinessType need to point");
            if (dto.UploadType != UploadType.SingleImage && dto.UploadType != UploadType.Files) throw new Exception("UploadType need be SingleImage|Files");
            //==制作Uploads
            Uploads uploads = null;
            bool isExists = true;
            if (dto.UploadId != null)//从数据库读取
            {
                uploads = _uploads.Find(x => x.Id == dto.UploadId).SingleOrDefault();
                //if (uploads == null) throw new Exception("no data found of this uploadId");
            }
            if (uploads == null)//重新制作
            {
                isExists = false;
                uploads = new Uploads()
                {
                    Id = dto.UploadId,
                    BusinessType = dto.BusinessType,
                    App = dto.App,
                    Creator = dto.Creator,
                    CreateTime = DateTime.Now,
                    UploadType = dto.UploadType
                };
            }
            //==生成设置
            var requestUrl = $"{Request.Scheme}://{Request.Host}";
            //var requestUrl = Request.GetDisplayUrl();
            //requestUrl = requestUrl.Substring(0, requestUrl.LastIndexOf("/Upload"));
            UploadSettings settings = new UploadSettings()
            {
                //UriPath = Request.GetDisplayUrl().Replace("http:", "https:").Replace("File", "")                
                UriPath = requestUrl
            };
            switch (dto.UploadType)
            {
                case UploadType.SingleImage:
                    var pam1 = new ImageUploadParam
                    {
                        UploadType = dto.UploadType,
                        UploadFiles = dto.File.Select(x => new UploadFileInfo() { FileName = x.FileName, Length = x.Length, Extension = Path.GetExtension(x.FileName), FileStream = x.OpenReadStream() }),
                        Directory = !string.IsNullOrEmpty(dto.Directory) ? dto.Directory : dto.BusinessType,
                        DeleteFiles = uploads.GetFiles()
                    };

                    if (dto.CompressesJSON != null) pam1.ImageCompressSettings = JsonSerializer.Deserialize<IEnumerable<ImageCompressSetting>>(dto.CompressesJSON, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    settings.UploadParam = pam1;
                    uploads.ClearFiles();
                    break;
                case UploadType.MutipleImage:
                    var pam2 = new ImageUploadParam
                    {
                        UploadType = dto.UploadType,
                        UploadFiles = dto.File.Select(x => new UploadFileInfo() { FileName = x.FileName, Length = x.Length, Extension = Path.GetExtension(x.FileName), FileStream = x.OpenReadStream() }),
                        Directory = !string.IsNullOrEmpty(dto.Directory) ? dto.Directory : dto.BusinessType,
                    };
                    settings.UploadParam = pam2;

                    if (dto.CompressesJSON != null) pam2.ImageCompressSettings = JsonSerializer.Deserialize<IEnumerable<ImageCompressSetting>>(dto.CompressesJSON, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    if (dto.DeleteFilesJSON != null) pam2.DeleteFiles = JsonSerializer.Deserialize<IEnumerable<FileItemBase>>(dto.DeleteFilesJSON, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    if (pam2.DeleteFiles != null) uploads.RemoveFiles(settings.UploadParam.DeleteFiles);
                    break;
                case UploadType.Files:
                    settings.UploadParam = new UploadParam
                    {
                        UploadType = dto.UploadType,
                        UploadFiles = dto.File.Select(x => new UploadFileInfo() { FileName = x.FileName, Length = x.Length, Extension = Path.GetExtension(x.FileName), FileStream = x.OpenReadStream() }),
                        Directory = !string.IsNullOrEmpty(dto.Directory) ? dto.Directory : dto.BusinessType
                    };

                    if (dto.DeleteFilesJSON != null) settings.UploadParam.DeleteFiles = JsonSerializer.Deserialize<IEnumerable<FileItemBase>>(dto.DeleteFilesJSON, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                    if (settings.UploadParam.DeleteFiles != null) uploads.RemoveFiles(settings.UploadParam.DeleteFiles);
                    break;
            }
            //==上传文件
            var rs = FileOperateBase.CreateOperate(uploads, settings).Save();
            //==更新结果至数据库
            if (!isExists) _uploads.InsertOne(uploads);
            else _uploads.ReplaceOne(x => x.Id == dto.UploadId, uploads);
            //==返回结果至前端
            return rs;
        }

        /// <summary>
        /// 获取上传信息详情
        /// </summary>
        [HttpGet("{uploadId}")]
        public Uploads Get(string uploadId)
        {
            return _uploads.Find(x => x.Id == uploadId).SingleOrDefault();
        }

        [HttpDelete("{uploadId}")]
        public IEnumerable<DeletedItem> Delete(string uploadId)
        {
            List<DeletedItem> rs = new List<DeletedItem>();
            //
            var upload = _uploads.Find(x => x.Id == uploadId).SingleOrDefault();
            if (upload == null) return rs;
            //
            foreach (var item in upload.GetFiles())
            {
                rs.Add(DeletePhysical(UploadSettings.WebRootPath.TrimEnd('/') + "/" + item.Path.TrimStart('/')));
            }
            //
            _uploads.DeleteOne(x => x.Id == uploadId);
            return rs;
        }

        [HttpPut("{uploadId}")]
        public UploadedInfo Put(string uploadId, IEnumerable<FileItemBase> deleteFiles)
        {
            UploadedInfo rs = new UploadedInfo
            {
                Uploads = _uploads.Find(x => x.Id == uploadId).SingleOrDefault()
            };
            if (rs.Uploads == null) throw new Exception("no uploads found");
            //
            var files = rs.Uploads.Files.FindAll(x => deleteFiles.Select(f => f.Path).Contains(x.O.Path));
            foreach (var item in files)
            {
                rs.Deleted.Add(DeletePhysical(UploadSettings.WebRootPath.TrimEnd('/') + "/" + item.O.Path.TrimStart('/')));
                foreach (var t in item.Ts)
                {
                    rs.Deleted.Add(DeletePhysical(UploadSettings.WebRootPath.TrimEnd('/') + "/" + t.Path.TrimStart('/')));
                }
            }
            //remove files info
            rs.Uploads.Files.RemoveAll(x => deleteFiles.Select(f => f.Path).Contains(x.O.Path));
            //update to db
            if (rs.Uploads.Files.Count == 0)
            {
                _uploads.DeleteOne(x => x.Id == rs.Uploads.Id);
            }
            else
            {
                _uploads.ReplaceOne(x => x.Id == rs.Uploads.Id, rs.Uploads);
            }
            return rs;
        }


        private DeletedItem DeletePhysical(string physicalPath)
        {
            var rs = new DeletedItem
            {
                PhysicalPath = physicalPath
            };
            if (System.IO.File.Exists(physicalPath))
            {
                System.IO.File.Delete(physicalPath);
                rs.Msg = "success";
                return rs;
            }
            else
            {
                rs.Msg = "failed,the file not find";
                return rs;
            }
        }
        #endregion

        [HttpGet("CheckSetting")]
        public void CheckSetting()
        {
            if (_uploads is null) throw new Exception("_uploads is null,please setting db and collectionName");
            if (string.IsNullOrWhiteSpace(UploadSettings.WebRootPath)) throw new Exception("UploadSettings.WebRootPath is not setting,please check appsettings");
            if (string.IsNullOrWhiteSpace(UploadSettings.RootFloder)) throw new Exception("UploadSettings.RootFloder is not setting,please check appsettings");
        }

    }

    #region dtos
    public class BaseUploadDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string App { get; set; }
        /// <summary>
        /// 创建者信息
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 资源ID
        /// </summary>
        public string UploadId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string BusinessType { get; set; }
        /// <summary>
        /// 上传文件目录
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// 上传文件(单或多文件)
        /// </summary>
        [Required]
        public IEnumerable<IFormFile> File { get; set; }
        /// <summary>
        /// 上传类型
        /// SingleImage,Files
        /// </summary>
        [Required]
        public UploadType UploadType { get; set; }
    }

    /// <summary>
    /// 文件上传接收对象(与前端传输一致)
    /// </summary>
    public class UploadDto : BaseUploadDto
    {
        /// <summary>
        /// 压缩配置,上传图片(单或多)时有效
        /// </summary>
        public string CompressesJSON { get; set; }
        /// <summary>
        /// 要删除的文件,上传文件或多图片上传时有效
        /// </summary>
        public string DeleteFilesJSON { get; set; }
    }
    public class SingleFileDto
    {
        [Required]
        public IEnumerable<IFormFile> File { get; set; }
    }

    #endregion
}