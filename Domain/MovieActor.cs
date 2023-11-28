namespace MoviesWebApi.Models
{
    public class MovieActor
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
       
        public int? ActorId { get; set; }
        public string Character { get; set; }

       
    }
}
