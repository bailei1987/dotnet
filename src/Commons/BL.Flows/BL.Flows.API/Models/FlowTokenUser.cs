using BL.Flows.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace BL.Flows.API.Models
{
    public static class HttpContextExtension
    {
        public static FlowTokenUser GetFlowLoginUserFromToken(this HttpContext httpContext)
        {
            var tokenT = httpContext.GetTokenAsync("access_token") ?? throw new("token is empty");
            var token = new JwtSecurityToken(tokenT.Result);
            var c_rid = token.Claims.FirstOrDefault(x => x.Type == "client_user_rid");
            var c_name = token.Claims.FirstOrDefault(x => x.Type == "client_user_name");
            var c_type = token.Claims.FirstOrDefault(x => x.Type == "client_user_type");
            var c_school = token.Claims.FirstOrDefault(x => x.Type == "client_user_school");
            var c_tag1 = token.Claims.FirstOrDefault(x => x.Type == "client_user_tag1");
            return c_rid is null | c_name is null || c_type is null
                ? throw new("rid,name,type missing")
                : new FlowTokenUser
                {
                    Name = c_name.Value,
                    Rid = c_rid.Value,
                    Type = string.IsNullOrWhiteSpace(c_type.Value) ? null : c_type.Value,
                    School = string.IsNullOrWhiteSpace(c_school.Value) ? null : c_school.Value,
                    Tag1 = string.IsNullOrWhiteSpace(c_tag1.Value) ? null : c_tag1.Value,
                };
        }
    }
}
