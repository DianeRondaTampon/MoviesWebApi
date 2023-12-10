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
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAllDirectors()
        {
            List<DirectorDto> directors = _directorService.GetAllDirectors();
            return Ok(directors);
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
            DirectorDto? director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(director);
            }
        }
     
        // POST: api/Directors                           
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DirectorDto>> PostDirector(DirectorDto directorDto)
        {
            DirectorDto directorCreatedDto =  _directorService.CreateDirector(directorDto);

            return Ok(directorCreatedDto);
        }


        // PUT: api/Directors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(int id, DirectorDto directorDto)
        {
            if (id != directorDto.Id)
            {
                return BadRequest();
            }

            bool success = _directorService.UpdateDirector(id, directorDto);
            if (success)
            {
                return Ok(directorDto);
            }
            else
            {
                return NotFound();
            }
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
        public ActionResult<List<MovieDirectorDto>> GetMoviesFromDirector(string nameOfTheDirector)
        {
            List<MovieDirectorDto> result = _directorService.getMoviesFromDirector(nameOfTheDirector);
            return Ok(result);
        }

    }
}
