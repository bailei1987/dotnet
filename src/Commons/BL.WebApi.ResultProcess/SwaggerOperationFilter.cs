using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace BL.WebApi.ResultProcess
{
    /// <summary>
    /// 需要身份认证的接口加锁图标
    /// </summary>
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo.DeclaringType?.GetCustomAttributes(true).Union(context.MethodInfo.GetCustomAttributes(true)).OfType<AuthorizeAttribute>();
            if (!authAttributes!.Any()) return;
            operation.Security = new List<OpenApiSecurityRequirement> { new()
            {
                {
                    // Put here you own security scheme, this one is an example
                    new ()
                    {
                        Reference = new ()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            }};
            operation.Responses.Add("401", new() { Description = "Unauthorized" });
        }
    }

    //startup.ConfigureServices中,会导致所有接口加锁图标
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement {
    //    {new OpenApiSecurityScheme{ Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme,Id = "Bearer" }}, new string[] { } }
    //});
}
