namespace Litera.Data.Entities
{
    public class Message : BaseEntity
    {
        public byte[]? Content { get; set; } = null;
        public string DataType { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
        public DateTime LastEditedTime { get; set; }
        public bool IsRead { get; set; }
        public User Author { get; set; }
        public Guid ChatId { get; set; }
    }
}
