using System.Collections.Generic;
using AutoMapper;
using scm.Service;
using Scm.Data;
using Scm.Data.Repositories;
using Scm.Domain;
using Scm.Controllers.Dtos;

namespace Scm.Services
{
    public class MaestrosService
    {
        private ScmContext _context;
        private IMapper _mapper;
        private MaestrosRepository _maestrosRepository;
        private HorariosRepository _horarioRepository;

        public MaestrosService(ScmContext context, IMapper mapper, MaestrosRepository maestrosRepository, HorariosRepository horarioRepository)
        {
            _context = context;
            _mapper = mapper;
            _maestrosRepository = maestrosRepository;
            _horarioRepository = horarioRepository;
        }

        public List<Maestros> getDetallerMestros(List<Maestros> maestros)
        {
            var result = new ServiceResult<Maestros>();
            var horarios = _horarioRepository.GetAll();

           foreach (var item in maestros)
            {
                item.setDetalles(horarios);
            }
            return maestros;
        }
    }
    
}