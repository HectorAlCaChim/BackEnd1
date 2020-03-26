using Scm.Domain;

namespace Scm.Data.Repositories
{
    public class HorariosRepository : BaseRepository<Horarios>
    {
        public HorariosRepository(ScmContext context) : base(context)
        {
        }
    }

}