using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IReviewService _reviewService;

        public MovieController(IMovieService movieService, IReviewService reviewService)
        {
            _movieService = movieService;
            _reviewService = reviewService;
        }

        public IActionResult Movies(string genre)
        {
            var MovieByGenreList = _movieService.GetMoviesByCategory(genre);

         

            return View(MovieByGenreList);
        }
        public IActionResult PopularMovies(string genre)
        {
            var popularMovies = _movieService.GetPopularMoviesByGenre(genre, rating: 3);

            return View(popularMovies);
        }

        [HttpPost("watchlist")]
        public async Task<IActionResult> WatchList(UserWatchList userWatchList)
        {
            await _movieService.AddToWatchList(userWatchList);
            return View("Details",userWatchList);
        }

        public IActionResult Details(int id)
        {
            var MovieByGenreList = _movieService.GetMovieById(id);
            return View(MovieByGenreList);
        }
    }
}
