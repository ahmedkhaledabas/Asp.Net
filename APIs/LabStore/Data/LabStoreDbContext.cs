using LabStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabStore.Data
{
    public class LabStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public LabStoreDbContext(DbContextOptions<LabStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Labtop> Labs => Set<Labtop>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<ContactUs> ContactUs => Set<ContactUs>();
    }
}
