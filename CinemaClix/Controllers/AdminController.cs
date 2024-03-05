using CinemaClix.Interfaces;
using CinemaClix.Models;
using CinemaClix.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IMovieService _movieService;
        public AdminController(IAdminService adminService, IMovieService movieService)
        {
            this.adminService = adminService;
            _movieService = movieService;
        }

        public IActionResult AdminDashboard([FromQuery] string MovieTitle)
        {
            var MovieSearchResults = _movieService.GetAll(MovieTitle);
            return View(MovieSearchResults);
        }



        [HttpPost("suspenduser")]
        public async Task<IActionResult> SuspendUser(int userid)
        {
            await adminService.SuspendUser(userid);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpPost("giveaccesstouser")]
        public async Task<IActionResult> GiveAccessToUsers(int userid)
        {
            await adminService.GiveAccessToUsers(userid);
            return RedirectToAction("AdminDashboard", "Admin");
        }

        [HttpPost("removesubscriptionforuser")]

        public async Task<IActionResult> AdminRemoveSubscription(string GmailAddress)
        {
            await adminService.RemoveSubscriptionForUser(GmailAddress);
            return RedirectToAction("AdminDashboard", "Admin");
        }



    }
}
