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

namespace Scm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaestrosController: ControllerBase
    {
        private  MaestrosRepository _maestrosRepository;
        private MaestrosService _maestrosService;
        private ScmContext _scmContext;
        private IMapper _mapper;

        public MaestrosController(MaestrosRepository maestrosRepository, MaestrosService maestrosService,ScmContext scmContext, IMapper mapper)
        {
            _maestrosRepository = maestrosRepository;
            _scmContext = scmContext;
            _mapper = mapper;
            _maestrosService = maestrosService;
        }
        [HttpPost("Agregar")]
        public string Agregar([FromBody] MaestrosDto model){ ///Estamos pidiendo los datos de EmpleadoDto
                    Maestros maestro = _mapper.Map<Maestros>(model);///De dto a Empleado
                    _maestrosRepository.Insert(maestro); ///inserta xd
                    _scmContext.SaveChanges(); ///guarda en la base de datos
            return "Se ha agregado correctamente";
        }
        [HttpPut("Actualizar")]
        public IActionResult Modificar(string clave,[FromBody] MaestrosDto model )
        {
            Maestros maestrosUpdate = _mapper.Map<Maestros>(model);///se cre un mapeo de los datos en el modelo empleado
            _maestrosRepository.Update(maestrosUpdate);//recive los datos y los actualiza
            _scmContext.SaveChanges();
            //se cre una varible Dto que almacena un mapeo de EmpleadoDto
            //EmpleadoDto es una clase que toma los datos pedidos en los contructores
            var Dto = _mapper.Map<MaestrosDto>(maestrosUpdate);
            return Ok(Dto);///regresa los datos de DTO
        }
        [HttpGet ("BuscarID")]
        public IActionResult GetId(string id){
            var horario = _maestrosRepository.GetById(id);
            if(horario == null)
                return NotFound();
            var horarioDto = _mapper.Map<MaestrosDto>(horario);
            return Ok(horarioDto);
        }
        [HttpDelete("Eliminar")]//etiqueta para eliminar
        public String eliminar(string clave){ //recive la entrada de un id
                //el onjeto empleado repository peromite el llamdo de las funciones BaseRepository
                _maestrosRepository.Delete(clave);//se busca la id empledo
                _scmContext.SaveChanges();
                return "Se elimino";
        }
        [HttpGet("todos")]
        public IActionResult Get(){
            var maestros = _maestrosRepository.GetAll();
            var maestrosdto = _mapper.Map<List<MaestrosDto>>(maestros);
            return Ok(maestrosdto);
        }
        [HttpGet("mestrosDetalles")]
        public IActionResult GetDetalles(){
            var maestros = _maestrosRepository.GetAll();
            var maestrosDetalles=_maestrosService.getDetallerMestros(maestros);
            var maestrosResponsedto= _mapper.Map<List<MaestrosResponseDto>>(maestrosDetalles);
            return Ok(maestrosResponsedto);
        }
    }
}