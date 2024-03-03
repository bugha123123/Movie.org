using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Interfaces
{
    public interface IReviewService
    {

        Task AddReview( Review review);

        IEnumerable<Review> GetReviews();

       Review GetReviewById(int id);
      
    }
}
