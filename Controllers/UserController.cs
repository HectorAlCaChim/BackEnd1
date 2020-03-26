using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scm.Controllers.Dtos;
using Scm.Data;
using Scm.Data.Repositories;
using Scm.Domain;
using Scm.Services;
using System.Linq;

namespace Scm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class UserController: ControllerBase
    {
        private UserRepository _userRepository;
        private ScmContext _scmContext;
        private IMapper _mapper;
        private UserService _userService;

        public UserController(UserRepository userRepository, ScmContext scmContext, IMapper mapper, UserService userService)
        {
            _userRepository = userRepository;
            _scmContext = scmContext;
            _mapper = mapper;
            _userService = userService;
        }
         [HttpPost("Agregar")]
        public string Agregar([FromBody] UserDto model){ ///Estamos pidiendo los datos de EmpleadoDto
                    User user = _mapper.Map<User>(model);///De dto a Empleado
                    _userRepository.Insert(user); ///inserta xd
                    _scmContext.SaveChanges(); ///guarda en la base de datos
                
            return "Se ha agregado correctamente";
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            //User user = _mapper.Map<User>(model);
            var accessResult = _userService.getAcceso(model.password, model.email);

            if (accessResult.isSuccess){
                var result = _mapper.Map<UserDtoT>(accessResult.Result);
                var accessToken = _userService.Authenticate(result.email, result.role);
                return Ok(accessToken);
            }else{
                return BadRequest(accessResult.Errors);
            }     
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
    
}
