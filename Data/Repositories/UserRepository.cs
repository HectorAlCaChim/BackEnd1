using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Scm.Domain;

namespace Scm.Data.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        private ScmContext _scmContext;
        private readonly DbSet<User> _dbSet;
        public UserRepository(ScmContext context) : base(context)
        {
            _scmContext = context;
            _dbSet = _context.Set<User>(); 
        }
        public User getValidation(string email, string password)
        {
            return _dbSet.Where(a => a.email == email && a.password == password ).Single();
        }
    }

}