using Microsoft.AspNetCore.Mvc;
using CinemaClix.Models;
using CinemaClix.Interfaces;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using CinemaClix.Services;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace CinemaClix.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly IGmailService _gmailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userservice;
        public ResetPasswordController(IGmailService gmailService, IHttpContextAccessor httpContextAccessor, IUserService userservice)
        {
            _gmailService = gmailService;
            _httpContextAccessor = httpContextAccessor;
            _userservice = userservice;
        }

        public IActionResult SendGmail()
        {
            return View();
        }

    
        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost("sendresetlink")]
        public IActionResult SendResetLink(ResetPassword resetPassword)
        {

            string resetToken = GenerateRandomToken(40);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddSeconds(30),
                SameSite = SameSiteMode.None, 
                Secure = true,
                Path = "/" 
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("ResetPasswordToken", resetToken.ToString(), cookieOptions);

            resetPassword.Body = resetToken;

            _gmailService.SendPasswordResetEmail(resetPassword.Body);


            return RedirectToAction("SendGmail", resetPassword);
        }
        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                await _userservice.UpdateUser(user);

                TempData["SuccessMessage"] = "Password updated successfully.";

              

                return RedirectToAction("Login", "Login");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Gmail Is Incorrect";
           
                return RedirectToAction("UpdatePassword", "ResetPassword");
            }
        }

        private string GenerateRandomToken(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder token = new StringBuilder();

            Random random = new Random();
            
                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(characters.Length);
                    token.Append(characters[index]);
                }
            

            return token.ToString();
        }

        [HttpPost]
        public IActionResult VerifyCode(string verificationCode)
        {
            string correctVerificationCode = _httpContextAccessor.HttpContext.Request.Cookies["ResetPasswordToken"];

            if (verificationCode.Trim() == correctVerificationCode.Trim())
            {
                Response.Cookies.Delete("ResetPasswordToken");

                return RedirectToAction("UpdatePassword", "ResetPassword");
            }
            else
            {
                return RedirectToAction("SendGmail", "ResetPassword");
            }
        }



    }
}
