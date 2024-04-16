
using LabStore.Data;
using LabStore.IRepository;
using LabStore.Models;
using LabStore.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LabStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //service ask controller
            builder.Services.AddDbContext<LabStoreDbContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("name=ConnectionStrings:Default")));
            builder.Services.AddScoped<ILabtopRepository, LabRepository>();
            builder.Services.AddScoped<IBrandRepository , BrandRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<LabStoreDbContext>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
