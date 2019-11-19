﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace OilStationCoreAPI.AuthHepler
{
    /// <summary>
    /// 颁发Jwt字符串
    /// </summary>
    public class JwtHelper
    {
        public static string IssueJwt(TokenModelJwt tokenModel)
        {
            string iss = Appsettings.app(new string[] { "Audience", "Issuer" });
            string aud = Appsettings.app(new string[] { "Audience", "Audience" });
            string secret = Appsettings.app(new string[] { "Audience", "Secret" });
            var claims = new List<Claim>
            {
                /*
                 * 特别重要：
                   1、这里将用户的部分信息，比如 uid 存到了Claim 中，如果你想知道如何在其他地方将这个 uid从 Token 中取出来，请看下边的SerializeJwt() 方法，或者在整个解决方案，搜索这个方法，看哪里使用了！
                   2、你也可以研究下 HttpContext.User.Claims ，具体的你可以看看 Policys/PermissionHandler.cs 类中是如何使用的。
                 */
                 new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid.ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                 new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                 // 这个就是过期时间，目前是过期1000秒，可自定义，注意JWT有自己的缓冲过期时间
                 new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds()}"),
                 new Claim(JwtRegisteredClaimNames.Iss,iss),
                 new Claim(JwtRegisteredClaimNames.Aud,aud),
            };
            // 可以将一个用户的多个角色全部赋予；
            // 作者：DX 提供技术支持；
            //添加声明
            claims.AddRange(tokenModel.Claims.Select(x => new Claim(x.Type, x.Value)));
            //如果tokenModel的角色为空则，不进行赋予角色
            if (tokenModel.Role!=null)
            {
                claims.AddRange(tokenModel.Role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
            }
            //秘钥 (SymmetricSecurityKey 对安全性的要求，密钥的长度太短会报出异常)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: iss,
                claims: claims,
                signingCredentials: creds);
            var jwtHandler = new JwtSecurityTokenHandler();
            var encodedJwt = jwtHandler.WriteToken(jwt);
            return encodedJwt;
        }

        /// <summary>
        /// 解析Token
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJwt SerilaizeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = new JwtSecurityToken(jwtStr);
            object role;
            try
            {
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            var tm = new TokenModelJwt
            {
                Uid = jwtToken.Id,
                Role = role != null ? role.ToString() : "",
            };
            return tm;
        }
    }
}