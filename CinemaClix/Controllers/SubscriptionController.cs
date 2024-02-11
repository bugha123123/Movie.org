using CinemaClix.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionservice;

        public SubscriptionController(ISubscriptionService subscriptionservice)
        {
            _subscriptionservice = subscriptionservice;
        }

        public IActionResult Subscription()
        {
            return View();
        }
    }
}
