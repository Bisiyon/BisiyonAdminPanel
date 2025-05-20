using Microsoft.EntityFrameworkCore;

namespace BisiyonAdminPanel
{
    public class BisiyonSaasMainDbContext : DbContext
    {
        public BisiyonSaasMainDbContext(DbContextOptions<BisiyonSaasMainDbContext> options) : base(options)
        {

        }

        public DbSet<Sites> Sites { get; set; }

    }
}