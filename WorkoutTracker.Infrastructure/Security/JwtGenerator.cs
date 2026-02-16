using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTracker.Infrastructure.Security
{
    public class JwtGenerator : IJwtGenerator
    {
        private IConfiguration _congiguration;

        public JwtGenerator(IConfiguration congiguration)
        {
            _congiguration = congiguration;
        }

        public string GenerateToken(string userId, string email)
        {
            //Get JWT settings
            var key = _congiguration["Jwt:Key"];
            var issuer = _congiguration["Jwt:Issuer"];
            var audience = _congiguration["Jwt:Audience"];
            var expieryMinutes = int.Parse(_congiguration["Jwt:ExpiryMinutes"]!);

            //Generate claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //create signing credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //create token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expieryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
