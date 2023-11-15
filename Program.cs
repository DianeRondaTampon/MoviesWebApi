using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Application;
using MoviesWebApi.Repositories;
using System.Configuration;

namespace MoviesWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            //dependency injection:

            // Add DbContext
            builder.Services.AddDbContext<MovieDbContext>(options => 
                options.UseLazyLoadingProxies()
                    .UseSqlServer("Server=DESKTOP-9998B8S\\SQLEXPRESS;Database=Movies;User Id=userMovie;Password=userMovie;TrustServerCertificate=True;"));

 
            // Add Repositories
            builder.Services.AddScoped<ActorRepository>();
            builder.Services.AddScoped<DirectorRepository>();
            builder.Services.AddScoped<GenderRepository>();
            builder.Services.AddScoped<MovieActorRepository>();
            builder.Services.AddScoped<MovieRepository>();
            // Add other repositories if needed

            // Add Services
            builder.Services.AddScoped<ActorService>();
            builder.Services.AddScoped<CalculationService>();
            builder.Services.AddScoped<DirectorService>();
            builder.Services.AddScoped<GenderService>();
            builder.Services.AddScoped<MovieActorService>();
            builder.Services.AddScoped<MovieService>();
            // Add other services if needed




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


            app.UseHttpsRedirection();


            app.UseAuthorization();


            app.MapControllers();


            app.Run();
        }
    }
}