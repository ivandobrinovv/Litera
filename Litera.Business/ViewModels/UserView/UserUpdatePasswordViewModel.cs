using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Business.ViewModels.UserView
{
    public class UserUpdatePasswordViewModel
    {
        public Guid Id { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? RepeatNewPassword { get; set; }
    }
}
