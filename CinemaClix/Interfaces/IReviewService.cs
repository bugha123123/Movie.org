using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Interfaces
{
    public interface IReviewService
    {

        Task AddReview( Review review,int MovieId);

        IEnumerable<Review> GetReviews();

       Review GetReviewById(int id);
      
    }
}
