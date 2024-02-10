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
