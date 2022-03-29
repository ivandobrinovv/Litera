using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litera.Business.ViewModels.UserView
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "The password must contain at least one digit, one upper case letter, one lower case letter and one special symbol(@$!%*?&)!")]
        public string Password { get; set; } = string.Empty;
    }
}
