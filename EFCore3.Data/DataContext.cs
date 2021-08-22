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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Supplier>().HasMany(e => e.Stock).WithMany(p => p.Suppliers).UsingEntity(j => j.ToTable("SupplierProducts"));
            builder.Entity<Carrier>().HasMany(e => e.Tarrifs).WithOne(p => p.Carrier).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
