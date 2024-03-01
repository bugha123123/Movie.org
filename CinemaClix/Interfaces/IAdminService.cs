using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface IAdminService
    {

        Task<List<Movie>> GetMovies();

        Task<List<Show>> GetShows();

        Task<List<User>> GetUsers();

        Task<List<LikedShows>> GetLikedShows();
    }
}
