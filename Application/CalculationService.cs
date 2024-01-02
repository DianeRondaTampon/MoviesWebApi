using Azure;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Identity.Client;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using Newtonsoft.Json.Linq;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing.Printing;

namespace MoviesWebApi.Application
{
   

    public class CalculationService
    {

        private readonly ActorRepository _actorRepository;
        private readonly DirectorRepository _directorRepository;
        private readonly GenderRepository _genderRepository;
        private readonly MovieActorRepository _movieActorRepository;
        private readonly MovieRepository _movieRepository;
        private readonly IConfiguration _configuration;
        private readonly ILog _logger;

        //this is a constructor
        public CalculationService(ActorRepository actorRepository, DirectorRepository directorRepository,
            GenderRepository genderRepository, MovieActorRepository movieActorRepository, MovieRepository movieRepository,
            IConfiguration configuration, ILog logger)
        {
            this._actorRepository = actorRepository;
            this._directorRepository = directorRepository;
            this._genderRepository = genderRepository;
            this._movieActorRepository = movieActorRepository;
            this._movieRepository = movieRepository;
            this._configuration = configuration;
            this._logger = logger;
        }


        //(int i=0; 2<;i++)
        public int sumTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        public int sumOfTheNumberLessThan(int givenNumber)
        {
            int result;
            int sum = 0;
            if (sum == 0)
            {
                result = 0;
            }
            else
            {
                result = 5 / sum;
            }

            for (int i = 1; i < givenNumber; i++)
            {
                sum = sum + i;
            }

            return sum;
        }

        public int factorialOfAGivenNumber(int number)
        {
            int factorial = 1;
            for (int i = 1; i <= number; i++)
                factorial = factorial * i;

            return factorial;
        }

        public string repeatStrings(int number, string text)
        {
            string result = "";
            for (int i = 1; i <= number; i++)
                result = result + text;

            return result;
        }

        public string youCanVote(int age)
        {

            string result = "";

            if (age >= 18)
            {
                result = "You can vote";
            }
            else
            {
                result = "You cannot vote";
            }

            return result;
        }

        public int[,] generateMatrix(int rows, int columns, int content)
        {
            int[,] matrix = new int[rows, columns];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                    matrix[r, c] = content;

            return matrix;
        }



        public int practiceTheVariables()
        {

            int variable;
            int variable1 = 1;
            variable1 = 2;
            variable = 3;


            int tobleron;
            tobleron = variable1; //1


            int juice;
            int juiceOrange = 5;
            juiceOrange = 6;
            juice = 7;

            int paramol;
            paramol = juiceOrange;

            int notebook;
            int cumputernotebook1 = 1;
            cumputernotebook1 = 10;
            cumputernotebook1 = 1;

            int resultAddition = juiceOrange + paramol + tobleron; //14
            int resultSubtraction = juiceOrange - cumputernotebook1;//5
            int resultMultiplication = cumputernotebook1 * variable;//3
            int resultDivision = variable * tobleron;//6

            variable = 10;
            int resultNew;
            resultNew = variable + tobleron; //12

            resultAddition = cumputernotebook1 + juiceOrange + paramol; //13


            return 0;
        }

        public string OpenAnBankAccount(int age, string nationality, string client)
        {

            string result = "";
            string nationalFilipino = "filipino";
            string clientOfTheBank = "yes";
            if (age >= 18 && nationalFilipino == nationality && clientOfTheBank == client)
            {
                result = "You can open your bank account";
            }
            else
            {
                result = "You cannot open a bank account";
            }

            return result;
        }


        public List<DataNumberDto> generateDataNumber(int quantity)
        {
            List<DataNumberDto> result = new List<DataNumberDto>();

            for (int i = 1; i <= quantity; i++)
            {
                string even = "";
                if (i % 2 == 0)
                {
                    even = "even";
                }
                else
                {
                    even = "odd";
                }

                DataNumberDto dataNumberDto = new DataNumberDto();
                //{
                //    Id = i,
                //    //Even = even,
                //    Even = i % 2 == 0 ? "even" : "odd",
                //    Double = i * 2,
                //    Adult = i >= 18,
                //};
                dataNumberDto.Double = i * 2;
                dataNumberDto.Id = i;
                dataNumberDto.Even = even;
                dataNumberDto.Adult = i >= 18;

                result.Add(dataNumberDto);
            }

            return result;
        }





        public Car workWithCar(string color)
        {
            //create an object of the class using a constructor
            Car car = new Car(color);

            car.List.Add(10);

            car.accelerate();
            car.accelerate();
            car.accelerate();

            return car;
        }


        public int? transformHourFromPhilippinesToSpain(int hour)
        {
            int? result = null;
            //validation of Input Data
            if (hour >= 24)
            {
                result = null; ;//input param is wrong, so we return null

            }
            else
            {
                if (hour < 0)
                {
                    result = null;//input param is wrong, so we return null
                }
                else
                {
                    //the input parameter is right
                    int spainHour = hour - 7;

                    if (spainHour < 0)
                    {
                        spainHour = spainHour + 24;
                    }
                    result = spainHour;
                }

            }
            return result;
        }


        public string CalculateAgeStatus(int age)
        {
            string result = "";

            if (age < 0)
            {
                result = "You are invalid age";
            }
            else if (age < 18)
            {
                result = "You are underage";
            }
            else if (age < 65)
            {
                result = "You are an adult";
            }
            else
            {
                result = "You are retired";
            }

            return result;
        }


