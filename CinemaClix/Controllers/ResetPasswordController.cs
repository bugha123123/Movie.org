using Microsoft.AspNetCore.Mvc;
using CinemaClix.Models;
using CinemaClix.Interfaces;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace CinemaClix.Controllers
{
    public class ResetPasswordController : Controller
    {
        private readonly IGmailService _gmailService;

        public ResetPasswordController(IGmailService gmailService)
        {
            _gmailService = gmailService;
        }

        public IActionResult SendGmail()
        {
            return View();
        }

        [HttpPost("sendresetlink")]
        public IActionResult SendResetLink(ResetPassword resetPassword)
        {
       
            string resetToken = GenerateResetToken();



            resetPassword.Body = $"Click the following link to reset your password: https://localhost:7206/ResetPassword/UpdatePassword";

            _gmailService.SendPasswordResetEmail(resetPassword.Body);

            return RedirectToAction("Index", "Home");
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
