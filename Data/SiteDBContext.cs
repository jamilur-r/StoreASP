using Microsoft.EntityFrameworkCore;
using StoreASP.Models;


namespace StoreASP.Data
{
    public class SiteDBContext : DbContext
    {
        public SiteDBContext(DbContextOptions<SiteDBContext> options) : base(options) { }
        
        DbSet<SiteSettings> SiteSettingss {get; set;}
    }
}