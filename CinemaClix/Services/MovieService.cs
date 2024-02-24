using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class MovieService : IMovieService
    {

        private readonly AppDBContext _dbContext;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MovieService(AppDBContext dbContext, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task AddToWatchList(UserWatchList userWatchList)
        {
            try
            {
                var loggedInUser = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

                if (int.TryParse(loggedInUser, out int userId))
                {
                    var foundUser = await _userService.GetUserById(userId);

                    if (foundUser != null)
                    {
                        // Check if the movie is not already in the user's watchlist
                        var existingWatchList = await _dbContext.UserWatchLists
                            .FirstOrDefaultAsync(w => w.UserId == userWatchList.UserId && w.WatchListedMovieId == userWatchList.WatchListedMovieId);

                        if (existingWatchList == null)
                        {
                            // Add the movie to the user's watchlist
                            _dbContext.UserWatchLists.Add(userWatchList);
                            await _dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            // Movie is already in the watchlist
                            // You can handle this case accordingly (e.g., show a message to the user)
                        }
                    }
                    else
                    {
                        // User not found by the provided id
                        // You can handle this case accordingly (e.g., show an error message)
                    }
                }
                else
                {
                    // Unable to parse UserId from the cookie
                    // You can handle this case accordingly (e.g., show an error message)
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log or show an error message)
                Console.WriteLine($"Error adding to watchlist: {ex.Message}");
                throw;
            }
        }

        public Movie GetMovieById(int id)
        {
            Movie Movie =  _dbContext.Movies.FirstOrDefault(x => x.Id == id)!;

            return  Movie;
        }

   

        public List<Movie> GetMovieList()
        {
         return _dbContext.Movies.ToList();
        }

    
        public List<Movie> GetMoviesByCategory(string category)
        {
            return _dbContext.Movies.Where(m => m.Genre == category).ToList();
        }

        public IEnumerable<Movie> GetPopularMoviesByGenre(string genre, int rating)
        {
            var genreMovies = GetMoviesByCategory(genre); 
            var popularMovies = genreMovies.Where(m => m.Rating > rating);

            return popularMovies;
        }

 

    }
}
