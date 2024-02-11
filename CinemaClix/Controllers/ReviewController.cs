using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Review()
        {
            return View();
        }
    }
}
