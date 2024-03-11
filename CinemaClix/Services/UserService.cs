using Azure;
using System.Drawing;
using System.Drawing.Imaging;

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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using SixLabors.ImageSharp.PixelFormats;

namespace CinemaClix.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(AppDBContext dbContext, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
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
                return null;
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
        public async Task UpdateUserProfile(User user, IFormFile profileImage)
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies["UserId"] is string userIdString && int.TryParse(userIdString, out int loggedInUserId))
            {
                var userToUpdate = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == loggedInUserId);

                if (userToUpdate != null)
                {
                    userToUpdate.UserName = user.UserName;
                    userToUpdate.GmailAddress = user.GmailAddress;

                    if (profileImage != null && profileImage.Length > 0)
                    {
                       
                        string uniqueFileName = ProcessUploadedFile(profileImage);

                        userToUpdate.ProfileImageFileName = uniqueFileName;
                    }

                    _dbContext.Users.Update(userToUpdate);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private string ProcessUploadedFile(IFormFile profileImage)
        {
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ProfileImage");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var image = System.Drawing.Image.FromStream(profileImage.OpenReadStream()))
            {
                // Resize the image if needed (adjust dimensions accordingly)
                var resizedImage = ResizeImage(image, 200, 200);

                // Save the resized image to the file system
                resizedImage.Save(filePath, ImageFormat.Png);
            }

            return uniqueFileName;
        }

        private System.Drawing.Image ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }





    }
}
