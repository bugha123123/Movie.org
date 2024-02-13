using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Review(int id)
        {
            var Review  = _reviewService.GetReviewById(id);
            return View(Review);
        }

   


        [HttpPost("addreview")]
        public IActionResult AddReview([Bind("Name, Description, Location")] Review review)
        {
          
               
                    _reviewService.AddReview(review);

                    return RedirectToAction("Index", "Home");
              
            

     
        }

    }
}
