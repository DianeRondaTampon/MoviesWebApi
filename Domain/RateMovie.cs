namespace MoviesWebApi.Models
{
    public class RateMovie
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rate { get; set; }

    }
}
