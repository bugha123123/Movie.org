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

        public async Task AddToWatchlist(WatchListedMovie watchListedMovie, int id)
        {
         
              
                    var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

                    if (int.TryParse(CookieUserId, out int LoggedInUser))
                    {
                        var FoundUser = await _userService.GetUserById(LoggedInUser);
                        var FoundMovie = GetMovieById(watchListedMovie.id);

                        if (FoundUser != null && FoundMovie != null)
                        {
                            // Rest of your code

                            WatchListedMovie NewWatchlist = new WatchListedMovie()
                            {
                                AddedBy = FoundUser.GmailAddress!,
                                IsWatchListed = true,
                                Movieid = FoundMovie.Id,
                            };

                            await _dbContext.watchListedMovies.AddAsync(NewWatchlist);
                            await _dbContext.SaveChangesAsync();

                        // Redirect to a relevant page after successful submission
                        }
                   
                    }
                
            
        
         
        }



        public Movie GetMovieById(int id)
        {
            Movie movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id)!;

            if (movie == null)
            {
         
                return null;
            }


            return movie;
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

        public Task WatchListMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
