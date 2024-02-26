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
                var FoundMovie = GetMovieById(id);

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
        public async Task RemoveWatchListById(string MovieTitle)
        {
            try
            {
                var WatchListToDelete = await _dbContext.watchListedMovies.FirstOrDefaultAsync(w => w.MovieTitle == MovieTitle);

                if (WatchListToDelete != null)
                {
                    _dbContext.watchListedMovies.Remove(WatchListToDelete);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing movie from watchlist: {ex.Message}");
            }
        }

        public async Task LikeMovie(int id)
        {
            var loggedInUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(loggedInUserId, out int userId))
            {
                var foundUser = await _userService.GetUserById(userId);
                var foundMovie = GetMovieById(id);

                if (foundUser != null && foundMovie != null)
                {
                    bool isAlreadyLiked = await IsAlreadyLiked(id);

                    if (!isAlreadyLiked)
                    {
                        Likes newLike = new Likes()
                        {
                            MovieId = foundMovie.Id,
                            UserId = foundUser.Id,
                            MovieImage = foundMovie.Image,
                            MovieTitle = foundMovie.Title,
                        };

                        await _dbContext.Likes.AddAsync(newLike);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }



        public async Task<List<Likes>> GetAllLikes()
        {
            var userId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            int.TryParse(userId, out int user);

            var foundUser = await _userService.GetUserById(user);

            if (foundUser != null)
            {
                var allLikes = await _dbContext.Likes
                    .Where(u => u.UserId == foundUser.Id)
                    .ToListAsync();

                return allLikes;
            }

            return new List<Likes> { };
        }

        public async Task<bool> IsAlreadyLiked(int id)
        {
            var userId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(userId, out int user))
            {
                var foundUser = await _userService.GetUserById(user);
                var FoundMovie = GetMovieById(id);

                if (foundUser != null && FoundMovie != null)
                {
                    var existingLike = await _dbContext.Likes
                        .FirstOrDefaultAsync(l => l.UserId == foundUser.Id && l.MovieId == FoundMovie.Id);

                    return existingLike != null;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }


        public async Task DeleteLike(int MovieId)
        {
            var LikedMovieToDelete = await _dbContext.Likes.FirstOrDefaultAsync(m => m.MovieId == MovieId);

            if (LikedMovieToDelete != null)
            {
                 _dbContext.Likes.Remove(LikedMovieToDelete);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

  
