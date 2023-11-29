using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;

namespace MoviesWebApi.Application
{
    public class MovieActorService
    {
        private readonly MovieActorRepository _repository;

        public MovieActorService(MovieActorRepository repository)
        {
            _repository = repository;
        }

        public List<MovieActor> GetAllMovieActor()
        {
            return _repository.GetAllMovieActor();
        }

        public MovieActor? GetMovieActorById(int id)
        {
            return _repository.GetMovieActorById(id);
        }

        public MovieActor CreateMovieActor(CreateMovieActorDto movieActorDto)
        {
            MovieActor movieActor = new MovieActor()
            {
                ActorId = movieActorDto.ActorId,
                MovieId = movieActorDto.MovieId,
                Id = movieActorDto.Id,
                Character = movieActorDto.Character
            };
            _repository.AddMovieActor(movieActor);
            return movieActor;
        }

        

        public bool UpdateMovieActor(int id, MovieActor movieActor)
        {
            if (_repository.GetMovieActorById(id) == null)
                return false;

            movieActor.Id = id;
            _repository.UpdateMovie(movieActor);
            return true;
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
