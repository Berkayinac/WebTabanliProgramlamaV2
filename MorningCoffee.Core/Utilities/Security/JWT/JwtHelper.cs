using Microsoft.Extensions.Configuration;
using MorningCoffee.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MorningCoffee.Core.Extensions;
using System.Text;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using MorningCoffee.Core.Utilities.Security.Encryption;

namespace MorningCoffee.Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {

        IConfiguration _configuration { get; }
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentinalsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, operationClaims, signingCredentials);
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);

            var accessToken = new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
            return accessToken;
        }
        
        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user, List<OperationClaim> operationClaims, SigningCredentials signingCredentials)
        {
          JwtSecurityToken jwt =  new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: SetClaims(user, operationClaims),
                notBefore: DateTime.Now,
                expires: _accessTokenExpiration,
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            List<Claim> claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(o => o.Name).ToArray());
            return claims;
        }
    }
}
