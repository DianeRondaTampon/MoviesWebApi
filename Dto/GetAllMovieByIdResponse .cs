namespace MoviesWebApi.Dto
{
    public class GetAllMovieByIdResponse
    {
        //properties
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? DirectorId { get; set; }
        public int? GenderId { get; set; }
        public decimal AverageRating { get; set; }



    }
}
