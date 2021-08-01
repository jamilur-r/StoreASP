using Microsoft.EntityFrameworkCore;
using StoreASP.Models;


namespace StoreASP.Data
{
    public class SiteDBContext : DbContext
    {
        public SiteDBContext(DbContextOptions<SiteDBContext> options) : base(options) { }

        public DbSet<SiteSettings> SiteSettingss { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}