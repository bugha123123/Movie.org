using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface IShowService
    {

      Task<List<Show>> GetShowByGenre(string Genre);

        Task<Show> GetShowById(int Id);
    }
}
