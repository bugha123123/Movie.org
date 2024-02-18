using CinemaClix.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class ShowController : Controller
    {

        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        public async  Task<IActionResult> Shows(string genre)
        {
            var ShowsByGenre = await _showService.GetShowByGenre(genre);
            return View(ShowsByGenre);
        }
    }
}
