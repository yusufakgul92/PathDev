using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PathDev.Core.Model.Base.Enum;
using PathDev.Core.Model.Base.Extension;
using PathDev.Core.Model.Base.Helper;
using PathDev.Core.Model.Dto.Customer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PathDev.Core.Model.Authorization.Jwt
{
    public class JwtHelper : IJwtHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions TokenOptions;
        private DateTime AccessTokenExpiration;
        public IHttpContextAccessor _httpContextAccessor;
        public JwtHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Configuration = configuration;
            TokenOptions = new TokenOptions()
            {
                AccessTokenExpiration = 720,
#if DEBUG
                Audience = Configuration["Jwt:LocalAudience"],
                Issuer = Configuration["Jwt:LocalIssuer"],
#else
                Audience = Configuration["Jwt:Audience"],
                Issuer = Configuration["Jwt:Issuer"],
#endif
                SecurityKey = Configuration["Jwt:SecurityKey"]
            };
            AccessTokenExpiration = DateTime.Now.AddMinutes(TokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(CustomerDto user)
        {
            AccessTokenExpiration = DateTime.Now.AddMinutes(TokenOptions.AccessTokenExpiration);

            var securityKey = BaseHelper.CreateSecurityKey(TokenOptions.SecurityKey);
            var signingCredentials = BaseHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(TokenOptions, signingCredentials, user);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = AccessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, SigningCredentials signingCredentials, CustomerDto user)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: AccessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(signingCredentials, user),
                signingCredentials: signingCredentials);
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(SigningCredentials signingCredentials, CustomerDto user)
        {
            var claims = new List<Claim>();
            claims.AddCustomerId(user.Id);
            claims.AddUserName(user.Username);

            if (user.IsSystemRole)
            {
                claims.AddRoles(new string[] { "Customer", "Admin" });
            }
            else
            {
                claims.AddRoles(new string[] { "Customer" });
            }

            return claims;
        }
    }
}
