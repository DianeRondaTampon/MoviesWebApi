using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Controllers;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using NuGet.Protocol.Core.Types;
using System.Diagnostics.Metrics;
using System.IO;

namespace MoviesWebApi.Application
{
    public class ActorService
    {
        private readonly ActorRepository actorRepository;
        private readonly MovieRepository movieRepository;

        public ActorService(ActorRepository actorRepository, MovieRepository movieRepository)
        {
            this.actorRepository = actorRepository;
            this.movieRepository = movieRepository;
        }

        public List<ActorDto> GetAllActors()
        {
            List<Actor> actors = actorRepository.GetAllActor();
            List<ActorDto> actorDtos = new List<ActorDto>();
            foreach (Actor actor in actors) 
            {
                ActorDto actorDto = new ActorDto()
                {
                    Id = actor.Id,
                    Name = actor.Name,
                };
                actorDtos.Add(actorDto);
            }

            return actorDtos;
        }

        public ActorDto? GetActorById(int id)
        {
            Actor? actor = actorRepository.GetActorById(id);
            ActorDto? actorDto = null;
            if (actor != null)
            {
                actorDto = new ActorDto()
                {
                    Id = actor.Id,
                    Name = actor.Name,
                };
            }

            return actorDto;
        }

        public ActorDto CreateActor(ActorDto actorDto)
        {
            Actor actor = new Actor()
            {
                Id = actorDto.Id,
                Name = actorDto.Name,
            };
            Actor actorCreated = actorRepository.AddActor(actor);
            ActorDto actorCreatedDto = new ActorDto()
            {
                Id = actorCreated.Id,
                Name = actorCreated.Name
            };

            return actorCreatedDto;
        }



        public bool UpdateActor(int id, ActorDto actorDto)
        {
    
            Actor getActor = actorRepository.GetActorById(id);

            if (getActor == null)
            {
                return false; 
            }

            getActor.Id = actorDto.Id;
            getActor.Name = actorDto.Name;

            actorRepository.UpdateActor(getActor); 
          
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
       
        public List<ActorsMovieDto> actorsOfTheMovie (string movieName)
        {
            Movie movie = movieRepository.GetAllMovies().Where(m => m.Title == movieName).FirstOrDefault();

            List<ActorsMovieDto> actorsMovieDto = new List<ActorsMovieDto>();

            foreach (MovieActor movieActor in movie.MovieActor) 
            {
                
                ActorsMovieDto actorMovieDto = new ActorsMovieDto()
                {
                    NameActor = movieActor.Actor.Name,
                    MovieId = movie.Id,
                    ActorId = movieActor.ActorId,
                    Character = movieActor.Character,
                    Title = movie.Title,
                    Year = movie.Year,
                    DirectorId = movie.DirectorId,
                    GenderId = movie.GenderId
                };
                actorsMovieDto.Add(actorMovieDto);
            }

            return actorsMovieDto;
        }

    }
}


