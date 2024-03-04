using CinemaClix.ApplicationDBContext;
using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface IAdminService
    {

        Task<List<Movie>> GetMovies();

        Task<List<Show>> GetShows();

        Task<List<User>> GetUsers();

        Task<List<LikedShows>> GetLikedShows();
        Task<List<Likes>> GetLikedMovies();
        Task<List<Subscriptions>> GetSubscriptions();

        Task<List<User>> GetSuspendedUser();

        Task GiveAccessToUsers(int userId);
        Task SuspendUser(int userId);
        Task AddMovie(Movie movie); 

        Task RemoveSubscriptionForUser(string GmailAddress);


        Task<List<Chat>> GetChatHistory();

        Task DeleteMessageById(int id);

        
         
    }
}
