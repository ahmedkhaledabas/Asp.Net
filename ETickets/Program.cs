using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ETicketsDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("name=ConnectionStrings:DefaultConnection")));

            builder.Services.AddScoped<IMovieRepository , MovieRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
            builder.Services.AddIdentity<ApplicationUser , IdentityRole>().AddEntityFrameworkStores<ETicketsDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movie}/{action=Index}/{id?}");

            app.Run();
        }

        

    }
}
