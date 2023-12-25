using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Application;
using MoviesWebApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace MoviesWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;


        public void ConfigureServices(IServiceCollection services)
        {

            //injection of dependencies
         
            // Add DbContext
            services.AddDbContext<MovieDbContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(_configuration.GetConnectionString("MoviesDatabase")));

            // Add Repositories
            services.AddScoped<ActorRepository>();
            services.AddScoped<DirectorRepository>();
            services.AddScoped<GenderRepository>();
            services.AddScoped<MovieActorRepository>();
            services.AddScoped<MovieRepository>();

            // Add Services
            services.AddScoped<ActorService>();
            services.AddScoped<CalculationService>();
            services.AddScoped<DirectorService>();
            services.AddScoped<GenderService>();
            services.AddScoped<MovieActorService>();
            services.AddScoped<MovieService>();
            services.AddScoped<GetActorById.GetActorByIdHandler>();
            services.AddScoped<GetAllActors.GetAllActorsHandler>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MovieDbContext dbContext)
        {
            //apply the migration when program start
            dbContext.Database.Migrate();
           

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



