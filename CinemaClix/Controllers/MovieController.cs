using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using CinemaClix.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReviewService _reviewService;
        private readonly AppDBContext _dbContext;

        public MovieController(IMovieService movieService, IReviewService reviewService, IUserService userService, IHttpContextAccessor httpContextAccessor, AppDBContext dbContext)
        {
            _movieService = movieService;
            _reviewService = reviewService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
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

        public IActionResult Details(int id)
        {
            var MovieByGenreList = _movieService.GetMovieById(id);
            return View(MovieByGenreList);
        }

        public async  Task<IActionResult> WatchList()
        {
            var Watchlist = await _movieService.GetAllWatchlist();
            return View(Watchlist);
        }

        [HttpPost("addwatchlist")]
        public async Task<IActionResult> AddWatchlist( WatchListedMovie watchListedMovie, int id)
        {
            
                await _movieService.AddToWatchlist(watchListedMovie, id);


                return RedirectToAction("Index", "Home");
       
         
                }


    }
}
