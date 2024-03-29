﻿using System.ComponentModel.DataAnnotations;

namespace Litera.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; } = string.Empty;
        public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
    }
}
