using AutoMapper;
using Litera.Data.Entities;

namespace Litera.Business.ViewModels.ChatView
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, ChatViewModel>().ReverseMap();
        }
    }
}
