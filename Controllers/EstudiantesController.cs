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
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController: ControllerBase
    {
        private EstudiantesRepository _estudiantesRepository;
        private ScmContext _scmContext;
        private IMapper _mapper;

        public EstudiantesController( EstudiantesRepository estudiantesRepository, ScmContext context, IMapper mapper)
        {
            _estudiantesRepository = estudiantesRepository;
            _scmContext = context;
            _mapper = mapper;
        }

        [HttpPost("Agregar")]
        public string Agregar([FromBody] EstudiantesDto model){ ///Estamos pidiendo los datos de EmpleadoDto
                    Estudiantes estudiante = _mapper.Map<Estudiantes>(model);///De dto a Empleado
                    _estudiantesRepository.Insert(estudiante); ///inserta xd
                    _scmContext.SaveChanges(); ///guarda en la base de datos
                
            return "Se ha agregado correctamente";
        }
        [HttpGet ("BuscarID")]
        public IActionResult GetId(int id){
            var estudiante = _estudiantesRepository.GetById(id);
            if(estudiante == null)
                return NotFound();
            var estudiantesDtos = _mapper.Map<EstudiantesResponseDto>(estudiante);
            return Ok(estudiantesDtos);
        }
        [HttpPut("Actualizar")]//etiqueta pora actualizar
        public IActionResult Modificar(int IdEstudiantes,[FromBody] EstudiantesUpdateDto model )
        {
            Estudiantes estudiantes = _mapper.Map<Estudiantes>(model);///se cre un mapeo de los datos en el modelo empleado
            _estudiantesRepository.Update(estudiantes);//recive los datos y los actualiza
            _scmContext.SaveChanges();
            //se cre una varible Dto que almacena un mapeo de EmpleadoDto
            //EmpleadoDto es una clase que toma los datos pedidos en los contructores
            var Dto = _mapper.Map<EstudiantesDto>(estudiantes);
            return Ok(Dto);///regresa los datos de DTO
        }
        [HttpDelete("Eliminar")]//etiqueta para eliminar
        public String eliminar(int estudianteId){ //recive la entrada de un id
                //el onjeto empleado repository peromite el llamdo de las funciones BaseRepository
                _estudiantesRepository.Delete(estudianteId);//se busca la id empledo
                _scmContext.SaveChanges();
                return "Se elimino";
        }
        [HttpGet("VerTodos")]
        public IActionResult Get(){
            var estudiante = _estudiantesRepository.GetAll();
            var estudiantedto = _mapper.Map<List<EstudiantesResponseDto>>(estudiante);
            return Ok(estudiantedto);
        }
    }    
}