        public string SchoolGradeQualification(int grade)
        {
            string result = "";

            if (grade < 0 || grade > 100)
            {
                result = "You grade is invalid";
            }
            else if (grade < 60)
            {
                result = "F ";
            }
            else if (grade < 65)
            {
                result = "E";
            }
            else if (grade < 70)
            {
                result = "D";
            }
            else if (grade < 80)
            {
                result = "C";
            }
            else if (grade <= 90)
            {
                result = "B";
            }
            else
            {
                result = "A";
            }
            return result;
        }


        public List<int> ListOfNumbersOrdered(List<int> list)
        {
            //NEED TO STORAGE THE "INDEX" INTO A VARIABLE, for know what part of list is order and what part of the list is unordered
            for (int index = 0; index < list.Count - 1; index++)
            {
                //"UNORDERED LIST" is part of the list starting in INDEX, finish in the end of the list
                //transverse the "UNORDERED list" to find the smallest element
                //insert the smallest element in the INDEX
                //then remove from the position it was


                //find the smallest

                int minimum = int.MaxValue;
                int indexMinimum = 0; //is the position of the minimum in the list

                //transverse the unordered list
                for (int i = index; i < list.Count; i++)
                {
                    //i will compare all the elements of the list with the smallest number to fimd the smallest,
                    //if the elements of the list is smaller, then put that as a new smallest number
                    if (list[i] < minimum)
                    {
                        minimum = list[i];
                        indexMinimum = i;
                    }
                }


                //insert the smallest element in the INDEX Position
                list.Insert(index, minimum);


                //then remove from the position it was
                list.RemoveAt(indexMinimum + 1);

            }


            return list;
        }



        public int? findSubstring(string substring, string inputString)
        {
            // I will compare each possible substring with the provided substring until I found the match or
            // Until it will be finidhed means = NULL/not found
            int? result = null;//not found

            int inputLength = inputString.Length;
            int substringLenght = substring.Length;

            for (int i = 0; i <= inputLength - substringLenght; i++)
            {
                //get the first part of the comparison, from the inputString, for example: "my"
                //the second part of the comparison, substring , "is"

                //check if substring match to the part of inputString
                if (inputString.Substring(i, substringLenght) == substring)
                {

                    //i will return the position because substring is found
                    result = i;

                }
                else
                {
                    //return not found

                }
            }

            //i will return the position i where i found it or null
            return result;

        }

        public Actor? GetActorById(int id, List<Actor> listActors)
        {
            foreach (Actor actor in listActors)
            {
                if (actor.Id == id)
                    return actor;
            }

            return null;
        }

        public int? GetMinimumYearMovie(List<MovieDto> listMovies)
        {
            //I will find the smallest
            int? minimumYearMovie = int.MaxValue;

            foreach (MovieDto movie in listMovies)
            {
                //I will compare all the elements of the list  of Movies so I can to fimd the smallest
                if (movie.Year < minimumYearMovie)
                {
                    minimumYearMovie = movie.Year;

                }
            }

            int? result = minimumYearMovie;

            //if the minimumyears was not found return null 
            if (minimumYearMovie == int.MaxValue)
            {
                // minimum not found 
                result = null;
            }
            return result;
        }

        public int? GetMinimumYearMovieMin(List<MovieDto> listMovies)
        {
            int? minimum = listMovies.Min(movie => movie.Year);
            return minimum;
        }

        public int GetDirectorsQuantity(List<Director> listDirectors)
        {
            int quantity = 0;

            foreach (Director director in listDirectors)
            {
                quantity++;
            }
            return quantity;
        }

        public List<int> GetIntegersDouble(List<int> listIntegers)
        {

            List<int> integersDouble = new List<int>();

            foreach (int integer in listIntegers)
            {
                integersDouble.Add(integer * 2);
            }
            return integersDouble;

        }

        public GetTotalRepositoriesDto GetTotalRepositories()
        {


            int totalActors = _actorRepository.GetAllActor().Count;
            int totalDirectors = _directorRepository.GetAllDirectors().Count;
            int totalGenders = _genderRepository.GetAllGender().Count;
            int totalMovies = _movieRepository.GetAllMovies().ToList().Count;
            int totalMoviesActor = _movieActorRepository.GetAllMovieActors().Count;


            GetTotalRepositoriesDto GetTotalRepositoriesDto = new GetTotalRepositoriesDto()
            {
                TotalActors = totalActors,
                TotalDirectors = totalDirectors,
                TotalGenders = totalGenders,
                TotalMovies = totalMovies,
                TotalMoviesActor = totalMoviesActor

            };
            return GetTotalRepositoriesDto;
        }

        public Car GenerateCars()
        {
            int id = 1;
            string name = "name";
            string brand = "brand";
            decimal speed = 10;
            string color = "yellow";
            Car car = new Car(id, name, brand, speed, color);

            int quantityOfElementsList = car.List.Count;

            Car car2 = new Car(id, name, brand, speed, color);

            Car car3 = new Car(id, name, brand, speed, color);
            foreach (int element in car3.List)
            {
                //do something
            }

            return car;
        }


        public GetValueResponseDto GetValue()
        {

            GetValueResponseDto getValueResponseDto = new GetValueResponseDto()
            {
                MyValue = _configuration.GetValue<string>("MyValue"),
                MyGrades = _configuration.GetValue<decimal>("MyGrades"),
                MyAccess = _configuration.GetValue<bool>("MyAccess"),
                Height = _configuration.GetValue<int>("Destination:Height"),
                Width = _configuration.GetValue<int>("Destination:Width"),
            };
            return getValueResponseDto;
        }

        public bool TestLog()
        {

            // Use the logger
            _logger.Debug("Debug message from service.");
            _logger.Info("Info message from service.");
            _logger.Warn("Warning message from service.");
            _logger.Error("Error message from service.", new Exception("Something went wrong."));
            _logger.Fatal("Fatal message from service.");

   
            return true;
        }







    }
}





       










   

