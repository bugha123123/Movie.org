using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class ShowController : Controller
    {
        public IActionResult Shows()
        {
            return View();
        }
    }
}
