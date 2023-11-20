using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Controllers;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Application
{
    public class ActorService
    {
        private readonly ActorRepository actorRepository;

        public ActorService(ActorRepository actorRepository)
        {
            this.actorRepository = actorRepository;
        }

        public List<Actor> GetAllActor()
        {
            return actorRepository.GetAllActor();
        }

        public Actor? GetActorById(int id)
        {
            return actorRepository.GetActorById(id);
        }

        public Actor CreateActor(Actor actor)
        {
            actorRepository.AddActor(actor);
            return actor;
        }

        private void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public bool UpdateActor(int id, Actor actor)
        {
            //check if the actor dont exist
            if (actorRepository.GetActorById(id) == null)
                return false;

            actor.Id = id;
            actorRepository.UpdateActor(actor);
            return true;
        }

        public bool DeleteActor(int id)
        {
            if (actorRepository.GetActorById(id) == null)
                return false;

            actorRepository.DeleteActor(id);
            return true;
        }

        public List<Actor> generateActors(int number)
        {
            List<Actor> actors = new List<Actor>();//the list of actor is created empty
            
            for (int i = 1; i <= number; i++)
            {
                //add element to the list ,way1:
                actors.Add(new Actor { Id = i, Name = "Juan Carlos" });


                ///add element to the list ,way2:
                //Actor actor = new Actor { Id = 7, Name = "Juan Carlos" };
                //actors.Add(actor);

            }

            return actors;
        }

    }
}


