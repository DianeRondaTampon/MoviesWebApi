﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Application;
using MoviesWebApi.Models;
using Newtonsoft.Json;

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
            string result = _calculationService.repeatStrings(number,text);

            return Ok(result);
        }

      

        // GET: api/Calculation/sumTwoNumbers
        [HttpGet("sumTwoNumbers")]
        public  ActionResult<int> sumTwoNumbers(int number1, int number2) 
        {
            int total =_calculationService.sumTwoNumbers(number1,number2);               

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
            string result=_calculationService.youCanVote(age);
            return Ok(result);
        }

        // GET: api/Calculation/OpenAnBankAccount
        [HttpGet("OpenAnBankAccount")]
        public ActionResult<string> OpenAnBankAccount(int age, string nationality,string client)
        {
            string result = _calculationService.OpenAnBankAccount(age,nationality,client);
            return Ok(result);
        }
    }
}