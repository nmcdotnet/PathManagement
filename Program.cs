
using Microsoft.EntityFrameworkCore;
using PathManagement.Data;
using PathManagement.Mappings;
using PathManagement.Repositories;

namespace PathManagement
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

            builder.Services.AddDbContext<PathManagementDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("PathManagementConnectionString"))); // Add dbcontent connect with sqlserver by connection string from appseting.json

            //Inject Repositories
            builder.Services.AddScoped<IPathRepository,SQLPathRepository>();

            //Automapper
            builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

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
