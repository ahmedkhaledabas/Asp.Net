using LabStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabStore.Data
{
    public class LabStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public LabStoreDbContext() { }

        public LabStoreDbContext(DbContextOptions<LabStoreDbContext> options) : base() { }
        public DbSet<Labtop> Labs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ContactUs> ContactUs {  get; set; }
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
