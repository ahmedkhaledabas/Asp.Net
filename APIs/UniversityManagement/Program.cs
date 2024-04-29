
using Microsoft.EntityFrameworkCore;
using UniversityManagement.Data;
using UniversityManagement.IRepository;
using UniversityManagement.Repository;

namespace UniversityManagement
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
            builder.Services.AddDbContext<UniversityDbContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("name = ConnectionStrings:Default")));
            builder.Services.AddScoped<ICollegeRepo , CollegeRepo>();
            

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
