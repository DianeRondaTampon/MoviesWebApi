using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Controllers;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Application
{
    public class ActorService
    {
        private readonly ActorRepository _repository;

        public ActorService(ActorRepository repository)
        {
            _repository = repository;
        }

        public List<Actor> GetAllActor()
        {
            return _repository.GetAllActor();
        }

        public Actor? GetActorById(int id)
        {
            return _repository.GetActorById(id);
        }

        public Actor CreateActor(Actor actor)
        {
            _repository.AddActor(actor);
            return actor;
        }

        private void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public bool UpdateActor(int id, Actor actor)
        {
            //check if the actor dont exist
            if (_repository.GetActorById(id) == null)
                return false;

            actor.Id = id;
            _repository.UpdateActor(actor);
            return true;
        }

        public bool DeleteActor(int id)
        {
            if (_repository.GetActorById(id) == null)
                return false;

            _repository.DeleteActor(id);
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


