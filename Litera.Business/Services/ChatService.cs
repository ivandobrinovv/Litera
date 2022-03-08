using Litera.Business.ViewModels.ChatView;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;

namespace Litera.Business.Services
{
    public class ChatService : BaseService<Chat, ChatViewModel, IChatRepository>
    {
        public ChatService(IChatRepository repository)
            : base(repository)
        {

        }
    }
}
