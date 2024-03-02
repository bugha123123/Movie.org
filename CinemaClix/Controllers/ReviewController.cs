using CinemaClix.Interfaces;
using CinemaClix.Models;
using CinemaClix.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IMovieService _movieservice;
        public ReviewController(IReviewService reviewService, IMovieService movieservice)
        {
            _reviewService = reviewService;
            _movieservice = movieservice;
        }

        public IActionResult Review(int id)
        {
            var Movie = _movieservice.GetMovieById(id);  
            

            return View(Movie);
        }


        [HttpPost("addreview")]
        public IActionResult AddReviewForUser([Bind("Name, Description, Location")] Review review, int MovieId)
        {
            try
            {
                _reviewService.AddReview(review, MovieId);
                return RedirectToAction("Review", "Review");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddReviewForUser action: {ex.Message}");

                TempData["ErrorMessage"] = "Failed to add the review. Please try again.";

                return RedirectToAction("Index", "Home");
            }
        }


    }
}
