using Azure;
using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks;
using BCrypt.Net;

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
                if (await _dbContext.Users.AnyAsync(u => u.GmailAddress == user.GmailAddress))
                {
                    throw new InvalidOperationException("A user with this Gmail address already exists.");
                }

                var userToAdd = new User
                {
                    UserName = user.UserName,
                    GmailAddress = user.GmailAddress,
                    Password = HashPassword(user.Password),
                    Role = "Member"
                };

                _dbContext.Users.Add(userToAdd);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during user creation: {ex.Message}");
                throw;
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                User? userToDelete = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (userToDelete == null)
                {
                    throw new Exception("User not found");
                }

                _dbContext.Users.Remove(userToDelete);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Exception during user deletion: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var userToFind = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

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
                User? userToUpdate = await _dbContext.Users.FirstOrDefaultAsync(x => x.GmailAddress == user.GmailAddress);
                if (user == null)
                {
                    throw new  Exception("User not found");
                }


                if (userToUpdate == null)
                {
                    throw new Exception("User not found");
                }


                userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<User?> AuthLogin(User userInput)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.GmailAddress == userInput.GmailAddress);

                if (user != null && VerifyPassword(userInput.Password, user.Password))
                {
                    if (user.Suspended)
                    {
                        return null; 
                    }

                    return user; 
                }

                return null; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during login: {ex.Message}");
                return null;
            }
        }

        // Verify the password using BCrypt.Net
        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }


        public async Task Logout()
        {
            try
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(-1),
                    Path = "/", 
                    SameSite = SameSiteMode.None, 
                    Secure = true 
                };
              
                       _httpContextAccessor.HttpContext.Response.Cookies.Append("IsAdmin", "", cookieOptions);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", "", cookieOptions);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("ResetPasswordToken", "", cookieOptions);

                _httpContextAccessor.HttpContext.Response.Cookies.Append("UserId", "", cookieOptions);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("UserName", "", cookieOptions);

                Console.WriteLine("Logout successful");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Exception during logout: {ex.Message}");
            }
        }

        public async Task UpdateUserProfile(User user)
        {
           
            if (_httpContextAccessor.HttpContext.Request.Cookies["UserId"] is string userIdString && int.TryParse(userIdString, out int LoggedInUser))
            {
             
                var UserToUpdate = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == LoggedInUser);

                if (UserToUpdate != null)
                {

                    UserToUpdate.UserName = user.UserName;
                    UserToUpdate.Password = user.Password; 
                    UserToUpdate.GmailAddress = user.GmailAddress;

                    
                    _dbContext.Users.Update(UserToUpdate);
                    await _dbContext.SaveChangesAsync();
                }
            }
         
        }

    
    }
}
