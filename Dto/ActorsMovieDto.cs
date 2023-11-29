namespace MoviesWebApi.Dto
{
    public class ActorsMovieDto
    {
        public string NameActor { get; set; }
        public int MovieId { get; set; }

        public int? ActorId { get; set; }
        public string Character { get; set; }

       
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? DirectorId { get; set; }
        public int? GenderId { get; set; }

       

    }
}
