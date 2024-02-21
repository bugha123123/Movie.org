
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaClix.Controllers
{
    public class HomeController : Controller
    {
     private readonly ISubscriptionService _subscriptionService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ISubscriptionService subscriptionService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _subscriptionService = subscriptionService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var AllSubscriptions = _subscriptionService.GetSubscriptions();
            return View(AllSubscriptions);
        }

        public async Task<IActionResult> Profile()
        {
            int LoggedInUserId;
            var userIdFromCookie =  _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            if (int.TryParse(userIdFromCookie, out LoggedInUserId))
            {

                var UserById = await _userService.GetUserById(LoggedInUserId);
                return View(UserById);
            }
          

            return View(null);
            
           
        }

        [HttpPost("updateuserprofile")]

        public async Task<IActionResult> UpdateProfileCredentials(User user)
        {
           await _userService.UpdateUserProfile(user);

            return RedirectToAction("Index", "Home");
        }

     

       
    }
}
