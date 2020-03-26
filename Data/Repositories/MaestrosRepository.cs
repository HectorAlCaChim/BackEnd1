using Scm.Domain;

namespace Scm.Data.Repositories
{
    public class MaestrosRepository : BaseRepository<Maestros>
    {
        public MaestrosRepository(ScmContext context) : base(context)
        {
        }
    }

}