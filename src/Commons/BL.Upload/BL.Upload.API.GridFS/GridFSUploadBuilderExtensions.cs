using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
namespace BL.Upload.API.GridFS
{
    public static class GridFSUploadBuildExtensions
    {
        public static IServiceCollection AddGridFSUpload(this IServiceCollection services, IMongoDatabase database, GridFSBucketOptions gridFSBucketOptions = null, string businessApp = null, bool useDefalutdb = true)
        {
            if (database is null) throw new("db cant be null");
            BusinessApp = businessApp;
            var bucket = new GridFSBucket(useDefalutdb ? database.Client.GetDatabase("blcommon") : database, gridFSBucketOptions);
            _ = services.Configure<FormOptions>(options =>
              {
                  options.MultipartBodyLengthLimit = long.MaxValue;
                  options.ValueLengthLimit = int.MaxValue;
              });
            _ = services.Configure<KestrelServerOptions>(options => options.Limits.MaxRequestBodySize = int.MaxValue);
            _ = services.AddSingleton(bucket);
            return services;
        }
        public static string BusinessApp { get; set; }
    }
}