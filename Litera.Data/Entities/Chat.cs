using System.ComponentModel.DataAnnotations;

namespace Litera.Data.Entities
{
    public class Chat : BaseEntity
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        // check the default array value
        public byte[]? Image { get; set; } = null;
        public string ThemeColor { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
