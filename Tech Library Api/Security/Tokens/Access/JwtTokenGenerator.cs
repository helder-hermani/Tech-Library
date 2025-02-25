using DotNetEnv;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tech_Library_Api.Domain.Entities;

namespace Tech_Library_Api.Security.Tokens.Access
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                //new Claim("IdUser", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Expires = DateTime.UtcNow.AddMinutes(60),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(SecurityKey(),SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        public static SymmetricSecurityKey GetSecurityKey()
        {
            return SecurityKey();
        }

        private static SymmetricSecurityKey SecurityKey()
        {
            var signinKey = Env.GetString("API_KEY");
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
        }
    }

    
}
