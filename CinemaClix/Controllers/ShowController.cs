using CinemaClix.Interfaces;
using CinemaClix.Models;
using CinemaClix.Services;
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


        public async  Task<IActionResult> LikedShows()
        {
           var AllShows = await _showService.GetAllLikes();
            return View(AllShows);
        }
        public async Task<IActionResult> WatchListedShows()
        {
            var AllWatchList = await _showService.GetAllShowWatchlist();
            return View(AllWatchList);
        }
        public async  Task<IActionResult> ShowDetails(int id)
        {
            var ShowById = await _showService.GetShowById(id);
            return View(ShowById);  
        }
        [HttpPost("addshowwatchlist")]
        public async Task<IActionResult> AddShowWatchList(WatchListedShow watchListedShow,int id)
        {
            await _showService.AddToWatchlist(watchListedShow, id);

            return RedirectToAction("WatchListedShows", "Show");
        }

        [HttpPost("removeshowatchlist")]

        public async Task<IActionResult> RemoveShowWatchList(string ShowTitle)
        {
            await _showService.RemoveWatchListById(ShowTitle);

            return RedirectToAction("WatchListedShows", "Show");
        }

        [HttpPost("addlikesForShow")]
        public async Task<IActionResult> AddLikesForShow(int id)
        {

            await _showService.LikeShow(id);
            return RedirectToAction("LikedShows", "Show"); 



        }


        [HttpPost("deletelikesForShow")]
        public async Task<IActionResult> DeleteLikesForShow(int ShowId)
        {
           
                await _showService.DeleteLike(ShowId);
                return RedirectToAction("LikedShows", "Show");
         

          
        }
    }
}
