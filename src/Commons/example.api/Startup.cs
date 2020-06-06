using bl.filters;
using BL.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using models;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowedHosts", builder =>
                {
                    builder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader();
                });
            });
            //db contenxt
            //BaseDbContext.RegistConventionPack(options => { options.AddNotConvertObjectIdToStringTypes(typeof(WeatherForecast)); });
            BaseDbContext.RegistConventionPack();
            var connCfg = Configuration.GetSection("db1").Get<NetCoreAppSetting>();
            var db = new DbContext(connCfg);
            services.AddSingleton(db);
            //same format of api results
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionMiddleware>();
                options.Filters.Add<ExecuteMiddleware>();
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            //
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "example.API",
                    Version = "v1",
                    Description = ""
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowedHosts");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger().UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "My API");
            });
        }
    }
}
