using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class ShowService : IShowService

    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDBContext _dbContext;

        public ShowService(AppDBContext dbContext, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task AddToWatchlist(WatchListedShow watchListedShow, int id)
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(CookieUserId, out int LoggedInUser))
            {
                var FoundUser = await _userService.GetUserById(LoggedInUser);
                var FoundShow = await GetShowById(id);

                if (FoundUser != null && FoundShow != null)
                {

                    bool isMovieAlreadyWatchlisted = await IsShowAlreadyWatchlisted(FoundShow.Id);

                    if (!isMovieAlreadyWatchlisted)
                    {
                        WatchListedShow NewWatchlist = new WatchListedShow()
                        {
                            AddedBy = FoundUser.GmailAddress!,
                            ShowTitle = FoundShow.ShowName,
                            IsWatchListed = true,
                            ShowId = FoundShow.Id,
                            Show = FoundShow,
                            ReleaseDate = FoundShow.ReleaseDate,
                            Image = FoundShow.PosterImage,
                            Director = FoundShow.Director,
                            AddedByUserName = FoundUser.UserName!

                        };

                        await _dbContext.watchListedShows.AddAsync(NewWatchlist);
                        await _dbContext.SaveChangesAsync();


                    }
                    else
                    {

                    }
                }
            }
        }


        private async Task<bool> IsShowAlreadyWatchlisted(int ShowId)
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];
            int.TryParse(CookieUserId, out int UserId);

            var FoundUser = await _userService.GetUserById(UserId);

            return await _dbContext.watchListedShows
                .AnyAsync(w => w.ShowId == ShowId && w.AddedBy == FoundUser.GmailAddress);
        }
        public async Task<List<Show>> GetShowByGenre(string Genre)
        {
     var Shows =    await   _dbContext.Shows.Where(i => i.Genre == Genre).ToListAsync();

            return Shows;
        }

        public async Task<Show> GetShowById(int Id)
        {
           var FoundShowById = await _dbContext.Shows.FirstOrDefaultAsync(i => i.Id == Id);

            if (FoundShowById == null)
            {
                throw new Exception("User By that Id Not found GO TO (GETSHOWSBYID())");
            }

            return FoundShowById;
        }


        public  List<Show> GetShows()
        {
         

            return _dbContext.Shows.ToList();
        }

        public async Task<List<WatchListedShow>> GetAllShowWatchlist()
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            int.TryParse(CookieUserId, out var User);

            var FoundUser = await _userService.GetUserById(User);

            var AllWatchlist = await _dbContext.watchListedShows.Where(u => u.AddedBy == FoundUser.GmailAddress).ToListAsync();

            return AllWatchlist;
        }

        public async Task RemoveWatchListById(string ShowTitle)
        {
            try
            {
                var WatchListToDelete = await _dbContext.watchListedShows.FirstOrDefaultAsync(w => w.ShowTitle == ShowTitle);

                if (WatchListToDelete != null)
                {
                    _dbContext.watchListedShows.Remove(WatchListToDelete);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing Show from watchlist: {ex.Message}");
            }
        }

        public async Task LikeShow(int id)
        {
            var loggedInUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(loggedInUserId, out int userId))
            {
                var foundUser = await _userService.GetUserById(userId);
                var foundShow = await GetShowById(id);

                if (foundUser != null && foundShow != null)
                {
                    bool isAlreadyLiked = await IsAlreadyLiked(id);

                    if (!isAlreadyLiked)
                    {
                        LikedShows newLike = new LikedShows()
                        {
                            ShowId = foundShow.Id,
                            UserId = foundUser.Id!,
                            ShowImage = foundShow.PosterImage,
                            ShowTitle = foundShow.ShowName,
                        };

                        await _dbContext.LikedShows.AddAsync(newLike);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task<List<LikedShows>> GetAllLikes()
        {
            var userId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            int.TryParse(userId, out int user);

            var foundUser = await _userService.GetUserById(user);

            if (foundUser != null)
            {
                var allLikes = await _dbContext.LikedShows
                    .Where(u => u.UserId == foundUser.Id)
                    .ToListAsync();

                return allLikes;
            }

            return new List<LikedShows> { };
        }

        public async Task<bool> IsAlreadyLiked(int id)
        {
            var userId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(userId, out int user))
            {
                var foundUser = await _userService.GetUserById(user);
                var FoundShow = await GetShowById(id);

                if (foundUser != null && FoundShow != null)
                {
                    var existingLike = await _dbContext.LikedShows
                        .FirstOrDefaultAsync(l => l.UserId == foundUser.Id && l.ShowId == FoundShow.Id);

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
            var LikedShowToDelete = await _dbContext.LikedShows.FirstOrDefaultAsync(m => m.ShowId == MovieId);

            if (LikedShowToDelete != null)
            {
                _dbContext.LikedShows.Remove(LikedShowToDelete);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
