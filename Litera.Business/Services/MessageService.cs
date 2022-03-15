using AutoMapper;
using Litera.Business.Services.Interfaces;
using Litera.Business.ViewModels.MessageView;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;

namespace Litera.Business.Services
{
    public class MessageService : BaseService<Message, MessageViewModel, IMessageRepository>, IMessageService
    {
        public MessageService(IMessageRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }
    }
}
