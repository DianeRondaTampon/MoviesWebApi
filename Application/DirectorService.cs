using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace MoviesWebApi.Application
{
    public class DirectorService
    {
        private readonly DirectorRepository _repository;
        private readonly MovieRepository _movieRepository;

        //this is a constructor,doens't have a return parameter, has a list of input parameter 
        public DirectorService(DirectorRepository repository, MovieRepository movieRepository)
        {
            _repository = repository ;
            _movieRepository = movieRepository;
        }

        public List<Director> GetAllDirector()
        {
            return _repository.GetAllDirector();
        }

        public Director? GetDirectorById(int id)
        {
            //Director diane= _repository.GetDirectorById(id);
            //bool isNULL = diane == null;
            //bool isVeryNull = _repository.GetDirectorById(id) == null;

            //if(_repository.GetDirectorById(id)==null)
            //{
            //    //is null ->doesn't exist
            //}
            //else
            //{
            //    //is a director exist
            //}

            return _repository.GetDirectorById(id);
        }

        public Director CreateDirector(Director director)
        {
            _repository.AddDirector(director);
            return director;
        }

       

        public bool UpdateDirector(int id, Director director)
        {
            //First GET the director from repository         
            Director getDirector =_repository.GetDirectorById(id);
            
            //Second MODIFY the properties of the Director that you get
            getDirector.Id =  director.Id;
            getDirector.Name = director.Name;

            //Third UPDATE the director in the repository
            _repository.UpdateDirector(getDirector);
            return true;
        }


        public bool DeleteDirector(int id)
        {
            if (_repository.GetDirectorById(id) == null)
                return false;

            _repository.DeleteDirector(id);
            return true;
        }

        public List<MovieDirectorDto> getMoviesFromDirector(string nameOfTheDirector)
        {
            List<MovieDirectorDto> movieDirectorDto = new List<MovieDirectorDto>();//Create an empty list

            //get all the movies of the director

             //var moviesEnumerable = _movieRepository.GetAllMovie().Where(m => m.DirectorId == 1);
             List<Movie> movies= _movieRepository.GetAllMovies().Where(m => m.Director != null && m.Director.Name == nameOfTheDirector).ToList();

            //List<Movie> movies = _movieRepository.GetAllMovies()
            //    .Include(m => m.Director) // Include the Director navigation property
            //    .Where(m => m.Director != null && m.Director.Name == nameOfTheDirector)
            //    .ToList();

            //transverse all the movies of the list

            foreach (Movie movie in movies)

            {
                //add element to the list ,way1:
                movieDirectorDto.Add(new MovieDirectorDto
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    DirectorId = movie.DirectorId,
                    GenderId = movie.GenderId,
                    DirectorName = movie.Director?.Name,
                }); ;

            }

            return movieDirectorDto;
        }

    }
}
