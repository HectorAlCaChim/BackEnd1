using Scm.Domain;

namespace Scm.Data.Repositories
{
    public class EstudiantesRepository : BaseRepository<Estudiantes>
    {
        public EstudiantesRepository(ScmContext context) : base(context)
        {

        }
    }
    
}