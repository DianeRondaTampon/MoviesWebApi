using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.Application;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateMovieController : ControllerBase
    {
        private readonly RateMovieService _rateMovieService;

        public RateMovieController(RateMovieService rateMovieService)
        {
            _rateMovieService = rateMovieService;
        }


        /// <summary>
        /// In the RateMovie controller the endpoint CreateRateMovie
        /// </summary>
        /// <param name="createRateMovieRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<bool>> CreateRateMovie(CreateRateMovieRequest createRateMovieRequest)
        {
            string response = _rateMovieService.CreateRateMovie(createRateMovieRequest);

            //in response i will recive a message of error 
            //if success an empty ""

            if (response != "")
            {
                return BadRequest(response);
            }
            return Ok(true);

        }
    }
}


