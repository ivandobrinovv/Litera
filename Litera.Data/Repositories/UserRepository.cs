using Litera.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Data.Repositories.Interfaces
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LiteraDbContext context) : base(context)
        {
        }

        public User? GetByEmail(string email)
        {
            return context.Set<User>().SingleOrDefault(u => u.Email == email);
        }
    }
}
