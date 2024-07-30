namespace TmdbMovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
    }
}
