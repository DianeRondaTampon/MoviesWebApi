using Microsoft.EntityFrameworkCore;

namespace MoviesWebApi.Models
{
    public class MovieDto
    {
        //properties
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? DirectorId { get; set; }
        public int? GenderId { get; set; }

        //constructor
        public MovieDto() { 
        }

    }
}
