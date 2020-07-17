using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BL.Files.Save.API
{

    public static class FilesSaveBuildExtensions
    {
        public static IApplicationBuilder UseBLFilesSave(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
        {
            var tipTitle = "BL.Files.Save.API.UseBLFilesSave method:";
            var maxSize = configuration["FILESSAVE_SETTINGS_MAXSIZE"];
            if (!string.IsNullOrWhiteSpace(maxSize))
            {
                if (long.TryParse(maxSize, out long tmaxSize) == false) throw new Exception($"{tipTitle} can not convert [FILESSAVE_SETTINGS_MAXSIZE] in env to type long");
                else
                {
                    FilesSaveSettings.MaxSize = tmaxSize;
                    Console.WriteLine($"{tipTitle} find FILESSAVE_SETTINGS_MAXSIZE in env,use value [{FilesSaveSettings.MaxSize}]Byte");
                }
            }
            else
            {
                Console.WriteLine($"{tipTitle} no FILESSAVE_SETTINGS_MAXSIZE in env,try get settings from appsettings.json)");
                var sets = configuration.GetSection("FilesSaveSettings");
                if (sets is null)
                {
                    Console.WriteLine($"{tipTitle} cant find FilesSaveSettings.MaxSize in appsettings.json,use default value [{FilesSaveSettings.MaxSize}]Byte");
                }
                else
                {
                    var maxsizeSection = sets.GetSection("MaxSize");
                    if (maxsizeSection is null) Console.WriteLine($"{tipTitle} cant find FilesSaveSettings.MaxSize in appsettings.json,use default value [{FilesSaveSettings.MaxSize}]Byte");
                    else
                    {
                        try
                        {
                            FilesSaveSettings.MaxSize = maxsizeSection.Get<long>();
                            Console.WriteLine($"{tipTitle} find FilesSaveSettings.MaxSize in appsettings.json,use value [{FilesSaveSettings.MaxSize}]Byte");
                        }
                        catch
                        {
                            throw new Exception($"{tipTitle} can not convert [FilesSaveSettings.MaxSize] in appsettings.json to type long");
                        }
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(env.WebRootPath)) env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            FilesSaveSettings.WebRootPath = env.WebRootPath;
            //
            app.UseStaticFiles();
            return app;
        }
        /*
        /// <summary>
        /// get get settings from env or appsettings.json
        /// [required]RootFloder: FILESSAVE_SETTINGS_ROOTFLODER(env),FilesSaveSettings.RootFloder(appsettings.json)
        /// [default:long.MaxValue]MaxSize: FILESSAVE_SETTINGS_MAXSIZE(env),FilesSaveSettings.MaxSize
        /// </summary>
        public static IApplicationBuilder UseBLFilesSave(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
        {
            var tipTitle = "BL.Files.Save.API.UseBLFilesSave method:";
            Console.WriteLine($"{tipTitle} Start Configure!");
            FilesSaveSettings.RootFloder = configuration["FILESSAVE_SETTINGS_ROOTFLODER"];
            if (!string.IsNullOrWhiteSpace(FilesSaveSettings.RootFloder))
            {
                Console.WriteLine($"{tipTitle} find FILESSAVE_SETTINGS_ROOTFLODER in env,use value [{FilesSaveSettings.RootFloder}] for Upload RootFloder)");
                var maxSize = configuration["FILESSAVE_SETTINGS_MAXSIZE"];
                if (!string.IsNullOrWhiteSpace(maxSize))
                {
                    if (long.TryParse(maxSize, out long tmaxSize) == false) throw new Exception($"{tipTitle} can not convert [FILESSAVE_SETTINGS_MAXSIZE] in env to type long");
                    else
                    {
                        FilesSaveSettings.MaxSize = tmaxSize;
                        Console.WriteLine($"{tipTitle} find FILESSAVE_SETTINGS_MAXSIZE in env,use value [{FilesSaveSettings.MaxSize}]");
                    }
                }
                else
                {
                    Console.WriteLine($"{tipTitle} no FILESSAVE_SETTINGS_MAXSIZE in env,use default(long.MaxValue)");
                }
            }
            else
            {
                Console.WriteLine($"{tipTitle} no FILESSAVE_SETTINGS_ROOTFLODER in env,try get settings from appsettings.json");
                var sets = configuration.GetSection("FilesSaveSettings");
                if (sets is null) throw new Exception($"{tipTitle} cant not find FilesSaveSettings in appsettings.json");
                FilesSaveSettings.RootFloder = sets.GetValue<string>("RootFloder");
                if (string.IsNullOrWhiteSpace(FilesSaveSettings.RootFloder)) throw new Exception($"{ tipTitle } cant not find FilesSaveSettings.RootFloder or FilesSaveSettings.RootFloder is empty in appsettings.json");
                FilesSaveSettings.MaxSize = sets.GetValue<long>("MaxSize");
                Console.WriteLine($"{tipTitle} find FilesSaveSettings.MaxSize in appsettings.json,use value [{FilesSaveSettings.MaxSize}]");
            }

            if (string.IsNullOrWhiteSpace(env.WebRootPath)) env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            FilesSaveSettings.WebRootPath = env.WebRootPath;
            //
            app.UseStaticFiles();
            return app;
        }
        */
    }


}