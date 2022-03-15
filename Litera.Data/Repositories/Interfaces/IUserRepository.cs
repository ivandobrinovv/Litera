using Litera.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Data.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetByEmail(string email);
    }
}
