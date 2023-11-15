using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MoviesWebApi.Dto;
using MoviesWebApi.Models;
using MoviesWebApi.Repositories;
using NuGet.Packaging.Signing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;

namespace MoviesWebApi.Application
{
    public class CalculationService
    {
        //(int i=0; 2<;i++)
        public int sumTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        public int sumOfTheNumberLessThan(int givenNumber)
        {
            int sum = 0;
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
            string nationalFilipino= "filipino";
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
            List<DataNumberDto> dataNumberDtoList = new List<DataNumberDto>();

            for (int i = 1; i <= quantity; i++)
            {
                string even = "";
                if(i % 2 == 0)
                {
                    even = "even";
                }
                else
                {
                    even = "odd";
                }
                DataNumberDto dataNumberDto = new DataNumberDto()
                {
                    Id = i,
                    Even = even,
                    Double = i * 2,
                    Adult = i >= 18,

                };


                dataNumberDtoList.Add(dataNumberDto);
            }




            //dataNumberDto = new DataNumberDto()
            

            //List<Object> objects =.Where(c => c.Quantity != null && c. == quantity).ToList();

            //string result = "";
            //string nationalFilipino = "filipino";
            //string clientOfTheBank = "yes";
            //if (age >= 18 && nationalFilipino == nationality && clientOfTheBank == client)
            //{
            

            return dataNumberDtoList;
        }


      













    }
}
