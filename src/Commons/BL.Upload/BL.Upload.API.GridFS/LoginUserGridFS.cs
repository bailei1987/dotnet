using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace BL.Files.Upload.API.GridFS.Models
{
    public class OperatorItemGridFS
    {
        public string Rid { get; set; }
        public string Name { get; set; }
    }
    public class LoginUserGridFS
    {
        public string Rid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string School { get; set; }
        public string Tag1 { get; set; }

        public OperatorItemGridFS ToOperator()
        {
            return new()
            {
                Name = Name,
                Rid = Rid
            };
        }
    }
    public static class HttpContextExtension
    {
        public static LoginUserGridFS GetLoginUserFromToken(this HttpContext httpContext)
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
                : new LoginUserGridFS
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
