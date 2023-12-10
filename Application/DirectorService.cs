using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.Xml;

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

        public List<DirectorDto> GetAllDirectors()
        {
            List<Director> directors = _repository.GetAllDirectors();
            List<DirectorDto> directorDtos = new List<DirectorDto>();

            foreach (Director director in directors) 
            {
                DirectorDto directorDto = new DirectorDto()
                {
                    Id = director.Id,
                    Name = director.Name
                 
                };
                directorDtos.Add(directorDto);

            }
                return directorDtos;
        }


        //this function will return a director or null if not found 



        //first is that the variable DirectorDto need to initialize as null, then 


        public DirectorDto? GetDirectorById(int id)
        {
            
            Director? director = _repository.GetDirectorById(id);

            if (director != null)
            {
                //CASE A: director WILL HAVE A DIRECTOR
                //Transform from Director to DirectorDto
                //RETURN  DirectorDto 

                //transform from Director to DirectorDto 
                DirectorDto directorDto = new DirectorDto()
                {
                    //transform from Director to DirectorDto 

                    Id = director.Id,
                    Name = director.Name
                };

                return directorDto;
            }
            else
            {
                //CASE B: director WILL BE A NULL
                //RETURN NULL

                return null;
            }
        
        }

        public DirectorDto CreateDirector(DirectorDto directorDto)
        {
            //transform from DirectorDto to Director
            Director director = new Director()
            {
                Id = directorDto.Id,
                Name = directorDto.Name,
            };
           
            Director directorCreated =_repository.AddDirector(director);
            //transform from Director to DirectorDto 
            DirectorDto directorCreatedDto = new DirectorDto()
            {
                Id = directorCreated.Id,
                Name = directorCreated.Name,
            };

            return directorCreatedDto;
        }

       

        public bool UpdateDirector(int id, DirectorDto directorDto)
        {
            //First GET the director from repository         
            Director getDirector =_repository.GetDirectorById(id);

            if (getDirector == null)
            {
                return false;
            }

            //Second MODIFY the properties of the Director that you get
            getDirector.Id =  directorDto.Id;
            getDirector.Name = directorDto.Name;

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
