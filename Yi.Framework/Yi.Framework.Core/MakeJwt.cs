using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Yi.Framework.Common.Const;
using Yi.Framework.Model.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Yi.Framework.Core
{

    public class jwtUser
    { 
        public user user { get; set; }
        public List<menu> menuIds { get; set; }
    
    }

   public class MakeJwt
    {

        /// <summary>
        /// user需关联所有roles,还有一个menuIds
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public static string app(jwtUser _user)
        {
            //通过查询权限，把所有权限加入进令牌中
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"));
            claims.Add(new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"));
            claims.Add(new Claim(ClaimTypes.Name, _user.user.username));
            claims.Add(new Claim(ClaimTypes.Sid, _user.user.id.ToString()));
            foreach (var k in _user.menuIds)
            {
                claims.Add(new Claim("menuIds",k.id.ToString()));
            }
            foreach (var k in _user.user.roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, k.role_name));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConst.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: JwtConst.Domain,
                audience: JwtConst.Domain,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            var tokenData = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenData;
        }

    }
}
