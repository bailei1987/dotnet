using BL.MongoDB;
using BL.Upload.API.GridFS;
using BL.WebApi.ResultProcess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using models;
using System.Text.Json.Serialization;

namespace example.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string[] origins = Configuration.GetValue<string>("AllowedHosts").Split(",");
            //
            _ = services.AddCors(options => options.AddPolicy("AllowedHosts", builder => _ = builder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader()));
            //db
            var db = services.AddBLMongoDbContext<DbContext>(Configuration, opt => opt.AddNotConvertObjectIdToStringTypes(typeof(Test2)));
            _ = services.AddGridFSUpload(db._database, new() { ChunkSizeBytes = 1048576 });
            //same format of api results
            _ = services.AddControllers(options =>
            options.Filters.Add<ActionExecuteFilter>()).AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())).SetCompatibilityVersion(CompatibilityVersion.Latest);

            //
            _ = services.AddSwaggerGen(options =>
               options.SwaggerDoc("v1", new()
               {
                   Title = "example.API",
                   Version = "v1",
                   Description = ""
               }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            _ = app.UseResponseTime();
            _ = app.UseGlobalException();
            _ = app.UseCors("AllowedHosts");
            //_ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints =>
               _ = endpoints.MapControllers());
            _ = app.UseSwagger().UseSwaggerUI(c =>
               {
                   string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                   c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "My API");
               });
        }
    }
}
