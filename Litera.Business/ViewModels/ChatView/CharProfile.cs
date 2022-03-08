using AutoMapper;
using Litera.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Business.ViewModels.ChatView
{
    public class CharProfile : Profile
    {
        public CharProfile()
        {
            CreateMap<Chat, ChatViewModel>();  
        }
    }
}
