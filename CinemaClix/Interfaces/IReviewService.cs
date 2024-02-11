using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface IReviewService
    {

        void AddReview(Review review);

        IEnumerable<Review> GetReviews();
    }
}
