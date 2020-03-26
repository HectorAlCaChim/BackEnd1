using Scm.Domain;

namespace Scm.Data.Repositories
{
    public class MateriasRepository : BaseRepository<Materias>
    {
        public MateriasRepository(ScmContext context) : base(context)
        {
        }
    }

}