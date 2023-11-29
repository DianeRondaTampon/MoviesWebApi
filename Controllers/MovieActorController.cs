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
    public class MovieActorController : ControllerBase
    {
        private readonly MovieActorService _movieactorService;

        public MovieActorController(MovieActorService movieActorservice)
        {
            _movieactorService = movieActorservice;
        }

        // GET: api/MovieActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActor>>> GetMovieActor()
        {
            return Ok(_movieactorService.GetAllMovieActor());
        }

        // GET: api/MovieActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActor>> GetMovieActor(int id)
        {
            MovieActor movieactor = _movieactorService.GetMovieActorById(id);
            if (movieactor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movieactor);
            }
        }

        // PUT: api/MovieActors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieActor(int id, MovieActor movieActor)
        {
            if (id != movieActor.Id)
            {
                return BadRequest();
            }


            bool success = _movieactorService.UpdateMovieActor(id, movieActor);
            if (success)
            {
                return Ok(movieActor);
            }
            else
            {
                throw new Exception();
            }
        }

        // POST: api/MovieActors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieActor>> PostMovieActor(CreateMovieActorDto movieActor)
        {
            _movieactorService.CreateMovieActor(movieActor);

            return Ok(movieActor);
        }

        // DELETE: api/MovieActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieActor(int id)
        {
            if (_movieactorService.DeleteMovieActor(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }     
    }
}
