using AutoMapper;
using Litera.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Business.ViewModels.UserView
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserUpdateViewModel, UserViewModel>().ReverseMap();
        }
    }
}
