using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Infrastructure;
using MoviesWebApi.Models;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Repositories
{
    public class RateMovieRepository
    {

        private readonly MovieDbContext _context;

        public RateMovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IQueryable<RateMovie> GetAllRateMovies()
        {
            //we are returning IQueryable instead of List because we use the property navigation test
            return _context.RateMovie;
        }

        public RateMovie? GetRateMovieById(int id)
        {
            return _context.RateMovie.Find(id);
        }

        public RateMovie AddRateMovie(RateMovie rateMovie)
        {
            _context.RateMovie.Add(rateMovie);
            _context.SaveChanges();
            return rateMovie;
        }

        public void UpdateRateMovie(RateMovie rateMovie)
        {
            _context.Entry(rateMovie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRateMovie(int id)
        {
            var rateMovie = _context.RateMovie.Find(id);
            if (rateMovie != null)
            {
                _context.RateMovie.Remove(rateMovie);
                _context.SaveChanges();
            }
        }

       
    }
}

