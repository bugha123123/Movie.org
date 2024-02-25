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
                var FoundMovie = GetMovieById(id); // Use the parameter 'id' instead of 'watchListedMovie.id'

                if (FoundUser != null && FoundMovie != null)
                {
                   
                    bool isMovieAlreadyWatchlisted = await IsMovieAlreadyWatchlisted(FoundMovie.Id);

                    if (!isMovieAlreadyWatchlisted)
                    {
                        WatchListedMovie NewWatchlist = new WatchListedMovie()
                        {
                            AddedBy = FoundUser.GmailAddress!,
                            MovieTitle = FoundMovie.Title,
                            IsWatchListed = true,
                            Movieid = FoundMovie.Id,
                            Movie = FoundMovie,
                            ReleaseDate = FoundMovie.ReleaseDate,
                            Image = FoundMovie.Image,
                            Director = FoundMovie.Director,
                            AddedByUserName = FoundUser.UserName!
                       
                        };

                        await _dbContext.watchListedMovies.AddAsync(NewWatchlist);
                        await _dbContext.SaveChangesAsync();

                    
                    }
                    else
                    {
                      
                    }
                }
            }
        }

        private async Task<bool> IsMovieAlreadyWatchlisted(int movieId)
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            int.TryParse(CookieUserId, out int UserId);

            var FoundUser = await _userService.GetUserById(UserId);

            return await _dbContext.watchListedMovies
                .AnyAsync(w => w.Movieid == movieId && w.AddedBy == FoundUser.GmailAddress);
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

        public async Task<List<WatchListedMovie>> GetAllWatchlist()
        {

            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            int.TryParse(CookieUserId, out var User);

            var FoundUser = await _userService.GetUserById(User);

            var AllWatchlist = await _dbContext.watchListedMovies.Where(u => u.AddedBy == FoundUser.GmailAddress).ToListAsync();

            return AllWatchlist;
        }
    }
}
