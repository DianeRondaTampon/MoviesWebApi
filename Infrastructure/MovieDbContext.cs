using MoviesWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Configuration;

namespace MoviesWebApi.Infrastructure
{
    public class MovieDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public MovieDbContext(DbContextOptions<MovieDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }
        public DbSet<RateMovie> RateMovie { get; set; }
        



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //this property for Lazy Loading
                optionsBuilder.UseLazyLoadingProxies();


                // Replace "YourServer", "YourDatabase", "YourUsername", and "YourPassword" with your actual database details
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MoviesDatabase"));

            }
        }

    }
}
