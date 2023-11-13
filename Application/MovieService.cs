using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using NuGet.Protocol.Core.Types;

namespace MoviesWebApi.Application
{
    public class MovieService
    {
        private readonly MovieRepository _repository;

        public MovieService(MovieRepository repository)
        {
            _repository =   repository;
        }

        public List<Movie> GetAllMovie()
        {
            return _repository.GetAllMovie();
        }

        public Movie? GetMovieById(int id)
        {
            return _repository.GetMovieById(id);
        }

        public Movie CreateMovie(Movie movie)
        {
            _repository.AddMovie(movie);
            return movie;
        }

        private void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(int id, Movie movie)
        {
            if (_repository.GetMovieById(id) == null)
                return false;

            movie.Id = id;
            _repository.UpdateMovie(movie);
            return true;
        }

        public bool DeleteMovie(int id)
        {
            if (_repository.GetMovieById(id) == null)
                return false;

            _repository.DeleteMovie(id);
            return true;
        }
    }
}
