using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Interfaces
{
    public interface IReviewService
    {


        IEnumerable<Review> GetReviews();

       Review GetReviewById(int id);
      
    }
}
