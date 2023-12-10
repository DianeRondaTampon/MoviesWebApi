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
    public class GendersController : ControllerBase
    {
        private readonly GenderService _genderService;

        public GendersController(GenderService  genderservice)
        {
            _genderService = genderservice;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderDto>>> GetAllGenders()
        {
            List<GenderDto> genders = _genderService.GetAllGenders();
            return Ok(genders);
        }


        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenderDto>> GetGender(int id)
        {
          
            GenderDto genderDto = _genderService.GetGenderById(id);
            if (genderDto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(genderDto);
            }
        }
        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenderDto>> PostGender(GenderDto genderDto)
        {
            GenderDto genderCreatedDto = _genderService.CreateGender(genderDto);

            return Ok(genderCreatedDto);
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
