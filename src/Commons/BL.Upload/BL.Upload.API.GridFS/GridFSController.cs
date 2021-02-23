using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using BL.Files.Upload.API.GridFS.Models;
using MongoDB.Driver;
using BL.Upload.API.GridFS;

namespace BL.Files.Upload.API.GridFS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GridFSController : ControllerBase
    {
        private readonly GridFSBucket bucket;
        public GridFSController(GridFSBucket bucket) { this.bucket = bucket; }

        [Authorize]
        [HttpPost]
        public IEnumerable<UploadItemResult> Post([FromForm] UploadDto dto)
        {
            var user = HttpContext.GetLoginUserFromToken();
            if (string.IsNullOrWhiteSpace(dto.BusinessType)) throw new("BusinessType can not be null");
            if (dto.File is null || dto.File.Count == 0) throw new("no files find");
            var rsList = new List<UploadItemResult> { };
            if (!string.IsNullOrWhiteSpace(dto.DeleteIds))
            {
                var delete_ids = dto.DeleteIds.Split(',', '|', ';');
                foreach (var did in delete_ids)
                {
                    bucket.Delete(ObjectId.Parse(did));
                }
            }
            foreach (var item in dto.File)
            {
                var uploadOptions = new GridFSUploadOptions
                {
                    BatchSize = dto.File.Count,
                    Metadata = new()
                    {
                        { "contentType", item.ContentType }
                    }
                };
                var bapp = dto.App ?? GridFSUploadBuildExtensions.BusinessApp;
                if (string.IsNullOrWhiteSpace(bapp)) throw new("BusinessApp can not be null");
                _ = uploadOptions.Metadata.AddRange(new BsonDocument { { "app", bapp } });
                if (!string.IsNullOrWhiteSpace(dto.BusinessType)) _ = uploadOptions.Metadata.AddRange(new BsonDocument { { "business", dto.BusinessType } });
                if (!string.IsNullOrWhiteSpace(dto.Category)) _ = uploadOptions.Metadata.AddRange(new BsonDocument { { "category", dto.Category } });
                _ = uploadOptions.Metadata.AddRange(new BsonDocument { { "creator", user.ToOperator().ToBsonDocument() } });
                var oid = bucket.UploadFromStream(item.FileName, item.OpenReadStream(), uploadOptions);
                rsList.Add(new()
                {
                    FileId = oid.ToString(),
                    FileName = item.FileName,
                    Length = item.Length,
                    ContentType = item.ContentType
                });
            }
            return rsList;
        }

        [HttpGet("{id}/DownloadStream")]
        public object GetDownloadStream(string id)
        {
            return bucket.OpenDownloadStream(ObjectId.Parse(id), new()
            {
                Seekable = true
            });
        }

        [HttpGet("{id}/FileStream")]
        public FileStreamResult GetFileStream(string id)
        {
            var stream = bucket.OpenDownloadStream(ObjectId.Parse(id), new () { Seekable = true });
            return File(stream, stream.FileInfo.Metadata["contentType"].AsString, stream.FileInfo.Filename);
        }

        [HttpGet("{id}/FileContent")]
        public FileContentResult GetFileContent(string id)
        {
            var fi = bucket.Find("{_id:ObjectId('" + id + "')}").SingleOrDefault() ?? throw new("no data find");
            if (fi.Length >= 1048576 * 5) throw new("该文件超过5M,请使用流下载");
            var bytes = bucket.DownloadAsBytes(ObjectId.Parse(id));
            return File(bytes, fi.Metadata["contentType"].AsString, fi.Filename);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            bucket.Delete(ObjectId.Parse(id));
        }

        #region dtos
        public class UploadDto
        {
            /// <summary>
            /// BusinessApp与该值至少要有一个.当该值存在时,优化取此值.
            /// </summary>
            public string App { get; set; }
            /// <summary>
            /// 资源ID
            /// </summary>
            public string DeleteIds { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [Required]
            public string BusinessType { get; set; }
            /// <summary>
            /// 用于资源中心,记录所属目录id
            /// </summary>
            public string Category { get; set; }
            /// <summary>
            /// 上传文件(单或多文件)
            /// </summary>
            [Required]
            public List<IFormFile> File { get; set; }
        }

        #endregion
    }
}