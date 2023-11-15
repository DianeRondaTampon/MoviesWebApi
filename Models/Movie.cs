using Microsoft.EntityFrameworkCore;

namespace MoviesWebApi.Models
{
    public class Movie
    {
        //properties
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? DirectorId { get; set; }
        public int? GenderId { get; set; }

        //navigation property
        public virtual Director Director { get; set; }



    }
}
