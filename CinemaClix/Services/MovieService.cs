using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class MovieService : IMovieService
    {

        private readonly AppDBContext _dbContext;

        public MovieService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie GetMovieById(int id)
        {
            Movie Movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id)!;

            return Movie;
        }

        public List<Movie> GetMovieList()
        {
         return _dbContext.Movies.ToList();
        }
        public List<Movie> GetMoviesByCategory(string category)
        {
            return _dbContext.Movies.Where(m => m.Genre == category).ToList();
        }
  
    }
}
