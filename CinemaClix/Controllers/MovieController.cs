using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Movies(string genre)
        {
            var MovieByGenreList = _movieService.GetMoviesByCategory(genre);
            return View(MovieByGenreList);
        }

     public IActionResult WatchFilm(string genre)
        {
            var MovieByGenreList = _movieService.GetMoviesByCategory(genre);
            return View(MovieByGenreList);
        }
    }
}
