using Microsoft.EntityFrameworkCore;

namespace UniversityManagement.Data
{
    public class UniversityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build().GetConnectionString("Default");
            optionsBuilder.UseSqlServer(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
