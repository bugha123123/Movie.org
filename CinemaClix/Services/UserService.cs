using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaClix.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(AppDBContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddNewUser(User user)
        {
            // Check if a user with the same Gmail address already exists
            if (await _dbContext.Users.AnyAsync(u => u.GmailAddress == user.GmailAddress))
            {
                throw new InvalidOperationException("A user with this Gmail address already exists.");
            }

            // Note: Avoid storing passwords in plain text for security reasons
            var UserToAdd = new User
            {
                UserName = user.UserName,
                GmailAddress = user.GmailAddress,
                Password = user.Password  // Store the password as is (plain text)
            };

            await _dbContext.Users.AddAsync(UserToAdd);
            await _dbContext.SaveChangesAsync();
        }



        public async Task AddSubscriptionToUser(int userId, Subscriptions subscription)
        {
            var user = await _dbContext.Users.Include(u => u.Subscriptions).FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.Subscriptions ??= new List<Subscriptions>();
                user.Subscriptions.Add(subscription);

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"User with Id {userId} not found.");
            }
        }

        public async Task DeleteUser(int id)
        {
            User? UserToDelete = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id)!;
            if (UserToDelete == null)
            {
                throw new Exception("User Not found");
            }
            _dbContext.Users.Remove(UserToDelete);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            User? UserToFind = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id)!;
            if (UserToFind == null)
            {
                throw new Exception("User Not found");
            }
            return UserToFind;
        }


        public async Task UpdateUser(User user)
        {
            User? userToUpdate = await _dbContext.Users.Include(u => u.Subscriptions).FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userToUpdate == null)
            {
                throw new Exception("User Not found");
            }

            userToUpdate.GmailAddress = user.GmailAddress;
            userToUpdate.Password = user.Password;
            userToUpdate.UserName = user.UserName;

        

            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> AuthLogin(User userInput)
        {
            try
            {
                // Retrieve all users from the database
                var allUsers = await _dbContext.Users.ToListAsync();

                // Find the user with the entered Gmail address
                var user = allUsers.FirstOrDefault(u => u.GmailAddress == userInput.GmailAddress);

                if (user != null && user.Password == userInput.Password)
                {
                    // Login successful
                    return user;
                }

                // Login failed
                return null;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception during login: {ex.Message}");
                return null;
            }
        }



        public async Task Logout()
        {
            try
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(-1), // Expire the cookie
                    Path = "/", // Make sure the path is consistent with login
                    SameSite = SameSiteMode.None, // Adjust based on your security requirements
                    Secure = true // Set to true if your site uses HTTPS
                };

                _httpContextAccessor.HttpContext.Response.Cookies.Append("UserId", "", cookieOptions);

                // Log success or any additional information
                Console.WriteLine("Logout successful");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception during logout: {ex.Message}");
            }
        }
    }
}
