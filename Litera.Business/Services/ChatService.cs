using Litera.Business.Models.Chat;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;

namespace Litera.Business.Services
{
    public class ChatService : BaseService<Chat, ChatModel, IChatRepository>
    {
        public ChatService(IChatRepository repository)
            : base(repository)
        {

        }
    }
}
