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
        private readonly MovieActorService _movieActorService;

        public MovieActorController(MovieActorService movieActorservice)
        {
            _movieActorService = movieActorservice;
        }

        // GET: api/MovieActors
        [HttpGet]
        public async Task<ActionResult<List<MovieActorDto>>> GetAllMovieActors()
        {
            List<MovieActorDto> movieActors = _movieActorService.GetAllMovieActors();
            return Ok(movieActors);
        }

        // GET: api/MovieActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActorDto>> GetMovieActor(int id)
        {
            MovieActorDto? movieActor = _movieActorService.GetMovieActorById(id);
            if (movieActor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movieActor);
            }
        }

        // POST: api/MovieActors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieActorDto>> PostMovieActor(MovieActorDto movieActorDto)
        {

            MovieActorDto createdMovieActorDto = _movieActorService.CreateMovieActor(movieActorDto);

            return Ok(createdMovieActorDto);
        }

        // PUT: api/MovieActors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<MovieActor>> PutMovieActor(int id, MovieActorDto movieActorDto)
        {
            if (id != movieActorDto.Id)
            {
                //throw new Exception("The id to be updated is not the same as the id of the object to be updated");
                return BadRequest();
            }

            bool success = _movieActorService.UpdateMovieActor(id, movieActorDto);
            if (success)
            {
                return Ok(movieActorDto);
            }
            else
            {
                //the id doesnt exist, not found
                return NotFound();
            }
        }


        // DELETE: api/MovieActors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieActor(int id)
        {
            if (_movieActorService.DeleteMovieActor(id))
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
