using AutoMapper;
using Scm.Controllers.Dtos;
using Scm.Domain;


namespace Scm.Infrastructure.Mapping
{
    public class MappingProfile : Profile {
    public MappingProfile() {

            CreateMap<User, AuthenticateModel>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDtoT>();
            CreateMap<UserDtoT, User>();

            CreateMap<Horarios,HorarioDto>().ReverseMap();

            CreateMap<Materias, MateriaDto>().ReverseMap();

            CreateMap<Maestros, MaestrosDto>().ReverseMap();
            CreateMap<Maestros, MaestrosResponseDto>().ReverseMap();

            CreateMap<Estudiantes, EstudiantesDto>();
            CreateMap<EstudiantesDto, Estudiantes>();
            CreateMap<EstudiantesUpdateDto,Estudiantes>();
            CreateMap<Estudiantes,EstudiantesUpdateDto>();
            CreateMap<EstudiantesResponseDto,Estudiantes>();
            CreateMap<Estudiantes,EstudiantesResponseDto>();
        }
    }
}