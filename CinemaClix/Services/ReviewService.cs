using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;

namespace CinemaClix.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDBContext _dbContext;

        public ReviewService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddReview(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Review> GetReviews()
        {
          return _dbContext.Reviews.ToList();
        }
    }
}
