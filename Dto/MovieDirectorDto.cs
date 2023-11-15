namespace MoviesWebApi.Dto
{
    //for the endpoint getMoviesFromDirector 
    public class MovieDirectorDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? DirectorId { get; set; }
        public int? GenderId { get; set; }


        //public int DirectorId { get; set; }  
        public string DirectorName { get; set; }
                


    }
}
