using AutoMapper;
using Litera.Business.Services.Interfaces;
using Litera.Business.ViewModels.ChatView;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;

namespace Litera.Business.Services
{
    public class ChatService : BaseService<Chat, ChatViewModel, IChatRepository>, IChatService
    {
        public ChatService(IChatRepository repository, IMapper mapper)
            : base(repository, mapper)
        {

        }
    }
}
