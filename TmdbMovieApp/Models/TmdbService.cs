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
    }

    public class TmdbResponse
    {
        public List<Movie> Results { get; set; }
    }
}
