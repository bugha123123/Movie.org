using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDBContext _appDBContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public AdminService(AppDBContext appDBContext, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _appDBContext = appDBContext;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task AddMovie(Movie movie)
        {
            _appDBContext.Movies.Add(movie);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Likes>> GetLikedMovies()
        {
            return await _appDBContext.Likes.ToListAsync();
        }

        public async Task<List<LikedShows>> GetLikedShows()
        {
            return await _appDBContext.LikedShows.ToListAsync();
        }


        public async Task<List<Chat>> GetChatHistory()
        {
            var chat = await _appDBContext.Chat.ToListAsync();
            if (chat != null)
            {
                return chat;
            }

            return new List<Chat>();
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _appDBContext.Movies.ToListAsync();
        }

        public async Task<List<Show>> GetShows()
        {
            return await _appDBContext.Shows.ToListAsync();
        }

        public async Task<List<Subscriptions>> GetSubscriptions()
        {
            return await _appDBContext.Subscriptions.ToListAsync();
        }

        public async Task<List<User>> GetSuspendedUser()
        {
            return await _appDBContext.Users.Where(u => u.Suspended == true).ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _appDBContext.Users
                .Where(user => user.Role != "Admin" && user.Suspended != true)
                .ToListAsync();
        }

        public async Task GiveAccessToUsers(int userId)
        {
            var suspendedUser = await _appDBContext.Users.FirstOrDefaultAsync(u => u.Id == userId && u.Suspended); ;

            if (suspendedUser != null)
            {
                suspendedUser.Suspended = false;


                await _appDBContext.SaveChangesAsync();
            }
        }

        public async Task RemoveSubscriptionForUser(string GmailAddress)
        {
            var SubscriptionToRemoveFor = await _appDBContext.Subscriptions.FirstOrDefaultAsync(u => u.AddedBy == GmailAddress);
            if (SubscriptionToRemoveFor != null)
            {
                _appDBContext.Subscriptions.Remove(SubscriptionToRemoveFor);
                await _appDBContext.SaveChangesAsync();
            }

        }

        public async Task SuspendUser(int userId)
        {
            var userToSuspend = await _appDBContext.Users
                .Where(user => user.Id == userId)
                .FirstOrDefaultAsync();

            if (userToSuspend != null)
            {
                userToSuspend.Suspended = true;
                var SubscriptionToDelete = await _appDBContext.Subscriptions.FirstOrDefaultAsync(s => s.AddedBy == userToSuspend.GmailAddress);
                if (SubscriptionToDelete != null)
                {
                    _appDBContext.Subscriptions.Remove(SubscriptionToDelete);
                    await _appDBContext.SaveChangesAsync();
                }

                await _appDBContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("User not found", nameof(userId));
            }
        }

        public async Task DeleteMessageById(int id)
        {
            var MessageToDelete = await _appDBContext.Chat.FirstOrDefaultAsync(m => m.Id == id);
            if (MessageToDelete != null)
            {
                _appDBContext.Chat.Remove(MessageToDelete);
                await _appDBContext.SaveChangesAsync();
            }

        }

        public async Task AddPrivateChatMessage(PrivateChat chat, int RecId)
        {
            var CookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (!string.IsNullOrEmpty(CookieUserId) && int.TryParse(CookieUserId, out int LoggedInUser))
            {
                var FoundUser = await _userService.GetUserById(LoggedInUser);
                var RecUser = await _userService.GetUserById(RecId);

                if (FoundUser != null && RecUser != null)
                {
                    chat.SenderUserName = FoundUser.UserName!;
                    chat.RecipientUserName = RecUser.UserName!;
                    chat.RecipientId = RecUser.Id;
                    chat.Timestamp = DateTime.UtcNow;
                    chat.IsRead = false;

                    chat.Message = chat.Message;
                    await _appDBContext.privateChats.AddAsync(chat);
                    await _appDBContext.SaveChangesAsync();
                }

            }



        }

        public async Task<List<PrivateChat>> GetPrivateChatHistory(int recipientId)
        {
            var cookieUserId = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (!string.IsNullOrEmpty(cookieUserId) && int.TryParse(cookieUserId, out int loggedInUserId))
            {
                var foundUser = await _userService.GetUserById(loggedInUserId);
                var recipientUser = await _userService.GetUserById(recipientId);

                if (foundUser != null && recipientUser != null)
                {
                    var privateChatHistory = await _appDBContext.privateChats
                        .Where(c =>
                            (c.RecipientId == recipientUser.Id && c.SenderUserName == foundUser.UserName) ||
                            (c.RecipientId == foundUser.Id && c.SenderUserName == recipientUser.UserName))
                        .OrderBy(c => c.Timestamp)
                        .ToListAsync();

                    return privateChatHistory;
                }
            }

            return new List<PrivateChat>();
        }



    }
}
