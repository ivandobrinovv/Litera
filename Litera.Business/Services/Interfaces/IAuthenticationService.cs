using Litera.Business.ViewModels.Authenticate;
using Litera.Business.ViewModels.UserView;
using Microsoft.AspNetCore.Http;

namespace Litera.Business.Services.Interfaces
{
    public interface IAuthenticationService
    {
        UserViewModel? Authenticate(AuthenticationViewModel model);
        void Login(AuthenticationViewModel model, HttpContext context);
        void Logout(HttpContext context);
    }
}