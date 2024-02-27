using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface IShowService
    {

      Task<List<Show>> GetShowByGenre(string Genre);

        Task<Show> GetShowById(int Id);

        List<Show> GetShows();

        Task AddToWatchlist(WatchListedShow watchListedShow, int id);


        Task<List<WatchListedShow>> GetAllShowWatchlist();

        Task RemoveWatchListById(string ShowTitle);


        Task LikeShow(int id);

        Task<List<Likes>> GetAllLikes();

        Task<bool> IsAlreadyLiked(int id);

        Task DeleteLike(int MovieId);
    }
}
