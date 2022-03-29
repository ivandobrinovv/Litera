using AutoMapper;
using Litera.Business.Services.Interfaces;
using Litera.Business.ViewModels.UserView;
using Litera.Data.Entities;
using Litera.Data.Repositories.Interfaces;
using BCryptHelper = BCrypt.Net.BCrypt;

namespace Litera.Business.Services
{
    public class UserService : BaseService<User, UserViewModel, IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper)
            : base(repository, mapper)
        {

        }

        public override async Task<User> OnBeforeCreate(UserViewModel model)
        {
            model.Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt());

            return await base.OnBeforeCreate(model);
        }

        public override async Task<User> OnBeforeUpdate(UserViewModel model)
        {
            var entity = await GetByIdAsync(model.Id);
            model.Password = entity.Password;

            return await base.OnBeforeUpdate(model);
        }

        public async Task UpdatePassword(UserUpdatePasswordViewModel model)
        {
            var user = await GetByIdAsync(model.Id);

            if (model.NewPassword == model.RepeatNewPassword)
            {
                throw new ArgumentException("NewPassword and RepeatNewPassword does not match!");
            }

            if (!BCryptHelper.Verify(model.OldPassword, user.Password))
            {
                throw new ArgumentException("Invalid password!");
            }

            if (model.OldPassword == model.NewPassword)
            {
                throw new ArgumentException("NewPassword is the same as OldPassword!");
            }

            user.Password = BCryptHelper.HashPassword(model.NewPassword, BCryptHelper.GenerateSalt());

            var entity = _mapper.Map<User>(user);

            await _repository.UpdateAsync(entity);
        }
    }
}
