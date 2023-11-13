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

        public MovieActor CreateMovieActor(MovieActor movieActor)
        {
            _repository.AddMovieActor(movieActor);
            return movieActor;
        }

        private void AddMovieActor(MovieActor movieActor)
        {
            throw new NotImplementedException();
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
