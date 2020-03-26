using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using scm.Service;
using Scm.Controllers.Dtos;
using Scm.Data;
using Scm.Data.Repositories;
using Scm.Domain;
using Scm.Helpers;

namespace Scm.Services
{

    public class UserService 
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        { 
            new User { email = "", password = "Test", name = "nombre", lastName = "apellido", role = "test" } 
        };

        private readonly AppSettings _appSettings;
////////////////////////////////////////////////////////////////////////////////////////////////////////
        private UserRepository _userRepository;
        private ScmContext _context;
        private IMapper _mapper;
        public UserService(IOptions<AppSettings> appSettings, IMapper mapper,ScmContext context,UserRepository userRepository )
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _context = context;
            _mapper = mapper;
        }
        public ServiceResult<User> getAcceso(string password, string email){

            var result = new ServiceResult<User>();
            try{
                result.isSuccess = true;
                result.Result = _userRepository.getValidation(email, password);
                if(result.Result == null)
                {
                    result.isSuccess = false;
                    result.Errors = new List<string>();
                    result.Errors.Add("No existe ningun vale entre esas fechas");
                }
                return result;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Errors = new List<string>();
                result.Errors.Add(ex.ToString());
                return result;
            }
        }

        public String Authenticate(string email, string role)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),// Tiempo expire
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users.WithoutPasswords();
        }
    }
}