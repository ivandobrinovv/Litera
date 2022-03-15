using Litera.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Litera.Data
{
    public class LiteraDbContext : DbContext
    {
        public LiteraDbContext(DbContextOptions<LiteraDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Chats)
                .WithMany(c => c.Users);

            modelBuilder.Entity<Chat>()
                .HasMany(c => c.Messages);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Author);
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
