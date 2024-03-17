using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDBContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IMovieService _movieservice;
        public ReviewService(AppDBContext dbContext, IHttpContextAccessor httpContextAccessor, IUserService userService, IMovieService movieservice)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _movieservice = movieservice;
        }


     




        public Review GetReviewById(int id)
        {
           Review review = _dbContext.Reviews.FirstOrDefault(review => review.Id == id)!;

            return review;
        }

        public IEnumerable<Review> GetReviews()
        {
          return _dbContext.Reviews.ToList();
        }
    }
}
