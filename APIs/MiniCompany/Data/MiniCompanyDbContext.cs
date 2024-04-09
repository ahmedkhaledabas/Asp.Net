using Microsoft.EntityFrameworkCore;
using MiniCompany.Model;

namespace MiniCompany.Data
{
    public class MiniCompanyDbContext : DbContext
    {
        public MiniCompanyDbContext(){}

        public MiniCompanyDbContext(DbContextOptions<MiniCompanyDbContext> options) : base(options){}


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build().GetConnectionString("Default");
            optionsBuilder.UseSqlServer(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasMany(d=>d.Employees).WithOne(e=>e.Department).HasForeignKey(e=>e.DepartmentId).IsRequired();

        }
    }
}
