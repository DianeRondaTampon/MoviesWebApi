
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
    public class ActorsController : ControllerBase
    {
        private readonly ActorService _actorService;
        private readonly GetActorById.GetActorByIdHandler _getActorByIdHandler;
        private readonly GetAllActors.GetAllActorsHandler _getAllActorsHandler;

        public ActorsController(ActorService actorservice, GetActorById.GetActorByIdHandler getActorByIdHandler, GetAllActors.GetAllActorsHandler getAllActorsHandler)
        {
            _actorService = actorservice;
            _getActorByIdHandler = getActorByIdHandler;
            _getAllActorsHandler = getAllActorsHandler;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<List<ActorDto>>> GetAllActors()
        {
            List<ActorDto> actors = _actorService.GetAllActors();
            return Ok(actors);
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDto>> GetActor(int id)
        {
            ActorDto? actor = _actorService.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(actor);
            }
        }

        // POST: api/Actors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActorDto>> PostActor(ActorDto actorDto)
        {
            ActorDto actorCreatedDto = _actorService.CreateActor(actorDto);
            return Ok(actorCreatedDto);
        }


        // PUT: api/Actors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ActorDto>> PutActor(int id, ActorDto actorDto)
        {
            if (id != actorDto.Id)
            {
                return BadRequest();
            }

            bool success = _actorService.UpdateActor(id, actorDto);
            if (_actorService.UpdateActor(id, actorDto))
            {
                return Ok(actorDto);
            }
            else
            {
                return NotFound();
            }
        }


        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            if (_actorService.DeleteActor(id))
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
        public ActionResult<List<Actor>> GenerateActors(int number)
        {
            List<Actor> actors = _actorService.generateActors(number);
            return Ok(actors);
        }


        // GET: api/Actors/actorsOfTheMovie
        [HttpGet("actorsOfTheMovie")]
        public ActionResult<List<ActorsMovieDto>> ActorsOfTheMovie(string movieName)
        {
            List<ActorsMovieDto> actorsMovies = _actorService.actorsOfTheMovie(movieName);
            return Ok(actorsMovies);
        }

        // GET: api/Actors/GetActorByIdNewArchictecture
        [HttpGet("GetActorByIdNewArchictecture")]
        public ActionResult<GetActorById.GetActorByIdResponse> GetActorByIdNewArchictecture(int id)
        {

            GetActorById.GetActorByIdResponse? response = _getActorByIdHandler.GetActorByIdCommandHandler(new GetActorById.GetActorByIdRequest() { Id = id });

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        
        // GET: api/Actors/GetAllActorsNewArchictecture
        [HttpGet("GetAllActorsNewArchictecture")]
        public ActionResult<GetAllActors.GetAllActorsResponse> GetAllActorsNewArchictecture()
        {
            List <GetAllActors.GetAllActorsResponse> response = _getAllActorsHandler.GetAllActorsCommandHandler(new GetAllActors.GetAllActorsRequest() { });
            return Ok(response);
        }




    }
}
