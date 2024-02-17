using CinemaClix.Interfaces;
using CinemaClix.Models;
using CinemaClix.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaClix.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionservice;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubscriptionController(ISubscriptionService subscriptionservice, IHttpContextAccessor httpContextAccessor)
        {
            _subscriptionservice = subscriptionservice;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Subscription(int id)
        {
            var FoundSubscription = _subscriptionservice.GetSubById(id);
            return View(FoundSubscription);
        }


        [HttpPost("addsubscription")]

        public async  Task<IActionResult> AddSubscription(SubscriptionPlans subscriptions)
        {


            return Ok();
        }

    }
}
