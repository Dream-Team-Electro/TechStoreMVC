using Microsoft.EntityFrameworkCore;
using TechStoreMVC.Data.Models;

namespace TechStoreMVC.Data
{
    public class TechStoreContext : DbContext
    {
        public TechStoreContext(DbContextOptions<TechStoreContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
