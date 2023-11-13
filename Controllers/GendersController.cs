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
using MoviesWebApi.Models;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly GenderService _genderService;

        public GendersController(GenderService  genderservice)
        {
            _genderService = genderservice;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGender()
        {
            return Ok(_genderService.GetAllGender());
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            Gender gender = _genderService.GetGenderById(id);
            if (gender == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(gender);
            }
        }
        // PUT: api/Genders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(int id, Gender gender)
        {
            if (id != gender.Id)
            {
                return BadRequest();
            }


            bool success = _genderService.UpdateGender(id, gender);
            if (success)
            {
                return Ok(gender);
            }
            else
            {
                throw new Exception();
            }
        }
        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender gender)
        {
            _genderService.CreateGender(gender);

            return Ok(gender);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            if (_genderService.DeleteGender(id))
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
