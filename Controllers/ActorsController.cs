
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ActorsController : ControllerBase
    {
        private readonly ActorService _actorService;

        public ActorsController(ActorService actorservice)
        {
            _actorService = actorservice;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActor()
        {
          return Ok( _actorService.GetAllActor());
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            Actor actor = _actorService.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(actor);
            }
        }

        // PUT: api/Actors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }


            bool success = _actorService.UpdateActor(id, actor);
            if (success)
            {
                return Ok(actor);
            }
            else
            {
                throw new Exception();
            }
        }

        // POST: api/Actors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            _actorService.CreateActor(actor);

            return Ok(actor);
        }
    

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            if( _actorService.DeleteActor(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Actors/generateActors
        [HttpGet("generateActors")]
        public ActionResult<List<Actor>> generateActors(int number)
        {
            List<Actor> actors = _actorService.generateActors(number);
            return Ok(actors);
        }


        
    }
}
