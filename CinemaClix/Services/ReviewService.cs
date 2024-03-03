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

        public async Task AddReview(Review review)
        {
            // Get the logged-in user ID from the cookie
            var cookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            if (!int.TryParse(cookieUserId, out int loggedInUserId))
            {
                Console.WriteLine("Invalid UserId in the cookie");
                return;
            }

            var loggedInUser = await _userService.GetUserById(loggedInUserId);

            if (loggedInUser == null)
            {
                Console.WriteLine("User Not Found. Check AddReview Service Logic");
                return;
            }

            var foundMovie = _movieservice.GetMovieById(review.Movie.Id);

            if (foundMovie == null)
            {
                Console.WriteLine("Movie Not Found. Check AddReview Service Logic");
                return;
            }

            var newReview = new Review
            {
                AddedBy = loggedInUser.GmailAddress!,
                Description = review.Description,
                Location = review.Location,
                MovieId = foundMovie.Id,
                Name = review.Name,
                Movie = foundMovie,
            };

            try
            {
                // Add the new review to the Reviews DbSet and save changes
                _dbContext.Reviews.Add(newReview);
                await _dbContext.SaveChangesAsync();
                Console.WriteLine("Review successfully added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding review: {ex.Message}");
                throw;
            }
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
