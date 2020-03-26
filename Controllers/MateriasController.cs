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
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController: ControllerBase
    {
        private IMapper _mapper;
        private ScmContext _context;
        private MateriasRepository _materiasRepository;

        public MateriasController(IMapper mapper, ScmContext context, MateriasRepository materiasRepository)
        {
            _mapper = mapper;
            _context = context;
            _materiasRepository = materiasRepository;
        }
        [HttpPost("Agregar")]
        public string Agregar([FromBody] MateriaDto model){ ///Estamos pidiendo los datos de EmpleadoDto
                    Materias estudiante = _mapper.Map<Materias>(model);///De dto a Empleado
                    _materiasRepository.Insert(estudiante); ///inserta xd
                    _context.SaveChanges(); ///guarda en la base de datos
                
            return "Se ha agregado correctamente";
        }
        [HttpGet ("BuscarID")]
        public IActionResult GetId(int id){
            var materia = _materiasRepository.GetById(id);
            if(materia == null)
                return NotFound();
            var materiaDtos = _mapper.Map<MateriaDto>(materia);
            return Ok(materiaDtos);
        }
        [HttpPut("Actualizar")]//etiqueta pora actualizar
        public IActionResult Modificar(string materia,[FromBody] MateriaDto model )
        {
            Materias materias = _mapper.Map<Materias>(model);///se cre un mapeo de los datos en el modelo empleado
            _materiasRepository.Update(materias);//recive los datos y los actualiza
            _context.SaveChanges();
            //se cre una varible Dto que almacena un mapeo de EmpleadoDto
            //EmpleadoDto es una clase que toma los datos pedidos en los contructores
            var Dto = _mapper.Map<EstudiantesDto>(materias);
            return Ok(Dto);///regresa los datos de DTO
        }
        [HttpDelete("Eliminar")]//etiqueta para eliminar
        public String eliminar(int materia){ //recive la entrada de un id
                //el onjeto empleado repository peromite el llamdo de las funciones BaseRepository
                _materiasRepository.Delete(materia);//se busca la id empledo
                _context.SaveChanges();
                return "Se elimino";
        }
        [HttpGet("VerTodos")]
        public IActionResult Get(){
            var materias = _materiasRepository.GetAll();
            var materiasDto = _mapper.Map<List<MateriaDto>>(materias);
            return Ok(materiasDto);
        }
    }
    
}