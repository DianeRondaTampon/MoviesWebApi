﻿namespace MoviesWebApi.Dto
{
    public class GetMoviesFromYearDto
    {
        //properties
        public int Id { get; set; }
        public string Title { get; set; }   
        public int? Year  { get; set; }
        public string NameDirector { get; set; }
        public string NameGender { get; set;}
    }
  
}



