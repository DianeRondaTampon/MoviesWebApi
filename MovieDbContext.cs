using MoviesWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace MoviesWebApi
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }



        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Gender> Gender { get; set; }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //this property for Lazy Loading
                optionsBuilder.UseLazyLoadingProxies();


                // Replace "YourServer", "YourDatabase", "YourUsername", and "YourPassword" with your actual database details
                optionsBuilder.UseSqlServer("Server=DESKTOP-9998B8S\\SQLEXPRESS;Database=Movies;User Id=userMovie;Password=userMovie;TrustServerCertificate=True;");

                
            }


        }


        
    }
}
