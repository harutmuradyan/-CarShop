using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Models
{
    public class CarsContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Company> Companys { get; set; }

        public DbSet<CarModel> Models { get; set; }
        public DbSet<FileModel> Files { get; set; }

        public CarsContext(DbContextOptions<CarsContext> options)
        : base(options)
        {
            /*Database.EnsureCreated();*/
        }

    }
}