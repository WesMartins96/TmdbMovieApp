using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TmdbMovieApp.Models;

namespace TmdbMovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly TmdbService _tmdbService;

        public MoviesController(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet]
        [EnableCors("AllowSpecificOrigins")]
        public async Task<IActionResult> Index()
        {
            var movies = await _tmdbService.GetPopularMoviesAsync();
            return View(movies);
        }
    }
}
