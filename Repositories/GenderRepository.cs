using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Models;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Repositories
{
    public class GenderRepository
    {

        private readonly MovieDbContext _context;

        public GenderRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<Gender> GetAllGender()
        {
            return _context.Gender.ToList();
        }

        public Gender? GetGenderById(int id)
        {
            return _context.Gender.Find(id);
        }

        public void AddGender(Gender gender)
        {
            _context.Gender.Add(gender);
            _context.SaveChanges();
        }

        public void UpdateGender(Gender gender)
        {
            _context.Entry(gender).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteGender(int id)
        {
            var gender = _context.Gender.Find(id);
            if (gender != null)
            {
                _context.Gender.Remove(gender);
                _context.SaveChanges();
            }
        }

        
    }
}

