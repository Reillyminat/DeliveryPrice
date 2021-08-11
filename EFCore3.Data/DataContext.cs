using DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;

namespace EFCore5.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Carrier> Carriers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=.; Integrated Security=True; Initial Catalog = DeliveryServiceEFData");
        }
    }
}
