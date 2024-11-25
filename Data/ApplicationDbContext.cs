using Microsoft.EntityFrameworkCore;
using RaizesUrbanaWeb.Models;

namespace RaizesUrbanaWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Order>().HasMany(c => c.Items)
               .WithOne(e => e.Order)
               .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<User>().HasMany(c => c.Orders)
               .WithOne(e => e.User)
               .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().Property(e => e.Message).HasColumnType("varchar(1500)");
        }

    }
}
