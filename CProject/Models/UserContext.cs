using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CProject.Models
{
    public class UserContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Status>().HasData(
                new Status[]
                {
                    new Status{Id=1, Name="Отгружено"},
                    new Status{Id=2, Name="Фомируется в заказ"},
                    new Status{Id=3, Name="Доставляется"},
                    new Status{Id=4, Name="Доставлено"}
                });
        }
    }
}