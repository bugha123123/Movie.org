using CinemaClix.Interfaces;
using CinemaClix.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IUserService _RegisterService;

        public RegisterController(IUserService loginService)
        {
            _RegisterService = loginService;

        }



        [HttpPost("adduser")]
        public async Task<IActionResult> AddUser([Bind("GmailAddress,UserName,Password")] User createUserViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _RegisterService.AddNewUser(createUserViewModel);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Register", "Register");
                }
            }
            catch (InvalidOperationException ex)
            {
                ViewData["GmailAlreadyExists"] = $"{createUserViewModel.GmailAddress}, this GmailAddress already exists!!!";
                return View("Register", createUserViewModel);
            }
      
        }







        public IActionResult Register()
        {
            return View();
        }
  



    }
} 