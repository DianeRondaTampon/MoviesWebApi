using log4net;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using NuGet.Protocol.Core.Types;

namespace MoviesWebApi.Application
{
    public class RateMovieService
    {
        private readonly RateMovieRepository _repository;
        private readonly MovieRepository _movieRepository;
        private readonly ILog _logger;

        //this is a constructor

        public RateMovieService(RateMovieRepository repository, MovieRepository movieRepository, ILog logger)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            this._logger = logger;
        }


        // <summary>
        // Create a RateMovie
        // </summary>
        // <param name="createRateMovieRequest">the ratemovie that will be created </param>
        // <returns>Returns a string with "" if succesful, or a string with message if error</returns>
        public string CreateRateMovie(CreateRateMovieRequest createRateMovieRequest)
        {
           
            //we will check if the user and movie rate already exists (return message error)


            RateMovie? result = _repository.GetAllRateMovies().Where(r => r.MovieId == createRateMovieRequest.MovieId && r.UserId == createRateMovieRequest.UserId).FirstOrDefault();

            
            if (result != null)
            {
                string message = "Error: The user and movie rate already exists";
                _logger.Error(message);
                return message;
            }
            
            //we will check if the movie id not exists (return message error)
            Movie? movie = _movieRepository.GetMovieById(createRateMovieRequest.MovieId);

            if (movie == null)
            {
                string message = "Error: The movie id don't exists";
                _logger.Error(message);
                return message;

            }


            RateMovie newRateMovie = new RateMovie()
            {
                Id = createRateMovieRequest.Id,
                UserId = createRateMovieRequest.UserId,
                MovieId = createRateMovieRequest.MovieId,
                Rate = createRateMovieRequest.Rate,


            };

            RateMovie createdRateMovie = _repository.AddRateMovie(newRateMovie);

            return "";

        }



    }
}
