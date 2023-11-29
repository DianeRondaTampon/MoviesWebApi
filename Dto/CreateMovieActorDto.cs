namespace MoviesWebApi.Dto
{
    public class CreateMovieActorDto
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public int Id { get; set; }

        public string Character { get; set; }
    }
}
