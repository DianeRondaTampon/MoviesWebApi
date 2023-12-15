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

        public List<MovieActor> GetAllMovieActors()
        {
            return _context.MovieActor.ToList();
        }

        public MovieActor? GetMovieActorById(int id)
        {
            return _context.MovieActor.Find(id);
        }

        public MovieActor AddMovieActor(MovieActor movieActor)
        {
            _context.MovieActor.Add(movieActor);
            _context.SaveChanges();
            return movieActor;
        }

        public void UpdateMovieActor(MovieActor movie)
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
