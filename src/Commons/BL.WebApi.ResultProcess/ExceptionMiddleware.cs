using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BL.WebApi.ResultProcess
{
    class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonSerializer.Serialize(new
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Msg = ex.Message,
                Data = default(object)
            },
            typeof(object),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Converters= { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            });
            var code = HttpStatusCode.OK; // 将返回状态码置为200
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
    /// <summary>
    /// 全局异常中间件
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalException(this IApplicationBuilder builder) => builder.UseMiddleware<ExceptionMiddleware>();
    }
}
