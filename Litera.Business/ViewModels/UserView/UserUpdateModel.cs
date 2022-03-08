﻿using System.ComponentModel.DataAnnotations;

namespace Litera.Business.ViewModels.UserView
{
    public class UserUpdateModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
