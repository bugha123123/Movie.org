using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDBContext _dbContext;

        public ReviewService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddReview(Review review)
        {



         await   _dbContext.Reviews.AddAsync(review);
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
