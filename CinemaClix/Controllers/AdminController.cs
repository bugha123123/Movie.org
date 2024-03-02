using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult AdminDashboard()
        {
            return View();
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
    }
}
