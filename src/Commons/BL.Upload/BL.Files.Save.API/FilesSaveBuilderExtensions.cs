using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BL.Files.Save.API
{

    public static class FilesSaveBuildExtensions
    {
        public static IApplicationBuilder UseBLFilesSave(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
        {
            var tipTitle = "BL.Files.Save.API.UseBLFilesSave method:";
            FilesSaveSettings.RootFloder = configuration["FILESSAVE_SETTINGS_ROOTFLODER"];
            if (!string.IsNullOrWhiteSpace(FilesSaveSettings.RootFloder))
            {
                Console.WriteLine($"{tipTitle} find FILESSAVE_SETTINGS_ROOTFLODER in env,use value [{FilesSaveSettings.RootFloder}] for Upload RootFloder)");
            }
            else
            {
                Console.WriteLine($"{tipTitle} no RootFloder in env,try get settings from appsettings.json");
                var sets = configuration.GetSection("FilesSaveSettings");
                if (sets is null) throw new($"{tipTitle} cant find FilesSaveSettings.RootFloder in appsettings.json");
                FilesSaveSettings.RootFloder = sets["RootFloder"];
                if (string.IsNullOrWhiteSpace(FilesSaveSettings.RootFloder)) throw new($"{tipTitle} cant find FilesSaveSettings.RootFloder in appsettings.json");
                Console.WriteLine($"{tipTitle} find FilesSaveSettings.RootFloder in appsettings.json,use value [{FilesSaveSettings.RootFloder}] for Upload RootFloder)");
            }
            //
            var maxSize = configuration["FILESSAVE_SETTINGS_MAXSIZE"];
            if (!string.IsNullOrWhiteSpace(maxSize))
            {
                if (long.TryParse(maxSize, out long tmaxSize) == false) throw new($"{tipTitle} can not convert [FILESSAVE_SETTINGS_MAXSIZE] in env to type long");
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
                            throw new($"{tipTitle} can not convert [FilesSaveSettings.MaxSize] in appsettings.json to type long");
                        }
                    }
                }
            }
            if (string.IsNullOrWhiteSpace(env.WebRootPath)) env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            FilesSaveSettings.WebRootPath = env.WebRootPath;
            FilesSaveSettings.Ok = true;
            //
            _ = app.UseStaticFiles();
            return app;
        }
    }
}