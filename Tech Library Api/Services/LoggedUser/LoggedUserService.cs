using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using Tech_Library_Api.Domain.Entities;
using Tech_Library_Api.Infrastructure;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Tech_Library_Api.Services.LoggedUser
{
    public class LoggedUserService
    {
        private readonly HttpContext _httpContext;
        public LoggedUserService(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public User GetUser()
        {
            var authentication = _httpContext.Request.Headers.Authorization.ToString();
            var token = authentication["Bearer ".Length..].Trim();

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
            var userId = Guid.Parse(identifier);

            var db = new TechLibraryDbContext();

            return db.Users.First(user => user.Id == userId);
         }
    }

    
}
