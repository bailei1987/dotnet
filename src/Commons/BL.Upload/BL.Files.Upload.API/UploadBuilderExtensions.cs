using System;
using System.IO;
using BL.Files.Upload;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BL.Files.Upload.API
{

    public static class UploadBuildExtensions
    {
        /// <summary>
        /// set upload db and collection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="db">upload db</param>
        /// <param name="collection">upload collection</param>
        public static IServiceCollection AddUpload(this IServiceCollection services, IMongoDatabase db, string collection)
        {
            if (db is null || string.IsNullOrWhiteSpace(collection)) throw new Exception("uploads cant be null");
            services.AddSingleton(db.GetCollection<Uploads>(collection));
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;
            });
            return services;
        }
        public static IServiceCollection AddUploadUseDefaultColl(this IServiceCollection services, IMongoDatabase db)
        {
            var coll = db.Client.GetDatabase("blcommon").GetCollection<Uploads>("uploads");
            services.AddSingleton(coll);
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;
            });
            return services;
        }
        /// <summary>
        /// get get settings from env or appsettings.json
        /// [required]RootFloder: UPLOADSETTINGS_ROOTFLODER(env),UploadSettings.RootFloder(appsettings.json)
        /// [default:long.MaxValue]MaxSize: UPLOADSETTINGS_MAXSIZE(env),UploadSettings.MaxSize
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseUpload(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env, string businessApp = null)
        {
            var tipTitle = "BL.Files.Upload.API.UseUpload method:";
            Console.WriteLine($"{tipTitle} Start Configure!");
            UploadSettings.RootFloder = configuration["UPLOADSETTINGS_ROOTFLODER"];
            if (!string.IsNullOrWhiteSpace(UploadSettings.RootFloder))
            {
                Console.WriteLine($"{tipTitle} find UPLOADSETTINGS_ROOTFLODER in env,use value [{UploadSettings.RootFloder}] for Upload RootFloder)");
                var maxSize = configuration["UPLOADSETTINGS_MAXSIZE"];
                if (!string.IsNullOrWhiteSpace(maxSize))
                {
                    if (long.TryParse(maxSize, out long tmaxSize) == false) throw new Exception($"{tipTitle} can not convert [UPLOADSETTINGS_MAXSIZE] in env to type long");
                    else
                    {
                        UploadSettings.MaxSize = tmaxSize;
                        Console.WriteLine($"{tipTitle} find UPLOADSETTINGS_MAXSIZE in env,use value [{UploadSettings.MaxSize}]");
                    }
                }
                else
                {
                    Console.WriteLine($"{tipTitle} no UPLOADSETTINGS_MAXSIZE in env,use default(long.MaxValue)");
                }
            }
            else
            {
                Console.WriteLine($"{tipTitle} no UPLOADSETTINGS_ROOTFLODER in env,try get settings from appsettings.json");
                var sets = configuration.GetSection("UploadSettings");
                if (sets is null) throw new Exception($"{tipTitle} cant not find UploadSettings in appsettings.json");
                UploadSettings.RootFloder = sets.GetValue<string>("RootFloder");
                if (string.IsNullOrWhiteSpace(UploadSettings.RootFloder)) throw new Exception($"{ tipTitle } cant not find UploadSettings.RootFloder or UploadSettings.RootFloder is empty in appsettings.json");
                UploadSettings.MaxSize = sets.GetValue<long>("MaxSize");
                Console.WriteLine($"{tipTitle} find UploadSettings.MaxSize in appsettings.json,use value [{UploadSettings.MaxSize}]");
            }

            if (string.IsNullOrWhiteSpace(env.WebRootPath)) env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            UploadSettings.WebRootPath = env.WebRootPath;
            UploadSettings.App = businessApp;
            //
            app.UseStaticFiles();
            return app;
        }
    }


}