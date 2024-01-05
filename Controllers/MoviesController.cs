using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi;
using MoviesWebApi.Application;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using NuGet.Protocol.Plugins;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllMovies()
        {          
                return Ok(_movieService.GetAllMovies());
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            MovieDto? movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(MovieDto movieDto)
        {
            MovieDto movieDtoCreated = _movieService.CreateMovie(movieDto);

            if (movieDtoCreated == null)
            {
                return BadRequest("Invalid movie title provided");
            }


            return Ok(movieDtoCreated);
        }


        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<MovieDto>> PutMovie(int id, MovieDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return BadRequest();
            }

            bool success = _movieService.UpdateMovie(id, movieDto);
            if (success)
            {
                return Ok(movieDto);
            }
            else
            {
                return NotFound();
            }
        }


        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_movieService.DeleteMovie (id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        // GET: api/Actors/getMovieFromYear
        [HttpGet("getMovieFromYear")]
        public ActionResult<List<GetMoviesFromYearDto>> getMovieFromYear(int yearFrom, int yearUntil)
        {
            List <GetMoviesFromYearDto> movies = _movieService.getMovieFromYear(yearFrom, yearUntil);
            return Ok(movies);
        }


        // GET: api/Actors/getMoviesByGender
        [HttpGet("getMoviesByGender")]
        public ActionResult<List<MovieGenderDto>> getMoviesByGender(string nameGender)
        {
            List<MovieGenderDto> moviesGender = _movieService.getMoviesByGender(nameGender);
            return Ok(moviesGender);
        }







    }
}
