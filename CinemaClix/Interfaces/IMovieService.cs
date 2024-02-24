using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface IMovieService
    {

        List<Movie> GetMovieList();
        List<Movie> GetMoviesByCategory(string category);
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetPopularMoviesByGenre(string genre, int rating);

        Task AddToWatchList(UserWatchList userWatchList);

    }
}
