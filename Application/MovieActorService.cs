using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using System.Collections.Generic;

namespace MoviesWebApi.Application
{
    public class MovieActorService
    {
        private readonly MovieActorRepository _repository;

        public MovieActorService(MovieActorRepository repository)
        {
            _repository = repository;
        }

        public List<MovieActorDto> GetAllMovieActors()
        {
            
            List<MovieActor> movieActors = _repository.GetAllMovieActors();
            List<MovieActorDto> movieActorDtos = new List<MovieActorDto>();
            foreach (MovieActor movieActor in movieActors)
            {

                MovieActorDto movieActorDto = new MovieActorDto()
                {
                    Id = movieActor.Id,
                    MovieId = movieActor.MovieId,
                    ActorId = movieActor.ActorId,
                    Character = movieActor.Character,

                };
                movieActorDtos.Add(movieActorDto);
            }
            
            return movieActorDtos;
        }

        public MovieActorDto? GetMovieActorById(int id)
        {
            //the variable will have movieActor when it is found, when its not found the value be null
            MovieActor? movieActor = _repository.GetMovieActorById(id);
            MovieActorDto? movieActorDto = null;
            if (movieActor != null )
            {        
                //movieActor is not null, is found
                movieActorDto = new MovieActorDto()
                {
                    Id = movieActor.Id,
                    MovieId = movieActor.MovieId,
                    ActorId = movieActor.ActorId,
                    Character = movieActor.Character,
                };
            }


            return movieActorDto;
        }

        public MovieActorDto CreateMovieActor(MovieActorDto movieActorDto)
        {
            MovieActor movieActor = new MovieActor()
            {
                ActorId = movieActorDto.ActorId,
                MovieId = movieActorDto.MovieId,
                Id = movieActorDto.Id,
                Character = movieActorDto.Character
            };

            MovieActor movieActorCreated = _repository.AddMovieActor(movieActor);
            MovieActorDto movieActorDtoCreated = new MovieActorDto()
            {
                ActorId = movieActorCreated.ActorId,
                MovieId = movieActorCreated.MovieId,
                Id = movieActorCreated.Id,
                Character = movieActorCreated.Character,
            };         
            return movieActorDtoCreated;
        }

        

        public bool UpdateMovieActor(int id, MovieActorDto movieActorDto)
        {
        
            MovieActor? getMovieActor = _repository.GetMovieActorById(id);
            if (getMovieActor == null)
            {
                return false;
            }
            else
            {
                //update

                getMovieActor.ActorId = movieActorDto.ActorId;
                getMovieActor.MovieId = movieActorDto.MovieId;
                getMovieActor.Id = movieActorDto.Id;
                getMovieActor.Character = movieActorDto.Character;

                _repository.UpdateMovieActor(getMovieActor);

                return true;
            }
        }

        public bool DeleteMovieActor(int id)
        {
            if (_repository.GetMovieActorById(id) == null)
                return false;

            _repository.DeleteMovieActor(id);
            return true;
        }
    }
}
