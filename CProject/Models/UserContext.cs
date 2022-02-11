using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CProject.Models
{
    public class UserContext: IdentityDbContext<User>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
