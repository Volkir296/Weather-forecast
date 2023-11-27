using Microsoft.EntityFrameworkCore;

namespace WebLabApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }
    }
}
