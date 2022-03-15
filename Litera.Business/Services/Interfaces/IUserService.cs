using Litera.Business.ViewModels.UserView;
using Litera.Data.Entities;

namespace Litera.Business.Services.Interfaces
{
    public interface IUserService : IBaseService<User, UserViewModel>
    {
        Task UpdatePassword(UserUpdatePasswordViewModel model);
    }
}