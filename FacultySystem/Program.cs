
using FacultySystem.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FacultySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // serach about CORS 

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultySystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors("AllowReactApp");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();    

            app.Run();
            
        }
    }
}
