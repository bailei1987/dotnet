using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BL.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BL.IdentityServer.Community
{
    public static class LoginUserExtension
    {
        public static Dictionary<string, string> GetTokenRequestParamsDictionary(this LoginUser user)
        {
            return new Dictionary<string, string> {
                { "user_rid",user.Rid },
                { "user_name",user.Name },
                { "user_type",user.Type },
                { "user_school",user.School },
                 { "user_tag1",user.Tag1 },
            };
        }
    }
    public static class ICollectionClaimExtension
    {
        public static void AddLoginUserInfo(this ICollection<Claim> claims, LoginUser user)
        {
            claims.Add(new Claim("user_rid", user.Rid));
            claims.Add(new Claim("user_name", user.Name));
            claims.Add(new Claim("user_type", user.Type));
            claims.Add(new Claim("user_school", user.School));
            claims.Add(new Claim("user_tag1", user.Tag1));
        }
    }
    public static class HttpContextExtension
    {
        public static LoginUser GetLoginUserFromToken(this HttpContext httpContext)
        {
            var tokenT = httpContext.GetTokenAsync("access_token");
            if (tokenT is null) throw new Exception("token is empty");
            var token = new JwtSecurityToken(tokenT.Result);
            var c_rid = token.Claims.FirstOrDefault(x => x.Type == "client_user_rid");
            var c_name = token.Claims.FirstOrDefault(x => x.Type == "client_user_name");
            var c_type = token.Claims.FirstOrDefault(x => x.Type == "client_user_type");
            var c_school = token.Claims.FirstOrDefault(x => x.Type == "client_user_school");
            var c_tag1 = token.Claims.FirstOrDefault(x => x.Type == "client_user_tag1");
            if (c_rid is null | c_name is null || c_type is null) throw new Exception("rid,name,type missing");
            return new LoginUser
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
