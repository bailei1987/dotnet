using System.Text.Json.Serialization;
using BL.MongoDB;
using BL.WebApi.ResultProcess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            _ = services.AddCors(options => options.AddPolicy("AllowedHosts", builder => _ = builder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader()));
            //db
            var db = services.AddBLMongoDbContext<DbContext>(Configuration, opt => opt.AddIdExcepts(typeof(Test2)));
            //same format of api results
            services.AddControllers(options =>
            {
                options.Filters.Add<ActionExecuteFilter>();
                options.Filters.Add<ExceptionFilter>();
            }).AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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
