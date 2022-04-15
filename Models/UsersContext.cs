using Microsoft.EntityFrameworkCore;

namespace WebApi3.Models
{
    public class UsersContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
