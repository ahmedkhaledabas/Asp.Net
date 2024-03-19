using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoListDbContext :DbContext
    {
        public DbSet<ListItem> listItems {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true)
                .Build().GetConnectionString("DefaultConnection"));
        }
    }
}
