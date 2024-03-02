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

        public async Task AddReview(Review review, int movieId)
        {
            var cookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (!int.TryParse(cookieUserId, out int loggedInUser))
            {
                Console.WriteLine("Invalid UserId in the cookie");
                return;
            }

            var foundUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == loggedInUser);

            if (foundUser == null)
            {
                Console.WriteLine("User Not Found. Check AddReview Service Logic");
                return;
            }

            var foundMovie =  _movieservice.GetMovieById(movieId);

            if (foundMovie == null)
            {
                Console.WriteLine("Movie Not Found. Check AddReview Service Logic");
                return;
            }

            var newReview = new Review
            {
                AddedBy = foundUser.GmailAddress!,
                Description = review.Description,
                Location = review.Location,
                MovieId = foundMovie.Id,
                Name = review.Name,
            };

            await _dbContext.Reviews.AddAsync(newReview);
            await _dbContext.SaveChangesAsync();
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
