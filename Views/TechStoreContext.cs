using Microsoft.EntityFrameworkCore;
using TechStoreMVC.Views.Data.Models;

namespace TechStoreMVC.Views
{
    public class TechStoreContext : DbContext
    {
        public TechStoreContext(DbContextOptions options) : base(options)
        {
        }

        protected TechStoreContext()
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); // Когато категорията се изтрие, продуктите ще имат null стойност за CategoryId

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Когато поръчката се изтрие, всички продукти в поръчката също ще се изтрият

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            base.OnModelCreating(modelBuilder);
        }

        // Метод OnConfiguring, който конфигурира връзката с базата данни
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Настройване на връзката към базата данни (може да се използва конфигурационен файл)
                optionsBuilder.UseSqlServer("server=.;database=TechStoreDb;trusted_connection=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
