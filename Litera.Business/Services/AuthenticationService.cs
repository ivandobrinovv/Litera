using AutoMapper;
using Litera.Business.Services.Interfaces;
using Litera.Business.ViewModels.Authenticate;
using Litera.Business.ViewModels.UserView;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text;
using BCryptHelper = BCrypt.Net.BCrypt;

namespace Litera.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public UserViewModel? Authenticate(AuthenticationViewModel model)
        {
            User? user = _userRepository.GetByEmail(model.Email);
            if (user == null)
            {
                return null;
            }
            if (BCryptHelper.Verify(model.Password, user.Password))
            {
                return _mapper.Map<UserViewModel>(model);
            }
            return null;
        }

        public void Login(AuthenticationViewModel model, HttpContext context)
        {
            var user = Authenticate(model);
            if (user != null)
            {
                context.Session.Set(nameof(user.Id), user.Id.ToByteArray());
                context.Session.Set(nameof(user.Email), Encoding.UTF8.GetBytes(user.Email));
                context.Session.Set(nameof(user.Name), Encoding.UTF8.GetBytes(user.Name));

                // TODO: Check if this is necessary
                context.Session.CommitAsync();
            }
        }

        public void Logout(HttpContext context)
        {
            context.Session.Clear();
        }
    }
}
