using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            try
            {
                // Check if a user with the same Gmail address already exists
                if (await _dbContext.Users.AnyAsync(u => u.GmailAddress == user.GmailAddress))
                {
                    throw new InvalidOperationException("A user with this Gmail address already exists.");
                }

                // Note: Avoid storing passwords in plain text for security reasons
                var userToAdd = new User
                {
                    UserName = user.UserName,
                    GmailAddress = user.GmailAddress,
                    Password = user.Password,  // Store the password as is (plain text)
                    Reviews = user.Reviews  // Associate reviews with the user
                };

                _dbContext.Users.Add(userToAdd);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception during user creation: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                User? userToDelete = await _dbContext.Users.Include(u => u.Subscriptions).FirstOrDefaultAsync(x => x.Id == id);

                if (userToDelete == null)
                {
                    throw new Exception("User not found");
                }

                _dbContext.Users.Remove(userToDelete);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception during user deletion: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.Include(u => u.Subscriptions).ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            User? userToFind = await _dbContext.Users.Include(u => u.Subscriptions).FirstOrDefaultAsync(x => x.Id == id);

            if (userToFind == null)
            {
                throw new Exception("User not found");
            }

            return userToFind;
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                User? userToUpdate = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

                if (userToUpdate == null)
                {
                    throw new Exception("User not found");
                }

                userToUpdate.GmailAddress = user.GmailAddress;
                userToUpdate.Password = user.Password;
                userToUpdate.UserName = user.UserName;

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception during user update: {ex.Message}");
                throw;
            }
        }

        public async Task<User?> AuthLogin(User userInput)
        {
            try
            {
                // Find the user with the entered Gmail address
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.GmailAddress == userInput.GmailAddress);

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
