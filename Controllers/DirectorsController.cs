using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorService _directorService;

        public DirectorsController(DirectorService directorservice)
        {
            _directorService = directorservice;
        }

        // GET: api/Directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirector()
        {
            return Ok(_directorService.GetAllDirector());
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
            Director director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(director);
            }
        }


        // PUT: api/Directors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(int id, Director director)
        {

            if (id != director.Id)
            {
                return BadRequest();
            }


            bool success = _directorService.UpdateDirector(id, director);
            if (success)
            {
                return Ok(director);
            }
            else
            {
                throw new Exception();
            }
        }
        // POST: api/Directors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Director>> PostDirector(Director director)
        {
            _directorService.CreateDirector(director);

            return Ok(director);
        }

        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            if (_directorService.DeleteDirector(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        // GET: api/Directors/getMoviesFromDirector
        [HttpGet("getMoviesFromDirector")]
        public ActionResult<List<MovieDirectorDto>> getMoviesFromDirector(string nameOfTheDirector)
        {
            List<MovieDirectorDto> result = _directorService.getMoviesFromDirector(nameOfTheDirector);
            return Ok(result);
        }

    }
}
