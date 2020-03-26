using System;
using Microsoft.IdentityModel.Tokens;
using scm.Service;
using Scm.Domain;

namespace Scm.Infrastructure.Authentication
{
    public interface ITokenProvider
    {
        //string CreateToken(User user, DateTime expire);
        TokenValidationParameters GetTokenValidationParameters();
        string CreateToken(ServiceResult<User> accessResult, DateTime dateTime);
    }
}