using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace BL.Files.Upload.API.GridFS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GridFSController : ControllerBase
    {
        private readonly GridFSBucket bucket;
        public GridFSController(GridFSBucket bucket) { this.bucket = bucket; }

        [HttpPost]
        public IEnumerable<UploadItemResult> Post([FromForm] UploadDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.BusinessType)) throw new Exception("BusinessType can not be null");
            if (dto.File is null || dto.File.Count == 0) throw new Exception("no files find");
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
                    Metadata = new BsonDocument
                        {
                            { "contentType",item.ContentType}
                        }
                };
                if (!string.IsNullOrWhiteSpace(GridFSUploadBuildExtensions.BusinessApp)) uploadOptions.Metadata.AddRange(new BsonDocument { { "app", GridFSUploadBuildExtensions.BusinessApp } });
                if (!string.IsNullOrWhiteSpace(dto.BusinessType)) uploadOptions.Metadata.AddRange(new BsonDocument { { "business", dto.BusinessType } });
                if (!string.IsNullOrWhiteSpace(dto.Creator)) uploadOptions.Metadata.AddRange(new BsonDocument { { "creator", dto.Creator } });
                if (!string.IsNullOrWhiteSpace(dto.Category)) uploadOptions.Metadata.AddRange(new BsonDocument { { "category", dto.Category } });
                var oid = bucket.UploadFromStream(item.FileName, item.OpenReadStream(), uploadOptions);
                rsList.Add(new UploadItemResult { FileId = oid.ToString(), FileName = item.FileName, ContentType = item.ContentType });
            }
            return rsList;
        }

        [HttpGet("{id}")]
        public object Get(string id)
        {
            return bucket.OpenDownloadStream(ObjectId.Parse(id), new GridFSDownloadOptions { Seekable = true });
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
            /// 创建者信息
            /// </summary>
            public string Creator { get; set; }
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
        public class UploadItemResult
        {
            public string FileId { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
        }
        #endregion
    }
}