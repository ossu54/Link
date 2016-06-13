using Microsoft.EntityFrameworkCore;
using Zelda.Models;


namespace Zelda.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<WebSiteInfo> WebSiteInfos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
