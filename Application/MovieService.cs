using log4net;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using System.IO;
using System.Linq;

namespace MoviesWebApi.Application
{
    public class MovieService
    {
        private readonly MovieRepository _repository;
        private readonly RateMovieRepository _rateMovieRepository;
        private readonly ILog _logger;

        //this is a constructor

        public MovieService(MovieRepository repository, RateMovieRepository rateMovieRepository, ILog logger)
        {
            _repository = repository;
            _rateMovieRepository = rateMovieRepository;
            this._logger = logger;
           
        }

        public List<GetAllMovieResponse> GetAllMovies()
        {
            List<GetAllMovieResponse> result = new List<GetAllMovieResponse>();

            List<Movie> movies = _repository.GetAllMovies().ToList();

            foreach (Movie movie in movies)
            {

                GetAllMovieResponse movieResponse = new GetAllMovieResponse()
                {

                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    DirectorId = movie.DirectorId,
                    GenderId = movie.GenderId,
                    AverageRating = CalculateAverageRateMovie(movie.Id),

                }; 
                result.Add(movieResponse);
            }
            return result;
        }

        public GetAllMovieResponse? GetMovieById(int id)
        {

            Movie? movie = _repository.GetMovieById(id);
            if (movie == null)
            {
                return null;
            }
            else
            {
                GetAllMovieResponse movieResponde = new GetAllMovieResponse()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    DirectorId = movie.DirectorId,
                    GenderId = movie.GenderId,
                    AverageRating = CalculateAverageRateMovie(movie.Id)
                };
                return movieResponde;
            }
        }

        private decimal CalculateAverageRateMovie(int movieId)
        {
            //i will call the repository for the rates, NAME OF THE REPOSITORY IS RateMovieRepository

            List <RateMovie> rateMovie = _rateMovieRepository.GetAllRateMovies().Where(r => r.MovieId == movieId).ToList();

            //int sum = rateMovie.Sum(r => r.Rate); //lets do it normally without function sum
            int sum = 0;
            decimal count = rateMovie.Count;
            decimal average;

            //calculate sum of all elements of the list
            //sum = sum + element
            //when working with list when you need access to all the elements we learned how to do it in lesson of loops
            //foreach is for traverse a list
            
            foreach (RateMovie rateMovieItem in rateMovie)
            {
                sum = sum + rateMovieItem.Rate;
            }



            if (count > 0 )
            {
                average = sum / count;
                return average;
            }
            else
            {
                return 0;
            }
        }

        public MovieDto? CreateMovie(MovieDto movieDto)
        {
            MovieDto movieDtoCreated;
            try
            {
                if (string.IsNullOrEmpty(movieDto.Title))
                {

                    _logger.Error("Invalid movie title provided");
                    return null;
                }

                if (movieDto.Year < 1900 || movieDto.Year > 2100)
                {
                    _logger.Warn("Possible invalid movie year: " + movieDto.Title + movieDto.Year);
                }


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
                _logger.Info("Movie added: " + movieDto.Title);


                //i have  movieCreated i need movieDtoCreated
                movieDtoCreated = new MovieDto()
                {

                    Id = movieCreated.Id,
                    Title = movieCreated.Title,
                    Year = movieCreated.Year,
                    DirectorId = movieCreated.DirectorId,
                    GenderId = movieCreated.GenderId
                };
            }
            catch (Exception ex)
            {
                _logger.Error("Error unknown: " + ex.Message, ex);
                throw;
            }

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


 
            
 

  
