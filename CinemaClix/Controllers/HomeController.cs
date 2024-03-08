
using CinemaClix.ApplicationDBContext;
using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CinemaClix.Controllers
{
    public class HomeController : Controller
    {
     private readonly ISubscriptionService _subscriptionService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMovieService _movieService;
        private readonly AppDBContext _appDBContext;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IAdminService adminService;
        public HomeController(ISubscriptionService subscriptionService, IUserService userService, IHttpContextAccessor httpContextAccessor, IMovieService movieService, IHubContext<NotificationHub> hubContext, AppDBContext appDBContext, IAdminService adminService)
        {
            _subscriptionService = subscriptionService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _movieService = movieService;
            _hubContext = hubContext;
            _appDBContext = appDBContext;
            this.adminService = adminService;
        }

        public   IActionResult Index()
        {
       
            return View();
        }
        public async Task<IActionResult> PrivateChat(int UserId)
        {
            var recipientUser = await _userService.GetUserById(UserId);

            if (recipientUser == null)
            {
                return NotFound();
            }

            var recipientUserName = recipientUser.UserName;

            var viewModel = new PrivateChat
            {
                RecipientId = UserId,
                RecipientUserName = recipientUserName
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Chat()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> UpdateProfileCredentials([Bind("UserName,Password,GmailAddress")] User updateUserViewModel, IFormFile profileImage)
        {
            await _userService.UpdateUserProfile(updateUserViewModel, profileImage);
            return RedirectToAction("Profile", "Home");
        }


        [HttpPost("sendmessage")]
        public async Task<IActionResult> SendMessage(Chat chat)
        {

            var LoggedInUser = _httpContextAccessor.HttpContext.Request.Cookies["UserId"];

            int.TryParse(LoggedInUser, out int User);

            var FoundUser =  await _userService.GetUserById(User);

            if (FoundUser.Suspended)
            {
                ViewData["Suspended"] = "You have been suspended, Contact Support for assistance";
            }

            var chatMessage = new Chat { Sender = FoundUser.UserName, Message = chat.Message, SenderId = FoundUser.Id, SenderRole = FoundUser.Role };
            _appDBContext.Chat.Add(chatMessage);
            await _appDBContext.SaveChangesAsync();

            
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", FoundUser, chat.Message);

            return RedirectToAction("Chat", "Home"); 
        }



        [HttpPost("deletemessage")]

        public async Task<IActionResult> DeleteMessageById(int id)
        {
            await adminService.DeleteMessageById(id);
            return RedirectToAction("Chat", "Home");
        }

        [HttpPost("sendprivatemessage")]
        public async Task<IActionResult> SendPrivateMessage(PrivateChat chat, int RecId)
        {
            var recipientUser = await _userService.GetUserById(RecId);

            if (recipientUser == null)
            {
                TempData["ErrorMessage"] = "Recipient user not found.";
                return RedirectToAction("PrivateChat", "Home");
            }

            await adminService.AddPrivateChatMessage(chat, RecId);

            return RedirectToAction("PrivateChat", "Home", new { UserId = RecId });
        }



    }
}
