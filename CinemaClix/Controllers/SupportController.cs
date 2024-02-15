using CinemaClix.Interfaces;
using CinemaClix.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CinemaClix.Controllers
{
    public class SupportController : Controller
    {
        private readonly ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        public IActionResult Supports()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSupportRequest(Support support)
        {
          

            await _supportService.SendSupportEmailAsync(support);

            return RedirectToAction("Index", "Home");
        }
    }
}
