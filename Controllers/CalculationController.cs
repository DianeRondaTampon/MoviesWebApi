using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Application;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly CalculationService _calculationService;

        public CalculationController(CalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        // GET: api/Calculation/sumOfTheNumberLessThan
        [HttpGet("sumOfTheNumberLessThan")]
        public ActionResult<int> sumOfTheNumberLessThan(int givennumber)
        {
            int sum = _calculationService.sumOfTheNumberLessThan(givennumber);

            return Ok(sum);
        }

        // GET: api/Calculation/factorialOfAGiveNumber
        [HttpGet("factorialOfAGiveNumber")]
        public ActionResult<int> factorialOfAGiveNumber(int factorial)
        {
            int multiply = _calculationService.factorialOfAGivenNumber(factorial);

            return Ok(multiply);
        }

        // GET: api/Calculation/repeatStrings
        [HttpGet("repeatStrings")]
        public ActionResult<int> repeatStrings(int number, string text)
        {
            string result = _calculationService.repeatStrings(number, text);

            return Ok(result);
        }

        // GET: api/Calculation/sumTwoNumbers
        [HttpGet("sumTwoNumbers")]
        public ActionResult<int> sumTwoNumbers(int number1, int number2)
        {
            int total = _calculationService.sumTwoNumbers(number1, number2);

            return Ok(total);
        }

        // GET: api/Calculation/practiceTheVariables
        [HttpGet("practiceTheVariables")]
        public ActionResult<int> practiceTheVariables()
        {
            _calculationService.practiceTheVariables();
            return Ok();
        }

        // GET: api/Calculation/generateMatrix
        [HttpGet("generateMatrix")]
        public ActionResult<string> generateMatrix(int rows, int columns, int content)
        {
            int[,] matrix = _calculationService.generateMatrix(rows, columns, content);
            string json = JsonConvert.SerializeObject(matrix);

            return Ok(json);
        }
        // GET: api/Calculation/youCanVote
        [HttpGet("youCanVote")]
        public ActionResult<string> youCanVote(int age)
        {
            string result = _calculationService.youCanVote(age);
            return Ok(result);
        }

        // GET: api/Calculation/OpenAnBankAccount
        [HttpGet("OpenAnBankAccount")]
        public ActionResult<string> OpenAnBankAccount(int age, string nationality, string client)
        {
            string result = _calculationService.OpenAnBankAccount(age, nationality, client);
            return Ok(result);
        }

        // GET: api/Calculation/generateDataNumber
        [HttpGet("generateDataNumber")]
        public ActionResult<List<DataNumberDto>> generateDataNumber(int quantity)
        {
            List<DataNumberDto> result = _calculationService.generateDataNumber(quantity);
            return Ok(result);
        }


        // GET: api/Calculation/workWithCar
        [HttpGet("workWithCar")]
        public ActionResult<Car> workWithCar(string color)
        {
            Car car = _calculationService.workWithCar(color);

            return Ok(car);
        }

        // GET: api/Calculation/transformHourFromPhilippinesToSpain
        [HttpGet("transformHourFromPhilippinesToSpain")]
        public ActionResult<int> transformHourFromPhilippinesToSpain(int hour)
        {

            int? result = _calculationService.transformHourFromPhilippinesToSpain(hour);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }

        }
        // GET: api/Calculation/CalculateAgeStatus
        [HttpGet("CalculateAgeStatus")]
        public ActionResult<string> CalculateAgeStatus(int age)
        {
            string result = _calculationService.CalculateAgeStatus(age);
            return Ok(result);
        }


        // GET: api/Calculation/SchoolGradeQualification 
        [HttpGet("SchoolGradeQualification ")]
        public ActionResult<string> SchoolGradeQualification(int age)
        {
            string result = _calculationService.SchoolGradeQualification(age);
            return Ok(result);
        }

        // GET: api/Calculation/ListOfNumbersOrdered
        [HttpGet("ListOfNumbersOrdered")]
        public ActionResult<List<int>> ListOfNumbersOrdered([FromQuery] List<int> list)
        {
            List<int> listOrdered =_calculationService.ListOfNumbersOrdered(list);
            return Ok(listOrdered);
        }


        // GET: api/Calculation/ListOfString
        [HttpGet("ListOfString")]
        public ActionResult<List<string>> ListOfString([FromQuery] List<string> strings)
        {
             return Ok(strings);
        }


        // GET: api/Calculation/findSubstring
        [HttpGet("findSubstring")]
        public ActionResult<int?> findSubstring(string substring, string inputString)
        {
            return Ok(_calculationService.findSubstring(substring, inputString));
        }

        // GET: api/Calculation/GetActorById
        [HttpPost("GetActorById")]
        public ActionResult<Actor?> GetActorById(int id, [FromBody] List <Actor> actors)
        {

            Actor? actor =  _calculationService.GetActorById(id, actors);
            if (actor != null) 
            {
                return Ok(actor);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Calculation/GetMinimumYearMovie
        [HttpPost("GetMinimumYearMovie")]
        public ActionResult<int?> GetMinimumYearMovie(List<MovieDto> movies)
        {
            int? minimumYear = _calculationService.GetMinimumYearMovie(movies);

            if (minimumYear != null)
            { 
                return Ok(minimumYear); 
            }
            else 
            { 
                return NotFound(); 
            } 



        }

    }
}

