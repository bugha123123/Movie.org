using CinemaClix.Interfaces;
using CinemaClix.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;

namespace CinemaClix.Controllers
{
    public class SupportController : Controller
    {
        private readonly ISupportService _supportService;
        private readonly IUserService userService;

        public SupportController(ISupportService supportService, IUserService userService)
        {
            _supportService = supportService;
            this.userService = userService;
        }

        public IActionResult Supports(int id)
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SubmitSupportRequest(Support support)
        {
            if (ModelState.IsValid)
            {
                await _supportService.SendSupportEmailAsync(support);

                TempData["SuccessMessage"] = "Message Sent Successfully";

                return RedirectToAction("Index", "Home");
            }

            return View("Supports", support);
        }

    }
}
