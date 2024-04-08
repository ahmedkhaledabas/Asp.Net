using ETickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Web;

namespace ETickets.Data
{
    public class ETicketsDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<MovieCart> MovieCarts {  get; set; }

        public ETicketsDbContext() { } 

        public ETicketsDbContext(DbContextOptions<ETicketsDbContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json" , true , true).Build().GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actor>().HasMany(a => a.Movies).WithMany(m => m.Actors).UsingEntity<ActorMovie>();

            modelBuilder.Entity<Cart>().HasMany(c => c.Movies).WithMany(m => m.Carts).UsingEntity<MovieCart>();

            modelBuilder.Entity<ApplicationUser>().HasOne(u => u.Cart)
            .WithOne(c => c.ApplicationUser).HasForeignKey<Cart>(c => c.ApplicationUserId).IsRequired();
        }

        public DbSet<ETickets.ViewModels.ApplicationUserViewModel> ApplicationUserViewModel { get; set; } = default!;

        public DbSet<ETickets.ViewModels.RoleViewModel> RoleViewModel { get; set; } = default!;
    }
}
