﻿using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Tls;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CinemaClix.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IGmailService _gmailService;
        public LoginController(IUserService userService, IHttpContextAccessor httpContextAccessor, IGmailService gmailService)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _gmailService = gmailService;
        }

        public IActionResult Login()
        {
            return View();
        }
     
        // LoginController.cs
        [HttpPost("authlogin")]
        public async Task<IActionResult> AuthLogin([Bind("GmailAddress, Password")] User userInput)
        {
            try
            {
                var user = await _userService.AuthLogin(userInput);
             
                if (user != null)
                {

                    var token = GenerateToken(user);


                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddHours(1),
                        SameSite = SameSiteMode.None, // Adjust this based on your security requirements
                        Secure = true, // Set to true if your site uses HTTPS
                        Path = "/" // Set the path to "/" for broader accessibility
                    };

                    _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", token, cookieOptions);

             
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid email or password";
                    return View("Login", userInput);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during login: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred during login.";
                return View();
            }
        }
        public IActionResult LogOut()
        {
            _userService.Logout();

            // Redirect to the home page after logout
            return RedirectToAction("Index", "Home");
        }


        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName)
    };

            var secretKey = Encoding.UTF8.GetBytes("YourSecretKeyHere");

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);

         
            var token = new JwtSecurityToken(
                issuer: "Cinema",          
                audience: "CinemaClix",     
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),  
                signingCredentials: signingCredentials
            );

            // Serialize the token to a string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }



    }
}
