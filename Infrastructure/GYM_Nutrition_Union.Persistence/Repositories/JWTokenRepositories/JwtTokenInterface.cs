using GYM_Nurition.Domain.Entities;
using GYM_Nutrition_Union.Application.Interfaces.JWTokenInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Persistence.Repositories.JWTokenRepositories
{
    public class JwtTokenInterface : IJwtTokenInterface
    {
        private readonly IConfiguration _cfg;

        public JwtTokenInterface(IConfiguration cfg)
        {
            _cfg = cfg;
        }

        public (string Token, DateTime Expires) GenerateToken(AppUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddHours(2);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.AppUserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.AppUserEmail),
            new Claim("firstName", user.AppUserFirstName),
            new Claim("lastName", user.AppUserLastName)
        };

            var token = new JwtSecurityToken(
                issuer: _cfg["Jwt:Issuer"],
                audience: _cfg["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expires);
        }
    }
}
