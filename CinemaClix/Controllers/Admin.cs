using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class Admin : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
