using CinemaClix.Models;

namespace CinemaClix.Interfaces
{
    public interface IMovieService
    {

        List<Movie> GetMovieList();
        List<Movie> GetMoviesByCategory(string category);
        Movie GetMovieById(int id);

        
    }
}
