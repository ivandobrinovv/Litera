using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;

namespace Litera.Data.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(LiteraDbContext context)
            : base(context) { 
        }
    }
}
