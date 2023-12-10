using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Models;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Repositories
{
    public class DirectorRepository
    {

        private readonly MovieDbContext _context;

        public DirectorRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<Director> GetAllDirectors()
        {
            return _context.Director.ToList();
        }

        public Director? GetDirectorById(int id)
        {
            return _context.Director.Find(id);
        }

        public Director AddDirector(Director director)
        {
            _context.Director.Add(director);
            _context.SaveChanges();
            return director;
        }

        public void UpdateDirector(Director director)
        {
            _context.Entry(director).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteDirector(int id)
        {
            var director = _context.Director.Find(id);
            if (director != null)
            {
                _context.Director.Remove(director);
                _context.SaveChanges();
            }
        }

        
    }
}

