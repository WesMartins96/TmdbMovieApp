using Newtonsoft.Json;

namespace TmdbMovieApp.Models
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "6a13cca23b6aff72941441ed6aab2481";

        public TmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetPopularMoviesAsync()
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}&language=pt-BR");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var tmdbResponse = JsonConvert.DeserializeObject<TmdbResponse>(content);

            return tmdbResponse.Results;
        }

        public async Task<TmdbResponse> GetAllMoviesAsync(int page)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/top_rated?api_key={_apiKey}&language=pt-BR&page={page}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<TmdbResponse>(content);
            return movies;
        }
    }

    public class TmdbResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("results")]
        public List<Movie> Results { get; set; }
    }
}
