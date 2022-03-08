using AutoMapper;
using Litera.Business.ViewModels.UserView;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;
using DevOne.Security.Cryptography.BCrypt;

namespace Litera.Business.Services
{
    public class UserService : BaseService<User, UserModel, IUserRepository>
    {
        public UserService(IUserRepository repository, IMapper mapper)
            :base(repository, mapper)
        {

        }

        public override User OnBeforeCreate(UserModel model)
        {
            model.Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt());

            return base.OnBeforeCreate(model);
        }

        // Implement Update and UpdatePassword methods
        //public async Task Update(UserUpdateModel model)
        //{
        //    var userModel = _mapper.Map<UserModel>(model);

        //    await base.Update(userModel);
        //}
    }
}
