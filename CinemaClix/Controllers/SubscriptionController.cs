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

        public IActionResult Subscription(string PlanType)
        {
            var FoundSubscription = _subscriptionservice.GetSubByPlanType(PlanType);
            return View(FoundSubscription);
        }

        [HttpPost("addsubscription")]
        public async Task<IActionResult> AddSubscription( Subscriptions subscriptions)
        {
            await _subscriptionservice.AddSubscription(subscriptions );
            return Ok(subscriptions);
        }


    }
}
