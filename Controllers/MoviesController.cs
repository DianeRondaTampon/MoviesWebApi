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
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return Ok(_movieService.GetAllMovie());
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            Movie movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }


            bool success = _movieService.UpdateMovie(id, movie);
            if (success)
            {
                return Ok(movie);
            }
            else
            {
                throw new Exception();
            }
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _movieService.CreateMovie(movie);

            return Ok(movie);
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
        public ActionResult<List<MovieDto>> getMovieFromYear(int yearFrom, int yearUntil)
        {
            List <MovieDto> movies = _movieService.getMovieFromYear(yearFrom, yearUntil);
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
