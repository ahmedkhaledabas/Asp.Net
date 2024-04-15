using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using ETickets.Services;
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

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });



            builder.Services.AddDbContext<ETicketsDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("name=ConnectionStrings:DefaultConnection")));

            builder.Services.AddScoped<IMovieRepository , MovieRepository>();
            builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<GetUserProperties>();
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

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movie}/{action=Index}/{id?}");

            app.Run();
        }

        

    }
}
