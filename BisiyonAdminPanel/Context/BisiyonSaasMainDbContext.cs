using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BisiyonAdminPanel
{
    public class BisiyonSaasMainDbContext : DbContext
    {
        public BisiyonSaasMainDbContext()
        {

        }

        public BisiyonSaasMainDbContext(DbContextOptions<BisiyonSaasMainDbContext> options) : base(options)
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = GetConnectionString();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.ConfigureWarnings(builder =>
                {
                    builder.Ignore(CoreEventId.NavigationBaseIncludeIgnored);
                });
                optionsBuilder.UseSqlServer(connectionString, y =>
                {
                    y.CommandTimeout(1200);
                    y.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            }
        }

        public string GetConnectionString()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var basePath = Directory.GetParent(AppContext.BaseDirectory)!.FullName;
            var appSettingsJsonFilePath = Path.Combine(basePath, $"appsettings.{environment}.json");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(appSettingsJsonFilePath, optional: true)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("Default");
            return connectionString ?? "";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Province)
                .WithMany()
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.NoAction); // veya DeleteBehavior.Restrict

            modelBuilder.Entity<Company>()
                .HasOne(c => c.District)
                .WithMany()
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.NoAction); // veya DeleteBehavior.Restrict

            modelBuilder.Entity<District>()
                .HasOne(d => d.Province)
                .WithMany()
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Sites> Sites { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
    }
}