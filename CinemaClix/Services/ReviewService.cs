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

        public async Task AddReview(Review review, int MovieId)
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(CookieUserId, out int LoggedInUser))
            {
                var FoundUser = await _userService.GetUserById(LoggedInUser);
                var FoundMovie = _movieservice.GetMovieById(MovieId);

                if (FoundUser != null && FoundMovie != null)
                {
                    Review NewReview = new Review()
                    {
                        AddedBy = FoundUser.GmailAddress!,
                        Description = review.Description,
                        Location = review.Location,
                        MovieId = FoundMovie.Id,
                        Name = review.Name,
                    };

                    await _dbContext.Reviews.AddAsync(NewReview);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("User or Movie Not Found. Check AddReview Service Logic");
                }
            }
            else
            {
                Console.WriteLine("Invalid UserId in the cookie");
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
