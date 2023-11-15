using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Models;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Repositories
{
    public class MovieRepository
    {

        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return _context.Movie;
        }

        public Movie? GetMovieById(int id)
        {
            return _context.Movie.Find(id);
        }

        public void AddMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movie.Find(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                _context.SaveChanges();
            }
        }

       
    }
}

