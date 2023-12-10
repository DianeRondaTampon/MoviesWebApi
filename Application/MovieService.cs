using MoviesWebApi.Dto;
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
            _repository = repository;
        }

        public List<Movie> GetAllMovie()
        {

            return _repository.GetAllMovies().ToList();
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


        public List<GetMoviesFromYearDto> getMovieFromYear(int yearFrom, int yearUntil)
        {
            List<Movie> movies = _repository.GetAllMovies().Where(m => m.Year >= yearFrom && m.Year <= yearUntil).ToList();

            List<GetMoviesFromYearDto> result = new List<GetMoviesFromYearDto>();


            foreach (Movie movie in movies)
            {
                GetMoviesFromYearDto movieDto = new GetMoviesFromYearDto()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    NameDirector = movie.Director?.Name,
                    NameGender = movie.Gender?.Name
                };
                result.Add(movieDto);

            }

            return result;
        }

        public List<MovieGenderDto> getMoviesByGender(string nameGender)
        {
            List<Movie> movies = _repository.GetAllMovies().Where(m => m.Gender.Name == nameGender).ToList();


            // Using Select to project Person objects to PersonDto objects
            List<MovieGenderDto> moviesGenderDto = movies.Select(m => new MovieGenderDto
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                IdGender = m.GenderId,
                NameGender = m.Gender.Name


            }).ToList();

            return moviesGenderDto;
        }






    }
}
            
 

  
