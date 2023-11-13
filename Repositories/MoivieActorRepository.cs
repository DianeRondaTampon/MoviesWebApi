using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Models;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Repositories
{
    public class MovieActorRepository
    {
        private readonly MovieDbContext _context;

        public MovieActorRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<MovieActor> GetAllMovieActor()
        {
            return _context.MovieActor.ToList();
        }

        public MovieActor? GetMovieActorById(int id)
        {
            return _context.MovieActor.Find(id);
        }

        public void AddMovieActor(MovieActor movieActor)
        {
            _context.MovieActor.Add(movieActor);
            _context.SaveChanges();
        }

        public void UpdateMovie(MovieActor movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMovieActor(int id)
        {
            var movieActor = _context.MovieActor.Find(id);
            if (movieActor != null)
            {
                _context.MovieActor.Remove(movieActor);
                _context.SaveChanges();
            }
        }

       
    }
}
