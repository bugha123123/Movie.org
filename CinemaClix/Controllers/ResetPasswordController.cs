using Microsoft.AspNetCore.Mvc;
using CinemaClix.Models;
using CinemaClix.Interfaces;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using CinemaClix.Services;

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

        public IActionResult CheckVerification()
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
       
            string resetToken = GenerateResetToken();

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(1),
                SameSite = SameSiteMode.None, 
                Secure = true,
                Path = "/" 
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("ResetPasswordToken", resetToken.ToString(), cookieOptions);

            resetPassword.Body = $"{resetToken}";

            _gmailService.SendPasswordResetEmail(resetPassword.Body);

            return RedirectToAction("CheckVerification", "ResetPassword");
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



        [HttpPost]
        public IActionResult VerifyCode(string verificationCode)
        {

            string correctVerificationCode = _httpContextAccessor.HttpContext.Request.Cookies["ResetPasswordToken"];

            if (verificationCode.Trim() == correctVerificationCode.Trim())
            {
             
                return RedirectToAction("UpdatePassword", "ResetPassword"); 
            }
            else
            {
                return RedirectToAction("SendGmail", "ResetPassword");
            }
        }


        private static string GenerateResetToken()
        {
            const int tokenLength = 32;

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] tokenBytes = new byte[tokenLength];
                rng.GetBytes(tokenBytes);

                return BitConverter.ToString(tokenBytes).Replace("-", string.Empty);
            }
        }
    }
}
