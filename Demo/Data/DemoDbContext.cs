using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class DemoDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true)
                .Build().GetConnectionString("DefaultConnection"));
        }
    }
}
