using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using System.IO;

namespace MoviesWebApi.Application
{
    public class MovieService
    {
        private readonly MovieRepository _repository;

        public MovieService(MovieRepository repository)
        {
            _repository = repository;
        }

        public List<MovieDto> GetAllMovies()
        {
            List<MovieDto> result = new List<MovieDto>();

            List<Movie> movies = _repository.GetAllMovies().ToList();

            foreach (Movie movie in movies)
            {

                MovieDto movieDto = new MovieDto()
                {

                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    DirectorId = movie.DirectorId,
                    GenderId = movie.GenderId

                };
                result.Add(movieDto);
            }
            return result;
        }

        public MovieDto? GetMovieById(int id)
        {

            Movie? movie = _repository.GetMovieById(id);
            if (movie == null)
            {
                return null;
            }
            else
            {
                MovieDto movieDto = new MovieDto()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    DirectorId = movie.DirectorId,
                    GenderId = movie.GenderId
                };
                return movieDto;
            }


        }

        public MovieDto CreateMovie(MovieDto movieDto)
        {
            //I have a DTO and I need a MOVIE
            Movie movie = new Movie()
            {

                Id = movieDto.Id,
                Title = movieDto.Title,
                Year = movieDto.Year,
                DirectorId = movieDto.DirectorId,
                GenderId = movieDto.GenderId

            };
            Movie movieCreated = _repository.AddMovie(movie);
            //i have  movieCreated i need movieDtoCreated
            MovieDto movieDtoCreated = new MovieDto()
            {

                Id = movieCreated.Id,
                Title = movieCreated.Title,
                Year = movieCreated.Year,
                DirectorId = movieCreated.DirectorId,
                GenderId = movieCreated.GenderId
            };

            return movieDtoCreated;
        }

        public bool UpdateMovie(int id, MovieDto movieDto)
        {
            Movie? getMovie = _repository.GetMovieById(id);

            if (getMovie == null) 
            {
                // It is not found the id of movie do not exist 
                return false;
            }

            getMovie.Id = movieDto.Id;
            getMovie.Title = movieDto.Title;
            getMovie.Year = movieDto.Year;
            getMovie.DirectorId = movieDto.DirectorId;
            getMovie.GenderId = movieDto.GenderId;

            _repository.UpdateMovie(getMovie);

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
            
 

  
