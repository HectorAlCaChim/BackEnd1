using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using scm.Service;
using Scm.Domain;

namespace Scm.Infrastructure.Authentication
{
    public class JwtProvider : ITokenProvider
    {
        private RsaSecurityKey _key;
        private string _algoritm;
        private string _issuer;
        private string _audience;
        public JwtProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters(){ KeyContainerName = keyName};
            var provider = new RSACryptoServiceProvider(2048, parameters);
            _key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;// TIPO DE INCRIPTACION
            _issuer = issuer;
            _audience = audience;
        }

        public string CreateToken(ServiceResult<User> accessResult, DateTime expiry)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>(){
                new Claim(ClaimTypes.Name, $"{accessResult.Result.name}"),
                new Claim(ClaimTypes.Role, $"{accessResult.Result.role}"),
            });
            SecurityToken token = tokenHandler.CreateJwtSecurityToken( new SecurityTokenDescriptor{
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_key, _algoritm),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });
            return tokenHandler.WriteToken(token);
        }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }

}