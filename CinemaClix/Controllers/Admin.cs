using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class Admin : Controller
    {
        private readonly IAdminService adminService;

        public Admin(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }
     



  
    }
}
