using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Infrastructure;
using MoviesWebApi.Models;
using NuGet.Protocol.Core.Types;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Repositories
{
    public class ActorRepository
    {
        private readonly MovieDbContext _context;

        public ActorRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<Actor> GetAllActor()
        {
            return _context.Actor.ToList();
        }

        public Actor? GetActorById(int id)
        {
            return _context.Actor.Find(id);
        }

        public Actor AddActor(Actor actor)
        {
            _context.Actor.Add(actor);
            _context.SaveChanges();
            return actor;
        }

        public void UpdateActor(Actor actor)
        {
            _context.Entry(actor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteActor(int id)
        {
            var actor = _context.Actor.Find(id);
            if (actor != null)
            {
                _context.Actor.Remove(actor);
                _context.SaveChanges();
            }
        }

     
       
    }
}

