using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scm.Controllers.Dtos;
using Scm.Data;
using Scm.Data.Repositories;
using Scm.Domain;

namespace Scm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "admin")]
    public class HorariosController : ControllerBase
    {
        private HorariosRepository _horariosRepository;
        private ScmContext _context;
        private IMapper _mapper;
        public HorariosController(HorariosRepository horariosRepository, ScmContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _horariosRepository = horariosRepository;   
        }

        [HttpPost("Agregar")]
        public string Agregar([FromBody] HorarioDto model){ ///Estamos pidiendo los datos d
                    Horarios horarios = _mapper.Map<Horarios>(model);///De dto a model
                    _horariosRepository.Insert(horarios); ///inserta 
                    _context.SaveChanges(); ///guarda en la base de datos
                
            return "Se ha agregado correctamente";
        }
        [HttpGet ("BuscarID")]
        public IActionResult GetId(string id){
            var horario = _horariosRepository.GetById(id);
            if(horario == null)
                return NotFound();
            var horarioDto = _mapper.Map<HorarioDto>(horario);
            return Ok(horarioDto);
        }
        [HttpPut("Actualizar")]
        public IActionResult Modificar(string clave,[FromBody] HorarioDto model )
        {
            Horarios horarioUpdate = _mapper.Map<Horarios>(model);///se cre un mapeo de los datos en el modelo empleado
            _horariosRepository.Update(horarioUpdate);//recive los datos y los actualiza
            _context.SaveChanges();
            //se cre una varible Dto que almacena un mapeo de EmpleadoDto
            //EmpleadoDto es una clase que toma los datos pedidos en los contructores
            var Dto = _mapper.Map<HorarioDto>(horarioUpdate);
            return Ok(Dto);///regresa los datos de DTO
        }
        [HttpDelete("Eliminar")]//etiqueta para eliminar
        public String eliminar(string clave){ //recive la entrada de un id
                //el onjeto empleado repository peromite el llamdo de las funciones BaseRepository
                _horariosRepository.Delete(clave);//se busca la id empledo
                _context.SaveChanges();
                return "Se elimino";
        }
        [HttpGet("VerTodos")]
        public IActionResult Get(){
            var horarios = _horariosRepository.GetAll();
            var horariosDto = _mapper.Map<List<HorarioDto>>(horarios);
            return Ok(horariosDto);
        }
    }
}