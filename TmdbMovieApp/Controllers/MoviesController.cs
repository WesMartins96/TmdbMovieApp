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
        public async Task<IActionResult> Index(int page = 1)
        {
            var movies = await _tmdbService.GetAllMoviesAsync(page);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = movies.TotalPages;
            return View(movies.Results);
        }
    }
}
